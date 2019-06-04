namespace VitDeck.Validator
{
    /// <summary>
    /// 検証ルールの基本となる抽象クラス
    /// </summary>
    public abstract class BaseRule : IRule
    {
        /// <summary>
        /// ルール名
        /// </summary>
        internal string name;
        /// <summary>
        /// 検証結果
        /// </summary>
        internal ValidationResult result;

        public BaseRule(string name)
        {
            this.name = name;
            result = new ValidationResult(name);
        }
        /// <summary>
        /// 検証結果を返す
        /// </summary>
        /// <returns>検証結果</returns>
        public ValidationResult GetResult()
        {
            return result;
        }
        /// <summary>
        /// 定められたルールに従って検証する。検証後にresultフィールドを結果として返す
        /// </summary>
        /// <returns>`result`に格納された検証結果</returns>
        public abstract ValidationResult Validate();
    }
}