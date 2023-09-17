using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Main
{
    /// <summary>
    /// Workflowによる制作状況を管理するためのScriptableObject
    /// このScriptableObjectアセットが配置されているフォルダが制作物のルートフォルダとなる。
    /// </summary>
    [CreateAssetMenu(menuName = "VitDeck/Workspace")]
    public class Workspace : ScriptableObject
    {
        [SerializeField] private Workflow workflow;

        public string GetFolderPath()
        {
            return System.IO.Path.GetDirectoryName(UnityEditor.AssetDatabase.GetAssetPath(this));
        }

        /// <summary>
        /// 与えられたパスを管理下に持つWorkspaceを探して返す。
        /// </summary>
        /// <param name="folderPath">対象のパス</param>
        /// <param name="workspace">発見したWorkspace</param>
        /// <returns>Workspaceが見つかればtrue,そうでなければfalse</returns>
        public static bool Find(string folderPath, out Workspace workspace)
        {
            var candidateWorkspacePath = AssetDatabase.FindAssets("t:" + typeof(Workspace).FullName)
                .Select(AssetDatabase.GUIDToAssetPath)
                .Where(path =>
                {
                    var directoryName = System.IO.Path.GetDirectoryName(path)?.Replace('\\', '/');
                    return !string.IsNullOrEmpty(directoryName) &&
                           folderPath.StartsWith(directoryName);
                })
                .OrderBy(path => path.Length)
                .LastOrDefault();

            if (string.IsNullOrEmpty(candidateWorkspacePath))
            {
                workspace = default;
                return false;
            }

            var candidateWorkspace = AssetDatabase.LoadAssetAtPath<Workspace>(candidateWorkspacePath);
            workspace = candidateWorkspace;
            return workspace != null;
        }
    }
}
