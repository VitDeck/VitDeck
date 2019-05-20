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
        [SerializeField]
        string latestVersionLabel = null;
        [SerializeField]
        string tag = null;

        // テスト用
        string releaseUrl = "https://vkettools.github.io/VitDeckTest/releases/latest.json";

        public static void ShowWindow()
        {
            GetWindow<InfoWindow>(true, "VitDeck");
        }

        private void OnEnable()
        {
            tag = UpdateCheck.GetLatestVersion(releaseUrl);
            versionLabel = "Version : " + VitDeck.GetVersion();
            latestVersionLabel = "Latest Version : " + tag;
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField(versionLabel);
            EditorGUILayout.LabelField(latestVersionLabel);

            if (UpdateCheck.IsLatest())
            {
                EditorGUILayout.LabelField("最新のバージョンです");
                return;
            }

            if (tag == "None")
            {
                EditorGUILayout.LabelField("ネットワークに接続できません");
                return;
            }

            EditorGUILayout.LabelField("最新のバージョンにアップデートしてください");
            if (GUILayout.Button("Update"))
            {
                UpdateCheck.UpdatePackage();
            }
        }
    }
}
