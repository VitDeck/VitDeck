using UnityEngine;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.TemplateLoader
{
    public static class VitDeckDummyCreateAssetMenu
    {
        [MenuItem("Assets/Create/VitDeck/Dummy asset")]
        public static void CreateAsset()
        {
            Object instance = ScriptableObject.CreateInstance<VitDeckDummy>();
            string assetName = "Dummy.asset";
            AssetUtility.CreateAssetInteractivity(instance, assetName);
        }
    }
}