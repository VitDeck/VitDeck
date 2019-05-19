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

        PackageDownloader downloader = new PackageDownloader();

        // テスト用
        string releaseUrl = "https://vkettools.github.io/VitDeckTest/releases/latest.json";
        string downloadUrl = "https://github.com/sktkkoo/any-test-repository/releases/download/v1.0/releasetest-1.0.0.unitypackage";
        string packageName = "releasetest-1.0.0.unitypackage";

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

            if(UpdateCheck.IsLatest())
            {
                EditorGUILayout.LabelField("最新のバージョンです");
                return;
            }

            EditorGUILayout.LabelField(latestVersionLabel);
            EditorGUILayout.LabelField("最新のバージョンにアップデートしてください");
            if(GUILayout.Button("Update"))
            {
                downloader.Download(downloadUrl, packageName);
                AssetDatabase.ImportPackage(Application.dataPath + "/" + packageName, true);
            }
        }
    }
}
