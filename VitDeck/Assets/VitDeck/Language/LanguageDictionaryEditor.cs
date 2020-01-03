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

                if (GUILayout.Button("Copy All", EditorStyles.miniButton))
                {
                    var csv = ToTSV();
                    GUIUtility.systemCopyBuffer = csv;
                }

                if (GUILayout.Button("Replace All", EditorStyles.miniButton))
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
            var sepalator = '\t';

            var rows = tsvText.Split('\n');

            var translations = new List<LanguageDictionary.Pair>(rows.Length);

            foreach (var row in rows)
            {
                var columns = row.Split(sepalator);

                if (columns.Length < 2)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(columns[0]))
                {
                    continue;
                }

                var key = columns[0];
                var value = columns[1];

                translations.Add(new LanguageDictionary.Pair() { Key = key, Value = value });
            }

            dictionary.SetTranslations(translations.ToArray());
            treeView.Reload();
        }

        private string ToTSV()
        {
            var translations = dictionary.GetTranslations();
            var builder = new StringBuilder();

            foreach (var translation in translations)
            {
                builder.AppendFormat("{0}\t{1}\n", translation.Key, translation.Value);
            }

            return builder.ToString();
        }
    }
}