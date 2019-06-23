using UnityEngine;
using System.Linq;
using UnityEditor;
using System.Collections.Generic;

namespace VitDeck.Validator
{
    public class MissingReferenceRule : BaseRule
    {
        public MissingReferenceRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var missingPrefabs = target.GetAllObjects()
                .Where(IsMissingPrefab);

            foreach (var missingPrefab in missingPrefabs)
            {
                var targetGameObject = missingPrefab;
                var errorMessage = string.Format("missingプレハブが含まれています！（{0}）", targetGameObject.name);
                AddIssue(new Issue(targetGameObject, IssueLevel.Error, errorMessage));
            }

            var missingComponentSets = target.GetAllObjects()
                .Where(IsNotMissingPrefab)
                .SelectMany(EnumerateComponentSets)
                .Where(set => set.component == null);

            foreach (var missingComponentSet in missingComponentSets)
            {
                var targetGameObject = missingComponentSet.gameObject;
                var errorMessage = string.Format("missingコンポーネントが含まれています！（{0}）", missingComponentSet.gameObject.name);
                AddIssue(new Issue(targetGameObject, IssueLevel.Error, errorMessage));
            }

            var missingProperties = 
                AllPropertiesEnumerator.From(target.GetAllObjects().Where(IsNotMissingPrefab))
                .Where(IsMissng);

            foreach (var missingProperty in missingProperties)
            {
                string message;
                var targetObject = missingProperty.serializedObject.targetObject;
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
                AddIssue(new Issue(targetObject, IssueLevel.Error, message));
            }
        }

        struct ObjectComponentSet
        {
            public readonly GameObject gameObject;
            public readonly Component component;

            public ObjectComponentSet(GameObject gameObject, Component component)
            {
                this.gameObject = gameObject;
                this.component = component;
            }
        }

        private static IEnumerable<ObjectComponentSet> EnumerateComponentSets(GameObject gameObject)
        {
            return gameObject
                .GetComponents<Component>()
                .Select(cp => new ObjectComponentSet(gameObject, cp));
        }

        static bool IsMissingPrefab(GameObject gameObject)
        {
            return PrefabUtility.GetPrefabType(gameObject) == PrefabType.MissingPrefabInstance;
        }

        static bool IsNotMissingPrefab(GameObject gameObject)
        {
            return !IsMissingPrefab(gameObject);
        }

        static bool IsMissng(SerializedProperty serializedProperty)
        {
            if (serializedProperty.propertyType != SerializedPropertyType.ObjectReference ||
                serializedProperty.objectReferenceValue != null ||
                !serializedProperty.hasChildren)
            {
                return false;
            }

            var fileId = serializedProperty.FindPropertyRelative("m_FileID");
            if (fileId == null ||
                fileId.intValue == 0)
            {
                return false;
            }

            return true;
        }
    }
}