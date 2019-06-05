

namespace VitDeck.Validator
{
    /// <summary>
    /// サンプルルールセット
    /// </summary>
    public class SampleRuleSet : BaseRuleSet
    {
        public override string RuleSetName
        {
            get { return "サンプルルールセット"; }
        }
        [Validation]
        public SampleRule rule1 = new SampleRule("ルール１");
        [Validation]
        public SampleRule rule2 = new SampleRule("ルール２", "カスタム設定値２");
    }
}