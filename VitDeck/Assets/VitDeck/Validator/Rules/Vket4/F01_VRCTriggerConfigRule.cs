using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
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
            if (IsExcludedAsset(obj))
            {
                return;
            }

            var trigger = obj.GetComponent<VRC_Trigger>();
            if (trigger == null) return;

            var triggerEvents = trigger.Triggers;

            foreach (var triggerEvent in triggerEvents)
            {
                if (!broadcastTypesWhitelist.Contains(triggerEvent.BroadcastType))
                {
                    AddIssue(new Issue(
                        obj, 
                        IssueLevel.Error, 
                        string.Format("VRC_Triggerコンポーネントで次のBroadcastTypeは使用できません:{0}", triggerEvent.BroadcastType),
                        "使用可能なBroadcastTypeに変更するか、使用申請をして下さい。"));
                }

                if (!triggerWhitelist.Contains(triggerEvent.TriggerType))
                {
                    AddIssue(new Issue(
                        obj,
                        IssueLevel.Error,
                        string.Format("VRC_Triggerコンポーネントで次のTriggerは使用できません:{0}", triggerEvent.TriggerType),
                        "使用可能なTriggerに変更するか、使用申請をして下さい。"));
                }

                var actions = triggerEvent.Events;
                foreach (var action in actions)
                {
                    if (!actionWhitelist.Contains(action.EventType))
                    {
                        AddIssue(new Issue(
                            obj,
                            IssueLevel.Error,
                            string.Format("VRC_Triggerコンポーネントで次のActionは使用できません:{0}", action.EventType),
                            "使用可能なActionに変更するか、使用申請をして下さい。"));
                    }
                }
            }
        }

        private bool IsExcludedAsset(GameObject obj)
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