using System.Collections;
using System.Collections.Generic;

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

            return string.Format(translated, args);
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