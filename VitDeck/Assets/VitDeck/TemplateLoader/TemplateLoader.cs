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
        /// <summary>
        /// テンプレートからベースフォルダを複製する。
        /// </summary>
        /// <param name="templateFolderName">テンプレートのルートフォルダ名</param>
        /// <param name="path">`Assets`から始まる複製先のフォルダパス。省略時はAssets直下に複製される。</param>
        /// <returns>複製が成功した場合trueを返す。</returns>
        public static bool Load(string templateFolderName, string path = "Assets")
        {
            const string templateAssetsFolder = "TemplateAssets";
            var result = false;
            //guidをキーとしたアセット辞書
            var assetDictionary = new Dictionary<string, TemplateAsset>();

            //Create asset dictionary
            var separatorChar = Path.AltDirectorySeparatorChar;
            var templateFolderPath = GetTemplatesFolderPath() + separatorChar + templateFolderName;
            var templateAssetsFolderPath = templateFolderPath + separatorChar + templateAssetsFolder;
            Debug.Log("Load:" + templateFolderPath);
            var assetGuids = AssetDatabase.FindAssets("", new string[] { templateAssetsFolderPath });
            foreach (var guid in assetGuids.Distinct())
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var destinationPath = createDistinationPath(templateAssetsFolderPath, assetPath, path);
                var ta = new TemplateAsset(guid, assetPath, destinationPath);
                assetDictionary.Add(guid, ta);
            }
            //Copy Assets
            Debug.Log("Load to:" + path);   
            foreach (TemplateAsset ta in assetDictionary.Values)
            {
                //Copy all file and folder in `templateAssets` folder
                if (ta.isAssetInFolder(templateAssetsFolderPath))
                {
                    if (!AssetDatabase.CopyAsset(ta.templatePath, ta.destinationPath))
                    {
                        Debug.LogError("Template copy failed.");
                    }
                }
            }
            result = true;
            foreach (TemplateAsset ta in assetDictionary.Values)
            {
                //Remove readonly label
                var obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(ta.destinationPath);
                List<string> labels = new List<string>(AssetDatabase.GetLabels(obj));
                labels.RemoveAll(s => s.Contains("VitDeck.ReadOnly"));
                AssetDatabase.SetLabels(obj, labels.ToArray());
                //Delete dummy assets
                if (AssetDatabase.GetMainAssetTypeAtPath(ta.destinationPath) == typeof(VitDeckDummy))
                {
                    AssetDatabase.DeleteAsset(ta.destinationPath);
                }
            }
            //Replace Asset names
            //todo: #17 https://github.com/vkettools/VitDeck/issues/17
            //

            //Replace object reference
            //todo

            return result;
        }

        private static string createDistinationPath(string templateFolderPath, string assetPath, string targetPath)
        {
            return assetPath.Replace(templateFolderPath, targetPath);
        }

        /// <summary>
        /// テンプレート名を取得する。
        /// </summary>
        /// <param name="folderName">フォルダー名</param>
        /// <returns>テンプレート名</returns>
        public static string GetTemplateName(string folderName)
        {
            // ToDo: #18 https://github.com/vkettools/VitDeck/issues/18
            return "テンプレート名:" + folderName;
        }

        /// <summary>
        /// テンプレート名を取得する
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

        private class TemplateAsset
        {
            public TemplateAsset(string _guid, string _templatePath, string _destinationPath)
            {
                guid = _guid;
                templatePath = _templatePath;
                destinationPath = _destinationPath;
            }
            internal bool isFolder
            {
                get
                {
                    return AssetDatabase.IsValidFolder(templatePath);
                }
            }
            internal bool isAssetInFolder(string path)
            {
                return Path.GetDirectoryName(templatePath) == path;
            }
            //テンプレート内GUID
            internal string guid;
            //テンプレート内パス
            internal string templatePath;
            //コピー先パス
            internal string destinationPath;

        }
    }
}