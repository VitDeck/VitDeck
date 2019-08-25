using UnityEngine;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.Exporter
{
    public static class ExportSettingCreateAssetMenu
    {
        [MenuItem("Assets/Create/VitDeck/Export Setting")]
        public static void CreateAsset()
        {
            Object instance = ScriptableObject.CreateInstance<ExportSetting>();
            string assetName = "ExportSetting.asset";
            AssetUtility.CreateAssetInteractivity(instance, assetName);
        }
    }
}