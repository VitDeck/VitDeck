using System;
using UnityEngine;

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
                    "Apply Root Motionは使用できません。",
                    "Humanoidの場合は代わりにAnimationClipのBake Into Poseを使用してください。"
                    ));
            }
            if (component.cullingMode == AnimatorCullingMode.AlwaysAnimate)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Warning,
                    "不具合が出る場合を除き、CullingModeはAlwaysを避けて下さい。"
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
                    string.Format("Animatorと{0}を併用することは出来ません。", mustSeparatedType),
                    "親子関係を付けるなどして同じGameObject上に存在する事を避けて下さい。"
                    ));
            }
        }
    }
}