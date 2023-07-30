namespace VitDeck.Validator
{
    /// <summary>
    /// 実行する検証ルールを束ねたセットを定義するためのインターフェース。
    /// </summary>
    public interface IRuleSet
    {
        /// <summary>
        /// ルールセット自身の名前。
        /// </summary>
        string RuleSetName { get; }

        /// <summary>
        /// 検証対象検索オブジェクト
        /// </summary>
        IValidationTargetFinder TargetFinder { get; }

        /// <summary>
        /// ルールセットに含まれる検証ルールの配列を返す
        /// </summary>
        /// <returns>検証ルールの配列</returns>
        IRule[] GetRules();
    }
}