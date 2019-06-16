using UnityEditor;
using System.Text.RegularExpressions;

namespace VitDeck.Validator
{
    /// <summary>
    /// アセット名の使用禁止文字を検出するルール
    /// </summary>
    public class AssetNamingRule : BaseRule
    {
        private readonly string permissionPattern;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="assetName">アセット名</param>
        public AssetNamingRule(string name, string permissionPattern = "[\x21-\x7e]+") : base(name)
        {
            this.permissionPattern = permissionPattern;
        }

        protected override void Logic(ValidationTarget target)
        {
            var paths = target.GetAllAssetPaths();
            var matchPattern = string.Format("^{0}$", permissionPattern);

            foreach (var path in paths)
            {
                if (!Regex.IsMatch(path, matchPattern))
                {
                    string prohibition = GetProhibitionPattern(path, permissionPattern);
                    var reference = AssetDatabase.LoadMainAssetAtPath(path);
                    var message = string.Format("アセット名({0})に使用禁止文字({1})が含まれています。", path, prohibition);
                    AddIssue(new Issue(reference, IssueLevel.Error, message, string.Empty));
                }
            }
        }

        private string GetProhibitionPattern(string path, string permissionPattern)
        {
            string prohibition = path;
            foreach (Match match in Regex.Matches(path, permissionPattern))
            {
                prohibition = Regex.Replace(prohibition, match.Value, "");
            }
            return prohibition;
        }
    }
}