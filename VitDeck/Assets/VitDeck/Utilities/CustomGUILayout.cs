using UnityEditor;
using UnityEngine;

namespace VitDeck.Utilities
{
    /// <summary>
    /// VitDeck独自のGUIの共通パーツを提供するクラス。
    /// </summary>
    public static class CustomGUILayout
    {

        /// <summary>
        /// URLリンクボタンを作成します。
        /// </summary>
        /// <param name="label">UIに表示する文字列</param>
        /// <param name="url">リンク先URL</param>
        /// <param name="options">指定してレイアウトオプションを渡すときのレイアウトオプションのリスト</param>
        public static void URLButton(string label, string url, params GUILayoutOption[] options)
        {
            GUIContent content = new GUIContent();
            string imageFolder = AssetUtility.getImageFolderPath();
            content.image = AssetDatabase.LoadAssetAtPath<Texture2D>(imageFolder + "/Link_icon.png");
            content.text = label;
            if (GUILayout.Button(content, options))
            {
                URLUtility.openURL(url);
            }
        }
    }
}
