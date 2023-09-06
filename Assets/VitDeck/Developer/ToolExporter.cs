using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.Developer
{
    /// <summary>
    /// VitDeck自体のunitypackageを作成し、デスクトップへ出力します。
    /// </summary>
    internal class ToolExporter
    {
        private static readonly string DestinationFolderPath
            = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        private static readonly string RootPath = "Assets/VitDeck";

        private static readonly Regex IgnorePattern = new Regex(@"^Assets/VitDeck/(
            Main/ToolExporter\.cs
            |Utilities/GUIDEnumerator\.cs
            |Placement(/.+)?
            |Temporary(/.+)?
            |.+/Tests/.+
            |TestUtilities(/.+)?
            |Templates/(Sample_template|0.+)(/.+)?
            |Validator/Rules/Sample(/.+)?
            |Config/(UserSettings|DefaultExportSetting.*|PlacementSettings|Vket.+)\.asset
        )$", RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);

        [MenuItem("VitDeck/Export VitDeck", false, 201)]
        private static void Export()
        {
            AssetDatabase.ExportPackage(
                AssetDatabase.GetAllAssetPaths().Where(path => path == ToolExporter.RootPath
                    || path.StartsWith(ToolExporter.RootPath + "/") && !ToolExporter.IgnorePattern.IsMatch(path))
                    .ToArray(),
                Path.Combine(
                    ToolExporter.DestinationFolderPath,
                    $"{ProductInfoUtility.GetDeveloperLinkTitle()}-{ProductInfoUtility.GetVersion()}.unitypackage"
                )
            );
        }
    }
}
