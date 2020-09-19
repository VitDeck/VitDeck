using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class F01_AnimatorComponentRule : ComponentBaseRule<Animator>
    {
        private readonly Type[] mustUseSeparatelyComponents;
        private readonly IObjectDetector ignoredPrefabDetector;

        public F01_AnimatorComponentRule(string name, Type[] mustUseSeparatelyComponents, IObjectDetector ignoredPrefabDetector = null) : base(name)
        {
            this.mustUseSeparatelyComponents = mustUseSeparatelyComponents;
            this.ignoredPrefabDetector = ignoredPrefabDetector ?? new DefaultObjectDetector();
        }

        protected override void ComponentLogic(Animator component)
        {
            var isPartOfOfficialAsset = ignoredPrefabDetector.IsTargetObject(component);
            var serializedObject = new SerializedObject(component);

            var applyRootMotion = serializedObject.FindProperty("m_ApplyRootMotion");
            if (IsValueToPointOut(
                applyRootMotion.boolValue,
                applyRootMotion.prefabOverride, 
                isPartOfOfficialAsset))
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    LocalizedMessage.Get("F01_AnimatorComponentRule.ShouldNotUseApplyRootMotion"),
                    LocalizedMessage.Get("F01_AnimatorComponentRule.ShouldNotUseApplyRootMotion.Solution")
                    ));
            }

            var cullingMode = serializedObject.FindProperty("m_CullingMode");
            if (IsValueToPointOut(
                cullingMode.enumValueIndex == (int)AnimatorCullingMode.AlwaysAnimate,
                cullingMode.prefabOverride, 
                isPartOfOfficialAsset))
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Warning,
                    LocalizedMessage.Get("F01_AnimatorComponentRule.ShouldNotUseAlwaysAnimate")
                    ));
            }
        }

        private bool IsValueToPointOut(bool value, bool prefabOverrided, bool isPartOfOfficialAsset)
        {
            if (isPartOfOfficialAsset && !prefabOverrided)
            {
                return false;
            }
            return value;
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
            foreach (var type in mustUseSeparatelyComponents)
            {
                CheckComponent(type, hasComponentObject);

            }
        }

        private void CheckComponent(Type mustSeparatedType, GameObject targetObject)
        {
            var parentComponent = targetObject.GetComponent(mustSeparatedType);
            if (parentComponent != null)
            {
                AddIssue(new Issue(
                    targetObject,
                    IssueLevel.Error,
                    LocalizedMessage.Get("F01_AnimatorComponentRule.MustUseComponentsSeparately", mustSeparatedType),
                    LocalizedMessage.Get("F01_AnimatorComponentRule.MustUseComponentsSeparately.Solution")
                    ));
            }
        }
    }
}