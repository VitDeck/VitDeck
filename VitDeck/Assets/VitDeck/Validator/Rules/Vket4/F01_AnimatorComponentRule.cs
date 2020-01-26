using System;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class F01_AnimatorComponentRule : ComponentBaseRule<Animator>
    {
        private readonly Type[] mustUseSeparatelyComponents;

        public F01_AnimatorComponentRule(string name, Type[] mustUseSeparatelyComponents) : base(name)
        {
            this.mustUseSeparatelyComponents = mustUseSeparatelyComponents;
        }

        protected override void ComponentLogic(Animator component)
        {
            if (component.applyRootMotion)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    LocalizedMessage.Get("F01_AnimatorComponentRule.ShouldNotUseApplyRootMotion"),
                    LocalizedMessage.Get("F01_AnimatorComponentRule.ShouldNotUseApplyRootMotion.Solution")
                    ));
            }
            if (component.cullingMode == AnimatorCullingMode.AlwaysAnimate)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Warning,
                    LocalizedMessage.Get("F01_AnimatorComponentRule.ShouldNotUseAlwaysAnimate")
                    ));
            }
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