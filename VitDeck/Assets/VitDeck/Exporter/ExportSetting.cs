using UnityEditor;
using UnityEngine;

namespace VitDeck.Exporter
{
    [CreateAssetMenu(fileName = "ExportSetting.asset", menuName = "VitDeck/Export Setting")]
    public class ExportSetting : ScriptableObject
    {
        public string SettingName = "";
    }
}