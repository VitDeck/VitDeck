using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.Validator
{
    /// <summary>
    /// ルールチェック機能を提供する。
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// ルールチェックを実行する。
        /// </summary>
        public static ValidationResult[] Validate(BaseRuleSet ruleSet, string baseFolder)
        {
            var rules = ruleSet.GetRules();
            var results = new List<ValidationResult>();
            foreach (var rule in rules)
            {
                try
                {

                    ValidationResult result = rule.Validate(baseFolder);
                    results.Add(result);
                }
                catch (FatalValidationErrorException e)
                {
                    Debug.LogError("ルールチェックを中断しました:" + e.Message);
                    results.Add(rule.GetResult());
                    break;
                }

            }
            return results.ToArray();
        }

        public static BaseRuleSet[] GetRuleSets()
        {
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(BaseRuleSet)));
            var ruleSets = new List<BaseRuleSet>();
            foreach (var type in types)
            {
                var instance = (BaseRuleSet)System.Activator.CreateInstance(type);
                if (instance != null)
                    ruleSets.Add(instance);
            }
            return ruleSets.ToArray();
        }
    }

}