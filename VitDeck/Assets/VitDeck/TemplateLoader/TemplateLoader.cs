using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using VitDeck.Language;
using VitDeck.Utilities;

namespace VitDeck.TemplateLoader
{
    /// <summary>
    /// テンプレートから作成機能を提供する。
    /// </summary>
    public static class TemplateLoader
    {
        private const string readonlyLabel = "VitDeck.ReadOnly";
        private const string replceStringFormat = "{{{0}}}";

        /// <summary>
        /// テンプレートからベースフォルダを複製する。
        /// </summary>
        /// <param name="templateFolderName">テンプレートのルートフォルダ名</param>
        /// <param name="replaceLsit">置換情報ID,置換後文字列のペア</param>
        /// <param name="copyDistinationPath">`Assets`から始まる複製先のフォルダパス。省略時はAssets直下に複製される。</param>
        /// <returns>複製が成功した場合trueを返す。</returns>
        public static bool Load(string templateFolderName, Dictionary<string, string> replaceLsit, string copyDistinationPath = "Assets")
        {
            const string templateAssetsFolder = "TemplateAssets";
            string temporaryFolderPath = AssetUtility.RootFolderPath + Path.AltDirectorySeparatorChar + "Temporary";
            var separatorChar = Path.AltDirectorySeparatorChar;
            var templateFolderPath = GetTemplatesFolderPath() + separatorChar + templateFolderName;
            var copyRootPath = templateFolderPath + separatorChar + templateAssetsFolder;
            var property = GetTemplateProperty(templateFolderName);

            if (UnityEditor.EditorSettings.serializationMode == SerializationMode.ForceBinary)
                Debug.LogWarning("Asset serialization mode is ForceBinary. Template will load incompletely.");

            Debug.Log("Load:" + templateFolderPath);
            var assetGuids = AssetDatabase.FindAssets("", new string[] { copyRootPath });
            if (assetGuids.Length == 0)
            {
                return true;
            }

            //Create asset dictionary
            Debug.Log("Create asset dictionary");
            //テンプレート側のguidをキーとしたアセット辞書
            var assetDictionary = new Dictionary<string, TemplateAsset>();
            foreach (var guid in assetGuids.Distinct())
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var destinationPath = CreateDistinationPath(assetPath, copyRootPath, temporaryFolderPath);
                var replacedDestinationPath = CreateReplacedDistinationPath(property, destinationPath, replaceLsit);
                assetDictionary.Add(guid, new TemplateAsset(guid, assetPath, destinationPath, replacedDestinationPath));
            }

            //Create temporary folder
            if (AssetDatabase.IsValidFolder(temporaryFolderPath))
                AssetDatabase.DeleteAsset(temporaryFolderPath);
            AssetDatabase.CreateFolder(AssetUtility.RootFolderPath, "Temporary");

            //Check distination path
            if (CheckDestinationExists(assetDictionary, copyRootPath) ||
                CheckDuplicatePath(assetDictionary) ||
                CheckPathLengthLimit(assetDictionary) ||
                CheckInvalidReplaceChar(replaceLsit))
            {
                return false;
            }

            //Copy Assets
            Debug.Log("Load template to:" + copyDistinationPath);
            foreach (var ta in assetDictionary.Values)
            {
                //Copy all child files and folders in `templateAssets` folder
                if (ta.IsAssetInFolder(copyRootPath))
                {
                    if (!AssetDatabase.CopyAsset(ta.templatePath, ta.destinationPath))
                    {
                        Debug.LogError(string.Format("Template load failed.{0} to {1}", ta.templatePath, ta.destinationPath));
                        return false;
                    }
                }
            }

            ModifyCopiedAssets(assetDictionary, property, replaceLsit);

            //Move to Final destination path
            var guids = AssetDatabase.FindAssets("t:Object", new string[] { temporaryFolderPath });
            //Regex mathes child assets directly under temporaryFolderPath
            var regex = new Regex("^" + temporaryFolderPath + "/[^/]*$");
            if (guids.Length > 0)
            {
                var targetAssetPaths = guids.Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                    .Where(path => regex.IsMatch(path) == true)
                    .ToArray();
                foreach (var path in targetAssetPaths)
                {
                    var finalDestinationPath = path.Replace(temporaryFolderPath, copyDistinationPath);
                    var validateMoveAssetResult = AssetDatabase.ValidateMoveAsset(path, finalDestinationPath);
                    if (!string.IsNullOrEmpty(validateMoveAssetResult))
                    {
                        Debug.LogError(string.Format("Template load failed.{0} to {1}:{2}", path, finalDestinationPath, validateMoveAssetResult));
                        return false;
                    }
                    AssetDatabase.MoveAsset(path, finalDestinationPath);
                }
            }
            AssetDatabase.Refresh();
            return true;
        }

        private static bool CheckInvalidReplaceChar(Dictionary<string, string> replaceLsit)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (var str in replaceLsit.Values)
            {
                if (str.IndexOfAny(invalidChars) >= 0)
                {
                    Debug.LogError(LocalizedMessage.Get("TemplateLoader.InvalitCharsDetected", str));
                    return true;
                }
            }
            return false;
        }

        private static void ModifyCopiedAssets(Dictionary<string, TemplateAsset> assetDictionary, TemplateProperty property, Dictionary<string, string> replaceList)
        {
            foreach (var ta in assetDictionary.Values)
            {
                //Remove readonly label
                var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(ta.destinationPath);
                var labels = AssetDatabase.GetLabels(asset);
                labels = labels.Where(label => label != readonlyLabel).ToArray();
                AssetDatabase.SetLabels(asset, labels.ToArray());
                //Delete dummy assets
                if (ta.IsDummyAsset)
                {
                    AssetDatabase.DeleteAsset(ta.destinationPath);
                }
            }

            ReplaceObjectReference(assetDictionary, property, replaceList);

            //Replace Asset file names
            //ReplaceAssetFileName(assetDictionary, property, replaceList);
            //使用していない引数を削除
            ReplaceAssetFileName(assetDictionary);

            //Replace Scene object names
            ReplaceSceneObjectNames(assetDictionary, property, replaceList);
        }

        private static void ReplaceSceneObjectNames(Dictionary<string, TemplateAsset> assetDictionary, TemplateProperty property, Dictionary<string, string> replaceList)
        {
            foreach (var ta in assetDictionary.Values)
            {
                if (AssetDatabase.GetMainAssetTypeAtPath(ta.replacedDestinationPath) != typeof(SceneAsset))
                    continue;
                var scene = EditorSceneManager.OpenScene(ta.replacedDestinationPath, OpenSceneMode.Additive);
                foreach (var rootObject in scene.GetRootGameObjects())
                {
                    foreach (var t in rootObject.GetComponentsInChildren<Transform>())
                    {
                        //Debug.Log(t.gameObject.name);
                        ReplaceSceneObjectName(t.gameObject, property.replaceList, replaceList);
                    }
                }
                EditorSceneManager.SaveScene(scene);
                EditorSceneManager.CloseScene(scene, true);
            }
        }

        private static void ReplaceSceneObjectName(GameObject gameObject, ReplacementDefinition[] replaceDef, Dictionary<string, string> replaceList)
        {
            if (replaceDef == null || replaceList == null || replaceList.Count == 0)
                return;
            foreach (var def in replaceDef)
            {
                var serchStr = string.Format(replceStringFormat, def.searchString);
                var replaceStr = replaceList.ContainsKey(def.ID) ? replaceList[def.ID] : string.Empty;
                gameObject.name = gameObject.name.Replace(serchStr, replaceStr);
            }
        }

        //private static void ReplaceAssetFileName(Dictionary<string, TemplateAsset> assetDictionary, TemplateProperty property, Dictionary<string, string> replaceList)
        //使用していない引数を削除
        private static void ReplaceAssetFileName(Dictionary<string, TemplateAsset> assetDictionary)
        {
            var log = "Loading (ReplaceAssetFileName)" + Environment.NewLine;
            //置換中一時パスのリスト
            var tempPathDictionary = new Dictionary<string, string>();
            foreach (var ta in assetDictionary.Values)
            {
                tempPathDictionary.Add(ta.destinationPath, ta.destinationPath);
            }

            // 置換前のコピー先パス長の昇順で処理
            IOrderedEnumerable<KeyValuePair<string, TemplateAsset>> ordered =
                assetDictionary.OrderBy(selector =>
                {
                    return selector.Value.destinationPath.Length;
                });

            foreach (KeyValuePair<string, TemplateAsset> pair in ordered)
            {
                var ta = pair.Value;
                //一時パス
                var before = tempPathDictionary[ta.destinationPath];
                //最終パス
                var after = ta.replacedDestinationPath;
                var moveResult = AssetDatabase.MoveAsset(before, after);
                AssetDatabase.Refresh();
                log += "from:" + ta.destinationPath + " to:" + ta.replacedDestinationPath + Environment.NewLine;
                if (!string.IsNullOrEmpty(moveResult))
                    log += moveResult + Environment.NewLine;
                //一時パスの置換
                if (ta.IsFolder)
                {
                    foreach (var p in ordered)
                    {
                        var tmpPath = tempPathDictionary[p.Value.destinationPath];
                        if (tmpPath.IndexOf(before) == 0 &&
                           (tmpPath.Length == before.Length || tmpPath[before.Length] == Path.AltDirectorySeparatorChar))
                        {
                            tempPathDictionary[p.Value.destinationPath] = tmpPath.Replace(before, after);
                        }
                    }
                }
            }

            Debug.Log(log);
        }

        private static void ReplaceObjectReference(Dictionary<string, TemplateAsset> assetDictionary, TemplateProperty property, Dictionary<string, string> replaceList)
        {
            var replaceGuidPairDictionary = CreateReplaceGuidPairDictionary(assetDictionary);
            var replaceNamePairDictionary = CreateReplaceNamePairDictionary(property, replaceList);
            if (replaceGuidPairDictionary.Count > 0)
            {
                foreach (var ta in assetDictionary.Values)
                {
                    IReferenceModifier modifier = BuildReferenceModifier(ta, replaceGuidPairDictionary, replaceNamePairDictionary);
                    if (modifier != null)
                        modifier.Modify(ta.destinationPath);
                }
            }
        }

        private static IReferenceModifier BuildReferenceModifier(TemplateAsset ta, Dictionary<string, string> replaceGuidPairDictionary, Dictionary<string, string> replaceNamePairDictionary)
        {
            if (ta.IsDummyAsset || ta.IsFolder)
                return null;
            IReferenceModifier modifier = null;
            if (AssetDatabase.GetMainAssetTypeAtPath(ta.templatePath) == typeof(AnimationClip))
            {
                modifier = new AnimationClipReferenceModifier(replaceNamePairDictionary);
            }
            else if (Path.GetExtension(ta.templatePath).Equals(".fbx", StringComparison.OrdinalIgnoreCase))
            {
                modifier = new FbxReferenceModifier(replaceGuidPairDictionary);
            }
            else
            {
                modifier = new GuidReferenceModifier(replaceGuidPairDictionary);
            }
            return modifier;
        }

        /// <summary>
        /// コピー先直下にすでに同名アセットがあるかどうか確認する。
        /// </summary>
        /// <param name="assetDictionary">コピー対象のアセット辞書</param>
        /// <param name="copyRootPath">コピーするテンプレートアセットのルートフォルダパス</param>
        /// <returns>コピーが不可能な場合trueを返す</returns>
        private static bool CheckDestinationExists(Dictionary<string, TemplateAsset> assetDictionary, string copyRootPath)
        {
            foreach (var ta in assetDictionary.Values)
            {
                if (ta.IsAssetInFolder(copyRootPath))
                {
                    var error = AssetDatabase.ValidateMoveAsset(ta.templatePath, ta.destinationPath);
                    if (!string.IsNullOrEmpty(error))
                    {
                        Debug.LogError(string.Format("Template load failed. {0}", error));
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool CheckDuplicatePath(Dictionary<string, TemplateAsset> assetDictionary)
        {
            var pathList = new List<string>();
            var assets = assetDictionary.Values;
            foreach (var asset in assets)
                pathList.Add(asset.replacedDestinationPath);
            if (pathList.Count != pathList.Distinct<string>().Count<string>())
            {
                LocalizedMessage.Get("TemplateLoader.DestinationAlreadyExists");
                return true;
            }
            return false;
        }

        private static bool CheckPathLengthLimit(Dictionary<string, TemplateAsset> assetDictionary)
        {
            var maxPathLength = 255;
            //`Assets`フォルダーのフルパス
            var projectPath = Application.dataPath;
            foreach (var ta in assetDictionary.Values)
            {
                var pathLength = projectPath.Length + ta.replacedDestinationPath.Length - "Assets".Length;
                if (pathLength > maxPathLength)
                {
                    Debug.LogError(LocalizedMessage.Get("TemplateLoader.OverlengthPathDetected", ta.replacedDestinationPath));
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 置換するGUIDのペア辞書を作成する。
        /// </summary>
        /// <param name="assetDictionary">コピー対象のアセット辞書</param>
        /// <returns>置換前のduid,置換後のguidをペアにした辞書</returns>
        private static Dictionary<string, string> CreateReplaceGuidPairDictionary(Dictionary<string, TemplateAsset> assetDictionary)
        {
            var dic = new Dictionary<string, string>();
            var log = "Loading (CreateReplaceGuidPairDictionary)" + Environment.NewLine;
            foreach (var ta in assetDictionary.Values)
            {
                if (ta.IsDummyAsset || ta.IsFolder)
                    continue;
                var searchStr = ta.guid;
                var replaceStr = AssetDatabase.AssetPathToGUID(ta.destinationPath);
                log += string.Format("{0}({1}) to {2}({3})", ta.templatePath, ta.guid, ta.destinationPath, replaceStr) + Environment.NewLine;
                dic.Add(searchStr, replaceStr);
            }
            Debug.Log(log);
            return dic;
        }

        private static Dictionary<string, string> CreateReplaceNamePairDictionary(TemplateProperty property, Dictionary<string, string> replaceList)
        {
            var dic = new Dictionary<string, string>();
            if (property.replaceList != null)
            {
                foreach (var def in property.replaceList)
                {
                    var serchStr = string.Format(replceStringFormat, def.searchString);
                    var replaceStr = replaceList.ContainsKey(def.ID) ? replaceList[def.ID] : string.Empty;
                    dic.Add(serchStr, replaceStr);
                }
            }
            return dic;
        }

        private static string CreateDistinationPath(string assetPath, string copyRootPath, string targetPath)
        {
            return assetPath.Replace(copyRootPath, targetPath);
        }

        private static string CreateReplacedDistinationPath(TemplateProperty property, string destinationPath, Dictionary<string, string> replaceLsit)
        {
            var replacedPath = destinationPath;
            if (property.replaceList != null)
            {
                foreach (var def in property.replaceList)
                {
                    var serchStr = string.Format(replceStringFormat, def.searchString);
                    var replaceStr = replaceLsit.ContainsKey(def.ID) ? replaceLsit[def.ID] : string.Empty;
                    replacedPath = replacedPath.Replace(serchStr, replaceStr);
                }
            }
            return replacedPath;
        }

        /// <summary>
        /// テンプレート名を取得する。
        /// </summary>
        /// <param name="folderName">フォルダー名</param>
        /// <returns>テンプレート名</returns>
        public static string GetTemplateName(string folderName)
        {
            var name = GetTemplateProperty(folderName).templateName;
            if (string.IsNullOrEmpty(name))
                name = string.Format("No name[{0}]", folderName);
            return name;
        }

        /// <summary>
        /// テンプレート名を配列で取得する。
        /// </summary>
        /// <param name="folderNames">フォルダ名の配列</param>
        /// <returns>テンプレート名の配列</returns>
        public static string[] GetTemplateNames(string[] folderNames)
        {
            var folderNameList = new List<string>();
            foreach (var folder in folderNames)
            {
                folderNameList.Add(GetTemplateName(folder));
            }
            return folderNameList.ToArray();
        }

        /// <summary>
        /// テンプレートが格納されたフォルダー名の配列を取得する。
        /// </summary>
        /// <returns>テンプレート名のフォルダ名の配列</returns>
        public static string[] GetTemplateFolders()
        {
            string[] templateFolders = new string[] { };
            {
                var templatesFolderPath = GetTemplatesFolderPath();
                var templateFolderIndex = templatesFolderPath.Split(Path.AltDirectorySeparatorChar).Length;
                var templateFolderGuids = AssetDatabase.FindAssets("t:Folder", new string[] { templatesFolderPath });
                var paths = AssetUtility.GuidsToPaths(templateFolderGuids);
                var folderNameList = new List<string>();

                //Templatesフォルダ直下のディレクトリ名を取得
                foreach (var path in paths)
                {
                    var directories = path.Split(Path.AltDirectorySeparatorChar);
                    if (directories.Length > templateFolderIndex)
                    {
                        folderNameList.Add(directories[templateFolderIndex]);
                    }
                }
                templateFolders = folderNameList.Distinct().ToArray();
            }
            return templateFolders;
        }

        /// <summary>
        /// テンプレートの格納されたフォルダのパスを返す。
        /// VitDeck.TempletsFolderを付けたフォルダーの最初の一つを返す。
        /// </summary>
        /// <returns></returns>
        private static string GetTemplatesFolderPath()
        {
            var templatesFolderGuids = AssetDatabase.FindAssets("l:VitDeck.TemplatesFolder");
            var path = "";
            if (templatesFolderGuids != null && templatesFolderGuids.Length > 0)
            {
                path = AssetDatabase.GUIDToAssetPath(templatesFolderGuids[0]);
            }
            else
            {
                throw new DirectoryNotFoundException("Templates folder not found.");
            }
            return path;
        }

        /// <summary>
        /// テンプレート情報を取得する
        /// </summary>
        /// <param name="name">テンプレートのフォルダ名</param>
        /// <returns><テンプレート情報オブジェクト</returns>
        public static TemplateProperty GetTemplateProperty(string name)
        {
            var rootPath = GetTemplatesFolderPath() + Path.AltDirectorySeparatorChar + name;
            var guids = AssetDatabase.FindAssets("t:TemplateProperty", new string[] { rootPath });
            TemplateProperty property = null;
            if (guids.Length >= 2)
            {
                Debug.LogWarning(LocalizedMessage.Get("TemplateLoader.InformationFileDuplicated"));
            }
            else if (guids.Length == 1)
            {
                var propertyFilePath = AssetDatabase.GUIDToAssetPath(guids[0]);
                property = AssetDatabase.LoadAssetAtPath<TemplateProperty>(propertyFilePath);
            }
            else
            {
                Debug.LogWarning(LocalizedMessage.Get("TemplateLoader.InformationFileNotFound"));
            }
            return property ?? ScriptableObject.CreateInstance<TemplateProperty>();
        }

        /// <summary>
        /// テンプレート内のコピー対象のアセット情報
        /// </summary>
        private class TemplateAsset
        {
            public TemplateAsset(string _guid, string _templatePath, string _destinationPath, string _replacedDestinationPath)
            {
                guid = _guid;
                templatePath = _templatePath;
                destinationPath = _destinationPath;
                replacedDestinationPath = _replacedDestinationPath;
            }
            internal bool IsFolder
            {
                get
                {
                    return AssetDatabase.IsValidFolder(templatePath);
                }
            }
            internal bool IsDummyAsset
            {
                get
                {
                    return AssetDatabase.GetMainAssetTypeAtPath(templatePath) == typeof(VitDeckDummy);
                }
            }
            internal bool IsAssetInFolder(string path)
            {
                // .NET4.0環境ではGetDirectoryName()はパス区切りを\に変換してしまう為回避する。
                return Path.GetDirectoryName(templatePath).Replace('\\', '/') == path;
            }
            //テンプレート内GUID
            internal string guid;
            //テンプレート内パス
            internal string templatePath;
            //コピー先パス
            internal string destinationPath;
            //置換後のアセットパス
            internal string replacedDestinationPath;
        }
    }
}
