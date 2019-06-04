namespace VitDeck.Validator
{
    /// <summary>
    /// サンプルルール
    /// </summary>
    public class SampleRule : BaseRule
    {
        private string customSetting;
        public SampleRule(string name, string custom = "デフォルト設定値") : base(name)
        {
            this.customSetting = custom;
        }

        internal override void Logic(string baseFolder)
        {
            //前提チェック
            if (string.IsNullOrEmpty(baseFolder))
                throw new FatalValidationErrorException("ベースフォルダが指定されていません。");
            //チェック結果を設定
            AddIssue(new Issue(null, IssueLevel.Info, "これはサンプルルールの検証結果です。", "解決策テキスト", "https://github.com/vkettools/VitDeck/issues/57"));
            AddResultLog(baseFolder);
            AddResultLog(customSetting);
        }
    }
}