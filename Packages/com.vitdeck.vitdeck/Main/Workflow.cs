using System;
using UnityEngine;
using UnityEngine.Serialization;
using VitDeck.Validator;

namespace VitDeck.Main
{
    [CreateAssetMenu(menuName = "VitDeck/Workflow")]
    public class Workflow : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField, HideInInspector] private string ruleSetTypeFullName;
        private IRuleSet ruleSet;

        public void OnBeforeSerialize()
        {
            ruleSetTypeFullName = ruleSet == null ? "" : ruleSet.GetType().FullName;
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