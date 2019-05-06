using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace VitDeck.Utilities
{
    /// <summary>
    /// アセットに対する操作を提供するクラス。
    /// </summary>
    public static class AssetUtility
    {
        private static string _imageFolderPath;

        /// <summary>
        /// VitDeck用画像フォルダのパス
        /// </summary>
        /// <remarks>
        /// Unityで`ImagesFolder`ラベルが付与されているアセットの一つ目のパスを返す。
        /// 存在しない場合はExceptionを返す。
        /// </remarks>
        public static string ImageFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_imageFolderPath))
                {
                    string[] imageFolderGUIDs = AssetDatabase.FindAssets("l:VitDeck.ImagesFolder");
                    if (imageFolderGUIDs != null && imageFolderGUIDs.Length > 0)
                    {
                        _imageFolderPath = AssetDatabase.GUIDToAssetPath(imageFolderGUIDs[0]);
                    }
                    else
                    {
                        throw new DirectoryNotFoundException("Images folder not found.");
                    }
                }
                return _imageFolderPath;
            }
        }

        /// <summary>
        /// 指定されたファイル/ディレクトリ及び、その子のアセットを列挙する。
        /// </summary>
        /// <param name="path">アセットもしくはディレクトリのパス</param>
        /// <returns>アセットの列挙</returns>
        public static IEnumerable<UnityEngine.Object> EnumerateAssets(string path)
        {
            foreach (var assetPath in IOUtility.EnumerateFileSystemEntries(path))
            {
                if (assetPath.EndsWith(".meta"))
                {
                    continue;
                }
                var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
                if (asset == null)
                {
                    continue;
                }
                yield return asset;
            }
        }
    }
}
