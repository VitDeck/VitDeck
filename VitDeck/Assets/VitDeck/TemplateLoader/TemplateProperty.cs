using System;
using UnityEngine;

namespace VitDeck.TemplateLoader
{
    public class TemplateProperty : ScriptableObject
    {
        [SerializeField]
        public string templateName;
        [SerializeField]
        public string description;
        [SerializeField]
        public TextAsset lisenseFile;
        [SerializeField]
        public string developer;
        [SerializeField]
        public string developerUrl;
        [SerializeField]
        public ReplacementDefinition[] replaceList;
    }
}