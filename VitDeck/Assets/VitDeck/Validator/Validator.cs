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
        public static ValidationResult[] Validate(IRuleSet ruleSet, string baseFolder)
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

        public static IRuleSet[] GetRuleSets()
        {
            var types = System.AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(IRuleSet).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface);
            var ruleSets = new List<IRuleSet>();
            foreach (var type in types)
            {
                try
                {
                    var instance = (IRuleSet)System.Activator.CreateInstance(type);
                    if (instance != null)
                        ruleSets.Add(instance);
                }
                catch (MissingMethodException)
                {
                    Debug.LogError(type + "の取得に失敗しました。RuleSetに引数付きコンストラクタを定義することは出来ません。");
                }

            }
            return ruleSets.ToArray();
        }
    }
}