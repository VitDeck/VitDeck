using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    internal class SkinnedMeshRendererRule : ComponentBaseRule<SkinnedMeshRenderer>
    {
        public SkinnedMeshRendererRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(SkinnedMeshRenderer component)
        {
            if (component.updateWhenOffscreen)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    LocalizedMessage.Get("SkinnedMeshRendererRule.MustTurnOffUpdateWhenOffscreen")));
            }

            if (component.sharedMaterials.Length == 0)
            {
                AddIssue(new Issue(
                       component,
                       IssueLevel.Error,
                       LocalizedMessage.Get("SkinnedMeshRendererRule.MustAttachMaterial")));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}