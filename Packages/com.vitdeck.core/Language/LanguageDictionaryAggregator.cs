using System;
using System.Collections;
using System.Collections.Generic;

namespace VitDeck.Language
{
    public class LanguageDictionaryAggregator : ILanguage
    {

        private readonly Dictionary<string, string> internalDictionary = new Dictionary<string, string>();

        public LanguageDictionaryAggregator(params ILanguage[] dictionaries)
        {
            foreach (var dictionary in dictionaries)
            {
                Add(dictionary);
            }
        }

        /// <summary>
        /// 辞書をAggregatorに追加し、一つの辞書として扱えるようにします。
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="overwrite">辞書のキーが重複したときに値を上書きするかどうか。falseの場合は既存の値が優先されます。</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Add(ILanguage dictionary, bool overwrite = false)
        {
            if (dictionary == this)
            {
                throw new InvalidOperationException("自分自身を追加することはできません。");
            }

            foreach (var pair in dictionary)
            {
                if (internalDictionary.ContainsKey(pair.Key))
                {
                    if (overwrite)
                    {
                        internalDictionary[pair.Key] = pair.Value;
                    }
                    continue;
                }
                internalDictionary.Add(pair.Key, pair.Value);
            }
        }

        public bool TryGetValue(string key, out string value)
        {
            return internalDictionary.TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return internalDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
