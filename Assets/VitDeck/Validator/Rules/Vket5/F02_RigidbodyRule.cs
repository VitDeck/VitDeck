using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    internal class F02_RigidbodyRule : ComponentBaseRule<Rigidbody>
    {
        public F02_RigidbodyRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(Rigidbody component)
        {
            if (!component.isKinematic)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    LocalizedMessage.Get("F02_RigidbodyRule.UseIsKinematic")));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}