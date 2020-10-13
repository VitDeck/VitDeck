using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class F02_PrefabLimitRule : BaseRule
    {
        private readonly HashSet<string> prefabGUIDs;
        private readonly int limit;

        public F02_PrefabLimitRule(string name, string[] prefabGUIDs, int limit) : base(name)
        {
            this.prefabGUIDs = new HashSet<string>(prefabGUIDs);
            this.limit = limit;
        }

        protected override void Logic(ValidationTarget target)
        {
            var objects = target
                .GetAllObjects()
                .Where(obj => PrefabUtility.GetPrefabType(obj) == PrefabType.PrefabInstance)
                .Select(obj => PrefabUtility.FindPrefabRoot(obj))
                .Distinct()
                .Where(IsTargetPrefabInstance)
                .ToArray();

            if (objects.Length > limit)
            {
                var message = LocalizedMessage.Get("F02_PrefabLimitRule.Overuse", limit, objects.Length);
                var solution = LocalizedMessage.Get("F02_PrefabLimitRule.Overuse.Solution");
                var solutionURL = LocalizedMessage.Get("F02_PrefabLimitRule.Overuse.SolutionURL");

                AddIssue(new Issue(
                    null,
                    IssueLevel.Error,
                    message,
                    solution,
                    solutionURL
                ));
            }
        }

        private bool IsTargetPrefabInstance(GameObject obj)
        {
            var asset = PrefabUtility.GetPrefabParent(obj);
            var path = AssetDatabase.GetAssetPath(asset);
            var guid = AssetDatabase.AssetPathToGUID(path);

            return prefabGUIDs.Contains(guid);
        }
    }
}
