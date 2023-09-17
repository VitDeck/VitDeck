using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using VitDeck.Main;

namespace VitDeck.ExhibitorGUI
{
    public class WorkspaceWindow : EditorWindow
    {
        private Workspace workspace;
        private Editor workspaceEditor;

        private void OnEnable()
        {
            EditorSceneManager.sceneOpened += (scene, mode) =>
            {
                Debug.Log("Scene Open");
                FetchCurrentWorkspace();
            };
        }

        [MenuItem("VitDeck/Workspace")]
        static void Open()
        {
            var window = GetWindow<WorkspaceWindow>(false, "Workspace");
            window.FetchCurrentWorkspace();
        }

        private void FetchCurrentWorkspace()
        {
            var currentScene = SceneManager.GetActiveScene();
            var currentScenePath = currentScene.path;
            if (Workspace.Find(currentScenePath, out var foundWorkspace))
            {
                workspace = foundWorkspace;
                workspaceEditor = Editor.CreateEditor(workspace);
            }
            else
            {
                workspace = null;
                DestroyImmediate(workspaceEditor);
                workspaceEditor = null;
            }
        }

        private void OnGUI()
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.ObjectField("Workspace", workspace, typeof(Workspace), false);
            EditorGUI.EndDisabledGroup();

            if (workspace == null)
            {
                EditorGUILayout.HelpBox(
                    "To enable the Workspace window, open a scene that exists within the workspace.", MessageType.Info);
                return;
            }

            workspaceEditor.OnInspectorGUI();
        }
    }
}
