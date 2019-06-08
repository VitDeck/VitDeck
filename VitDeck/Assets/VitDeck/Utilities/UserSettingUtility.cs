using System;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Utilities
{
    public class UserSettingUtility
    {
        private const string assetPath = "Assets/VitDeck/Utilities/UserSettings.asset";
        public static UserSettings GetUserSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath<UserSettings>(assetPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<UserSettings>();
                AssetDatabase.CreateAsset(settings, assetPath);
            }
            return settings;
        }
        public static void SaveUserSettings(UserSettings settings)
        {
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
        }
    }
}