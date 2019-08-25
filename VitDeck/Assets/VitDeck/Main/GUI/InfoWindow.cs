using System;
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
        string latestVersion = null;

        private static string developerLinkTitle = null;
        private static string developerLinkURL = null;
        private GUILayoutOption[] buttonStyle = new GUILayoutOption[] { GUILayout.Width(130) };

        public static void ShowWindow()
        {
            GetWindow<InfoWindow>(true, "VitDeck");
            AssetDatabase.importPackageCompleted -= ImportCallback;
            AssetDatabase.importPackageCompleted += ImportCallback;
        }

        private static void ImportCallback(string packageName)
        {
            var window = GetWindow<InfoWindow>(true, "VitDeck");
            if (window != null)
                window.Init();
        }

        private void Init()
        {
            versionLabel = "Version : " + ProductInfoUtility.GetVersion();
            developerLinkTitle = ProductInfoUtility.GetDeveloperLinkTitle();
            developerLinkURL = ProductInfoUtility.GetDeveloperLinkURL();
            if (UpdateCheck.Enabled)
            {
                var version = UpdateCheck.GetLatestVersion();
                if (version == null)
                {
                    latestVersion = "None";
                }
                else
                {
                    latestVersion = version;
                }
                latestVersionLabel = "Latest Version : " + latestVersion;
            }
        }

        private void OnEnable()
        {
            Init();
        }

        private void OnGUI()
        {
            //Version
            EditorGUILayout.LabelField(versionLabel);
            //Updater
            if (UpdateCheck.Enabled)
            {
                EditorGUILayout.LabelField(latestVersionLabel);
                VersionCheckLabelField();
            }
            //Developer info
            if (!string.IsNullOrEmpty(developerLinkTitle) &&
                !string.IsNullOrEmpty(developerLinkURL))
            {
                CustomGUILayout.URLButton(developerLinkTitle, developerLinkURL, buttonStyle);
            }
        }

        private void VersionCheckLabelField()
        {
            if (latestVersion == "None")
            {
                EditorGUILayout.LabelField("現在、最新のバージョンを取得できません。");
                EditorGUILayout.LabelField("ネットワーク接続を確認し、しばらく待ってやり直してください。");
            }
            else if (UpdateCheck.IsLatest())
            {
                EditorGUILayout.LabelField("最新のバージョンです");
            }
            else
            {
                EditorGUILayout.LabelField("最新のバージョンにアップデートしてください");
                if (GUILayout.Button("Update"))
                    UpdateCheck.UpdatePackage(latestVersion);
            }
        }
    }
}
