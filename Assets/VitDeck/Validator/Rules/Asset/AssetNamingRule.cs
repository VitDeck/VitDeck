using UnityEditor;
using System.Text.RegularExpressions;
using System.IO;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// アセット名の使用禁止文字を検出するルール
    /// </summary>
    /// <remarks>
    /// フォルダ名またはアセット名(拡張子含む)をチェックする。
    /// </remarks>
    public class AssetNamingRule : BaseRule
    {
        private readonly string permissionPattern;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="permissionPattern">使用許可文字列の正規表現</param>
        public AssetNamingRule(string name, string permissionPattern = "[\x21-\x7e ]+") : base(name)
        {
            this.permissionPattern = permissionPattern;
        }

        protected override void Logic(ValidationTarget target)
        {
            var paths = target.GetAllAssetPaths();
            var matchPattern = string.Format("^{0}$", permissionPattern);
            var rootFolderPath = target.GetBaseFolderPath();

            foreach (var path in paths)
            {
                if (!path.StartsWith(rootFolderPath))
                {
                    continue;
                }
                var assetName = Path.GetFileName(path);
                if (!Regex.IsMatch(assetName, matchPattern))
                {
                    string prohibition = GetProhibitionPattern(assetName, permissionPattern);
                    var reference = AssetDatabase.LoadMainAssetAtPath(path);
                    var message = LocalizedMessage.Get("AssetNamingRule.UnauthorizedTextDetected", path, prohibition);
                    AddIssue(new Issue(reference, IssueLevel.Error, message, string.Empty));
                }
            }
        }

        private string GetProhibitionPattern(string assetName, string permissionPattern)
        {
            string prohibition = "";
            foreach (char c in assetName)
            {
                if (Regex.IsMatch(c.ToString(), permissionPattern))
                    continue;
                else
                    prohibition += c;
            }
            return prohibition;
        }
    }
}