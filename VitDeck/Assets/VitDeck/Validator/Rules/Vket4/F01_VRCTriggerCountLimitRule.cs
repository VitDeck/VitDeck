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
                AddIssue(new Issue(
                    null,
                    IssueLevel.Error,
                    string.Format("VRC_Triggerコンポーネントの数が使用可能な制限を超えています。制限:{0}, 使用:{1}", limit, triggers.Length),
                    string.Format("使用するVRCコンポーネントを{0}個以下にして下さい。", limit)));
            }
        }
    }
}