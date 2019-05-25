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

        string releaseUrl = Repository.GetLatestReleaseURL();

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

            if (tag == "None")
            {
                EditorGUILayout.LabelField("最新のバージョンを取得できません。");
                EditorGUILayout.LabelField("ネットワーク接続を確認し、しばらく待ってやり直してください。");
                return;
            }

            if (UpdateCheck.IsLatest(releaseUrl))
            {
                EditorGUILayout.LabelField("最新のバージョンです");
                return;
            }

            EditorGUILayout.LabelField("最新のバージョンにアップデートしてください");
            if (GUILayout.Button("Update"))
            {
                UpdateCheck.UpdatePackage(tag);
            }
        }
    }
}
