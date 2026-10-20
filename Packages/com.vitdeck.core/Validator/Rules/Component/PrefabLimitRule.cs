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
                // 入れ子のPrefabがカウントをすり抜けないよう、最も外側ではなく全てのPrefabインスタンスのルートを対象にする
                .Where(PrefabUtility.IsAnyPrefabInstanceRoot)
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
            // 入れ子の内側のルートはGetCorrespondingObjectFromSourceだと外側のPrefab内のオブジェクトを返すため、
            // そのルート自身の元Prefabのパスを取得する
            var path = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(obj);
            var guid = AssetDatabase.AssetPathToGUID(path);

            return prefabGUIDs.Contains(guid);
        }
    }
}
