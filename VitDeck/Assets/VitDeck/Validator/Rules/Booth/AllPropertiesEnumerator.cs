using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

namespace VitDeck.Validator
{
    public class AllPropertiesEnumerator : IEnumerable<SerializedProperty>
    {
        HashSet<Object> uniqueSet;
        IEnumerable<GameObject> gameObjects;

        public AllPropertiesEnumerator(IEnumerable<GameObject> gameObjects)
        {
            this.uniqueSet = new HashSet<Object>();
            this.gameObjects = gameObjects;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<SerializedProperty> GetEnumerator()
        {
            return gameObjects
                .SelectMany(GetComponents)
                .SelectMany(GetProperties)
                .SelectMany(AggregateReferencedObject)
                .GetEnumerator();
        }

        private IEnumerable<Component> GetComponents(GameObject gameObject)
        {
            if (uniqueSet.Contains(gameObject))
                yield break;

            uniqueSet.Add(gameObject);

            foreach (var component in gameObject.GetComponents<Component>())
                yield return component;
        }

        private IEnumerable<SerializedProperty> GetProperties(Object target)
        {
            if (uniqueSet.Contains(target))
                yield break;

            uniqueSet.Add(target);

            var serializedObject = new SerializedObject(target);
            var iterator = serializedObject.GetIterator();

            while (iterator.NextVisible(true))
            {
                yield return iterator;
            }
        }

        private IEnumerable<SerializedProperty> AggregateReferencedObject(SerializedProperty property)
        {
            yield return property;

            if (property.propertyType != SerializedPropertyType.ObjectReference)
                yield break;

            var obj = property.objectReferenceValue;
            if (obj == null)
                yield break;

            var gameObject = obj as GameObject;
            if (gameObject != null)
            {
                var props = GetComponents(gameObject)
                    .SelectMany(GetProperties)
                    .SelectMany(AggregateReferencedObject);
                foreach (var prop in props)
                    yield return prop;
            }
            else
            {
                var props = GetProperties(obj)
                    .SelectMany(AggregateReferencedObject);
                foreach (var prop in props)
                    yield return prop;
            }
        }
    }
}