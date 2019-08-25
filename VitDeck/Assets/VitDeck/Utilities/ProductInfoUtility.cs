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
        public static ProductInfo GetProductInfo()
        {
            var assetPath = Path.Combine(AssetUtility.ConfigFolderPath, fileName);
            var productInfo = AssetDatabase.LoadAssetAtPath<ProductInfo>(assetPath);
            if (productInfo == null)
                Debug.LogError("Failed to load ProductInfo.");
            return productInfo;
        }
    }
}