using System;
using UnityEngine;
using UnityEngine.Serialization;
using VitDeck.Validator;

namespace VitDeck.Main
{
    /// <summary>
    /// VitDeckを使った一連の作業の流れを定義しているScriptableObject
    /// </summary>
    public class Workflow : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField, RuleSetType] private string ruleSet;
        private IRuleSet deserializedRuleSet;
        public IRuleSet RuleSet => deserializedRuleSet;

        public void OnBeforeSerialize()
        {
            ruleSet = deserializedRuleSet == null ? "" : deserializedRuleSet.GetType().AssemblyQualifiedName;
        }

        public void OnAfterDeserialize()
        {
            deserializedRuleSet = GetRuleSetInstance(ruleSet);
        }

        private static IRuleSet GetRuleSetInstance(string assemblyQualifiedName)
        {
            if (string.IsNullOrEmpty(assemblyQualifiedName))
            {
                return null;
            }

            var type = Type.GetType(assemblyQualifiedName);
            if (type == null)
            {
                Debug.LogError($"'{assemblyQualifiedName}'に対応する型のルールセットがプロジェクト内に定義されていません。");
                return null;
            }

            return Activator.CreateInstance(type) as IRuleSet;
        }
    }
}