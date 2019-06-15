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
        [Validation(order = -1)]
        public IRule rule1 = new SampleRule("ルール１");
        [Validation]
        public IRule rule2 = new SampleRule("ルール２", "カスタム設定値２");
        [Validation]
        public IRule unityVersionRule = new UnityVersionRule("[U01]Unityバージョンルール", "2017.4.15f1");
        [Validation]
        public IRule assetGuidBlacklistRule = new AssetGuidBlacklistRule("[A02]特定のGUIDを持つアセットの検出ルール",
            new string[] { "740112f6e77ca914d9c26eef5d68accd", "ae68339621fb41b4f9905188526120ea" });
    }
}