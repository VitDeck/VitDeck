using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    [InitializeOnLoad]
    public static class UnityAssetDuplicationEvent
    {
        static UnityAssetDuplicationEvent()
        {
            EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
        }

        private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);

            if (asset == null)
                return;
            if (Selection.activeObject != asset)
                return;

            Event evt = Event.current;

            if (evt.type != EventType.ValidateCommand && evt.type != EventType.ExecuteCommand)
                return;

            switch (evt.commandName)
            {
                case "Duplicate":
                    if (OnDuplicated != null)
                        OnDuplicated(path);
                    break;
                default:
                    // Debug.Log("Event: " + evt.type + " command: " + evt.commandName + " item: " + asset.name);
                    break;

            }
        }

        public static AssetDuplicatedDelegate OnDuplicated;

        public delegate void AssetDuplicatedDelegate(string assetPath);
    }
}