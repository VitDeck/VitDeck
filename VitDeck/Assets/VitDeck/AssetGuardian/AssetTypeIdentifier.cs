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
        public readonly PrefabType prefabType;

        public AssetTypeIdentifier(Type assetType) : this(assetType, PrefabType.None) { }

        public AssetTypeIdentifier(Type assetType, PrefabType prefabType)
        {
            this.assetType = assetType;
            this.prefabType = prefabType;
        }

        public static AssetTypeIdentifier Of(UnityEngine.Object asset)
        {
            var prefabType = PrefabUtility.GetPrefabType(asset);
            var assetType = asset.GetType();

            return new AssetTypeIdentifier(assetType, prefabType);
        }

        public override bool Equals(object obj)
        {
            var detail = obj as AssetTypeIdentifier;

            if (detail == null)
            {
                return false;
            }

            return assetType == detail.assetType
                && prefabType == detail.prefabType;
        }

        public override int GetHashCode()
        {
            return assetType.GetHashCode();
        }
    }
}