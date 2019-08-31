using UnityEditor;
using UnityEngine;

namespace VitDeck.Utilities
{
    /// <summary>
    /// VitDeck独自のGUIの共通パーツを提供するクラス。
    /// </summary>
    public static class CustomGUILayout
    {
        static private Texture2D _URLButtonImage;

        /// <summary>
        /// URLリンクボタンのアイコン画像
        /// </summary>
        static private Texture2D URLButtonImage
        {
            get
            {
                if (_URLButtonImage == null)
                {
                    string imageFolder = AssetUtility.ImageFolderPath;
                    _URLButtonImage = AssetDatabase.LoadAssetAtPath<Texture2D>(imageFolder + "/Link_icon.png") ?? new Texture2D(16, 16);
                }
                return _URLButtonImage;
            }
        }

        /// <summary>
        /// URLリンクボタンを作成します。
        /// </summary>
        /// <param name="label">UIに表示する文字列</param>
        /// <param name="url">リンク先URL</param>
        /// <param name="style">使用するGUIスタイル</param>
        /// <param name="options">指定してレイアウトオプションを渡すときのレイアウトオプションのリスト</param>
        public static void URLButton(string label, string url, GUIStyle style, params GUILayoutOption[] options)
        {
            GUIContent content = new GUIContent();
            content.image = URLButtonImage;
            content.text = label;
            content.tooltip = url;
            if (GUILayout.Button(content, style, options))
            {
                URLUtility.openURL(url);
            }
        }

        public static void URLButton(string label, string url, params GUILayoutOption[] options)
        {
            URLButton(label, url, GUI.skin.button, options);
        }
    }
}
