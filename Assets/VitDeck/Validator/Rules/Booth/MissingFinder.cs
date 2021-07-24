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
                if (PrefabUtility.GetPrefabInstanceStatus(unityObject) == PrefabInstanceStatus.MissingAsset)
                {
                    missingPrefabInstances.Add(unityObject as GameObject);
                    return;
                }

                foreach (var component in gameObject.GetComponents<Component>())
                {
                    // GetComponents<Component>()がnullを含んでいた場合、GUI上ではMissingコンポーネントとして扱われる。
                    // nullはエラーメッセージで活用できない為、親のgameObjectを記録する。
                    if (component == null)
                    {
                        missingComponentContainers.Add(gameObject);
                    }
                    else
                    {
                        FindRecursive(component);
                    }
                }
                return;
            }

            // Materialの場合の対応。
            var material = unityObject as Material;
            if (material != null)
            {
                CheckMaterial(material);
                return;
            }

            // その他のObjectの場合の対応。
            var serializedObject = new SerializedObject(unityObject);
            var iterator = serializedObject.GetIterator();

            while (iterator.NextVisible(true))
            {
                var current = iterator.Copy();

                if (IsMissing(current))
                {
                    missingProperties.Add(current);
                }
                else if (HasValidObjectReference(current))
                {
                    FindRecursive(current.objectReferenceValue);
                }
            }
        }

        private void CheckMaterial(Material material)
        {
            if (material.shader != null)
            {
                //設定中のシェーダーに存在するプロパティの取得
                var shaderProperties = new HashSet<string>();
                var count = ShaderUtil.GetPropertyCount(material.shader);
                for (int i = 0; i < count; i++)
                {
                    string propName = ShaderUtil.GetPropertyName(material.shader, i);
                    shaderProperties.Add(propName);
                }

                var matSo = new SerializedObject(material);
                var matSp = matSo.FindProperty("m_SavedProperties");
                var texEnvsSp = matSp.FindPropertyRelative("m_TexEnvs");
                for (int i = 0; i < texEnvsSp.arraySize; i++)
                {
                    var prop = texEnvsSp.GetArrayElementAtIndex(i);
                    var propName = prop.FindPropertyRelative("first").stringValue;
                    //設定中のシェーダーに存在するテクスチャ指定プロパティのみmissing検証
                    if (shaderProperties.Contains(propName))
                    {
                        var tex = prop.FindPropertyRelative("second.m_Texture");
                        if (tex != null && IsMissing(tex))
                        {
                            missingProperties.Add(prop);
                        }
                    }
                }
            }
        }

        private static bool HasValidObjectReference(SerializedProperty serializedProperty)
        {
            return serializedProperty.propertyType == SerializedPropertyType.ObjectReference &&
                   serializedProperty.objectReferenceValue != null;
        }

        private static bool IsMissing(SerializedProperty serializedProperty)
        {
            if (serializedProperty.propertyType != SerializedPropertyType.ObjectReference ||
                serializedProperty.objectReferenceValue != null)
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
