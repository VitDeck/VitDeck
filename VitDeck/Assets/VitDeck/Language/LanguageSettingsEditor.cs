using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Language
{
    [CustomEditor(typeof(LanguageSettings))]
    public class LanguageSettingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var property = serializedObject.FindProperty("language");

            var changed = EditorGUILayout.PropertyField(property);

            if (changed)
            {
                var target = property.objectReferenceValue as LanguageDictionary;
                LocalizedMessage.SetDictionary(target);
            }

        }
    }
}