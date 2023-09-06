using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class PrefabLimitRule : BaseRule
    {
        private readonly HashSet<string> prefabGUIDs;
        private readonly int limit;

        public PrefabLimitRule(string name, string[] prefabGUIDs, int limit) : base(name)
        {
            this.prefabGUIDs = new HashSet<string>(prefabGUIDs);
            this.limit = limit;
        }

        protected override void Logic(ValidationTarget target)
        {
            var objects = target
                .GetAllObjects()
                .Where(obj => PrefabUtility.GetPrefabInstanceStatus(obj) == PrefabInstanceStatus.Connected)
                .Select(PrefabUtility.GetOutermostPrefabInstanceRoot)
                .Distinct()
                .Where(IsTargetPrefabInstance)
                .ToArray();

            if (objects.Length > limit)
            {
                var message = LocalizedMessage.Get("PrefabLimitRule.Overuse", limit, objects.Length);
                var solution = LocalizedMessage.Get("PrefabLimitRule.Overuse.Solution");
                var solutionURL = LocalizedMessage.Get("PrefabLimitRule.Overuse.SolutionURL");

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
            var asset = PrefabUtility.GetCorrespondingObjectFromSource(obj);
            var path = AssetDatabase.GetAssetPath(asset);
            var guid = AssetDatabase.AssetPathToGUID(path);

            return prefabGUIDs.Contains(guid);
        }
    }
}
