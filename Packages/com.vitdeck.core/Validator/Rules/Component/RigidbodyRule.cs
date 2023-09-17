using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    internal class RigidbodyRule : ComponentBaseRule<Rigidbody>
    {
        public RigidbodyRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(Rigidbody component)
        {
            if (!component.isKinematic)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    LocalizedMessage.Get("RigidbodyRule.UseIsKinematic")));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}
