using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Utilities
{
    public class UserSettingUtility
    {
        private const string settingFileName = "UserSettings.asset";
        public static UserSettings GetUserSettings()
        {
            var assetPath = Path.Combine(AssetUtility.ConfigFolderPath, settingFileName);
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