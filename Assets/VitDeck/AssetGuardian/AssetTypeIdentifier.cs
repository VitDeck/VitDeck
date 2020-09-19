using System;
using UnityEditor;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// アセットの種類を判別する値オブジェクト。
    /// </summary>
    public class AssetTypeIdentifier
    {
        public readonly Type assetType;
        public readonly bool isPrefab;

        public AssetTypeIdentifier(Type assetType) : this(assetType, false) { }

        public AssetTypeIdentifier(Type assetType, bool isPrefab)
        {
            this.assetType = assetType;
            this.isPrefab = isPrefab;
        }

        public static AssetTypeIdentifier Of(UnityEngine.Object asset)
        {
            var assetType = asset.GetType();
#if UNITY_2018_3_OR_NEWER
            var prefabType = PrefabUtility.GetPrefabAssetType(asset);
            var isPrefab =
                prefabType == PrefabAssetType.Regular ||
                prefabType == PrefabAssetType.Variant;
#else
            var isPrefab = PrefabUtility.GetPrefabType(asset) == PrefabType.Prefab;
#endif
            return new AssetTypeIdentifier(assetType, isPrefab);
        }

        public override bool Equals(object obj)
        {
            var detail = obj as AssetTypeIdentifier;

            if (detail == null)
            {
                return false;
            }

            return assetType == detail.assetType
                && isPrefab == detail.isPrefab;
        }

        public override int GetHashCode()
        {
            return assetType.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + "type:" + assetType + "|isPrefab:" + isPrefab;
        }
    }
}