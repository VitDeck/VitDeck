namespace VitDeck.Validator
{
    /// <summary>
    /// Vket4の基本ルールセット。
    /// </summary>
    /// <remarks>
    /// 変数をabstractまたはvirtualプロパティで宣言し、継承先で上書きすることでワールドによる制限の違いを表現する。
    /// </remarks>
    public abstract class Vket4RuleSetBase : IRuleSet
    {
        public abstract string RuleSetName
        {
            get;
        }

        public IValidationTargetFinder TargetFinder { get { return new Vket4TargetFinder(); } }

        public IRule[] GetRules()
        {
            // デフォルトで使っていたAttribute式は宣言時にconst以外のメンバーが利用できない。
            // 継承したプロパティを参照して挙動を変えることが出来ない為、直接リストを返す方式に変更した。

            return new IRule[]
            {

                new DebugTargetEnumerationRule("Debug Enumerate"),

            };
        }
    }
}