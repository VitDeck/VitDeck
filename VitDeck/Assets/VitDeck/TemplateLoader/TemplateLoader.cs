using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.TemplateLoader
{
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
            Debug.Log("Load:" + templateFolderName);
            Debug.Log("Load to:" + path);

            return false;
        }

        /// <summary>
        /// テンプレート名を取得する。
        /// </summary>
        /// <param name="folderName">フォルダー名</param>
        /// <returns>テンプレート名</returns>
        public static string GetTemplateName(string folderName)
        {
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
            string[] templateFolders = new string[] { "Sample Template", "テンプレートB" };
            var templatesFolderGuids = AssetDatabase.FindAssets("l:VitDeck.TemplatesFolder");
            if (templatesFolderGuids != null && templatesFolderGuids.Length > 0)
            {
                var templatesFolderPath = AssetDatabase.GUIDToAssetPath(templatesFolderGuids[0]);
                var templateFolderIndex = templatesFolderPath.Split(Path.AltDirectorySeparatorChar).Length;
                var templateFolderGuids = AssetDatabase.FindAssets("t:Folder", new string[] { templatesFolderPath });
                var paths = GuidsToPaths(templateFolderGuids);
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
            else
            {
                throw new DirectoryNotFoundException("Templates folder not found.");
            }
            return templateFolders;
        }

        /// <summary>
        /// GUIDに対応したアセットパスの配列を返す。
        /// </summary>
        /// <param name="templateFolderGuids">guidの配列</param>
        /// <returns>アセットパスの配列</returns>
        private static string[] GuidsToPaths(string[] templateFolderGuids)
        {
            var names = new List<string>();
            foreach (var guid in templateFolderGuids)
            {
                var name = AssetDatabase.GUIDToAssetPath(guid);
                names.Add(name);
            }
            return names.ToArray();
        }
    }
}