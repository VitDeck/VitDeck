using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// <see cref="AssetGuardian"/>の、選択中のアセットの保護/保護解除を行うMenuItemを登録するクラス。
    /// </summary>
    public static class AssetGuardianContextMenu
    {
        [MenuItem("Assets/AssetGuardian/Protect")]
        static void Protect()
        {
            foreach (var asset in EnumerateSelectedAssets())
            {
                Protector.Protect(asset);
            }
        }

        [MenuItem("Assets/AssetGuardian/Protect", validate = true)]
        static bool ProtectValidate()
        {
            return IsSelectedAnyAssets();
        }

        [MenuItem("Assets/AssetGuardian/Unprotect")]
        static void Unprotect()
        {
            foreach (var asset in EnumerateSelectedAssets())
            {
                Protector.Unprotect(asset);
            }
        }

        [MenuItem("Assets/AssetGuardian/Unprotect", validate = true)]
        static bool UnprotectValidate()
        {
            return IsSelectedAnyAssets();
        }

        private static bool IsSelectedAnyAssets()
        {
            return Selection.assetGUIDs.Length > 0;
        }

        private static IEnumerable<UnityEngine.Object> EnumerateSelectedAssets()
        {
            return Selection.assetGUIDs
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .SelectMany(path => Utilities.AssetUtility.EnumerateAssets(path))
                .Distinct();
        }
    }
}