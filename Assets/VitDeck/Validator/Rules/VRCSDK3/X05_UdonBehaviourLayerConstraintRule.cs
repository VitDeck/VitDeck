#if VRC_SDK_VRCSDK3
using UnityEngine;
using VitDeck.Language;
using VRC.Udon;

namespace VitDeck.Validator
{
    /// <summary>
    /// UdonBehaviourを含むオブジェクトのLayerはUserLayer23としてください
    /// </summary>
    internal class X05_UdonBehaviourLayerConstraintRule : UdonBehaviourRule
    {
        public X05_UdonBehaviourLayerConstraintRule(string name) : base(name)
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
                            LocalizedMessage.Get("X05_UdonBehaviourLayerConstraintRule.InvalidLayer"),
                            LocalizedMessage.Get("X05_UdonBehaviourLayerConstraintRule.InvalidLayer.solution")
                        )
                    );
                }
            }
        }
    }
}
#endif