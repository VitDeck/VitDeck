namespace VitDeck.Validator
{
    /// <summary>
    /// 問題を自動修正するためのデリゲート
    /// </summary>
    public delegate ResolverResult ResolverDelegate();

    /// <summary>
    /// 問題の自動修正処理の結果のカテゴリ
    /// </summary>
    public enum ResolverResultType
    {
        Resolved,
        Failed,
        Cancelled,
    }

    /// <summary>
    /// 問題の自動修正を行った結果を表すオブジェクト
    /// </summary>
    public class ResolverResult
    {
        public string Message { get; }
        public ResolverResultType Type { get; }

        public ResolverResult(string message, ResolverResultType type)
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// 修正処理を行った結果、問題が解決した場合に使用する。
        /// 外的要因により修正処理を行わずに問題が解決した場合にも使用する。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResolverResult Resolved(string message)
        {
            return new ResolverResult(message, ResolverResultType.Resolved);
        }

        /// <summary>
        /// 修正処理を行おうとしたが、処理の競合などにより失敗した場合に使用する。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResolverResult Failed(string message)
        {
            return new ResolverResult(message, ResolverResultType.Failed);
        }

        /// <summary>
        /// 修正処理を行おうとしたが、ユーザーの介入によりキャンセルされた場合に使用する。
        /// この場合、問題は解決済みにならず、再度修正処理を行うことができる。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResolverResult Cancelled(string message)
        {
            return new ResolverResult(message, ResolverResultType.Cancelled);
        }
    }
}