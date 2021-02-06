using UnityEditor;
using VitDeck.Main;
using VitDeck.Utilities;

namespace VitDeck.Validator
{
    /// <summary>
    /// VitDeckのバージョンが最新でなければエラーを出します。
    /// </summary>
    public class VitDeckVersionRule : BaseRule
    {
        private readonly string solution;
        private readonly string solutionURL;

        /// <param name="name">ルール名。</param>
        /// <param name="permissionPattern">「^Assets/」で始まるベースフォルダの正規表現。</param>
        /// <param name="solution"><see cref="Issue.solution"/></param>
        /// <param name="solutionURL"><see cref="Issue.solutionURL"/></param>
        public VitDeckVersionRule(
            string name,
            string solution = "",
            string solutionURL = ""
        ) : base(name)
        {
            this.solution = solution;
            this.solutionURL = solutionURL;
        }

        protected override void Logic(ValidationTarget target)
        {
            if (!UpdateCheck.Enabled)
            {
                this.AddIssue(new Issue(
                    target: null,
                    IssueLevel.Warning,
                    "VitDeckのバージョンチェックが無効になっています。",
                    this.solution,
                    this.solutionURL
                ));
                return;
            }

            var latestVersion = UpdateCheck.GetLatestVersion();
            if (latestVersion == null)
            {
                this.AddIssue(new Issue(
                    target: null,
                    IssueLevel.Warning,
                    "VitDeckの最新バージョン番号の取得に失敗しました。",
                    this.solution,
                    this.solutionURL
                ));
                return;
            }

            var currentVersion = ProductInfoUtility.GetVersion();
            if (currentVersion != latestVersion)
            {
                this.AddIssue(new Issue(
                    target: null,
                    IssueLevel.Error,
                    $"VitDeckが最新バージョンではありません。\n現在のバージョン: {currentVersion}\n最新バージョン: {latestVersion}",
                    this.solution,
                    this.solutionURL
                ));
            }
        }
    }
}
