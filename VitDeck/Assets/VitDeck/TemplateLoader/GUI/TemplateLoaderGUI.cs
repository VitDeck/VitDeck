using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.TemplateLoader.GUI
{
    /// <summary>
    /// テンプレートから作成機能のGUI
    /// </summary>
    public class TemplateLoaderWindow : EditorWindow
    {
        const string prefix = "VitDeck/";
        List<Message> messages = new List<Message>();
        private static TemplateLoaderWindow window;
        /// <summary>
        /// テンプレートフォルダ名の配列
        /// </summary>
        private static string[] templateFolders = { };
        /// <summary>
        /// ポップアップ表示名の配列
        /// </summary>
        private static string[] templateOptions = { };
        private static int popupIndex = 0;
        private static TemplateProperty templateProperty;

        private static Vector2 licenceScroll;
        private static string tmp;

        [MenuItem(prefix + "Load Template", priority = 100)]
        static void Ooen()
        {
            window = GetWindow<TemplateLoaderWindow>(false, "VitDeck");
            Init();
            window.Show();
        }

        [InitializeOnLoadMethod]
        static void Init()
        {
            TemplateLoader.GetTemplateFolders();
            templateFolders = TemplateLoader.GetTemplateFolders();
            templateOptions = TemplateLoader.GetTemplateNames(templateFolders);
            popupIndex = 0;
            licenceScroll = new Vector2();
            templateProperty = TemplateLoader.GetTemplateProperty(templateFolders[popupIndex]);
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Template Loader");
            popupIndex = EditorGUILayout.Popup("Template", popupIndex, templateOptions);
            if (UnityEngine.GUI.changed)
            {
                templateProperty = TemplateLoader.GetTemplateProperty(templateFolders[popupIndex]);
                licenceScroll = new Vector2();
                messages = new List<Message>();
            }
            //Template Property
            EditorGUILayout.LabelField("", UnityEngine.GUI.skin.horizontalSlider);
            EditorGUILayout.LabelField("Description:", templateProperty.description);
            EditorGUILayout.LabelField("Developer:", templateProperty.developer);
            if (!string.IsNullOrEmpty(templateProperty.developerUrl))
                CustomGUILayout.URLButton(templateProperty.developerUrl, templateProperty.developerUrl);
            if (templateProperty.lisenseFile)
            {
                licenceScroll = EditorGUILayout.BeginScrollView(licenceScroll);
                GUILayout.TextArea(templateProperty.lisenseFile.text);
                EditorGUILayout.EndScrollView();
            }
            //Replace List
            EditorGUILayout.LabelField("", UnityEngine.GUI.skin.horizontalSlider);
            tmp = EditorGUILayout.TextField("サークルID", tmp);
            if (GUILayout.Button("作成"))
            {
                messages = new List<Message>();
                if (TemplateLoader.Load(templateFolders[popupIndex]))
                {
                    messages.Add(new Message(string.Format("テンプレート`{0}`をコピーしました。", templateFolders[popupIndex]), MessageType.Info));
                }
                else
                {
                    messages.Add(new Message(string.Format("テンプレート`{0}`のコピーに失敗しました。", templateFolders[popupIndex]), MessageType.Error));
                }
            }
            foreach (var message in messages)
            {
                EditorGUILayout.HelpBox(message.message, message.type, true);
            }
        }
        /// <summary>
        /// HelpBoxに表示するメッセージ
        /// </summary>
        internal class Message
        {
            public Message(string _message, MessageType _type)
            {
                message = _message;
                type = _type;
            }
            public string message;
            public MessageType type;
        }
    }
}