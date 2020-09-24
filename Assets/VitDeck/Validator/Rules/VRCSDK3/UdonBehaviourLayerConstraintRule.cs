#if VRC_SDK_VRCSDK3
using UnityEngine;
using VitDeck.Language;
using VRC.Udon;

namespace VitDeck.Validator
{
    /// <summary>
    /// UdonBehaviourを含むオブジェクトのLayerはUserLayer23としてください
    /// </summary>
    internal class UdonBehaviourLayerConstraintRule : BaseUdonBehaviourRule
    {
        public UdonBehaviourLayerConstraintRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(UdonBehaviour component)
        {
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
            var objs =  hasComponentObject.transform.GetComponentsInChildren<Transform>();
            foreach (var obj in objs)
            {
                if (obj.gameObject.layer != 23)
                {
                    AddIssue(new Issue(
                            obj, 
                            IssueLevel.Error, 
                            LocalizedMessage.Get("UdonBehaviourLayerConstraintRule.InvalidLayer"),
                            LocalizedMessage.Get("UdonBehaviourLayerConstraintRule.InvalidLayer.solution")
                        )
                    );
                }
            }
        }
    }
}
#endif