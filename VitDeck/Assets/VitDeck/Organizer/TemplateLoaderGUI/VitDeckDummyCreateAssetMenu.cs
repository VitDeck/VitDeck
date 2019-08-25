using UnityEngine;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.TemplateLoader
{
    /// <summary>
    /// <see cref="VitDeckDummy"/>アセットを生成するMenuItemを登録するクラス。
    /// </summary>
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