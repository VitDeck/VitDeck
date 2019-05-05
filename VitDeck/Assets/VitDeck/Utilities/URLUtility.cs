using System;
using UnityEngine;

namespace VitDeck.Utilities
{
    /// <summary>
    /// URL処理を提供するクラス。
    /// </summary>
    public static class URLUtility
    {
        /// <summary>
        /// URLをブラウザで開く
        /// </summary>
        /// <param name="url">URL文字列</param>
        public static void openURL(string url)
        {
            if (isValidURLString(url))
            {
                Application.OpenURL(url);
            }
        }

        /// <summary>
        /// 与えられた文字列が有効なURL文字列かどうか判定する。
        /// </summary>
        /// <param name="url">URL文字列</param>
        private static bool isValidURLString(string url)
        {
            return !string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
        }
    }
}
