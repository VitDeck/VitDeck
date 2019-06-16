using System.Collections;
using System.Collections.Generic;
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
                .Where(gameObject => PrefabUtility.GetPrefabType(gameObject) == PrefabType.MissingPrefabInstance);
            foreach(var missingPrefab in missingPrefabs)
            {
                var targetObject = missingPrefab;
                var errorMessage = string.Format("missingプレハブが含まれています！（{0}）", targetObject);
                AddIssue(new Issue(targetObject, IssueLevel.Error, errorMessage));
            }

            var missingProperties = target.GetAllObjects()
                .SelectMany(gameObject => gameObject.GetComponents<Component>())
                .SelectMany(LoadAllProperties)
                .Where(IsMissng);

            foreach(var missingProperty in missingProperties)
            {
                var targetObject = missingProperty.serializedObject.targetObject;
                var errorMessage = string.Format("missingフィールドが含まれています！（{0}/{1}）", targetObject , missingProperty.displayName);
                AddIssue(new Issue(targetObject, IssueLevel.Error, errorMessage));
            }
        }

        static IEnumerable<SerializedProperty> LoadAllProperties(Object obj)
        {
            var serializedObject = new SerializedObject(obj);
            var iterator = serializedObject.GetIterator();

            while (iterator.NextVisible(true))
            {
                yield return iterator;
            }
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