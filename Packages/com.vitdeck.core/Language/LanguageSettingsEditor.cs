using System.Collections;
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
            // // property.enumValueIndexからSystemLanguageに変換する際、なぜか+1ズレるので、-1して調整
            var language = (SystemLanguage)property.enumValueIndex - 1;
            var supportedLanguagesList = LocalizedMessage.GetSupportedLanguages().ToArray();
            var newLanguage = DrawEnumPopup(language, supportedLanguagesList);

            if (EditorGUI.EndChangeCheck())
            {
                // property.enumValueIndexにenumの値を入れる際、なぜか-1ズレるので、+1して調整
                property.enumValueIndex = (int)newLanguage +1;
                LocalizedMessage.SetCurrentLanguageInternal(newLanguage, false);
            }
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
