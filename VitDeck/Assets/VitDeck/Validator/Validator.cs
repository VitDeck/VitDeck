using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
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
        public static ValidationResult[] Validate(IRuleSet ruleSet, string baseFolder, bool forceOpenScene = false)
        {
            var rules = ruleSet.GetRules();
            ValidationTarget target;
            var results = new List<ValidationResult>();
            try
            {
                target = ruleSet.TargetFinder.Find(baseFolder, forceOpenScene);
                RegisterUndo(target);
            }
            catch (FatalValidationErrorException e)
            {
                Debug.LogError(e.Message);
                var result = new ValidationResult("検証対象の検索");
                result.AddIssue(new Issue(null, IssueLevel.Fatal, e.Message));
                results.Add(result);
                return results.ToArray();
            }
            foreach (var rule in rules)
            {
                try
                {
                    ValidationResult result = rule.Validate(target);
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

        private static void RegisterUndo(ValidationTarget target)
        {
            foreach (var rootObject in target.GetRootObjects())
                Undo.RegisterFullObjectHierarchyUndo(rootObject, "Validate");
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
                    Debug.LogError(type + "の取得に失敗しました。RuleSetは引数無しでインスタンスを生成出来る必要があります。");
                }
            }
            return ruleSets.ToArray();
        }
    }
}