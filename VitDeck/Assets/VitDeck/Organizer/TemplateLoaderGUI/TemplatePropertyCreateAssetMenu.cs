using UnityEngine;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.TemplateLoader
{
    /// <summary>
    /// <see cref="TemplateProperty"/>アセットを生成するMenuItemを登録するクラス。
    /// </summary>
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