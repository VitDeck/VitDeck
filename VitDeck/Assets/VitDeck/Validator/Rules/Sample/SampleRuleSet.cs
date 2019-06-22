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
        public IRule rule1 = new SampleRule("サンプルメッセージ");
        [Validation]
        public IRule unityVersionRule = new UnityVersionRule("[U01]Unityバージョンルール", "2017.4.28f1");
        [Validation]
        public IRule assetNamingRule = new AssetNamingRule("[A01]アセット名の使用禁止文字ルール", "[\x21-\x7e ]+");
        [Validation]
        public IRule assetGuidBlacklistRule = new AssetGuidBlacklistRule("[A02]特定のGUIDを持つアセットの検出ルール",
            new string[] { "740112f6e77ca914d9c26eef5d68accd", "ae68339621fb41b4f9905188526120ea" });
        [Validation]
        public IRule assetPathLengthRule = new AssetPathLengthRule("[A03]アセットパス長制限ルール", 184);
        [Validation]
        public IRule assetExtentionBlacklistRule = new AssetExtentionBlacklistRule("[A04]アセット拡張子ルール", new string[] { ".txt", ".md" });
        [Validation]
        public IRule boothBoundsRule = new BoothBoundsRule("[B01]ブースBounds超過検証ルール", new UnityEngine.Vector3(4.0f, 5.0f, 4.0f), 0.01f);
    }
}
