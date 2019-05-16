using UnityEditor;
using UnityEngine;

namespace VitDeck.Main.GUI
{
    /// <summary>
    /// VitDeckのツール情報を表示するウインドウ。
    /// </summary>
    public class InfoWindow : EditorWindow
    {
        [SerializeField]
        string versionLabel = null;
        //[SerializeField]
        string latestVersionLabel = null;
        [SerializeField]
        UpdateCheck check = new UpdateCheck();

        public static void ShowWindow()
        {
            GetWindow<InfoWindow>(true, "VitDeck");
        }

        private void OnEnable()
        {
            versionLabel = "Version : " + VitDeck.GetVersion();
            latestVersionLabel = "Latest Version : " + check.GetLatestVersion();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField(versionLabel);
            if(check.IsLatest()) {
                EditorGUILayout.LabelField("最新のバージョンです");
            }
            else{
                EditorGUILayout.LabelField(latestVersionLabel);
                GUILayout.Button("Update");
            }
        }
    }
}
