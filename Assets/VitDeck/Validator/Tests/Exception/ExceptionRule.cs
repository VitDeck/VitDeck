using System;
using UnityEditor;

namespace VitDeck.Validator
{
    /// <summary>
    /// サンプルルール
    /// </summary>
    public class ExceptionRule : BaseRule
    {
        public ExceptionRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            //必ずException
            throw new FatalValidationErrorException("テスト用の例外");
        }
    }
}