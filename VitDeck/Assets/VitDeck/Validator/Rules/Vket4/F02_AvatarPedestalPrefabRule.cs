using System;
using UnityEngine;
using VRCSDK2;

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
                            "VRC_Triggerが持つBroadcastTypeはlocalでなければなりません。"
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
                        "VRC_TriggerのTriggerTypeは、[Custom, OnInteract, OnEnterTrigger, OnExitTrigger, OnPickup, OnDrop, OnPickupUseDown, OnPickupUseUp]のいずれかである必要があります。" +
                        String.Format("{0}は使えません。", triggerType)
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
                            "VRC_TriggerのSendRPCはSetAvataUse以外使用できません。"
                            ));
                    }
                    break;
                default:
                    AddIssue(new Issue(
                        context,
                        IssueLevel.Error,
                        "VRC_TriggerのActionは、[AnimationFloat, AnimationBool, AnimationTrigger, ActivateCustomTrigger, AudioTrigger, PlayAnimation, SetComponentActive, SetGameObjectActive, SendRPC(SetAvatarUse)]のいずれかである必要があります。" +
                        String.Format("{0}は使えません。", action.EventType)
                        ));
                    break;
            }
        }
    }
}