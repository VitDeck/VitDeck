using UnityEngine;
using System.Linq;
using UnityEditor;
using System.Collections.Generic;

namespace VitDeck.Validator
{
    /// <summary>
    /// シーンから参照を辿れる全てのオブジェクト、Asset内にMissing参照が無い事を強制するルール。
    /// </summary>
    /// <remarks>
    /// 下記種類のmissingを検出する。
    /// - シーン上のMissing Prefab
    /// - GameObjectにアタッチされたコンポーネント(MonoBehaviour)のmissing
    /// - SerializedPropertyのobjectReferenceのmissing
    /// </remarks>
    public class MissingReferenceRule : BaseRule
    {
        public MissingReferenceRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var finder = new MissingFinder(target.GetAllObjects());

            foreach (var missingPrefabInstance in finder.MissingPrefabInstances)
            {
                var errorMessage = string.Format("missingプレハブが含まれています！（{0}）", missingPrefabInstance.name);
                AddIssue(new Issue(missingPrefabInstance, IssueLevel.Error, errorMessage));
            }

            foreach (var missingComponentContainer in finder.MissingComponentContainers)
            {
                var errorMessage = string.Format("missingコンポーネントが含まれています！（{0}）", missingComponentContainer.name);
                var mainAsset = GetMainAsset(missingComponentContainer);
                AddIssue(new Issue(mainAsset, IssueLevel.Error, errorMessage));
            }

            foreach (var missingProperty in finder.MissingProperties)
            {
                var targetObject = missingProperty.serializedObject.targetObject;
                string message;
                var targetComponent = targetObject as Component;
                if (targetComponent != null)
                {
                    message = string.Format("missingフィールドが含まれています！（{0} > {1} > {2}）",
                        targetComponent.gameObject.name,
                        targetComponent.GetType().Name,
                        missingProperty.displayName);
                }
                else
                {
                    message = string.Format("missingフィールドが含まれています！（{0} > {1}）",
                        targetObject.name,
                        missingProperty.displayName);
                }

                var mainAsset = GetMainAsset(targetObject);
                AddIssue(new Issue(mainAsset, IssueLevel.Error, message));
            }
        }

        static Object GetMainAsset(Object targetObject)
        {
            return AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GetAssetPath(targetObject)) ?? targetObject;
        }
    }
}