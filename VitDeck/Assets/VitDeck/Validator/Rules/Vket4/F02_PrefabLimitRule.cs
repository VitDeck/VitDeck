using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace VitDeck.Validator
{
    public class F02_PrefabLimitRule : BaseRule
    {
        private readonly HashSet<string> prefabGUIDs;
        private readonly int limit;
        private readonly bool negotiable;

        public F02_PrefabLimitRule(string name, string[] prefabGUIDs, int limit, bool negotiable = false) : base(name)
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
                var message = string.Format("上限を超えています。{0}/{1}", objects.Length, limit);
                var solution = negotiable ?
                    "申請することで上限突破が可能です。" : "";

                foreach (var obj in objects)
                {
                    AddIssue(new Issue(
                        obj,
                        IssueLevel.Error,
                        message,
                        solution
                        ));
                }
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