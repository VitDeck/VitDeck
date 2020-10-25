using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;
#if VRC_SDK_VRCSDK3
using VRC.SDKBase;
#elif VRC_SDK_VRCSDK2
using VRCSDK2;
#endif

namespace VitDeck.Validator
{
#if VRC_SDK_VRCSDK2 || VRC_SDK_VRCSDK3 
    /// <summary>
    /// VRC_Triggerコンポーネントの設定を検証するルール
    /// </summary>
    public class VRCTriggerConfigRule : BaseRule
    {
        private readonly VRC_EventHandler.VrcBroadcastType[] broadcastTypesWhitelist;
        private readonly VRC_Trigger.TriggerType[] triggerWhitelist;
        private readonly VRC_EventHandler.VrcEventType[] actionWhitelist;
        private readonly HashSet<string> excludedAssetGUIDs;

        public VRCTriggerConfigRule(string name, 
            VRC_EventHandler.VrcBroadcastType[] broadcastTypesWhitelist,
            VRC_Trigger.TriggerType[] triggerWhitelist,
            VRC_EventHandler.VrcEventType[] actionWhitelist,
            string[] excludedAssetGUIDs
        ) : base(name)
        {
            this.broadcastTypesWhitelist = broadcastTypesWhitelist;
            this.triggerWhitelist = triggerWhitelist;
            this.actionWhitelist = actionWhitelist;
            this.excludedAssetGUIDs = new HashSet<string>(excludedAssetGUIDs);
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
                if (!broadcastTypesWhitelist.Contains(triggerEvent.BroadcastType))
                {
                    AddIssue(new Issue(
                        obj, 
                        IssueLevel.Error, 
                        LocalizedMessage.Get("VRCTriggerConfigRule.UnauthorizedBroadcastType", triggerEvent.BroadcastType),
                        LocalizedMessage.Get("VRCTriggerConfigRule.UnauthorizedBroadcastType.Solution")));
                }

                if (!triggerWhitelist.Contains(triggerEvent.TriggerType))
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
                    if (!actionWhitelist.Contains(action.EventType))
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
            if (PrefabUtility.IsPartOfPrefabInstance(obj))
            {
                var prefabObj = PrefabUtility.GetCorrespondingObjectFromOriginalSource(obj);
                var path = AssetDatabase.GetAssetPath(prefabObj);
                var guid = AssetDatabase.AssetPathToGUID(path);
                var contains = excludedAssetGUIDs.Contains(guid);
                Debug.Log($"[IsExcludedAsset]{obj} -> {path} , {guid} , {contains}", obj);

                return contains;
            }
            else
            {
                return false;
            }
        }
    }
#endif
}