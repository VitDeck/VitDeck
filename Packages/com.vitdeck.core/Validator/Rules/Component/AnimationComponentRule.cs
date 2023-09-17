using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class AnimationComponentRule : ComponentBaseRule<Animation>
    {
        private readonly IObjectDetector ignoredPrefabDetector;

        public AnimationComponentRule(string name, IObjectDetector ignoredPrefabDetector = null) : base(name)
        {
            this.ignoredPrefabDetector = ignoredPrefabDetector ?? new DefaultObjectDetector();
        }

        protected override void ComponentLogic(Animation component)
        {
            var isOfficialAssetPart = ignoredPrefabDetector.IsTargetObject(component);
            var serializedObject = new SerializedObject(component);

            var cullingType = serializedObject.FindProperty("m_CullingType");
            if (IsValueToPointOut(
                    cullingType.enumValueIndex == (int)AnimationCullingType.AlwaysAnimate,
                    cullingType.prefabOverride,
                    isOfficialAssetPart))
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Warning,
                    LocalizedMessage.Get("AnimationComponentRule.ShouldNotUseAlwaysAnimate")
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
        }
    }
}
