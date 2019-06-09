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
        [Validation(order = -2)]
        public IRule unityVersionRule = new UnityVersionRule("Unityバージョンルール", "2017.4.15f1");
        [Validation(order = -1)]
        public IRule rule1 = new SampleRule("ルール１");
        [Validation]
        public IRule rule2 = new SampleRule("ルール２", "カスタム設定値２");
    }
}