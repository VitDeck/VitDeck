using System.Collections.Generic;
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
        List<Message> messages = new List<Message>();

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
            TemplateLoaderWindow window = (TemplateLoaderWindow)EditorWindow.GetWindow(typeof(TemplateLoaderWindow), false, "VitDeck");
            TemplateLoader.GetTemplateFolders();
            templateFolders = TemplateLoader.GetTemplateFolders();
            templateOptions = TemplateLoader.GetTemplateNames(templateFolders);
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Template Loader");
            popupIndex = EditorGUILayout.Popup("Template", popupIndex, templateOptions);
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