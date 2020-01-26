using UnityEngine;
using VitDeck.Language;

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
                    LocalizedMessage.Get("F01_AnimationComponentRule.ShouldNotUseAlwaysAnimate")
                    ));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}