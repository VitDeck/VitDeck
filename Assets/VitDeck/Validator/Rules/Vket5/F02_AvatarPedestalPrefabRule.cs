using System;
using UnityEngine;
using VitDeck.Language;

#if VRC_SDK_VRCSDK3
using VRC.SDKBase;
#elif VRC_SDK_VRCSDK2
using VRCSDK2;
#endif

namespace VitDeck.Validator
{
    public class F02_AvatarPedestalPrefabRule : BasePrefabRule
    {

        public F02_AvatarPedestalPrefabRule(string name, string[] targetPrefabGUIDs) : base(name, targetPrefabGUIDs)
        {
        }

        protected override void LogicForPrefabInstanceRoot(GameObject gameObject)
        {
            var triggerComponents = GetComponentsInChildrenSamePrefabInstance<VRC_Trigger>(gameObject, true);


            foreach (var triggerCompoent in triggerComponents)
            {
                foreach (var trigger in triggerCompoent.Triggers)
                {
                    if (trigger.BroadcastType != VRC_EventHandler.VrcBroadcastType.Local)
                    {
                        AddIssue(new Issue(
                            triggerCompoent,
                            IssueLevel.Error,
                            LocalizedMessage.Get("F02_AvatarPedestalPrefabRule.BroadcastTypeMustLocal")
                            ));
                    }

                    ValidateTriggerType(triggerCompoent, trigger.TriggerType);

                    foreach (var evt in trigger.Events)
                    {
                        ValidateAction(triggerCompoent, evt);
                    }
                }
            }
        }

        private void ValidateTriggerType(UnityEngine.Object context, VRC_Trigger.TriggerType triggerType)
        {
            switch (triggerType)
            {
                case VRC_Trigger.TriggerType.Custom:
                case VRC_Trigger.TriggerType.OnInteract:
                case VRC_Trigger.TriggerType.OnEnterTrigger:
                case VRC_Trigger.TriggerType.OnExitTrigger:
                case VRC_Trigger.TriggerType.OnPickup:
                case VRC_Trigger.TriggerType.OnDrop:
                case VRC_Trigger.TriggerType.OnPickupUseDown:
                case VRC_Trigger.TriggerType.OnPickupUseUp:
                    break;
                default:
                    AddIssue(new Issue(
                        context,
                        IssueLevel.Error,
                        LocalizedMessage.Get("F02_AvatarPedestalPrefabRule.UnauthorizedTriggerType", triggerType)
                        ));
                    break;
            }
        }

        private void ValidateAction(UnityEngine.Object context, VRC_EventHandler.VrcEvent action)
        {
            switch (action.EventType)
            {
                case VRC_EventHandler.VrcEventType.AnimationFloat:
                case VRC_EventHandler.VrcEventType.AnimationBool:
                case VRC_EventHandler.VrcEventType.AnimationTrigger:
                case VRC_EventHandler.VrcEventType.AnimationInt:
                case VRC_EventHandler.VrcEventType.AnimationIntAdd:
                case VRC_EventHandler.VrcEventType.AnimationIntDivide:
                case VRC_EventHandler.VrcEventType.AnimationIntMultiply:
                case VRC_EventHandler.VrcEventType.AnimationIntSubtract:
                case VRC_EventHandler.VrcEventType.ActivateCustomTrigger:
                case VRC_EventHandler.VrcEventType.AudioTrigger:
                case VRC_EventHandler.VrcEventType.PlayAnimation:
                case VRC_EventHandler.VrcEventType.SetComponentActive:
                case VRC_EventHandler.VrcEventType.SetGameObjectActive:
                    break;
                case VRC_EventHandler.VrcEventType.SendRPC:
                    if (action.ParameterString != "SetAvatarUse")
                    {
                        AddIssue(new Issue(
                            context,
                            IssueLevel.Error,
                            LocalizedMessage.Get("F02_AvatarPedestalPrefabRule.RPCMustSetAvatarUse")
                            ));
                    }
                    break;
                default:
                    AddIssue(new Issue(
                        context,
                        IssueLevel.Error,
                        LocalizedMessage.Get("F02_AvatarPedestalPrefabRule.UnauthorizedActionType", action.EventType)
                        ));
                    break;
            }
        }
    }
}