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
        /// <param name="level">指定したレベル以上のログを出力する。</param>
        /// <returns>ログテキスト</returns>
        public string GetResultLog(bool issueLogs = true, IssueLevel level = IssueLevel.Info)
        {
            if (!issueLogs && string.IsNullOrEmpty(resultLog))
                return "";
            var log = string.Format("# {0}", RuleName) + Environment.NewLine;
            log += resultLog;
            if (issueLogs && Issues.Count > 0)
            {
                foreach (var issue in Issues)
                {
                    if (issue.level < level)
                        continue;
                    var levelMark = GetLevelMark(issue);
                    var issueLog = levelMark + issue.message + Environment.NewLine;
                    if (issue.target != null)
                        issueLog += string.Format("({0})", issue.target.name) + Environment.NewLine;
                    if (!string.IsNullOrEmpty(issue.solution))
                        issueLog += issue.solution + Environment.NewLine;
                    if (!string.IsNullOrEmpty(issue.solutionURL))
                        issueLog += issue.solutionURL + Environment.NewLine;
                    log += issueLog + Environment.NewLine;
                }
            }
            return log;
        }

        private string GetLevelMark(Issue issue)
        {
            switch (issue.level)
            {
                case IssueLevel.Info: return "## [info]";
                case IssueLevel.Warning: return "## [!]";
                case IssueLevel.Error: return "## [!!]";
                case IssueLevel.Fatal: return "## [!!!]";
                default: return "";
            }
        }
    }
}