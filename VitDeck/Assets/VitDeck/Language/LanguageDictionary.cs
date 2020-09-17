using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Language
{
    [CreateAssetMenu]
    public class LanguageDictionary : ScriptableObject, ILanguage, ISerializationCallbackReceiver
    {
        [System.Serializable]
        public struct Pair
        {
            public string Key;
            public string Value;
        }

        [SerializeField]
        private Pair[] language = new Pair[0];
        private Dictionary<string, string> dictionary;

        public string this[string key]
        {
            get
            {
                return dictionary[key];
            }
        }

        internal Pair[] GetTranslations()
        {
            return language;
        }

        internal void SetTranslations(Pair[] pairs)
        {
            language = pairs;
            OnAfterDeserialize();
        }

        public bool TryGetValue(string key, out string value)
        {
            return dictionary.TryGetValue(key, out value);
        }

        public void OnBeforeSerialize()
        {

        }

        public void OnAfterDeserialize()
        {
            dictionary = new Dictionary<string, string>();
            foreach (var text in language)
            {
                dictionary.Add(text.Key, text.Value);
            }
        }
    }
}