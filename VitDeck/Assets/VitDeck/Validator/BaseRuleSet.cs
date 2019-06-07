using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    /// 実行する検証ルールのセットを定義するための抽象クラス。
    /// </summary>
    public abstract class BaseRuleSet
    {
        /// <summary>
        /// ルールセット名を返すプロパティ
        /// </summary>
        public abstract string RuleSetName
        {
            get;
        }

        /// <summary>
        /// ルールセットに含まれる検証ルールの配列を返す
        /// </summary>
        /// <returns>検証ルールの配列</returns>
        public IRule[] GetRules()
        {
            var rules = new List<IRule>();
            var ruleFields = this.GetType().GetFields()
                 .Where(field => field.GetCustomAttributes(typeof(ValidationAttribute), false) != null);
            foreach (var ruleField in ruleFields)
            {
                var rule = ruleField.GetValue(this) as IRule;
                if (rule != null)
                    rules.Add(rule);
                else
                    Debug.LogWarning(string.Format("IRule以外のフィールドに[Validation]が指定されているため無視されます。({0} in {1})", ruleField.Name, this.GetType().Name));
            }
            return rules.ToArray();
        }
    }
}