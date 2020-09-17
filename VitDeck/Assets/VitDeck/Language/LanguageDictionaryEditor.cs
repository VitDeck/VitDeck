using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using System;
using System.Text;

namespace VitDeck.Language
{
    [CustomEditor(typeof(LanguageDictionary))]
    public class LanguageDictionaryEditor : Editor
    {
        [SerializeField]
        private TreeViewState treeViewState;

        private LanguageDictionary dictionary;

        private LanguageDictionaryTreeView treeView;
        private SearchField searchField;

        private void OnEnable()
        {
            dictionary = (LanguageDictionary)target;
            treeView = LanguageDictionaryTreeView.CreateInstance(
                dictionary,
                ref treeViewState);

            searchField = new SearchField();
            searchField.downOrUpArrowKeyPressed += treeView.SetFocusAndEnsureSelectedItem;
        }

        public override void OnInspectorGUI()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();
                GUILayout.Label("Clipboard(tsv):");

                if (GUILayout.Button("Copy", EditorStyles.miniButton))
                {
                    var csv = ToTSV();
                    GUIUtility.systemCopyBuffer = csv;
                }

                if (GUILayout.Button("Paste", EditorStyles.miniButton))
                {
                    var csv = GUIUtility.systemCopyBuffer;
                    ReadFromTSV(csv);
                }
            }

            treeView.searchString = searchField.OnGUI(treeView.searchString);

            var rect = EditorGUILayout.GetControlRect(false, 200);
            treeView.OnGUI(rect);

        }

        private void ReadFromTSV(string tsvText)
        {
            
            var translations = new List<LanguageDictionary.Pair>();
            var tsv = CSVParser.LoadFromString(tsvText, CSVParser.Delimiter.Tab);
            
            int messageIDColumnIndex = 0;
            int messageColumnIndex = 1;
            
            foreach (var row in tsv)
            {
                var messageID = row[messageIDColumnIndex];
                var message = row[messageColumnIndex];
                
                translations.Add(new LanguageDictionary.Pair() { Key = messageID, Value = message });
            }

            dictionary.SetTranslations(translations.ToArray());
            EditorUtility.SetDirty(target);
            treeView.Reload();
        }

        private string ToTSV()
        {
            var translations = dictionary.GetTranslations();
            var builder = new StringBuilder();

            foreach (var translation in translations)
            {
                var value = translation.Value;

                if (IsMustQuote(value))
                {
                    value = $"\"{value.Replace("\"","\\\"")}\"";
                }

                builder.AppendFormat("{0}\t{1}\n", translation.Key, value);
            }

            return builder.ToString();
        }

        private bool IsMustQuote(string value)
        {
            return value.Contains("\t") || value.Contains("\n");
        }
    }
}