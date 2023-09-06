using UnityEngine;
using VitDeck.Language;

#if VRC_SDK_VRCSDK3
using VRC.SDKBase;

namespace VitDeck.Validator
{
    /// <summary>
    /// VRCStationコンポーネントの数が制限を超えていることを検出するルール
    /// </summary>
    public class VRCStationCountLimitRule : BaseRule
    {
        private int limit;
        public VRCStationCountLimitRule(string name, int limit) : base(name)
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
            var triggers = rootObject.GetComponentsInChildren<VRCStation>(true);

            if (triggers.Length > limit)
            {
                foreach (var trigger in triggers)
                {
                    AddIssue(new Issue(
                        trigger.gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("VRCStationCountLimitRule.Overuse", limit, triggers.Length),
                        LocalizedMessage.Get("VRCStationCountLimitRule.Overuse.Solution")));
                }
            }
        }
    }
}
#endif
