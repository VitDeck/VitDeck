using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace VitDeck.Validator
{
    public class UnityObjectReferenceChain : IEnumerable<Object>
    {
        private readonly ReferenceDictionary dictionary;

        public static UnityObjectReferenceChain ExploreFrom(IEnumerable<Object> objects)
        {
            return new UnityObjectReferenceChain(objects);
        }

        private UnityObjectReferenceChain(IEnumerable<Object> objects)
        {
            var hashSet = new HashSet<Object>();
            dictionary = new ReferenceDictionary();

            foreach (var @object in objects)
            {
                dictionary.AddReference(@object);
                FindAssetReferencesRecursive(@object, hashSet, dictionary);
            }
        }

        private static void FindAssetReferencesRecursive(Object unityObject, HashSet<Object> searchedAsset, ReferenceDictionary dictionary)
        {
            if (unityObject == null)
                return;
            if (searchedAsset.Contains(unityObject))
                return;

            searchedAsset.Add(unityObject);

            var gameObject = unityObject as GameObject;
            if (gameObject != null)
            {
                foreach (var component in gameObject.GetComponents<Component>())
                {
                    FindAssetReferencesRecursive(component, searchedAsset, dictionary);
                }

                return;
            }

            var material = unityObject as Material;
            if (material != null)
            {
                FindMaterialReferenceRecursive(material, dictionary);

                return;
            }

            FindSerializedObjectReferenceRecursive(unityObject, searchedAsset, dictionary);
        }

        private static void FindMaterialReferenceRecursive(Material material, ReferenceDictionary dictionary)
        {
            if (material.shader == null)
                return;

            //設定中のシェーダーに存在するプロパティの取得
            var count = ShaderUtil.GetPropertyCount(material.shader);
            var propertyNames = new string[count];
            for (int i = 0; i < count; i++)
            {
                string propName = ShaderUtil.GetPropertyName(material.shader, i);
                propertyNames[i] = propName;
            }

            var serializedObject = new SerializedObject(material);
            var texturesProperty = serializedObject.FindProperty("m_SavedProperties.m_TexEnvs");
            for (int i = 0; i < texturesProperty.arraySize; i++)
            {
                var textureContainerProperty = texturesProperty.GetArrayElementAtIndex(i);
                var textureName = textureContainerProperty.FindPropertyRelative("first").stringValue;
                // シェーダーに存在するテクスチャ指定プロパティ以外は無視
                if (!propertyNames.Contains(textureName))
                    continue;

                var texture = textureContainerProperty.FindPropertyRelative("second.m_Texture").objectReferenceValue;
                if (texture == null)
                    continue;

                dictionary.AddReference(material, texture);
            }
        }

        private static void FindSerializedObjectReferenceRecursive(Object unityObject, HashSet<Object> searchedAsset, ReferenceDictionary dictionary)
        {
            var serializedObject = new SerializedObject(unityObject);

            var iterator = serializedObject.GetIterator();

            int count = 0;
            while (iterator.NextVisible(true))
            {
                count++;
                var property = iterator;
                if (property.propertyType != SerializedPropertyType.ObjectReference)
                {
                    continue;
                }

                var referedAsset = property.objectReferenceValue;
                if (referedAsset == null)
                {
                    continue;
                }

                dictionary.AddReference(unityObject, referedAsset);

                FindAssetReferencesRecursive(referedAsset, searchedAsset, dictionary);
            }
        }

        public IEnumerator<Object> GetEnumerator()
        {
            return dictionary.GetReferredObjects().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ReferenceDictionary
        {
            private readonly Dictionary<Object, List<Object>> reverseDictionary = new Dictionary<Object, List<Object>>();

            public void AddReference(Object referrer, Object referred)
            {
                if (!reverseDictionary.TryGetValue(referred, out var referrers))
                {
                    referrers = new List<Object>();
                    reverseDictionary.Add(referred, referrers);
                }
                referrers.Add(referrer);
            }

            public void AddReference(Object referred)
            {
                if (reverseDictionary.ContainsKey(referred))
                {
                    return;
                }

                var referrerList = new List<Object>();
                reverseDictionary.Add(referred, referrerList);
            }

            public IEnumerable<KeyValuePair<Object, IEnumerable<Object>>> Enumerate()
            {
                foreach (var pair in reverseDictionary)
                {
                    yield return new KeyValuePair<Object, IEnumerable<Object>>(pair.Key, pair.Value.Distinct());
                }
            }

            public IEnumerable<Object> GetReferredObjects()
            {
                return reverseDictionary.Keys;
            }
        }
    }
}