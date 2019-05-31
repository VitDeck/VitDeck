using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;

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
        string version = null;

        string releaseURL = LatestRelease.GetReleaseJsonURL();

        private GUILayoutOption[] buttonStyle = new GUILayoutOption[] { GUILayout.Width(130) };

        public static void ShowWindow()
        {
            GetWindow<InfoWindow>(true, "VitDeck");
        }

        private void OnEnable()
        {
            versionLabel = "Version : " + VitDeck.GetVersion();

            LatestRelease.FetchReleaseInfo(releaseURL);
            if (LatestRelease.GetVersion() == null)
            {
                version = "None";
            }
            else
            {
                version = LatestRelease.GetVersion();
            }
            latestVersionLabel = "Latest Version : " + version;
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField(versionLabel);
            EditorGUILayout.LabelField(latestVersionLabel);

            if (version == "None")
            {
                EditorGUILayout.LabelField("現在、最新のバージョンを取得できません。");
                EditorGUILayout.LabelField("ネットワーク接続を確認し、しばらく待ってやり直してください。");
            }
            else if (UpdateCheck.IsLatest(releaseURL))
            {
                EditorGUILayout.LabelField("最新のバージョンです");
                CustomGUILayout.URLButton("VitDeck on GitHub", "https://github.com/vkettools/VitDeck", buttonStyle);
            }
            else
            {
                EditorGUILayout.LabelField("最新のバージョンにアップデートしてください");
                if (GUILayout.Button("Update"))
                    UpdateCheck.UpdatePackage(version);
            }
            CustomGUILayout.URLButton("VitDeck on GitHub", "https://github.com/vkettools/VitDeck", buttonStyle);
        }
    }
}
