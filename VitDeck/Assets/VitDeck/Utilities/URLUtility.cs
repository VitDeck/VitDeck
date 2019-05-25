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
        /// <remarks>
        /// Uriオブジェクトを作成できる形式かつ、スキームがhttpまたはhttpsの場合のみ許容する。
        /// </remarks>
        /// <param name="url">URL文字列</param>
        public static bool isValidURLString(string url)
        {
            Uri uri;
            return Uri.TryCreate(url, UriKind.Absolute, out uri) && (uri.Scheme == "http" || uri.Scheme == "https");
        }
    }
}
