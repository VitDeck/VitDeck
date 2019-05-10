using UnityEditor;
using UnityEngine;

namespace VitDeck.TemplateLoader.GUI
{
    /// <summary>
    /// テンプレートから作成機能のGUI
    /// </summary>
    public class TemplateLoaderWindow : EditorWindow
    {
        const string prefix = "VitDeck/";

        /// <summary>
        /// テンプレートフォルダ名の配列
        /// </summary>
        private static string[] templateFolders = { };
        /// <summary>
        /// ポップアップ表示名の配列
        /// </summary>
        private static string[] templateOptions = { };
        private static int popupIndex = 0;

        [MenuItem(prefix + "Load Template", priority = 100)]
        static void Init()
        {
            TemplateLoaderWindow window = (TemplateLoaderWindow)EditorWindow.GetWindow(typeof(TemplateLoaderWindow));
            TemplateLoader.GetTemplateFolders();
            templateFolders = TemplateLoader.GetTemplateFolders();
            templateOptions = TemplateLoader.GetTemplateNames(templateFolders);
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Template");
            popupIndex = EditorGUILayout.Popup(popupIndex, templateOptions);
            if (GUILayout.Button("作成"))
            {
                TemplateLoader.Load(templateFolders[popupIndex]);
            }
        }
    }
}