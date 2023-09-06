#if VRC_SDK_VRCSDK3
using VitDeck.Language;
using VRC.Udon;

namespace VitDeck.Validator
{
    /// <summary>
    /// UdonBehaviourのAllowOwnershipTransferOnCollisionは必ずFalseにすること
    /// </summary>
    internal class UdonBehaviourAllowOwnershipTransferOnCollisionIsFalseRule : BaseUdonBehaviourRule
    {
        public UdonBehaviourAllowOwnershipTransferOnCollisionIsFalseRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(UdonBehaviour component)
        {
            if (component.AllowCollisionOwnershipTransfer)
            {
                AddIssue(new Issue(
                        component, 
                        IssueLevel.Error, 
                        LocalizedMessage.Get("UdonBehaviourAllowOwnershipTransferOnCollisionIsFalseRule.isTrue"),
                        LocalizedMessage.Get("UdonBehaviourAllowOwnershipTransferOnCollisionIsFalseRule.isTrue.solution")
                    )
                );
            }
        }
    }
}
#endif
