using System;
using System.Linq;
using UnityEditor;

namespace VitDeck.Validator
{
    /// <summary>
    /// 特定のGUIDを持つアセットを検出する
    /// </summary>
    public class AssetGuidBlacklistRule : BaseRule
    {
        private readonly string[] guids;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="guids">禁止アセットのGUID配列</param>
        public AssetGuidBlacklistRule(string name, string[] guids) : base(name)
        {
            this.guids = guids;
        }

        protected override void Logic(ValidationTarget target)
        {
            var hitObjectPaths = target.GetAllAssetGuids()
                .Where(targetGuid => Array.Exists(guids, guid => guid == targetGuid))
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid));
            foreach (var path in hitObjectPaths)
            {
                var obj = AssetDatabase.LoadMainAssetAtPath(path);
                var message = "該当するアセットが検出されました。" + Environment.NewLine + path;
                AddIssue(new Issue(obj, IssueLevel.Error, message, string.Empty, string.Empty));
            }
        }
    }
}
