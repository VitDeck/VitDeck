using UnityEditor;

namespace VitDeck.Placement
{
    /// <summary>
    /// GUIDを変更してunitypackageをインポートします。
    /// </summary>
    /// <remarks>
    /// TODO: VitDeck.Utilities へ移動すべき。
    /// </remarks>
    public class ImportOnly
    {
        [MenuItem("VitDeck/Change GUID and Import unitypackage", priority = 132)]
        public static void Import()
        {
            var path = EditorUtility.OpenFilePanel(title: "VitDeck", directory: null, "unitypackage");
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            PackageImporter.Import(path);
        }
    }
}
