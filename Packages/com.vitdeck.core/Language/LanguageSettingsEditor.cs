using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Language
{
    [CustomEditor(typeof(LanguageSettings))]
    public class LanguageSettingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            LanguageSelectorField();
            serializedObject.ApplyModifiedProperties();
        }

        private void LanguageSelectorField()
        {
            var property = serializedObject.FindProperty("language");

            // 外部からの設定変更が行われている場合は、言語選択フィールドを無効化して、現在の言語を表示する
            if (LocalizedMessage.ExternalConfiguratorAvailable)
            {
                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.EnumPopup("Language", LocalizedMessage.CurrentLanguage);
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.HelpBox(LocalizedMessage.Get("languageSettingsEditor.externalConfiguratorAvailable"),
                    MessageType.Info);
                return;
            }

            // 外部からの設定変更がない場合は、言語選択フィールドを表示する
            EditorGUI.BeginChangeCheck();
            var language = ConvertPropertyValueToSystemLanguage(property.enumValueIndex);
            var supportedLanguagesList = LocalizedMessage.GetSupportedLanguages().ToArray();
            var newLanguage = DrawEnumPopup(language, supportedLanguagesList);

            if (EditorGUI.EndChangeCheck())
            {
                property.enumValueIndex = ConvertSystemLanguageToPropertyValue(newLanguage);
                LocalizedMessage.SetCurrentLanguageInternal(newLanguage, false);
            }
        }

        // SerializedPropertyの値からSystemLanguageへの変換
        private static SystemLanguage ConvertPropertyValueToSystemLanguage(int propertyValue)
        {
            return (SystemLanguage)(propertyValue - 1);
        }

        // SystemLanguageからSerializedPropertyの値への変換
        private static int ConvertSystemLanguageToPropertyValue(SystemLanguage language)
        {
            return (int)language + 1;
        }

        private static SystemLanguage DrawEnumPopup(SystemLanguage language, IReadOnlyList<SystemLanguage> availableLanguages)
        {
            // availableLanguageのリスト内におけるindexを取得する
            var indexInAvailableLanguages = IndexOf(language, availableLanguages);
            if (indexInAvailableLanguages == -1)
            {
                // 選択中の言語がサポート言語リストにない場合は、その言語を追加して再帰呼び出しを実行
                return DrawEnumPopup(language, new[] { language }.Concat(availableLanguages).ToArray());
            }

            // EnumPopupに表示する言語名のリストを作成
            var languageNames = availableLanguages.Select(l => l.ToString()).ToArray();

            // EnumPopupを表示し、選択された言語のindexを取得
            var newLanguageIndex = EditorGUILayout.Popup("Language", indexInAvailableLanguages, languageNames);

            // 選択された言語のindexに対応する言語を返す
            return availableLanguages[newLanguageIndex];
        }

        private static int IndexOf(SystemLanguage language, IReadOnlyList<SystemLanguage> languages)
        {
            for (var i = 0; i < languages.Count; i++)
            {
                if (languages[i] == language)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
