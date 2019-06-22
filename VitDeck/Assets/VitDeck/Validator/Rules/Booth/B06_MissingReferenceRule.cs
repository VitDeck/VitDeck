using UnityEngine;
using System.Linq;
using UnityEditor;

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

            var noMissingPrefabs = target.GetAllObjects().Where(IsNotMissingPrefab);
            var missingProperties = new AllPropertiesEnumerator(noMissingPrefabs).Where(IsMissng);

            foreach (var missingProperty in missingProperties)
            {
                var targetComponent = missingProperty.serializedObject.targetObject as Component;
                var errorMessage = string.Format("missingフィールドが含まれています！（{0} > {1} > {2}）",
                    targetComponent.gameObject.name, targetComponent.GetType().Name, missingProperty.displayName);
                AddIssue(new Issue(targetComponent, IssueLevel.Error, errorMessage));
            }
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