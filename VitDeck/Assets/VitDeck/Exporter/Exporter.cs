using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.Exporter
{
    /// <summary>
    /// エクスポート機能を提供する。
    /// </summary>
    public static class Exporter
    {
        public static ExportResult Export(string[] targetPaths, ExportSetting setting)
        {
            return new ExportResult();
        }
        public static ExportSetting[] GetExportSettings()
        {
            var filter = "t:ExportSetting";
            var settings = AssetDatabase.FindAssets(filter, new string[] { AssetUtility.ConfigFolderPath })
                .Select(guid => AssetDatabase.LoadAssetAtPath<ExportSetting>(AssetDatabase.GUIDToAssetPath(guid)));
            return settings.ToArray();
        }
    }
}