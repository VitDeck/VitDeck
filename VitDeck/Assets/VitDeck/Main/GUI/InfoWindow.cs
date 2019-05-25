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
        string tag = null;

        string releaseUrl = Repository.GetLatestReleaseURL();

        private GUILayoutOption[] buttonStyle = new GUILayoutOption[] { GUILayout.Width(130) };

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
                EditorGUILayout.LabelField("現在、最新のバージョンを取得できません。");
                EditorGUILayout.LabelField("ネットワーク接続を確認し、しばらく待ってやり直してください。");
            }
            else if (UpdateCheck.IsLatest(releaseUrl))
            {
                EditorGUILayout.LabelField("最新のバージョンです");
                CustomGUILayout.URLButton("VitDeck on GitHub", "https://github.com/vkettools/VitDeck", buttonStyle);
            }
            else
            {
                EditorGUILayout.LabelField("最新のバージョンにアップデートしてください");
                if (GUILayout.Button("Update"))
                    UpdateCheck.UpdatePackage(tag);
            }
            CustomGUILayout.URLButton("VitDeck on GitHub", "https://github.com/vkettools/VitDeck", buttonStyle);
        }
    }
}
