using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
                var message = string.Format("{0}の使用数が{1}個を超えています。({2}個)", type.Name, limit, foundAssets.Count);
                var solution = string.Format("使用個数を減らすか、公式から提供されている{0}を使用してください。", type.Name);

                foreach (var asset in foundAssets)
                {
                    AddIssue(new Issue(
                        asset,
                        IssueLevel.Error,
                        message,
                        solution));
                }
            }
        }

        private static string GetGUID(Object asset)
        {
            return AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(asset));
        }
    }
}