using UnityEngine;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.Exporter
{
    /// <summary>
    /// <see cref="ExportSetting"/>アセットを生成するMenuItemを登録するクラス。
    /// </summary>
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