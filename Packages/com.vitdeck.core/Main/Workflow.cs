using System;
using UnityEngine;
using UnityEngine.Serialization;
using VitDeck.Exporter;
using VitDeck.Validator;

namespace VitDeck.Main
{
    /// <summary>
    /// VitDeckを使った一連の作業の流れを定義しているScriptableObject
    /// </summary>
    public class Workflow : ScriptableObject
    {
        [SerializeField, RuleSetPopup] private string ruleSet;
        [SerializeField] private ExportSetting exportSetting;
        public IRuleSet RuleSet => Validator.Validator.GetRuleSet(ruleSet);
        public ExportSetting ExportSetting => exportSetting;
    }
}
