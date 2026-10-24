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

        // パッケージに含めないアセットのパターン。フォルダ自身も除外しないと空フォルダがパッケージに残るため、
        // 各項目はフォルダのパス(末尾なし)と配下のパス(/.+)の両方に一致させている。
        private static readonly Regex IgnorePattern = new Regex(@"^Packages/com\.vitdeck\.[a-z]+/(
            .+/Tests(/.+)?
            |TestUtilities(/.+)?
            |Validator/Rules/Sample(/.+)?
        )$", RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);

        [MenuItem("VitDeck/Export VitDeck", false, 201)]
        private static void Export()
        {
            try
            {
                EditorUtility.DisplayProgressBar("Export VitDeck", "", 0.0f);

                var corePackageAssets = AssetDatabase.GetAllAssetPaths()
                    .Where(path => path.StartsWith("Packages/com.vitdeck.core/") && !IgnorePattern.IsMatch(path))
                    .ToArray();
                var exhibitorPackageAssets = AssetDatabase.GetAllAssetPaths()
                    .Where(path => path.StartsWith("Packages/com.vitdeck.exhibitor/") && !IgnorePattern.IsMatch(path))
                    .ToArray();
                var organizerPackageAssets = AssetDatabase.GetAllAssetPaths()
                    .Where(path => path.StartsWith("Packages/com.vitdeck.organizer/") && !IgnorePattern.IsMatch(path))
                    .ToArray();

                EditorUtility.DisplayProgressBar("Export VitDeck", "Export Exhibitor Package", 0.5f);

                AssetDatabase.ExportPackage(
                    corePackageAssets.Concat(exhibitorPackageAssets).ToArray(),
                    Path.Combine(DestinationFolderPath,
                        $"VitDeck-Exhibitor-{ProductInfoUtility.GetVersion()}.unitypackage"
                    )
                );

                EditorUtility.DisplayProgressBar("Export VitDeck", "Export Organizer Package", 0.75f);

                AssetDatabase.ExportPackage(
                    corePackageAssets.Concat(exhibitorPackageAssets).Concat(organizerPackageAssets).ToArray(),
                    Path.Combine(DestinationFolderPath,
                        $"VitDeck-Organizer-{ProductInfoUtility.GetVersion()}.unitypackage"
                    )
                );

                EditorUtility.DisplayDialog("Export VitDeck", $"Exported packages to \"{DestinationFolderPath}\"",
                    "OK");
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }
    }
}
