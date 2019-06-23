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
        IEnumerator<SerializedProperty> enumerator;

        public static IEnumerable<SerializedProperty> From(IEnumerable<GameObject> gameObjects)
        {
            return new AllPropertiesEnumerator(gameObjects);
        }

        private AllPropertiesEnumerator(IEnumerable<GameObject> gameObjects)
        {
            this.uniqueSet = new HashSet<Object>();
            this.enumerator = gameObjects
                .SelectMany(GetComponents)
                .SelectMany(GetProperties)
                .SelectMany(AggregateReferencedObject)
                .GetEnumerator();
        }

        public static IEnumerable<SerializedProperty> From(IEnumerable<Component> components)
        {
            return new AllPropertiesEnumerator(components);
        }

        private AllPropertiesEnumerator(IEnumerable<Component> components)
        {
            this.uniqueSet = new HashSet<Object>();
            this.enumerator = components
                .SelectMany(GetProperties)
                .SelectMany(AggregateReferencedObject)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<SerializedProperty> GetEnumerator()
        {
            return enumerator;
        }

        private IEnumerable<Component> GetComponents(GameObject gameObject)
        {
            if (uniqueSet.Contains(gameObject))
                yield break;

            uniqueSet.Add(gameObject);

            foreach (var component in gameObject.GetComponents<Component>())
            {
                if (component == null)
                    continue;
                yield return component;
            }
        }

        private IEnumerable<SerializedProperty> GetProperties(Object target)
        {
            if (target == null || uniqueSet.Contains(target))
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