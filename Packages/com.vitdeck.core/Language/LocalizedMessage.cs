using System;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Language
{
    /// <summary>
    /// VitDeckの翻訳機能を提供するクラス。
    /// </summary>
    public static class LocalizedMessage
    {
        private const SystemLanguage DefaultLanguage = SystemLanguage.Japanese;

        private static readonly Dictionary<SystemLanguage, LanguageDictionaryAggregator> LanguageDictionaries
            = new Dictionary<SystemLanguage, LanguageDictionaryAggregator>();

        private static SystemLanguage currentCurrentLanguage = Application.systemLanguage;
        private static ILanguage currentLanguageDictionary = null;
        private static bool externalConfiguratorAvailable = false;

        /// <summary>
        /// 指定されたmessageIDに対応する翻訳文を取得します。
        /// </summary>
        /// <param name="messageID">辞書に登録されている翻訳文に対応したID</param>
        /// <param name="args">翻訳文内に埋め込まれたプレースホルダを置き換えるための引数</param>
        /// <returns>取得された翻訳文</returns>
        /// <exception cref="FormatException"></exception>
        public static string Get(string messageID, params object[] args)
        {
            if (currentLanguageDictionary == null)
            {
                currentLanguageDictionary = ChooseLanguageDictionary(currentCurrentLanguage);
            }

            if (currentLanguageDictionary == null)
            {
                return messageID;
            }

            var found = currentLanguageDictionary.TryGetValue(messageID, out var translated);

            if (!found)
            {
                return messageID;
            }

            try
            {
                return string.Format(translated, args);
            }
            catch (FormatException e)
            {
                throw new FormatException($"翻訳文のフォーマットが一致しません。\nMessageID={messageID}\nMessage{translated}", e);
            }
        }

        public static IReadOnlyCollection<SystemLanguage> GetSupportedLanguages()
        {
            return LanguageDictionaries.Keys;
        }

        /// <summary>
        /// LocalizedMessageで使用する辞書を設定します。
        /// </summary>
        /// <param name="dictionary"></param>
        [Obsolete("このメソッドはサポートされなくなりました。代わりに AddDictionary メソッドを使用してください。", true)]
        public static void SetDictionary(LanguageDictionary dictionary)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 現在の言語設定を取得、設定します。
        /// </summary>
        public static SystemLanguage CurrentLanguage
        {
            get => currentCurrentLanguage;
            set => SetCurrentLanguageInternal(value, true);
        }

        /// <summary>
        /// 言語設定が他ツールにより上書きされているかどうかを返します。VitDeck.Languageの内部動作に影響します。
        /// </summary>
        internal static bool ExternalConfiguratorAvailable => externalConfiguratorAvailable;

        internal static void SetCurrentLanguageInternal(SystemLanguage language, bool isExternalOperation)
        {
            currentCurrentLanguage = language;
            externalConfiguratorAvailable = isExternalOperation;
            currentLanguageDictionary = null;
        }

        /// <summary>
        /// LocalizedMessageで使用する言語辞書を追加します。
        /// 追加した辞書は設定した言語で利用され、既に同じキーが存在する場合は後から追加した辞書の内容が優先されます。
        /// </summary>
        /// <param name="language">追加する辞書がサポートする言語</param>
        /// <param name="dictionary">追加する辞書</param>
        public static void AddDictionary(SystemLanguage language, ILanguage dictionary)
        {
            if (!LanguageDictionaries.TryGetValue(language, out var aggregator))
            {
                LanguageDictionaries.Add(language, new LanguageDictionaryAggregator(dictionary));
                return;
            }

            aggregator.Add(dictionary, true);
        }

        /// <summary>
        /// VitDeckで予め用意された言語辞書を登録するためのメソッドです。
        /// このメソッドで登録された辞書は、他の辞書による上書きが優先的に行われます。
        /// </summary>
        /// <param name="language"></param>
        /// <param name="dictionary"></param>
        internal static void AddSystemDictionary(SystemLanguage language, ILanguage dictionary)
        {
            if (!LanguageDictionaries.TryGetValue(language, out var aggregator))
            {
                LanguageDictionaries.Add(language, new LanguageDictionaryAggregator(dictionary));
                return;
            }

            aggregator.Add(dictionary, false);
        }

        private static ILanguage ChooseLanguageDictionary(SystemLanguage language)
        {
            if (LanguageDictionaries.TryGetValue(language, out var dictionary))
            {
                return dictionary;
            }

            if (language == DefaultLanguage)
            {
                return null;
            }

            if (LanguageDictionaries.TryGetValue(DefaultLanguage, out dictionary))
            {
                return dictionary;
            }

            return null;
        }
    }
}
