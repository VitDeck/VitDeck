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
        private static TemplateLoaderWindow window;
        private static string[] templateFolders = { };
        private static string[] templateOptions = { };
        private static int popupIndex = 0;
        private static Vector2 licenceScroll;
        private static TemplateProperty templateProperty;
        private static List<Message> messages = new List<Message>();

        //todo: #17 https://github.com/vkettools/VitDeck/issues/17
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
            templateFolders = TemplateLoader.GetTemplateFolders();
            templateOptions = TemplateLoader.GetTemplateNames(templateFolders);
            popupIndex = 0;
            licenceScroll = new Vector2();
            messages = new List<Message>();
            if (templateFolders.Length > 0)
            {
                templateProperty = TemplateLoader.GetTemplateProperty(templateFolders[popupIndex]);
            }
            else
            {
                messages.Add(new Message("テンプレートがありません。", MessageType.Warning));
            }
        }

        private void OnGUI()
        {
            EditorGUIUtility.labelWidth = 80;
            EditorGUILayout.LabelField("Template Loader");
            popupIndex = EditorGUILayout.Popup("Template:", popupIndex, templateOptions);
            if (UnityEngine.GUI.changed)
            {
                templateProperty = TemplateLoader.GetTemplateProperty(templateFolders[popupIndex]);
                licenceScroll = new Vector2();
                messages = new List<Message>();
            }
            if (templateProperty != null)
            {
                //Template Property
                EditorGUILayout.LabelField("", UnityEngine.GUI.skin.horizontalSlider);
                EditorGUILayout.LabelField("Description:", templateProperty.description);
                EditorGUILayout.LabelField("Developer:", templateProperty.developer);
                if (!string.IsNullOrEmpty(templateProperty.developerUrl))
                    CustomGUILayout.URLButton("Open developer website", templateProperty.developerUrl);
                if (templateProperty.lisenseFile)
                {
                    licenceScroll = EditorGUILayout.BeginScrollView(licenceScroll);
                    GUILayout.TextArea(templateProperty.lisenseFile.text);
                    EditorGUILayout.EndScrollView();
                }
                //Replace List
                EditorGUILayout.LabelField("", UnityEngine.GUI.skin.horizontalSlider);
                //todo: #17 https://github.com/vkettools/VitDeck/issues/17
                tmp = EditorGUILayout.TextField("サークルID:", tmp);

                if (GUILayout.Button("作成"))
                {
                    messages = new List<Message>();
                    var folderName = templateFolders[popupIndex];
                    var templateName = templateOptions[popupIndex];
                    if (TemplateLoader.Load(folderName))
                    {
                        messages.Add(new Message(string.Format("テンプレート`{0}`をコピーしました。", templateName), MessageType.Info));
                    }
                    else
                    {
                        messages.Add(new Message(string.Format("テンプレート`{0}`のコピーに失敗しました。", templateName), MessageType.Error));
                    }
                }
            }
            foreach (var msg in messages)
            {
                EditorGUILayout.HelpBox(msg.message, msg.type, true);
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
