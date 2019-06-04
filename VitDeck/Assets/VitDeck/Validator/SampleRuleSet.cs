

namespace VitDeck.Validator
{
    /// <summary>
    /// サンプルルールセット
    /// </summary>
    public class SampleRuleSet : BaseRuleSet
    {
        public new readonly string ruleSetName = "サンプルルールセット";
        [Validation]
        public SampleRule rule1 = new SampleRule("ルール１");
        [Validation]
        public SampleRule rule2 = new SampleRule("ルール２", "カスタム設定値２");
    }
}