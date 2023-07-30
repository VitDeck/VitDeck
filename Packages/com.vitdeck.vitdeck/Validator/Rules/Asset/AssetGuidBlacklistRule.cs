using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// 特定のGUIDを持つアセットを検出する
    /// </summary>
    public class AssetGuidBlacklistRule : BaseRule
    {
        private readonly HashSet<string> unauthorizedIDSet;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="guids">検出したいアセットのGUIDの配列</param>
        public AssetGuidBlacklistRule(string name, string[] guids) : base(name)
        {
            unauthorizedIDSet = new HashSet<string>(guids);
        }

        protected override void Logic(ValidationTarget target)
        {
            var hitObjectPaths = target.GetAllAssetGuids()
                .Where(targetGuid => IsUnauthorized(targetGuid, target.GetBaseFolderPath()))
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid));
            foreach (var path in hitObjectPaths)
            {
                var obj = AssetDatabase.LoadMainAssetAtPath(path);
                var message = LocalizedMessage.Get("AssetGuidBlacklistRule.UnauthorizedAssetDetected", path);
                var solution = LocalizedMessage.Get("AssetGuidBlacklistRule.UnauthorizedAssetDetected.Solution");
                AddIssue(new Issue(obj, IssueLevel.Error, message, solution, string.Empty));
            }
        }

        private bool IsUnauthorized(string targetGuid, string baseFolderPath)
        {
            if (unauthorizedIDSet.Contains(targetGuid))
            {
                var targetPath = AssetDatabase.GUIDToAssetPath(targetGuid);

                if (targetPath.StartsWith(baseFolderPath))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
