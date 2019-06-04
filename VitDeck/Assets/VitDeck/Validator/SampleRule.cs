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

        public override ValidationResult Validate(string baseFolder)
        {
            //前提チェック
            if (string.IsNullOrEmpty(baseFolder))
                throw new FatalValidationErrorException("ベースフォルダが指定されていません。");
            //チェック結果を設定
            result.AddIssue(new Issue(null, IssueLevel.Info, "これはサンプルルールの検証結果です。", "解決策テキスト", "https://github.com/vkettools/VitDeck/issues/57"));
            result.AddResultLog(baseFolder);
            result.AddResultLog(customSetting);
            return result;
        }
    }
}