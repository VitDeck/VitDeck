using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;

namespace VitDeck.Utilities
{
    /// <summary>
    /// アセットに対する操作を提供するクラス。
    /// </summary>
    public static class AssetUtility
    {
        private static string _imageFolderPath;
        private static string _configFolderPath;
        /// <summary>
        /// VitDeck用画像フォルダのパス
        /// </summary>
        /// <remarks>
        /// Unityで`ImagesFolder`ラベルが付与されているアセットの一つ目のパスを返す。
        /// 存在しない場合はDirectoryNotFoundExceptionを返す。
        /// </remarks>
        public static string ImageFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_imageFolderPath))
                {
                    _imageFolderPath = GetFolderPath("VitDeck.ImagesFolder");
                }
                return _imageFolderPath;
            }
        }
        /// <summary>
        /// 設定ファイル用フォルダのパス
        /// </summary>
        /// <remarks>
        /// Unityでラベルが付与されているアセットの一つ目のパスを返す。
        /// 存在しない場合はDirectoryNotFoundExceptionを返す。
        /// </remarks>
        public static string ConfigFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_configFolderPath))
                {
                    _configFolderPath = GetFolderPath("VitDeck.ConfigFolder");
                }
                return _configFolderPath;
            }
        }

        private static string GetFolderPath(string assetLabel)
        {
            string folderPath = AssetDatabase.FindAssets("l:" + assetLabel)
                 .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                 .Where(path => path != null)
                 .FirstOrDefault();
            if (folderPath != null)
            {
                return folderPath;
            }
            else
            {
                throw new DirectoryNotFoundException(string.Format("folder for {0} not found.", assetLabel));
            }
        }

        /// <summary>
        /// GUIDに対応したアセットパスの配列を返す。
        /// </summary>
        /// <param name="guids">guidの配列</param>
        /// <returns>アセットパスの配列</returns>
        public static string[] GuidsToPaths(string[] guids)
        {
            var names = new List<string>();
            foreach (var guid in guids)
            {
                var name = AssetDatabase.GUIDToAssetPath(guid);
                names.Add(name);
            }
            return names.ToArray();
        }

        /// 指定されたファイル/フォルダ及び、その子のアセットを列挙する。
        /// </summary>
        /// <param name="path">アセットもしくはフォルダのパス</param>
        /// <returns>アセットの列挙可能オブジェクト</returns>
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

        /// <summary>
        /// <see cref="AssetDatabase.LoadAllAssetsAtPath(string)"/>を安全に呼び出すメソッド。
        /// </summary>
        /// <remarks>
        /// シーン(<see cref="SceneAsset"/>)に対して<see cref="AssetDatabase.LoadAllAssetsAtPath(string)"/>を行うと、<code>Do not use ReadObjectThreaded on scene objects!</code>というエラーが出ます。その回避のために、対象がSceneAssetであればメインアセットのみを読み込むという処理を行っています。
        /// </remarks>
        /// <param name="path"></param>
        /// <returns></returns>
        public static UnityEngine.Object[] LoadAllAssetsWithoutSceneAtPath(string path)
        {
            UnityEngine.Object[] allInstances;
            var mainAsset = AssetDatabase.LoadMainAssetAtPath(path);
            if (mainAsset is SceneAsset)
                allInstances = new UnityEngine.Object[] { mainAsset };
            else
                allInstances = AssetDatabase.LoadAllAssetsAtPath(path);
            return allInstances;
        }
    }
}
