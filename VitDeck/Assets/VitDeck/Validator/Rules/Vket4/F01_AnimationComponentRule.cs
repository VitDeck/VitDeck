using UnityEngine;

namespace VitDeck.Validator
{
    public class F01_AnimationComponentRule : ComponentBaseRule<Animation>
    {
        public F01_AnimationComponentRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(Animation component)
        {
            if (component.cullingType == AnimationCullingType.AlwaysAnimate)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Warning,
                    "不具合が出る場合を除き、CullingTypeはAlwaysを避けて下さい。"
                    ));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}