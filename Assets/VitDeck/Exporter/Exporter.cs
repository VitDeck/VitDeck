using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;
using VitDeck.Language;

namespace VitDeck.Exporter
{
    /// <summary>
    /// エクスポート機能を提供する。
    /// </summary>
    public static class Exporter
    {
        /// <summary>
        /// 指定したベースフォルダをunitypackageにエクスポートする。
        /// </summary>
        /// <param name="baseFolderPath">ベースフォルダパス</param>
        /// <param name="setting">エクスポートに使用する設定</param>
        /// <param name="forceExport">ファイルが既に存在していた場合に上書きするかどうか</param>
        /// <returns>エクスポート結果</returns>
        public static ExportResult Export(string baseFolderPath, ExportSetting setting, bool forceExport = false)
        {
            if (setting == null)
                throw new ArgumentNullException("Argument `setting` is null.");
            if (baseFolderPath == null)
                throw new ArgumentNullException("Argument `baseFolderPath` is null.");
            var exportFolderPath = setting.ExportFolderPath;
            if (string.IsNullOrEmpty(exportFolderPath) || !exportFolderPath.StartsWith("Assets"))
                throw new ArgumentNullException("Invalid export folder path:" + exportFolderPath);

            var fileName = string.IsNullOrEmpty(setting.fileNameFormat) ? "export.unitypackage" : setting.fileNameFormat;
            var outputPath = exportFolderPath + Path.AltDirectorySeparatorChar + fileName;
            var result = new ExportResult();

            //check export folder path
            if (!Directory.Exists(exportFolderPath))
                Directory.CreateDirectory(exportFolderPath);

            //export
            Debug.Log(string.Format("Export base folder:{0} export file:{1}", baseFolderPath, outputPath));
            var assetPaths = GetExportAssetPaths(baseFolderPath);
            var assetList = "# " + LocalizedMessage.Get("Exporter.TargetAsset") + System.Environment.NewLine + String.Join(System.Environment.NewLine, assetPaths);
            Debug.Log(assetList);
            result.log += assetList + System.Environment.NewLine;
            try
            {
                if (!forceExport && File.Exists(outputPath))
                    throw new IOException(LocalizedMessage.Get("Exporter.DestinationAlreadyExists", outputPath));
                AssetDatabase.ExportPackage(assetPaths, outputPath);
                //SHA-1 string rename
                if (fileName.IndexOf("{SHA-1}") != -1)
                {
                    var hash = GetHash(outputPath);
                    var newPath = exportFolderPath + Path.AltDirectorySeparatorChar + fileName.Replace("{SHA-1}", hash);
                    if (forceExport || !File.Exists(newPath))
                    {
                        File.Move(outputPath, newPath);
                    }
                    else
                    {
                        throw new IOException(LocalizedMessage.Get("Exporter.RenameDestinationAlreadyExists"));
                    }
                    outputPath = newPath;
                }
                result.log += LocalizedMessage.Get("Exporter.Succeeded") + System.Environment.NewLine + outputPath;
                result.exportFilePath = outputPath;
                result.exportResult = true;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                result.log += LocalizedMessage.Get("Exporter.Failed", e.Message) + System.Environment.NewLine;
                result.exportResult = false;
            }
            return result;
        }

        private static string GetHash(string outputPath)
        {
            using (var fs = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            {
                byte[] sha1byte = SHA1.Create().ComputeHash(fs);
                string sha1string = BitConverter.ToString(sha1byte).Replace("-", "").ToLower();
                return sha1string;
            }
        }

        private static string[] GetExportAssetPaths(string baseFolderPath)
        {
            var paths = AssetDatabase.FindAssets("t:Object", new string[] { baseFolderPath })
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid));
            return paths.ToArray();
        }

        /// <summary>
        /// Configフォルダに存在するエクスポート設定オブジェクトを取得する。
        /// </summary>
        /// <returns>エクスポート設定の配列</returns>
        public static ExportSetting[] GetExportSettings()
        {
            var filter = "t:ExportSetting";
            var settings = AssetDatabase.FindAssets(filter, new string[] { AssetUtility.ConfigFolderPath })
                .Select(guid => AssetDatabase.LoadAssetAtPath<ExportSetting>(AssetDatabase.GUIDToAssetPath(guid)));
            return settings.ToArray();
        }
    }
}