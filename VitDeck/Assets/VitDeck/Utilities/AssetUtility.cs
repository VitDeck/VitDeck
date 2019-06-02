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
