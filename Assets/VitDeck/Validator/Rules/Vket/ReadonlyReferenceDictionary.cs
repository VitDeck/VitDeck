using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public interface IReadonlyReferenceDictionary
    {
        IReadOnlyDictionary<Object, IReadOnlyList<Object>> Forward { get; }
        IReadOnlyDictionary<Object, IReadOnlyList<Object>> Reverse { get; }
    }
    
    public class ReadonlyReferenceDictionary : IReadonlyReferenceDictionary
    {
        public ReadonlyReferenceDictionary(
            IReadOnlyDictionary<Object, List<Object>> forward,
            IReadOnlyDictionary<Object, List<Object>> reverse)
        {
            Forward = ToReadOnly(forward);
            Reverse = ToReadOnly(reverse);
        }

        private static IReadOnlyDictionary<Object, IReadOnlyList<Object>> ToReadOnly(IReadOnlyDictionary<Object, List<Object>> dictionary)
        {
            var readonlyDictionary = new Dictionary<Object, IReadOnlyList<Object>>(dictionary.Count);
            foreach (var pair in dictionary)
            {
                readonlyDictionary.Add(pair.Key, pair.Value);
            }

            return readonlyDictionary;
        }

        public IReadOnlyDictionary<Object, IReadOnlyList<Object>> Forward { get; }
        public IReadOnlyDictionary<Object, IReadOnlyList<Object>> Reverse { get; }
    }
}