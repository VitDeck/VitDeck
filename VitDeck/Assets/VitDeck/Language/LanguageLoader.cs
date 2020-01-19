using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Language
{
    public class LanguageLoader
    {

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            var settings = FindLanguageSettingsInstance();

            LocalizedMessage.SetDictionary(settings.language);
        }

        private static LanguageSettings FindLanguageSettingsInstance()
        {
            LanguageSettings asset;
            var assetPath = Path.Combine(Utilities.AssetUtility.ConfigFolderPath, "LanguageSettings.asset");
            if (File.Exists(assetPath))
            {
                asset = AssetDatabase.LoadAssetAtPath<LanguageSettings>(assetPath);
            }
            else
            {
                asset = ScriptableObject.CreateInstance<LanguageSettings>();
                AssetDatabase.CreateAsset(asset, assetPath);
            }

            return asset;
        }
    }
}