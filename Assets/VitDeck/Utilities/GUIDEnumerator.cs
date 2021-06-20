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
            var guids = Selection.assetGUIDs
                .Select(AssetDatabase.GUIDToAssetPath)
                .SelectMany(AssetUtility.EnumerateAssets)
                .Select(AssetDatabase.GetAssetPath)
                .Select(AssetDatabase.AssetPathToGUID);

            var builder = new StringBuilder();
            foreach(var guid in guids)
            {
                builder.AppendFormat("\"{0}\",", guid);
                builder.AppendLine();
            }

            EditorGUIUtility.systemCopyBuffer = builder.ToString();
        }

        [MenuItem("Assets/MaterialGUIDToClipboard")]
        public static void EnumerateMaterialGUIDs()
        {
            var guids = Selection.assetGUIDs
                .Select(AssetDatabase.GUIDToAssetPath)
                .SelectMany(AssetUtility.EnumerateAssets)
                .Where(asset => asset is Material)
                .Select(AssetDatabase.GetAssetPath)
                .Select(AssetDatabase.AssetPathToGUID);

            var builder = new StringBuilder();
            foreach (var guid in guids)
            {
                builder.AppendFormat("\"{0}\",", guid);
                builder.AppendLine();
            }

            EditorGUIUtility.systemCopyBuffer = builder.ToString();
        }
    }
}