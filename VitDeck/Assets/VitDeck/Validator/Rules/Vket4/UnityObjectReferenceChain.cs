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
        private readonly ReferenceBook book;

        public static UnityObjectReferenceChain ExploreFrom(IEnumerable<Object> objects)
        {
            return new UnityObjectReferenceChain(objects);
        }

        private UnityObjectReferenceChain(IEnumerable<Object> objects)
        {
            var hashSet = new HashSet<Object>();
            book = new ReferenceBook();

            foreach (var @object in objects)
            {
                book.AddReference(@object);
                FindAssetReferencesRecursive(@object, hashSet, book);
            }
        }

        private static void FindAssetReferencesRecursive(Object unityObject, HashSet<Object> searchedAsset, ReferenceBook book)
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
                    FindAssetReferencesRecursive(component, searchedAsset, book);
                }

                return;
            }

            var material = unityObject as Material;
            if (material != null)
            {
                FindMaterialReferenceRecursive(material, book);

                return;
            }

            FindSerializedObjectReferenceRecursive(unityObject, searchedAsset, book);
        }

        private static void FindMaterialReferenceRecursive(Material material, ReferenceBook book)
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

                book.AddReference(texture, material);
            }
        }

        private static void FindSerializedObjectReferenceRecursive(Object unityObject, HashSet<Object> searchedAsset, ReferenceBook book)
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

                book.AddReference(referedAsset, unityObject);

                FindAssetReferencesRecursive(referedAsset, searchedAsset, book);
            }
        }

        public IEnumerator<Object> GetEnumerator()
        {
            return book.GetReferredObjects().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ReferenceBook
        {
            Dictionary<Object, List<Object>> book = new Dictionary<Object, List<Object>>();

            public void AddReference(Object referred, Object referrer)
            {
                List<Object> referrerList;
                if (!book.TryGetValue(referred, out referrerList))
                {
                    referrerList = new List<Object>();
                    book.Add(referred, referrerList);
                }

                referrerList.Add(referrer);
            }

            public void AddReference(Object referred)
            {
                if (!book.ContainsKey(referred))
                {
                    var referrerList = new List<Object>();
                    book.Add(referred, referrerList);
                }
            }

            public IEnumerable<KeyValuePair<Object, IEnumerable<Object>>> Enumerate()
            {
                foreach (var pair in book)
                {
                    yield return new KeyValuePair<Object, IEnumerable<Object>>(pair.Key, pair.Value.Distinct());
                }
            }

            public IEnumerable<Object> GetReferredObjects()
            {
                return book.Keys;
            }
        }
    }
}