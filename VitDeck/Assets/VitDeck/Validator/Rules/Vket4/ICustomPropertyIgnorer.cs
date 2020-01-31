using System;
using UnityEditor;

namespace VitDeck.Validator
{
    public interface ICustomPropertyIgnorer
    {
        bool IsIgnored(Type objectType, string propertyName);
    }

    public class DummyPropertyIgnorer : ICustomPropertyIgnorer
    {
        public bool IsIgnored(Type objectType, string propertyName)
        {
            return false;
        }
    }
}