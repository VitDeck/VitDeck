using UnityEngine;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.TemplateLoader
{
    public static class TemplatePropertyCreateAssetMenu
    {
        [MenuItem("Assets/Create/VitDeck/Template Property")]
        public static void CreateAsset()
        {
            Object instance = ScriptableObject.CreateInstance<TemplateProperty>();
            string assetName = "Property.asset";
            AssetUtility.CreateAssetInteractivity(instance, assetName);
        }
    }
}