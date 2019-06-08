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

        private static readonly string releaseURL = JsonReleaseInfo.GetReleaseUrl();

        private GUILayoutOption[] buttonStyle = new GUILayoutOption[] { GUILayout.Width(130) };

        public static void ShowWindow()
        {
            GetWindow<InfoWindow>(true, "VitDeck");
        }

        private void OnEnable()
        {
            versionLabel = "Version : " + VersionUtility.GetVersion();

            JsonReleaseInfo.FetchInfo(releaseURL);
            if (JsonReleaseInfo.GetVersion() == null)
            {
                version = "None";
            }
            else
            {
                version = JsonReleaseInfo.GetVersion();
            }
            latestVersionLabel = "Latest Version : " + version;
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField(versionLabel);
            EditorGUILayout.LabelField(latestVersionLabel);
            VersionCheckLabelField();
            CustomGUILayout.URLButton("VitDeck on GitHub", "https://github.com/vkettools/VitDeck", buttonStyle);
        }

        private void VersionCheckLabelField()
        {
            if (version == "None")
            {
                EditorGUILayout.LabelField("現在、最新のバージョンを取得できません。");
                EditorGUILayout.LabelField("ネットワーク接続を確認し、しばらく待ってやり直してください。");
            }
            else if (UpdateCheck.IsLatest(releaseURL))
            {
                EditorGUILayout.LabelField("最新のバージョンです");
            }
            else
            {
                EditorGUILayout.LabelField("最新のバージョンにアップデートしてください");
                if (GUILayout.Button("Update"))
                    UpdateCheck.UpdatePackage(version);
            }
        }
    }
}
