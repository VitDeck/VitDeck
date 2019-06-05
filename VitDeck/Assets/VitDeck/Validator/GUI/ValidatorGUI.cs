using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.Validator.GUI
{
    /// <summary>
    /// テンプレートから作成機能のGUI
    /// </summary>
    public class ValidatorWindow : EditorWindow
    {
        const string prefix = "VitDeck/";
        private static ValidatorWindow window;
        private BaseRuleSet[] ruleSets = { };
        private string[] ruleSetNames = { };
        private int popupIndex = 0;
        private string validationLog;
        private List<Message> messages;
        private DefaultAsset baseFolder;
        private ValidationResult[] results;
        private bool onlyErrorLog;
        private Vector2 scroll;

        [MenuItem(prefix + "Check Rule", priority = 101)]
        static void Ooen()
        {
            window = GetWindow<ValidatorWindow>(false, "VitDeck");
            window.Init();
            window.Show();
        }

        private void Init()
        {
            validationLog = "";
            messages = new List<Message>();
            ruleSets = Validator.GetRuleSets();
            var names = new List<string>();
            foreach (var rule in ruleSets)
                names.Add(rule.RuleSetName);
            ruleSetNames = names.ToArray();
        }

        private void OnGUI()
        {
            EditorGUIUtility.labelWidth = 80;
            EditorGUILayout.LabelField("Rule Checker");
            popupIndex = EditorGUILayout.Popup("RuleSet:", popupIndex, ruleSetNames);
            //BaseFolder field
            DefaultAsset newFolder = (DefaultAsset)EditorGUILayout.ObjectField("Base Folder:", baseFolder, typeof(DefaultAsset), true);
            var path = AssetDatabase.GetAssetPath(newFolder);
            baseFolder = AssetDatabase.IsValidFolder(path) ? newFolder : null;
            //Log Option
            onlyErrorLog = EditorGUILayout.ToggleLeft("Error log only", onlyErrorLog);
            //Check button
            if (GUILayout.Button("Check"))
            {
                var ruleSet = ruleSets[popupIndex];
                validationLog = "";
                messages = new List<Message>();
                OutLog(string.Format("Starting validation. (version:{0})", "1.0.0")); //ToDo: バージョン取得方法の検討
                OutLog(string.Format("Rule set:{0}", ruleSet.RuleSetName));
                results = Validator.Validate(ruleSet, AssetDatabase.GetAssetPath(baseFolder));
                validationLog += GetLog(results);
                if (!HasFatalError(results))
                {
                    messages.Add(new Message("ルールチェックが完了しました。", MessageType.Info));
                }
                else
                {
                    messages.Add(new Message("ルールチェックを中断しました", MessageType.Error));
                }
                OutLog("Validation complete.");
            }
            //Result log
            scroll = EditorGUILayout.BeginScrollView(scroll);
            validationLog = GUILayout.TextArea(validationLog, GUILayout.ExpandHeight(true));
            EditorGUILayout.EndScrollView();
            //Copy Button
            if (GUILayout.Button("Copy result"))
                OnCopyResultLog();
            //HelpMessage
            foreach (var msg in messages)
                EditorGUILayout.HelpBox(msg.message, msg.type, true);
        }

        private void OnCopyResultLog()
        {
            EditorGUIUtility.systemCopyBuffer = validationLog;
        }

        #region Log
        private void OutLog(string log)
        {
            Debug.Log(log);
            validationLog += log + System.Environment.NewLine;
        }

        private bool HasFatalError(ValidationResult[] results)
        {
            foreach (var result in results)
            {
                if (result.Issues.Count > 0)
                {
                    foreach (var issue in result.Issues)
                    {
                        if (issue.level == IssueLevel.Fatal)
                            return true;
                    }
                }
            }
            return false;
        }

        private string GetLog(ValidationResult[] results)
        {
            var log = "";
            foreach (var result in results)
            {
                log += result.GetResultLog() + Environment.NewLine;
            }
            return log;
        }
        #endregion

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
