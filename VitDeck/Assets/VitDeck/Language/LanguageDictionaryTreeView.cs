using System.Collections.Generic;
using UnityEngine;
using UnityEditor.IMGUI.Controls;

namespace VitDeck.Language
{
    public class LanguageDictionaryTreeView : TreeView
    {
        private readonly LanguageDictionary dictionary;

        public static LanguageDictionaryTreeView CreateInstance(
            LanguageDictionary dictionary,
            ref TreeViewState state
            )
        {
            if (state == null)
            {
                state = new TreeViewState();
            }

            var keyColumn = new MultiColumnHeaderState.Column()
            {
                headerContent = new GUIContent("MessageID"),
                headerTextAlignment = TextAlignment.Center,
                canSort = false,
                width = 100,
                minWidth = 50,
                autoResize = true,
                allowToggleVisibility = false,
            };

            var valueColumn = new MultiColumnHeaderState.Column()
            {
                headerContent = new GUIContent("Text"),
                headerTextAlignment = TextAlignment.Center,
                canSort = false,
                width = 150,
                minWidth = 50,
                autoResize = true,
                allowToggleVisibility = false,
            };

            var headerState = new MultiColumnHeaderState(
                new MultiColumnHeaderState.Column[] {
                        keyColumn,
                        valueColumn
                });

            var header = new MultiColumnHeader(headerState);
            header.canSort = false;
            header.ResizeToFit();

            return new LanguageDictionaryTreeView(
                dictionary,
                state,
                header);
        }

        private LanguageDictionaryTreeView(
            LanguageDictionary dictionary,
            TreeViewState state,
            MultiColumnHeader multiColumnHeader)
            : base(state, multiColumnHeader)
        {
            this.dictionary = dictionary;

            showAlternatingRowBackgrounds = true;
            showBorder = true;

            Reload();
        }

        protected override TreeViewItem BuildRoot()
        {
            var root = new TreeViewItem(
                id: -1,
                depth: -1,
                displayName: "Root");

            return root;
        }

        protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
        {
            var rows = GetRows();
            if (rows == null)
            {
                rows = new List<TreeViewItem>();
            }
            rows.Clear();

            var langList = dictionary.GetTranslations();

            for (int id = 0; id < langList.Length; id++)
            {
                var translation = langList[id];
                if (searchString != null &&
                    !translation.Key.Contains(searchString) &&
                    !translation.Value.Contains(searchString))
                {
                    continue;
                }

                var viewItem = new TreeViewItem()
                {
                    id = id,
                    displayName = translation.Key
                };

                root.AddChild(viewItem);
                rows.Add(viewItem);
            }

            SetupDepthsFromParentsAndChildren(root);

            return rows;
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var columnsCount = args.GetNumVisibleColumns();
            var item = dictionary.GetTranslations()[args.item.id];

            for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
            {
                var columnID = args.GetColumn(columnIndex);
                var rect = args.GetCellRect(columnIndex);

                if (columnID == 0)
                {
                    GUI.Label(rect, item.Key);
                }
                else
                {
                    GUI.Label(rect, item.Value);
                }
            }
        }
    }
}