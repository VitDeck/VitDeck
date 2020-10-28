#if VRC_SDK_VRCSDK3
using UnityEngine;
using VitDeck.Language;
using VRC.SDK3.Components;
using VRC.Udon;
using Object = UnityEngine.Object;

namespace VitDeck.Validator
{
    public class VRCPickupUdonBehaviourRule : ComponentBaseRule<VRCPickup>
    {
        private const string AutoResetPickupUdonId = "73398b290b7c5ec43a2e158bfc1c45db";
        public VRCPickupUdonBehaviourRule(string name) : base(name)
        {
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }

        protected override void ComponentLogic(VRCPickup component)
        {
            var udonBehaviours = component.gameObject.GetComponents<UdonBehaviour>();
            if (udonBehaviours == null || udonBehaviours.Length == 0)
            {
                RaiseNoUdonAutoResetPickupError(component);
                return;
            }

            foreach (var udonBehaviour in udonBehaviours)
            {
                if (udonBehaviour.programSource?.SerializedProgramAsset.name != AutoResetPickupUdonId) continue;
                if (!udonBehaviour.SynchronizePosition)
                {
                    AddIssue(new Issue(
                        component,
                        IssueLevel.Error,
                        LocalizedMessage.Get("VRCPickupUdonBehaviourRule.SynchronizePositionFalse"),
                        LocalizedMessage.Get("VRCPickupUdonBehaviourRule.SynchronizePositionFalse.Solution")));

                }
                return;
            }
            RaiseNoUdonAutoResetPickupError(component);
        }

        private void RaiseNoUdonAutoResetPickupError(Object obj)
        {
            AddIssue(new Issue(
                obj,
                IssueLevel.Error,
                LocalizedMessage.Get("VRCPickupUdonBehaviourRule.NotImplementedAutoResetPickup"),
                LocalizedMessage.Get("VRCPickupUdonBehaviourRule.NotImplementedAutoResetPickup.Solution")));
        }
    }
}
#endif
