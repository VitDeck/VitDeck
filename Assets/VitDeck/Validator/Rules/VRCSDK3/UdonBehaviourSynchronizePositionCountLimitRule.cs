#if VRC_SDK_VRCSDK3
using UnityEngine;
using VitDeck.Language;

using VRC.Udon;

namespace VitDeck.Validator
{
    /// <summary>
    /// SynchronizePositionが有効なUdonBehaviourは1ブースあたり limit まで
    /// </summary>
    public class UdonBehaviourSynchronizePositionCountLimitRule : BaseRule
    {
        private readonly int _limit;
        public UdonBehaviourSynchronizePositionCountLimitRule(string name, int limit) : base(name)
        {
            this._limit = limit;
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
            var udonBehaviours = rootObject.GetComponentsInChildren<UdonBehaviour>(true);
            var count = 0;
            foreach (var udonBehaviour in udonBehaviours)
            {
                if (udonBehaviour.SynchronizePosition) count++;
            }

            if (count > _limit)
            {
                foreach (var trigger in udonBehaviours)
                {
                    AddIssue(new Issue(
                        trigger.gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("UdonBehaviourSynchronizePositionCountLimitRule.Overuse", _limit, count),
                        LocalizedMessage.Get("UdonBehaviourSynchronizePositionCountLimitRule.Overuse.Solution")));
                }
            }
        }
    }
}
#endif
