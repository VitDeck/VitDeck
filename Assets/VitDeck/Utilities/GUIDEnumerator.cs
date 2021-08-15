using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Text;

namespace VitDeck.Utilities
{
    public class GUIDEnumerator
    {
        [MenuItem("Assets/GUIDToClipboard")]
        public static void EnumerateSelectedGUIDs()
        {
            var paths = Selection.assetGUIDs
                .Select(AssetDatabase.GUIDToAssetPath)
                .SelectMany(AssetUtility.EnumerateAssets)
                .Select(AssetDatabase.GetAssetPath);

            var builder = new StringBuilder();
            foreach(var path in paths)
            {
                builder.AppendLine($"\"{AssetDatabase.AssetPathToGUID(path)}\", // {path}");
            }

            EditorGUIUtility.systemCopyBuffer = builder.ToString();
        }

        [MenuItem("Assets/MaterialGUIDToClipboard")]
        public static void EnumerateMaterialGUIDs()
        {
            var paths = Selection.assetGUIDs
                .Select(AssetDatabase.GUIDToAssetPath)
                .SelectMany(AssetUtility.EnumerateAssets)
                .Where(asset => asset is Material)
                .Select(AssetDatabase.GetAssetPath);

            var builder = new StringBuilder();
            foreach (var path in paths)
            {
                builder.AppendLine($"\"{AssetDatabase.AssetPathToGUID(path)}\", // {path}");
            }

            EditorGUIUtility.systemCopyBuffer = builder.ToString();
        }
    }
}