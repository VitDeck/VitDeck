using System;

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
            AddIssue(new Issue(null, IssueLevel.Info, "これはサンプルルールの検証結果です。"));
            AddIssue(new Issue(null, IssueLevel.Info, "これはサンプルルールの解決策付き検証結果（情報）です。", "解決策テキスト", "https://github.com/vkettools/VitDeck/issues/57"));
            var items = "";

            for (int i = 0; i < 10; i++)
                items += "- item" + Environment.NewLine;
            AddIssue(new Issue(null, IssueLevel.Warning, "これはサンプルルールの改行の多い検証結果(警告)です。" + Environment.NewLine + items, "解決策テキスト", "https://github.com/vkettools/VitDeck/issues/57"));
            AddIssue(new Issue(null, IssueLevel.Error, "これはサンプルルールの検証結果(エラー)です。長い文------------------------------------------------------------章", "解決策テキスト", "https://github.com/vkettools/VitDeck/issues/57"));

            AddResultLog("customSetting：" + customSetting);
        }
    }
}