using System;
using UnityEngine;
using VRCSDK2;

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
            var triggers = rootObject.GetComponentsInChildren<VRC_Trigger>(true);

            if (triggers.Length > limit)
            {
                foreach (var trigger in triggers)
                {
                    AddIssue(new Issue(
                        trigger.gameObject,
                        IssueLevel.Error,
                        string.Format("VRC_Triggerコンポーネントの数が{0}個を超えています。({1}個)", limit, triggers.Length),
                        string.Format("使用個数を減らして下さい。")));
                }
            }
        }
    }
}