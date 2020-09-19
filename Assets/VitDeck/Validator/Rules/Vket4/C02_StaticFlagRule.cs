using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VitDeck.Language;

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
                        LocalizedMessage.Get("C02_StaticFlagRule.OccludeeStaticNotSet"),
                        LocalizedMessage.Get("C02_StaticFlagRule.OccludeeStaticNotSet.Solution")));
                }

                if ((flag & StaticEditorFlags.ReflectionProbeStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("C02_StaticFlagRule.ReflectionProveStaticNotSet"),
                        LocalizedMessage.Get("C02_StaticFlagRule.ReflectionProveStaticNotSet.Solution")));
                }

                if ((flag & StaticEditorFlags.BatchingStatic) == 0)
                {
                    AddIssue(new Issue(
                        gameObject,
                        IssueLevel.Warning,
                        LocalizedMessage.Get("C02_StaticFlagRule.BatchingStaticNotSet"),
                        LocalizedMessage.Get("C02_StaticFlagRule.BatchingStaticNotSet.Solution")));
                }
                
                if ((flag & StaticEditorFlags.OccluderStatic) != 0)
                {
                    var message = LocalizedMessage.Get("C02_StaticFlagRule.OccluderStaticNotAllowed");
                    var solution = LocalizedMessage.Get("C02_StaticFlagRule.OccluderStaticNotAllowed.Solution");
                    var solutionURL = LocalizedMessage.Get("C02_StaticFlagRule.OccluderStaticNotAllowed.SolutionURL");
                    
                    AddIssue(new Issue(gameObject, IssueLevel.Error, message, solution, solutionURL));
                }
            }
        }
    }
}