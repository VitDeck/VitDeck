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

        private GUILayoutOption[] buttonStyle = new GUILayoutOption[] { GUILayout.Width(130) };

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

            CustomGUILayout.URLButton("VitDeck on GitHub", "https://github.com/vkettools/VitDeck", buttonStyle);
        }
    }
}
