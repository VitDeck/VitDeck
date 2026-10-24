using System;
using System.Linq;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Language.Tests
{
    /// <summary>
    /// LanguageSettingsEditorがSerializedPropertyを介して言語を正しく読み書きできることを検証する。
    /// </summary>
    /// <remarks>
    /// SystemLanguageにはHungarianのスペルミス版Hugarianが同じ値で残っているため、
    /// 宣言順の位置を返すenumValueIndexと列挙値は値18より後ろで1ずれる。
    /// この影響を受けないことを全ての言語で確認する。
    /// </remarks>
    public class LanguageSettingsEditorTest
    {
        private static SystemLanguage[] AllLanguages => Enum.GetValues(typeof(SystemLanguage))
            .Cast<SystemLanguage>()
            .Distinct()
            .ToArray();

        private LanguageSettings settings;

        [SetUp]
        public void SetUp()
        {
            settings = ScriptableObject.CreateInstance<LanguageSettings>();
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.DestroyImmediate(settings);
        }

        [Test]
        public void ReadLanguage_ReturnsStoredLanguage([ValueSource(nameof(AllLanguages))] SystemLanguage language)
        {
            settings.language = language;
            var serializedObject = new SerializedObject(settings);
            var property = serializedObject.FindProperty("language");

            var result = LanguageSettingsEditor.ReadLanguage(property);

            Assert.That(result, Is.EqualTo(language));
        }

        [Test]
        public void WriteLanguage_StoresSelectedLanguage([ValueSource(nameof(AllLanguages))] SystemLanguage language)
        {
            // 書き込み前の値と区別できるよう、対象と異なる言語で初期化する
            settings.language = language == SystemLanguage.Japanese ? SystemLanguage.English : SystemLanguage.Japanese;
            var serializedObject = new SerializedObject(settings);
            var property = serializedObject.FindProperty("language");

            LanguageSettingsEditor.WriteLanguage(property, language);
            serializedObject.ApplyModifiedPropertiesWithoutUndo();

            Assert.That(settings.language, Is.EqualTo(language));
        }

        [Test]
        public void ReadAndWrite_RoundTripsSupportedLanguages()
        {
            foreach (var language in LocalizedMessage.GetSupportedLanguages())
            {
                var serializedObject = new SerializedObject(settings);
                var property = serializedObject.FindProperty("language");

                LanguageSettingsEditor.WriteLanguage(property, language);
                serializedObject.ApplyModifiedPropertiesWithoutUndo();
                serializedObject.Update();

                Assert.That(LanguageSettingsEditor.ReadLanguage(property), Is.EqualTo(language), language.ToString());
                Assert.That(settings.language, Is.EqualTo(language), language.ToString());
            }
        }
    }
}
