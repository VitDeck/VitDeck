using System;
using UnityEngine;
using VitDeck.Validator;

namespace VitDeck.Main
{
    /// <summary>
    /// VitDeckを使った一連の作業の流れを定義しているScriptableObject
    /// </summary>
    public class Workflow : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField, HideInInspector] private string ruleSetTypeFullName;
        private IRuleSet ruleSet;
        public IRuleSet RuleSet => ruleSet;

        public void OnBeforeSerialize()
        {
            ruleSetTypeFullName = ruleSet == null ? "" : ruleSet.GetType().AssemblyQualifiedName;
        }

        public void OnAfterDeserialize()
        {
            ruleSet = GetRuleSetInstance(ruleSetTypeFullName);
        }

        private static IRuleSet GetRuleSetInstance(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                return null;
            }

            var type = Type.GetType(fullName);
            if (type == null)
            {
                Debug.LogError($"{fullName}型のルールセットがプロジェクト内に定義されていません。");
                return null;
            }

            return Activator.CreateInstance(type) as IRuleSet;
        }
    }
}