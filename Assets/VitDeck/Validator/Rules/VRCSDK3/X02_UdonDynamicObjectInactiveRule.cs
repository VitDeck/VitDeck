#if VRC_SDK_VRCSDK3
using UnityEngine;
using VitDeck.Language;
using VRC.Udon;

namespace VitDeck.Validator
{
    /// <summary>
    /// 全てのUdonBehaviourオブジェクトの親であるDynamicオブジェクトは初期でInactive状態にしてください
    /// </summary>
    internal class X02_UdonDynamicObjectInactiveRule : BaseRule
    {
        public X02_UdonDynamicObjectInactiveRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjects = target.GetRootObjects();

            foreach (var rootObject in rootObjects)
            {
                LogicForRootObject(rootObject);
            }
        }

        private void LogicForRootObject(GameObject rootObject)
        {
            GameObject dynamicRoot = null;

            foreach (Transform child in rootObject.transform)
            {
                if (child.name == "Dynamic" && dynamicRoot == null)
                {
                    dynamicRoot = child.gameObject;
                }
            }

            CheckIsActive("Dynamic", dynamicRoot, false);
        }

        private void CheckIsActive(string instanceName, GameObject instance, bool isActive)
        {
            if (instance.activeSelf != isActive)
            {
                AddIssue(new Issue(
                    instance,
                    IssueLevel.Error,
                    LocalizedMessage.Get("X02_UdonDynamicObjectInactiveRule.isActive", instanceName),
                    LocalizedMessage.Get("X02_UdonDynamicObjectInactiveRule.isActive.Solution", instanceName)
                ));
            }
        }
    }
}
#endif