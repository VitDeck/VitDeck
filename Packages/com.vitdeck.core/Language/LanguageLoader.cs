using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Language
{
    /// <summary>
    /// Unityエディタが読み込まれたときに、VitDeckの翻訳機能にコア翻訳ファイルを自動で読み込ませるためのクラス。
    /// </summary>
    public static class LanguageLoader
    {
        private static Dictionary<SystemLanguage, string> languageGUIDs;
        private const SystemLanguage DefaultLanguage = SystemLanguage.English;
        private const string LogHeader = "[VitDeck]";

        /// <summary>
        /// 各種言語別に、コア翻訳ファイルのGUIDを保持するDictionary。
        /// </summary>
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

            // Unityの読込直後は言語設定ファイルを掴み損ねる可能性があるため、その場合はEditor.updateのタイミングまで遅延させる
            if (settings == null)
            {
                EditorApplication.update += DelayedInitialize;
                return;
            }

            LanguageDictionary dictionary;
            if (settings.language == null)
            {
                var currentLanguage = Application.systemLanguage;
                Debug.Log(LogHeader + "Current system language = " + currentLanguage);
                if (LanguageFileGUIDs.TryGetValue(currentLanguage, out var languageFileGuid))
                {
                    Debug.Log(LogHeader + "Load LanguageFile which for " + currentLanguage);
                }
                else
                {
                    Debug.Log(LogHeader +
                              "LanguageFile which for current system language is not found. load default LanguageFile.");
                    languageFileGuid = LanguageFileGUIDs[DefaultLanguage];
                }

                var defaultLanguagePath = AssetDatabase.GUIDToAssetPath(languageFileGuid);
                dictionary = AssetDatabase.LoadAssetAtPath<LanguageDictionary>(defaultLanguagePath);
            }
            else
            {
                Debug.Log(LogHeader + "Load overrode LanguageFile = " + settings.language);
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
