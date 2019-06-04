using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    /// 検出した個別の問題
    /// </summary>
    public class Issue
    {
        public Issue(Object target, IssueLevel level, string message, string solution = "", string solutionURL = "")
        {
            this.target = target;
            this.level = level;
            this.message = message;
            this.solution = solution;
            this.solutionURL = solutionURL;
        }
        /// <summary>
        /// 対象のオブジェクト
        /// </summary>
        public readonly Object target;
        /// <summary>
        /// 問題の重要度
        /// </summary>
        public readonly IssueLevel level;
        /// <summary>
        /// 問題に対するメッセージ
        /// </summary>
        public readonly string message;
        /// <summary>
        /// 解決策のメッセージ
        /// </summary>
        public readonly string solution;
        /// <summary>
        /// 解決策が記載されたWebページのURL
        /// </summary>
        public readonly string solutionURL;
    }
    /// <summary>
    /// 検出した問題の重要度
    /// </summary>
    public enum IssueLevel
    {
        Fatal = 3,
        Error = 2,
        Warning = 1,
        Info = 0
    }
}