using UnityEditor;
using UnityEngine;

namespace VitDeck.Main.GUI
{
    /// <summary>
    /// VitDeckのバージョン等の情報を表示するウィンドウです。
    /// </summary>
    public class InfoWindow : EditorWindow
    {
        [SerializeField]
        string versionLabel = null;

        public static void ShowWindow()
        {
            GetWindow<InfoWindow>(true, "VitDeck");
        }

        private void OnEnable()
        {
            versionLabel = "Version : " + VitDeck.GetVersion();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField(versionLabel);
        }
    }
}