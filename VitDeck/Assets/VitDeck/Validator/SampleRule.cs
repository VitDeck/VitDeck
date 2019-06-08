using System;
using UnityEditor;

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

        protected override void Logic(string baseFolderPath)
        {
            //前提チェック
            if (string.IsNullOrEmpty(baseFolderPath))
                throw new FatalValidationErrorException("ベースフォルダが指定されていません。");
            //チェック結果を設定
            var baseFolder = AssetDatabase.LoadAssetAtPath<DefaultAsset>(baseFolderPath);
            AddIssue(new Issue(baseFolder, IssueLevel.Info, "これはtargetを設定したサンプルルールの検証結果です。target:" + baseFolder.name));
            AddIssue(new Issue(null, IssueLevel.Info, "これはサンプルルールの解決策付き検証結果（情報）です。", "解決策テキスト", "https://github.com/vkettools/VitDeck/issues/57"));
            var items = "";

            for (int i = 0; i < 10; i++)
                items += "- item" + Environment.NewLine;
            AddIssue(new Issue(null, IssueLevel.Warning, "これはサンプルルールの改行の多い検証結果(警告)です。" + Environment.NewLine + items, "解決策テキスト", "https://github.com/vkettools/VitDeck/issues/57"));
            AddIssue(new Issue(null, IssueLevel.Error, "これはサンプルルールの検証結果(エラー)です。長い文------------------------------------------------------------章", "解決策テキスト", "https://github.com/vkettools/VitDeck/issues/57"));

            AddResultLog("Ruleのissueに紐付かないログです。customSetting：" + customSetting);
        }
    }
}