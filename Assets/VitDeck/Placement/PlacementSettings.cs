using UnityEngine;
using UnityEditor;
using VitDeck.Exporter;

namespace VitDeck.Placement
{
    /// <summary>
    /// <see cref="PlacementWizard"/>の設定値を保持します。
    /// </summary>
    public class PlacementSettings : ScriptableObject
    {
        public ExportSetting ExportSetting;
        public SceneAsset Location;
        public string FolderPath;
    }
}
