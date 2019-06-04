using System;
using System.Collections.Generic;

namespace VitDeck.Validator
{
    /// <summary>
    /// ルールごとに作られる結果クラス
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// 検証を実行したルール名
        /// </summary>
        public readonly string RuleName;
        /// <summary>
        /// 検証の結果検出した問題のリスト
        /// </summary>
        public readonly List<Issue> Issues;
        private string resultLog;

        public ValidationResult(string ruleName)
        {
            this.RuleName = ruleName;
            this.Issues = new List<Issue>();
        }
        /// <summary>
        /// 検出した問題を追加する
        /// </summary>
        /// <param name="issue">検出した個別の問題</param>
        public void AddIssue(Issue issue)
        {
            Issues.Add(issue);
        }
        /// <summary>
        /// 検証ログを追記する。
        /// </summary>
        /// <param name="log">メッセージ</param>
        public void AddResultLog(string log)
        {
            resultLog += log + Environment.NewLine;
        }
        /// <summary>
        /// 検証ログを取得する。
        /// </summary>
        /// <returns></returns>
        public string GetResultLog()
        {
            //ToDo:resultLogとIssuesから整形したログを返す（オプションで出力する情報を変える？）
            var log = string.Format("{0}: {1}", RuleName, resultLog);
            if (Issues.Count > 0)
            {
                foreach (var issue in Issues)
                {
                    var issueLog = issue.message + Environment.NewLine +
                        issue.solution + Environment.NewLine +
                        issue.solutionURL + Environment.NewLine;
                    log += issueLog;
                }
            }
            return log;
        }
    }
}