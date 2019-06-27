using System;
using UnityEngine;

namespace VitDeck.Utilities
{
    public class UserSettings:ScriptableObject
    {
        [SerializeField]
        public string validatorFolderPath = "";
        [SerializeField]
        public string validatorRuleSetType = "";
        [SerializeField]
        public string exporterSettingFileName = "";
    }
}