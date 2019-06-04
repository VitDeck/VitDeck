using System.Collections.Generic;
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
                ValidationResult result = rule.Validate();
                results.Add(result);
            }
            return results.ToArray();
        }
    }

}