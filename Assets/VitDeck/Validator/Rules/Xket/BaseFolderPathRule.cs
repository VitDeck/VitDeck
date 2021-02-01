using UnityEditor;
using System.Text.RegularExpressions;

namespace VitDeck.Validator
{
    /// <summary>
    /// ベースフォルダのパスが規則に一致するか検証します。
    /// </summary>
    public class BaseFolderPathRule : BaseRule
    {
        private readonly Regex permissionPattern;
        private readonly string solution;
        private readonly string solutionURL;

        /// <param name="name">ルール名。</param>
        /// <param name="permissionPattern">「^Assets/」で始まるベースフォルダの正規表現。</param>
        /// <param name="solution"><see cref="Issue.solution"/></param>
        /// <param name="solutionURL"><see cref="Issue.solutionURL"/></param>
        public BaseFolderPathRule(
            string name,
            Regex permissionPattern,
            string solution = "",
            string solutionURL = ""
        ) : base(name)
        {
            this.permissionPattern = permissionPattern;
            this.solution = solution;
            this.solutionURL = solutionURL;
        }

        protected override void Logic(ValidationTarget target)
        {
            var path = target.GetBaseFolderPath();

            if (!permissionPattern.IsMatch(path))
            {
                this.AddIssue(new Issue(
                    AssetDatabase.LoadMainAssetAtPath(path),
                    IssueLevel.Error,
                    "ベースフォルダのパスが規則に一致しません。",
                    this.solution,
                    this.solutionURL
                ));
            }
        }
    }
}
