using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Utilities
{
    /// <summary>
    /// 製品情報を提供する
    /// </summary>
    public static class ProductInfoUtility
    {
        private const string fileName = "ProductInfo.asset";
        /// <summary>
        /// 製品情報を取得する
        /// </summary>
        /// <returns>製品情報</returns>
        private static ProductInfo GetProductInfo()
        {
            var assetPath = Path.Combine(AssetUtility.ConfigFolderPath, fileName);
            var productInfo = AssetDatabase.LoadAssetAtPath<ProductInfo>(assetPath);
            if (productInfo == null)
                Debug.LogError("Failed to load ProductInfo.");
            return productInfo;
        }

        /// <summary>
        /// 開発者リンクのタイトル文字列を取得する
        /// </summary>
        /// <returns>開発者リンクのタイトル文字列</returns>
        public static string GetDeveloperLinkTitle()
        {
            var title = "";
            var productInfo = GetProductInfo();
            if (productInfo != null)
                title = productInfo.developerLinkTitle;
            return title;
        }

        /// <summary>
        /// 開発者リンクのURL文字列を取得する
        /// </summary>
        /// <returns>開発者リンクのURL文字列</returns>
        public static string GetDeveloperLinkURL()
        {
            var url = "";
            var productInfo = GetProductInfo();
            if (productInfo != null)
                url = productInfo.developerLinkURL;
            return url;
        }
    }
}