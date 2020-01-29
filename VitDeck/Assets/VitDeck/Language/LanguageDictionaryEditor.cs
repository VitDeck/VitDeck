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
            var translations = new List<LanguageDictionary.Pair>();

            for (int i = 0; i < tsvText.Length;)
            {
                var keyCell = new Cell(tsvText, i);
                i = keyCell.EndIndex + 1;
                if (i >= tsvText.Length)
                    break;
                var valueCell = new Cell(tsvText, i);
                i = valueCell.EndIndex + 1;

                translations.Add(new LanguageDictionary.Pair() { Key = keyCell.Content, Value = valueCell.Content });
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
                builder.AppendFormat("{0}\t{1}\n", translation.Key, translation.Value);
            }

            return builder.ToString();
        }

        private class Cell
        {
            private readonly string csv;
            private readonly int start;
            private readonly int end;
            private readonly string content;

            public Cell(string csv, int start)
            {
                this.csv = csv;
                this.start = start;

                bool multiLine = false;
                bool escaped = false;
                int i = start;
                for (; i < csv.Length; i++)
                {
                    var c = csv[i];

                    if (c == '"')
                    {
                        if (i == start)
                        {
                            multiLine = true;
                            escaped = true;
                        }
                        else
                        {
                            escaped = false;
                        }
                    }

                    if (c == '\n')
                    {
                        if (escaped)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (c == '\t')
                    {
                        break;
                    }
                }
                end = i;

                if (multiLine)
                {
                    content = csv.Substring(start + 1, end - start - 3).Trim();
                }
                else
                {
                    content = csv.Substring(start, end - start).Trim();
                }
            }

            public string Content
            {
                get
                {
                    return content;
                }
            }

            public int StartIndex
            {
                get
                {
                    return start;
                }
            }

            public int EndIndex
            {
                get
                {
                    return end;
                }
            }
        }
    }
}