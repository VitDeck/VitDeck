using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Language
{
    public static class LocalizedMessage
    {
        private static LanguageDictionary dictionary = null;

        public static string Get(string messageID, params object[] args)
        {
            if (dictionary == null)
            {
                return messageID;
            }

            string translated;
            var found = dictionary.TryGetValue(messageID, out translated);

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
                throw new InvalidOperationException(
                    String.Format("翻訳文のフォーマットが一致しません。\nMessageID={0}\nMessage{1}", messageID, translated), e);
            }
        }

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
