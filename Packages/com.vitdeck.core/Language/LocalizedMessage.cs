using System;
using UnityEngine;

namespace VitDeck.Language
{
    /// <summary>
    /// VitDeckの翻訳機能を提供するクラス。
    /// </summary>
    public static class LocalizedMessage
    {
        private static LanguageDictionary dictionary = null;

        /// <summary>
        /// 指定されたmessageIDに対応する翻訳文を取得します。
        /// </summary>
        /// <param name="messageID">辞書に登録されている翻訳文に対応したID</param>
        /// <param name="args">翻訳文内に埋め込まれたプレースホルダを置き換えるための引数</param>
        /// <returns>取得された翻訳文</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string Get(string messageID, params object[] args)
        {
            if (dictionary == null)
            {
                return messageID;
            }

            var found = dictionary.TryGetValue(messageID, out var translated);

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
                throw new InvalidOperationException($"翻訳文のフォーマットが一致しません。\nMessageID={messageID}\nMessage{translated}", e);
            }
        }

        /// <summary>
        /// LocalizedMessageで使用する辞書を設定します。
        /// </summary>
        /// <param name="dictionary"></param>
        public static void SetDictionary(LanguageDictionary dictionary)
        {
            LocalizedMessage.dictionary = dictionary;
        }
    }

    public interface ILanguage
    {
        string this[string key] { get; }
    }
}
