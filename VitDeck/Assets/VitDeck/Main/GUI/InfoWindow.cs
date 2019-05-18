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

        UpdateCheck check = new UpdateCheck();
        PackageDownloader downloader = new PackageDownloader();
        string test_url = "https://github.com/sktkkoo/any-test-repository/releases/download/v1.0/releasetest-1.0.0.unitypackage";
        string test_package_name = "releasetest-1.0.0.unitypackage";


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

            if(check.IsLatest())
            {
                EditorGUILayout.LabelField("最新のバージョンです");
                return;
            }

            EditorGUILayout.LabelField(latestVersionLabel);
            EditorGUILayout.LabelField("最新のバージョンにアップデートしてください");
            if(GUILayout.Button("Update"))
            {
                downloader.Download(test_url, test_package_name);
                AssetDatabase.ImportPackage(Application.dataPath + "/" + test_package_name, true);
            }
        }
    }
}
