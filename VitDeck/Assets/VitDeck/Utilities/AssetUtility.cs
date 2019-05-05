using System.IO;
using UnityEditor;

namespace VitDeck.Utilities
{
    /// <summary>
    /// アセットに対する操作を提供するクラス。
    /// </summary>
    public static class AssetUtility
    {
        /// <summary>
        /// VitDeck用画像フォルダのパスを取得する
        /// </summary>
        /// <remarks>
        /// Unityで`ImagesFolder`ラベルが付与されているアセットの一つ目のパスを返す。
        /// 存在しない場合はExceptionを返す。
        /// </remarks>
        /// <returns>画像が格納されているフォルダーのパス</returns>
        public static string getImageFolderPath()
        {
            string[] imageFolderGUIDs = AssetDatabase.FindAssets("l:ImagesFolder");
            string imageFolder = "";
            if (imageFolderGUIDs != null && imageFolderGUIDs.Length > 0)
            {
                imageFolder = AssetDatabase.GUIDToAssetPath(imageFolderGUIDs[0]);
            }
            else
            {
                throw new DirectoryNotFoundException("Images folder not found.");
            }
            return imageFolder;
        }
    }
}
