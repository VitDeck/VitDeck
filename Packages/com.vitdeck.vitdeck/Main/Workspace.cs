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
    }
}