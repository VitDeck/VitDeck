using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class D04_AssetTypeLimitRule : BaseRule
    {
        private readonly System.Type type;
        private readonly int limit;
        private readonly HashSet<string> excludedAssetGUIDs;

        public D04_AssetTypeLimitRule(string name, System.Type type, int limit, string[] excludedAssetGUIDs) : base(name)
        {
            this.type = type;
            this.limit = limit;
            this.excludedAssetGUIDs = new HashSet<string>(excludedAssetGUIDs);
        }

        protected override void Logic(ValidationTarget target)
        {
            var assets = target.GetAllAssets();

            List<Object> foundAssets = new List<Object>();

            foreach (var asset in assets)
            {
                if (asset.GetType() == type &&
                    !excludedAssetGUIDs.Contains(GetGUID(asset)))
                {
                    foundAssets.Add(asset);
                }
            }

            if (foundAssets.Count > limit)
            {
                var message = LocalizedMessage.Get("D04_AssetTypeLimitRule.Overuse", type.Name, limit, foundAssets.Count);
                var solution = LocalizedMessage.Get("D04_AssetTypeLimitRule.Overuse.Solution", type.Name);

                AddIssue(new Issue(
                    null,
                    IssueLevel.Error,
                    message,
                    solution));
            }
        }

        private static string GetGUID(Object asset)
        {
            return AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(asset));
        }
    }
}