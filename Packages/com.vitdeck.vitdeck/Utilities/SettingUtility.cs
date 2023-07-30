using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Utilities
{
    public class SettingUtility
    {
        public static T GetSettings<T>() where T : ScriptableObject
        {
            var assetPath = Path.Combine(AssetUtility.ConfigFolderPath, typeof(T).Name + ".asset");
            var settings = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset(settings, assetPath);
            }
            return settings;
        }
        public static void SaveSettings(ScriptableObject settings)
        {
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
        }
    }
}