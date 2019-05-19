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
        string release_url = "https://vkettools.github.io/VitDeckTest/releases/latest.json";
        string download_url = "https://github.com/sktkkoo/any-test-repository/releases/download/v1.0/releasetest-1.0.0.unitypackage";
        string package_name = "releasetest-1.0.0.unitypackage";

        public static void ShowWindow()
        {
            GetWindow<InfoWindow>(true, "VitDeck");
        }

        private void OnEnable()
        {
            tag = UpdateCheck.GetLatestVersion(release_url);
            versionLabel = "Version : " + VitDeck.GetVersion();
            latestVersionLabel = "Latest Version : " + tag;
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField(versionLabel);

            if(UpdateCheck.IsLatest(release_url))
            {
                EditorGUILayout.LabelField("最新のバージョンです");
                return;
            }

            EditorGUILayout.LabelField(latestVersionLabel);
            EditorGUILayout.LabelField("最新のバージョンにアップデートしてください");
            if(GUILayout.Button("Update"))
            {
                downloader.Download(download_url, package_name);
                AssetDatabase.ImportPackage(Application.dataPath + "/" + package_name, true);
            }
        }
    }
}
