using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

namespace VitDeck.Validator
{
    /// <summary>
    /// <see cref="UnityEngine.Object"/>の列挙から、オブジェクトが到達可能なオブジェクト内にあるmissing状態のPrefab, Component, その他のobjectReferenceを検出する。
    /// </summary>
    public class MissingFinder
    {
        HashSet<Object> uniqueObjectHashSet = new HashSet<Object>();

        HashSet<GameObject> missingPrefabInstances = new HashSet<GameObject>();
        HashSet<GameObject> missingComponentContainers = new HashSet<GameObject>();
        HashSet<SerializedProperty> missingProperties = new HashSet<SerializedProperty>();

        public IEnumerable<GameObject> MissingPrefabInstances
        {
            get { return missingPrefabInstances; }
        }

        public IEnumerable<GameObject> MissingComponentContainers
        {
            get { return missingComponentContainers; }
        }

        public IEnumerable<SerializedProperty> MissingProperties
        {
            get { return missingProperties; }
        }

        public MissingFinder(IEnumerable<Object> unityObjects)
        {
            foreach (var obj in unityObjects)
            {
                FindRecursive(obj);
            }
            uniqueObjectHashSet.Clear();
            uniqueObjectHashSet = null;
        }

        private void FindRecursive(Object unityObject)
        {
            if (unityObject == null)
                return;
            if (uniqueObjectHashSet.Contains(unityObject))
                return;
            uniqueObjectHashSet.Add(unityObject);

            // GameObjectの場合の対応。
            var gameObject = unityObject as GameObject;
            if (gameObject != null)
            {
                if (PrefabUtility.GetPrefabType(unityObject) == PrefabType.MissingPrefabInstance)
                {
                    missingPrefabInstances.Add(unityObject as GameObject);
                }
                else
                {
                    foreach (var component in gameObject.GetComponents<Component>())
                    {
                        // GetComponents<Component>()がnullを含んでいた場合、GUI上ではMissingコンポーネントとして扱われる。
                        // nullはエラーメッセージで活用できない為、親のgameObjectを記録する。
                        if (component == null)
                            missingComponentContainers.Add(gameObject);
                        FindRecursive(component);
                    }
                }
                return;
            }
            
            // その他のObjectの場合の対応。
            var serializedObject = new SerializedObject(unityObject);
            var iterator = serializedObject.GetIterator();

            while (iterator.NextVisible(true))
            {
                var current = iterator.Copy();

                if (IsMissng(current))
                {
                    missingProperties.Add(current);
                }
                else if (
                    current.propertyType == SerializedPropertyType.ObjectReference &&
                    current.objectReferenceValue != null)
                {
                    FindRecursive(current.objectReferenceValue);
                }
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