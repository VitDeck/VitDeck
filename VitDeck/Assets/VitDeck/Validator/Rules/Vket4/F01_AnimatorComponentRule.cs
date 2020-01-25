using UnityEngine;
using VRCSDK2;

namespace VitDeck.Validator
{
    public class F01_AnimatorComponentRule : ComponentBaseRule<Animator>
    {
        public F01_AnimatorComponentRule(string name) : base(name)
        {
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
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
            CheckComponent<VRC_Pickup>(hasComponentObject);
            CheckComponent<VRC_ObjectSync>(hasComponentObject);
        }

        private void CheckComponent<TComponent>(GameObject targetObject)
        {
            var parentComponent = targetObject.GetComponent<TComponent>();
            if (parentComponent != null)
            {
                AddIssue(new Issue(
                    targetObject,
                    IssueLevel.Error,
                    string.Format("Animatorと{0}を併用することは出来ません。", typeof(TComponent)),
                    "親子関係を付けるなどして同じGameObject上に存在する事を避けて下さい。"
                    ));
            }
        }
    }
}