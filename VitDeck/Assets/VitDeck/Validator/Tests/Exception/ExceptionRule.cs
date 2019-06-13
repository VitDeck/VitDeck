using System;
using UnityEditor;

namespace VitDeck.Validator
{
    /// <summary>
    /// サンプルルール
    /// </summary>
    public class ExceptionRule : BaseRule
    {
        private string customSetting;
        public ExceptionRule(string name, string custom = "デフォルト設定値") : base(name)
        {
            this.customSetting = custom;
        }

        protected override void Logic(ValidationTarget target)
        {
            //必ずException
            throw new FatalValidationErrorException("テスト用の例外");
        }
    }
}