using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    /// サンプルルールセット
    /// </summary>
    public class PassRuleSet : BaseRuleSet
    {
        public override string RuleSetName
        {
            get { return "パスルール"; }
        }

        [Validation] public IRule passRule = new UnityVersionRule("pass rule", Application.unityVersion);
    }
}
