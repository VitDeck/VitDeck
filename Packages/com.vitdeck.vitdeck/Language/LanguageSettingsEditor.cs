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

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(property);
            if (EditorGUI.EndChangeCheck())
            {
                var target = property.objectReferenceValue as LanguageDictionary;
                Debug.Log("Set " + target);
                LocalizedMessage.SetDictionary(target);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}