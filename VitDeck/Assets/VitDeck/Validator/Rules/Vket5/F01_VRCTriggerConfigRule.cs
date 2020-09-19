using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;
using VRCSDK2;

namespace VitDeck.Validator
{
    /// <summary>
    /// VRC_Triggerコンポーネントの設定を検証するルール
    /// </summary>
    public class VRCTriggerConfigRule : BaseRule
    {
        private readonly VRC_EventHandler.VrcBroadcastType[] broadcastTypesWhitelist;
        private readonly VRC_Trigger.TriggerType[] triggerWhitelist;
        private readonly VRC_EventHandler.VrcEventType[] actionWhitelist;
        private readonly HashSet<string> excludedAssetGUIDs;
        private readonly ICustomPropertyIgnorer propertyIgnorer;

        public VRCTriggerConfigRule(string name, 
            VRC_EventHandler.VrcBroadcastType[] broadcastTypesWhitelist,
            VRC_Trigger.TriggerType[] triggerWhitelist,
            VRC_EventHandler.VrcEventType[] actionWhitelist,
            string[] excludedAssetGUIDs,
            ICustomPropertyIgnorer propertyIgnorer = null
        ) : base(name)
        {
            this.broadcastTypesWhitelist = broadcastTypesWhitelist;
            this.triggerWhitelist = triggerWhitelist;
            this.actionWhitelist = actionWhitelist;
            this.excludedAssetGUIDs = new HashSet<string>(excludedAssetGUIDs);
            this.propertyIgnorer = propertyIgnorer ?? new DummyPropertyIgnorer();
        }

        protected override void Logic(ValidationTarget target)
        {
            var objs = target.GetAllObjects();

            foreach (var obj in objs)
            {
                LogicForObject(obj);
            }
        }

        private void LogicForObject(GameObject obj)
        {
            var triggers = obj.GetComponents<VRC_Trigger>();

            foreach (var trigger in triggers)
            {
                LogicForTrigger(trigger, obj);
            }
        }

        private void LogicForTrigger(VRC_Trigger trigger, GameObject obj)
        {
            if (IsExcludedAsset(trigger))
            {
                return;
            }

            var triggerEvents = trigger.Triggers;

            foreach (var triggerEvent in triggerEvents)
            {
                if (!broadcastTypesWhitelist.Contains(triggerEvent.BroadcastType) &&
                    !propertyIgnorer.IsIgnored(typeof(VRC_Trigger), "BroadcastType"))
                {
                    AddIssue(new Issue(
                        obj, 
                        IssueLevel.Error, 
                        LocalizedMessage.Get("VRCTriggerConfigRule.UnauthorizedBroadcastType", triggerEvent.BroadcastType),
                        LocalizedMessage.Get("VRCTriggerConfigRule.UnauthorizedBroadcastType.Solution")));
                }

                if (!triggerWhitelist.Contains(triggerEvent.TriggerType) &&
                    !propertyIgnorer.IsIgnored(typeof(VRC_Trigger), "TriggerType"))
                {
                    AddIssue(new Issue(
                        obj,
                        IssueLevel.Error,
                        LocalizedMessage.Get("VRCTriggerConfigRule.UnauthorizedTriggerType", triggerEvent.TriggerType),
                        LocalizedMessage.Get("VRCTriggerConfigRule.UnauthorizedTriggerType.Solution")));
                }

                var actions = triggerEvent.Events;
                foreach (var action in actions)
                {
                    if (!actionWhitelist.Contains(action.EventType) &&
                        !propertyIgnorer.IsIgnored(typeof(VRC_Trigger), "EventType"))
                    {
                        AddIssue(new Issue(
                            obj,
                            IssueLevel.Error,
                            LocalizedMessage.Get("VRCTriggerConfigRule.UnauthorizedActionType", action.EventType),
                            LocalizedMessage.Get("VRCTriggerConfigRule.UnauthorizedActionType.Solution")));
                    }
                }
            }
        }

        private bool IsExcludedAsset(UnityEngine.Object obj)
        {
            var prefabAsset = PrefabUtility.GetPrefabParent(obj);

            if (prefabAsset == null)
            {
                return false;
            }

            var path = AssetDatabase.GetAssetPath(prefabAsset);
            var guid = AssetDatabase.AssetPathToGUID(path);

            return excludedAssetGUIDs.Contains(guid);
        }
    }
}