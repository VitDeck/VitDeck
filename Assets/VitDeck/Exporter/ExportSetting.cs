using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Exporter
{
    public class ExportSetting : ScriptableObject
    {
        public string SettingName = "";
        [TextArea]
        public string Description = "";
        [Tooltip("Export folder path. This must be start with `Assets`")]
        public string ExportFolderPath = "Assets/Exports";
        [Tooltip("File name for export. If `{SHA-1}` is contained, it will replace SHA-1 hash value. If `{ID}` is contained, it will replace base folder name. If `{DATETIME}` is contained, it will replace exporting time.")]
        public string fileNameFormat = "export_file.unitypackage";
        [Tooltip("Class name of IRuleSet. If this field is empty, Export will skip validation.")]
        public string ruleSetName = "";
        [Tooltip("If true, Export will done though validation result has warning issues.")]
        public bool ignoreValidationWarning = false;
    }
}