using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.TemplateLoader
{
    /// <summary>
    /// テンプレートから作成機能を提供する。
    /// </summary>
    public static class TemplateLoader
    {
        private const string readonlyLabel = "VitDeck.ReadOnly";

        /// <summary>
        /// テンプレートからベースフォルダを複製する。
        /// </summary>
        /// <param name="templateFolderName">テンプレートのルートフォルダ名</param>
        /// <param name="copyDistinationPath">`Assets`から始まる複製先のフォルダパス。省略時はAssets直下に複製される。</param>
        /// <returns>複製が成功した場合trueを返す。</returns>
        public static bool Load(string templateFolderName, string copyDistinationPath = "Assets")
        {
            const string templateAssetsFolder = "TemplateAssets";
            var separatorChar = Path.AltDirectorySeparatorChar;
            var templateFolderPath = GetTemplatesFolderPath() + separatorChar + templateFolderName;
            var copyRootPath = templateFolderPath + separatorChar + templateAssetsFolder;
  

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
                var destinationPath = CreateDistinationPath(assetPath, copyRootPath, copyDistinationPath);
                //todo: #17 set replacedDistinationPath
                assetDictionary.Add(guid, new TemplateAsset(guid, assetPath, destinationPath));
            }

            //Check distination path
            if (CheckDestinationExists(assetDictionary, copyRootPath))
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

            ModifyCopyedAssets(assetDictionary);

            return true;
        }

        private static void ModifyCopyedAssets(Dictionary<string, TemplateAsset> assetDictionary)
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

            ReplaceObjectReference(assetDictionary);

            //Replace Asset file names
            //Replace Scene object names
            //todo: #17 https://github.com/vkettools/VitDeck/issues/17
        }

        private static void ReplaceObjectReference(Dictionary<string, TemplateAsset> assetDictionary)
        {
            var replacePairDictionary = CreateReplacePairDictionary(assetDictionary);
            if (replacePairDictionary.Count > 0)
            {
                foreach (var ta in assetDictionary.Values)
                {
                    if (ta.IsDummyAsset || ta.IsFolder)
                        continue;
                    StreamReader sr = new StreamReader(Path.GetFullPath(ta.destinationPath));
                    string s = sr.ReadToEnd();
                    sr.Close();
                    string replaced = s;
                    foreach (var guid in replacePairDictionary.Keys)
                    {
                        replaced = replaced.Replace(guid, replacePairDictionary[guid]);
                    }
                    if (s == replaced)
                        continue;
                    StreamWriter sw = new StreamWriter(Path.GetFullPath(ta.destinationPath));
                    sw.Write(replaced);
                    sw.Close();
                }
            }
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

        /// <summary>
        /// 置換するGUIDのペア辞書を作成する。
        /// </summary>
        /// <param name="assetDictionary">コピー対象のアセット辞書</param>
        /// <returns>置換前のduid,置換後のguidをペアにした辞書</returns>
        private static Dictionary<string, string> CreateReplacePairDictionary(Dictionary<string, TemplateAsset> assetDictionary)
        {
            var dic = new Dictionary<string, string>();
            foreach (var ta in assetDictionary.Values)
            {
                if (ta.IsDummyAsset || ta.IsFolder)
                    continue;
                var searchStr = ta.guid;
                var replaceStr = AssetDatabase.AssetPathToGUID(ta.destinationPath);
                Debug.Log(ta.templatePath + " to " + ta.destinationPath);
                //Debug.Log("replace:" + searchStr + " : " + replaceStr);
                dic.Add(searchStr, replaceStr);
            }
            return dic;
        }

        private static string CreateDistinationPath(string assetPath, string copyRootPath, string targetPath)
        {
            return assetPath.Replace(copyRootPath, targetPath);
        }

        /// <summary>
        /// テンプレート名を取得する。
        /// </summary>
        /// <param name="folderName">フォルダー名</param>
        /// <returns>テンプレート名</returns>
        public static string GetTemplateName(string folderName)
        {
            var name = GetTemplateProperty(folderName).templateName ?? string.Format("No name[{0}]", folderName);
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
                Debug.LogWarning("複数のテンプレート情報ファイルが存在します。");
            }
            else if (guids.Length == 1)
            {
                var propertyFilePath = AssetDatabase.GUIDToAssetPath(guids[0]);
                property = AssetDatabase.LoadAssetAtPath<TemplateProperty>(propertyFilePath);
            }
            else
            {
                Debug.LogWarning("テンプレート情報ファイルがみつかりませんでした。");
            }
            return property ?? ScriptableObject.CreateInstance<TemplateProperty>();
        }

        /// <summary>
        /// テンプレート内のコピー対象のアセット情報
        /// </summary>
        private class TemplateAsset
        {
            public TemplateAsset(string _guid, string _templatePath, string _destinationPath)
            {
                guid = _guid;
                templatePath = _templatePath;
                destinationPath = _destinationPath;
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
                return Path.GetDirectoryName(templatePath) == path;
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