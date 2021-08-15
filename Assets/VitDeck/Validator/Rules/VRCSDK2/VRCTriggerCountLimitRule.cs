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
    /// <summary>
    /// VRC_Triggerコンポーネントの数が制限を超えていることを検出するルール
    /// </summary>
    public class VRCTriggerCountLimitRule : BaseRule
    {
        private int limit;
        public VRCTriggerCountLimitRule(string name, int limit) : base(name)
        {
            this.limit = limit;
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjs = target.GetRootObjects();

            foreach (var rootObj in rootObjs)
            {
                LogicForRootObject(rootObj);
            }
        }

        private void LogicForRootObject(GameObject rootObject)
        {
#if VRC_SDK_VRCSDK2 || VRC_SDK_VRCSDK3 
            var triggers = rootObject.GetComponentsInChildren<VRC_Trigger>(true);

            if (triggers.Length > limit)
            {
                foreach (var trigger in triggers)
                {
                    AddIssue(new Issue(
                        trigger.gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("VRCTriggerCountLimitRule.Overuse", limit, triggers.Length),
                        LocalizedMessage.Get("VRCTriggerCountLimitRule.Overuse.Solution")));
                }
            }
#endif
        }
    }
}