using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// マテリアル数が1以上であることを確認する。
    /// </summary>
    internal class RendererRule : ComponentBaseRule<Renderer>
    {
        public RendererRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(Renderer component)
        {

            if (component.sharedMaterials.Length == 0)
            {
                AddIssue(new Issue(
                       component,
                       IssueLevel.Error,
                       LocalizedMessage.Get("RendererRule.MustAttachMaterial")));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}
