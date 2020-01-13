using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VitDeck.Validator
{
    public class C02_StaticFlagRule : BaseRule
    {

        private const StaticEditorFlags mustFlag = StaticEditorFlags.OccludeeStatic | StaticEditorFlags.ReflectionProbeStatic;
        private const StaticEditorFlags shouldFlag = StaticEditorFlags.BatchingStatic;

        public C02_StaticFlagRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjects = target.GetRootObjects();

            foreach(var rootObject in rootObjects)
            {
                var staticRoot = rootObject.transform.Find("Static");
                if (staticRoot == null)
                {
                    continue;
                }

                LogicForStaticRoot(staticRoot);
            }
        }

        private void LogicForStaticRoot(Transform staticRoot)
        {
            var children = staticRoot.GetComponentsInChildren<Transform>(true);

            foreach(var child in children)
            {
                var gameObject = child.gameObject;
                var flag = GameObjectUtility.GetStaticEditorFlags(child.gameObject);

                if((flag & StaticEditorFlags.OccludeeStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Error,
                        "Static設定のOccludeeStaticが有効になっていません。",
                        "必ずOccludeeStaticを有効にして下さい。"));
                }

                if ((flag & StaticEditorFlags.ReflectionProbeStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Error,
                        "Static設定のReflectionProbeStaticが有効になっていません。",
                        "必ずReflectionProbeStaticを有効にして下さい。"));
                }

                if ((flag & StaticEditorFlags.BatchingStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Warning,
                        "Static設定のBatchingStaticが有効になっていません。",
                        "有効にしてブースの見た目に問題が出る場合は、そのままで問題ありません。"));
                }
            }
        }
    }
}