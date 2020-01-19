using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// アセットの最大パス長を制限するルール。
    /// </summary>
    public class AssetPathLengthRule : BaseRule
    {
        private readonly int limit;
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="limit">パス長の上限</param>
        public AssetPathLengthRule(string name, int limit = 180) : base(name)
        {
            this.limit = limit;
        }

        protected override void Logic(ValidationTarget target)
        {
            var paths = target.GetAllAssetPaths();

            foreach (var path in paths)
            {
                var excess = path.Length - limit;
                if (excess > 0)
                {
                    var referenceObject = AssetDatabase.LoadMainAssetAtPath(path);
                    var message = LocalizedMessage.Get("AssetPathLengthRule.Overlength", limit, excess, path);
                    AddIssue(new Issue(referenceObject, IssueLevel.Error, message, string.Empty));
                }
            }
        }
    }
}
