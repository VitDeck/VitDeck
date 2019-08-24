using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    public static class AssetGuardianContextMenu
    {
        [MenuItem("Assets/Protect Selected Asset")]
        static void Protect()
        {
            var assets = Selection.objects
                .Select(obj => AssetDatabase.GetAssetPath(obj))
                .Where(obj => obj != null)
                .SelectMany(path => Utilities.AssetUtility.EnumerateAssets(path))
                .Distinct();
            foreach (var asset in assets)
            {
                Protector.Protect(asset);
            }
        }

        [MenuItem("Assets/Unprotect Selected Asset")]
        static void Unprotect()
        {
            var assets = Selection.objects
                .Select(obj => AssetDatabase.GetAssetPath(obj))
                .Where(obj => obj != null)
                .SelectMany(path => Utilities.AssetUtility.EnumerateAssets(path))
                .Distinct();
            foreach (var asset in assets)
            {
                Protector.Unprotect(asset);
            }
        }
    }
}