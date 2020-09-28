using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VketTools.Utilities;

namespace VitDeck.Validator
{
    internal class Vket5PropertyIgnorer : ICustomPropertyIgnorer
    {
        private readonly RequestComponent requested;
        private readonly HashSet<string> properties;

        public Vket5PropertyIgnorer(RequestComponent requested)
        {
            this.requested = requested;
            properties = new HashSet<string>(requested.Propertys);
        }

        public bool IsIgnored(Type objectType, string propertyName)
        {
            var path = objectType.Name + "." + propertyName;
            Debug.Log(path);
            return properties.Contains(path);
        }
    }
}