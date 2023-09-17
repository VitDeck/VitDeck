using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator.GUI
{
    [CustomPropertyDrawer(typeof(RuleSetPopupAttribute))]
    public class RuleSetPopupDrawer : PropertyDrawer
    {
        private static string[] ruleSetNameList = null;

        static RuleSetPopupDrawer()
        {
            InitializeRuleSetTypeNameList();
        }

        private static void InitializeRuleSetTypeNameList()
        {
            var ruleSets = Validator.GetRuleSets();

            ruleSetNameList = ruleSets.Select(t => t.GetType().Name).ToArray();
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var ruleSetTypeName = property.stringValue;
            var index = Array.IndexOf(ruleSetNameList, ruleSetTypeName);
            index = EditorGUI.Popup(position, label.text, index, ruleSetNameList);
            property.stringValue = index >= 0 ? ruleSetNameList[index] : "";
        }
    }
}
