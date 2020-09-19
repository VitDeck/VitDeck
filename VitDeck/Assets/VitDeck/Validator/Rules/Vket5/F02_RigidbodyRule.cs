using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    internal class F02_RigidbodyRule : ComponentBaseRule<Rigidbody>
    {
        private readonly ICustomPropertyIgnorer propertyIgnorer;

        public F02_RigidbodyRule(string name, ICustomPropertyIgnorer propertyIgnorer = null) : base(name)
        {
            this.propertyIgnorer = propertyIgnorer ?? new DummyPropertyIgnorer();
        }

        protected override void ComponentLogic(Rigidbody component)
        {
            if (!component.isKinematic &&
                !propertyIgnorer.IsIgnored(typeof(Rigidbody), "m_IsKinematic"))
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