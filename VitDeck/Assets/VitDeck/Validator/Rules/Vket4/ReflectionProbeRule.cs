using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    internal class ReflectionProbeRule : ComponentBaseRule<ReflectionProbe>
    {
        public ReflectionProbeRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(ReflectionProbe component)
        {
            if (component.mode != UnityEngine.Rendering.ReflectionProbeMode.Custom)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    LocalizedMessage.Get("ReflectionProbeRule.MustUseCustomTexture", component.mode)));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}