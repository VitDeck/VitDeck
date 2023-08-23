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

            if (GUILayout.Button("Run validation"))
            {
                var assetPath = AssetDatabase.GetAssetPath(serializedObject.targetObject);
                var baseDirectory = Path.GetDirectoryName(assetPath);
                var workflow = workflowProperty.objectReferenceValue as Workflow;
                if (workflow != null)
                {
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
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}