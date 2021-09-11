using System.Collections.Generic;

namespace VitDeck.Utilities
{
    /// <summary>
    /// .NET Standard 2.1のpolyfill。
    /// </summary>
    public static class Deconstruction
    {
        public static void Deconstruct<TKey, TValue>(
            this KeyValuePair<TKey, TValue> keyValuePair,
            out TKey key,
            out TValue value
        )
        {
            key = keyValuePair.Key;
            value = keyValuePair.Value;
        }
    }
}
