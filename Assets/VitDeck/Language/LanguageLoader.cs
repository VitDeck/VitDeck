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
        private static Dictionary<SystemLanguage, string> languageGUIDs;
        private static SystemLanguage defaultLanguage = SystemLanguage.English;

        private static Dictionary<SystemLanguage, string> LanguageFileGUIDs
        {
            get
            {
                if (languageGUIDs != null)
                {
                    return languageGUIDs;
                }

                languageGUIDs = new Dictionary<SystemLanguage, string>
                {
                    { SystemLanguage.English, "9c6ce664473c5364f97e0062f8d16c90" },
                    { SystemLanguage.Japanese, "bca05b8223e02d446a2f3bd3dea0ee44" }
                };

                return languageGUIDs;
            }
        }

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            var settings = FindLanguageSettingsInstance();

            if (settings == null)
            {
                EditorApplication.update += DelayedInitialize;
                return;
            }

            LanguageDictionary dictionary;
            if (settings.language == null)
            {
                string languageGUID;
                var currentLanguage = Application.systemLanguage;
                Debug.Log("Current system language = " + currentLanguage);
                if (LanguageFileGUIDs.TryGetValue(currentLanguage, out languageGUID))
                {
                    Debug.Log("Load LanguageFile which for " + currentLanguage);
                }
                else
                {
                    Debug.Log("LanguageFile which for current system language is not found. load default LanguageFile.");
                    languageGUID = LanguageFileGUIDs[defaultLanguage];
                }

                var defaultLanguagePath = AssetDatabase.GUIDToAssetPath(languageGUID);
                dictionary = AssetDatabase.LoadAssetAtPath<LanguageDictionary>(defaultLanguagePath);
            }
            else
            {
                Debug.Log("Load overrided LanguageFile = " + settings.language);
                dictionary = settings.language;
            }

            LocalizedMessage.SetDictionary(dictionary);
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

        private static void DelayedInitialize()
        {
            EditorApplication.update -= DelayedInitialize;
            Initialize();
        }
    }
}