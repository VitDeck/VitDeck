using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// AssetGuardian内で使う為に、UnityEditor上でアセットの複製コマンドが呼ばれた瞬間をフックする。
    /// </summary>
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
                    var objs = Selection.objects;
                    foreach(var obj in objs)
                    {
                        var p = AssetDatabase.GetAssetPath(obj);
                        if (OnAssetWillDuplicate != null)
                            OnAssetWillDuplicate(p);
                    }
                    
                    break;
                default:
                    // Debug.Log("Event: " + evt.type + " command: " + evt.commandName + " item: " + asset.name);
                    break;
            }
        }

        public static AssetDuplicateEventDelegate OnAssetWillDuplicate;

        public delegate void AssetDuplicateEventDelegate(string assetPath);
    }
}