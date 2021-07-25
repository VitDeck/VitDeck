using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace VitDeck.Validator
{
    public class UnityObjectReferenceChain
    {
        public readonly IReadonlyReferenceDictionary Result;

        public static UnityObjectReferenceChain ExploreFrom(IEnumerable<Object> objects)
        {
            return new UnityObjectReferenceChain(objects);
        }

        private UnityObjectReferenceChain(IEnumerable<Object> objects)
        {
            var hashSet = new HashSet<Object>();
            var dictionary = new ReferenceDictionary();

            foreach (var @object in objects)
            {
                dictionary.AddReference(@object);
                FindAssetReferencesRecursive(@object, hashSet, dictionary);
            }

            Result = dictionary.CreateReadonlyDictionary();
        }

        private static void FindAssetReferencesRecursive(Object unityObject, HashSet<Object> searchedAsset, ReferenceDictionary dictionary)
        {
            if (unityObject == null)
                return;
            if (searchedAsset.Contains(unityObject))
                return;

            searchedAsset.Add(unityObject);

            if (TryFindAssetReferencesAsGameObject(unityObject, searchedAsset, dictionary))
            {
                return;
            }
            if (TryFindAssetReferencesAsMaterial(unityObject, dictionary))
            {
                return;
            }

            FindSerializedObjectReferenceRecursive(unityObject, searchedAsset, dictionary);
        }

        private static bool TryFindAssetReferencesAsMaterial(Object unityObject, ReferenceDictionary dictionary)
        {
            var material = unityObject as Material;
            if (material == null)
            {
                return false;
            }
            
            FindMaterialReferenceRecursive(material, dictionary);

            return true;
        }

        private static bool TryFindAssetReferencesAsGameObject(Object unityObject, HashSet<Object> searchedAsset,
            ReferenceDictionary dictionary)
        {
            var gameObject = unityObject as GameObject;
            if (gameObject == null)
            {
                return false;
            }
            
            dictionary.AddReference(gameObject);

            var prefabStatus = PrefabUtility.GetPrefabInstanceStatus(gameObject);
            if ( prefabStatus == PrefabInstanceStatus.Connected )
            {
                var prefabRoot = PrefabUtility.GetNearestPrefabInstanceRoot(gameObject);
                if (prefabRoot == gameObject)
                {
                    var prefabPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(gameObject);
                    var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                    dictionary.AddReference(gameObject, prefab);
                    FindAssetReferencesRecursive(prefab, searchedAsset, dictionary);
                }
            }

            foreach (var component in gameObject.GetComponents<Component>())
            {
                FindAssetReferencesRecursive(component, searchedAsset, dictionary);
            }

            return true;
        }

        private static void FindMaterialReferenceRecursive(Material material, ReferenceDictionary dictionary)
        {
            if (material.shader == null)
                return;

            // シェーダーがベースフォルダに含まれない場合でもエラーが出ない問題に対する暫定対応
            // ※この記述がなくてもエラー出る場合がある
            dictionary.AddReference(material.shader);

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

            while (iterator.NextVisible(true))
            {
                var property = iterator;
                if (property.propertyType != SerializedPropertyType.ObjectReference)
                {
                    continue;
                }

                var referredAsset = property.objectReferenceValue;
                if (referredAsset == null)
                {
                    continue;
                }

                dictionary.AddReference(unityObject, referredAsset);

                FindAssetReferencesRecursive(referredAsset, searchedAsset, dictionary);
            }
        }

        private class ReferenceDictionary
        {
            private readonly Dictionary<Object, List<Object>> reverseDictionary = new Dictionary<Object, List<Object>>();
            private readonly Dictionary<Object, List<Object>> forwardDictionary = new Dictionary<Object, List<Object>>();

            public ReadonlyReferenceDictionary CreateReadonlyDictionary()
            {
                return new ReadonlyReferenceDictionary(forwardDictionary, reverseDictionary);
            }
            
            public void AddReference(Object referrer, Object referred)
            {
                if (!reverseDictionary.TryGetValue(referred, out var referrers))
                {
                    referrers = new List<Object>();
                    reverseDictionary.Add(referred, referrers);
                }
                referrers.Add(referrer);

                if (!forwardDictionary.TryGetValue(referrer, out var referredObjects))
                {
                    referredObjects = new List<Object>();
                    forwardDictionary.Add(referrer, referredObjects);
                }
                referredObjects.Add(referred);
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