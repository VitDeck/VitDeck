using UnityEngine;

namespace VitDeck.Utilities
{
    public static class SIReadableNumberText
    {
        static string[] array = {"", "k", "M", "G", "T", "P"};
        
        public static string Get(long value, string unit)
        {
            var index = value == 0 ? 0 : Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(value)) / 3);
            var num = value / Mathf.Pow(1000, index);
            return $"{num:##0.###} {array[index]}{unit}";
        }
    }
}
