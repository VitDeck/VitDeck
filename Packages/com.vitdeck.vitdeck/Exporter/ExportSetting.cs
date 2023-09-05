using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;
using VitDeck.Validator;

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
        [Tooltip("Class name of IRuleSet. If this field is empty, Export will skip validation."), RuleSetPopup]
        public string ruleSetName = "";
        [Tooltip("If true, Export will done though validation result has warning issues.")]
        public bool ignoreValidationWarning = false;
        [Tooltip("If true, Allow `Force Export`.")]
        public bool AllowForceExport = true;
        [Min(0), Tooltip("Max build byte count. If this field is `0`, Export will skip build size check.")]
        public int MaxBuildByteCount = 0;
        [Multiline(lines: 40), Tooltip("Extensions of the file to include in the unitypackage. A newline-separated extensions starting with `.`. Case-insensitive. If this field is empty, all files will be exported.")]
        public string AllowedExtensions;

        /// <exception cref="ArgumentException">「.」で始まらない行がある場合。</exception>
        /// <returns>小文字の拡張子リスト。空の場合はnull。</returns>
        public IEnumerable<string> GetAllowedExtensions()
        {
            if (string.IsNullOrWhiteSpace(this.AllowedExtensions))
            {
                return null;
            }

            return this.AllowedExtensions.Trim().Split('\n').Select(line => {
                var extension = line.Trim().ToLower();
                if (!extension.StartsWith("."))
                {
                    throw new ArgumentException($"「{extension}」は「.」で始まりません。");
                }
                return extension;
            });
        }
    }
}
