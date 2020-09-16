#if VRC_SDK_VRCSDK3
using UnityEngine;
using VRC.Udon;

namespace VitDeck.Validator
{
    internal class UdonBehaviourRule : ComponentBaseRule<UdonBehaviour>
    {
        public UdonBehaviourRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(UdonBehaviour component)
        {
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
            Debug.Log("UdonBehaviour Validation Test");
            if (false)
            {
                AddIssue(new Issue(
                    hasComponentObject,
                    IssueLevel.Error,
                    "Nyaaaaa"));
            }
        }
    }
}
#endif
