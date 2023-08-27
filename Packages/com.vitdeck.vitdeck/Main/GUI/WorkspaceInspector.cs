using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Main.GUI
{
    [CustomEditor(typeof(Workspace))]
    public class WorkspaceInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            var workflowProperty = serializedObject.FindProperty("workflow");
            EditorGUILayout.PropertyField(workflowProperty);
            var workflow = workflowProperty.objectReferenceValue as Workflow;
            var workspace = target as Workspace ??
                            throw new InvalidProgramException("Workspace inspector should be attached to Workspace.");

            EditorGUI.BeginDisabledGroup(workflow == null);

            if (GUILayout.Button("Run validation") && workflow != null)
            {
                var assetPath = AssetDatabase.GetAssetPath(serializedObject.targetObject);
                var baseDirectory = Path.GetDirectoryName(assetPath);

                Debug.Log("Run validation");
                var ruleSet = workflow.RuleSet;
                var results = Validator.Validator.Validate(ruleSet, baseDirectory);
                Debug.Log("Results:" + results.Length);
                foreach (var result in results)
                {
                    Debug.Log(result.RuleName);
                    Debug.Log("Issues:" + result.Issues.Count);
                    foreach (var issue in result.Issues)
                    {
                        Debug.Log(issue.message);
                    }
                }
            }

            if (GUILayout.Button("Export") && workflow != null)
            {
                var exportSettings = workflow.ExportSetting;
                var path = workspace.GetFolderPath();
                Exporter.Exporter.Export(path, exportSettings);
            }

            EditorGUI.EndDisabledGroup();

            serializedObject.ApplyModifiedProperties();
        }
    }
}