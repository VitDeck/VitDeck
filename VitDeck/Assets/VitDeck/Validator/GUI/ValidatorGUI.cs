using System;
using System.Collections.Generic;
using System.Linq;
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
        private static BaseRuleSet[] ruleSets;
        private static string[] ruleSetNames;
        private static BaseRuleSet[] RuleSets
        {
            get
            {
                if (ruleSets == null)
                {
                    ruleSets = Validator.GetRuleSets();
                }
                return ruleSets;
            }
        }
        private static string[] RuleSetNames
        {
            get
            {
                if (ruleSetNames == null)
                {
                    var names = new List<string>();
                    foreach (var rule in RuleSets)
                        names.Add(rule.RuleSetName);
                    ruleSetNames = names.ToArray();
                }
                return ruleSetNames;
            }
        }
        private BaseRuleSet selectedRuleSet;
        private DefaultAsset baseFolder;
        private ValidationResult[] results;
        private string validationLog;
        private List<Message> messages;
        private bool isHideInfoMessage;
        private Vector2 resultLogAreaScroll;
        private Vector2 msaageAreaScroll;
        private bool isOpenResultLogArea;
        private bool isOpenMessageArea;

        [MenuItem(prefix + "Check Rule", priority = 101)]
        static void Ooen()
        {
            window = GetWindow<ValidatorWindow>(false, "VitDeck");
            window.Init();
            window.Show();
        }

        [InitializeOnLoadMethod]
        private void Init()
        {
            validationLog = "";
            messages = new List<Message>();
            isOpenResultLogArea = false;
            isOpenMessageArea = true;
            LoadSettings();
        }

        private void LoadSettings()
        {
            var userSettings = UserSettingUtility.GetUserSettings();
            baseFolder = AssetDatabase.LoadAssetAtPath<DefaultAsset>(userSettings.validatorFolderPath);
            var ruleSets = RuleSets.Where(a => a.GetType().Name == userSettings.validatorRuleSetType);
            if (ruleSets.Count() > 0)
            {
                selectedRuleSet = ruleSets.First<BaseRuleSet>();
            }
        }

        private void SaveSettings()
        {
            var userSettings = UserSettingUtility.GetUserSettings();
            userSettings.validatorFolderPath = AssetDatabase.GetAssetPath(baseFolder);
            if(selectedRuleSet != null)
            {
                userSettings.validatorRuleSetType = selectedRuleSet.GetType().Name;
            }
            UserSettingUtility.SaveUserSettings(userSettings);
        }

        private void OnGUI()
        {
            EditorGUIUtility.labelWidth = 80;
            EditorGUILayout.LabelField("Rule Checker");
            //Rule set dropdown
            var index = EditorGUILayout.Popup("Rule Set:", GetPopupIndex(selectedRuleSet), RuleSetNames);
            selectedRuleSet = RuleSets[index];
            //Base folder field
            DefaultAsset newFolder = (DefaultAsset)EditorGUILayout.ObjectField("Base Folder:", baseFolder, typeof(DefaultAsset), true);
            var path = AssetDatabase.GetAssetPath(newFolder);
            baseFolder = AssetDatabase.IsValidFolder(path) ? newFolder : null;
            //Log Option
            isHideInfoMessage = EditorGUILayout.ToggleLeft("Show only errors & warnings", isHideInfoMessage);
            //Check button
            if (GUILayout.Button("Check"))
            {
                OnValidate();
            }
            //Result log
            isOpenResultLogArea = EditorGUILayout.Foldout(isOpenResultLogArea, "Result log");
            if (isOpenResultLogArea)
            {
                resultLogAreaScroll = EditorGUILayout.BeginScrollView(resultLogAreaScroll);
                validationLog = GUILayout.TextArea(validationLog, GUILayout.ExpandHeight(true));
                EditorGUILayout.EndScrollView();
            }
            //Help message
            if (messages != null)
            {
                var errorCount = GetMessageCount(MessageType.Error);
                var warningCount = GetMessageCount(MessageType.Warning);
                var infoCount = GetMessageCount(MessageType.Info);
                var sum = errorCount + warningCount + infoCount;
                var CountMessage = string.Format("{0}(Error:{1}  Warning:{2}  Informaiton:{3})", sum, errorCount, warningCount, infoCount);
                isOpenMessageArea = EditorGUILayout.Foldout(isOpenMessageArea, "Messages:" + CountMessage);
                if (isOpenMessageArea)
                {
                    msaageAreaScroll = EditorGUILayout.BeginScrollView(msaageAreaScroll);
                    foreach (var msg in messages)
                    {
                        if (msg.type < (isHideInfoMessage ? MessageType.Warning : MessageType.Info))
                            continue;
                        GetMessageBox(msg);
                    }
                    EditorGUILayout.EndScrollView();
                }
            }
            //Copy Button
            if (GUILayout.Button("Copy result log"))
                OnCopyResultLog();
        }

        private int GetPopupIndex(BaseRuleSet selectedRuleSet)
        {
            var index = 0;
            if(Array.IndexOf(RuleSets, selectedRuleSet) > 0)
            {
                index = Array.IndexOf(RuleSets, selectedRuleSet);
            }
            return index;
        }

        private void OnValidate()
        {
            if (selectedRuleSet == null)
                return;
            ClearLogs();
            SaveSettings();
            var baseFolderPath = AssetDatabase.GetAssetPath(baseFolder);
            OutLog("Starting validation.");
            results = Validator.Validate(selectedRuleSet, baseFolderPath);
            var header = string.Format("- version:{0}", "1.0.0") + Environment.NewLine;//ToDo: バージョン取得方法の検討
            header += string.Format("- Rule set:{0}", selectedRuleSet.RuleSetName) + Environment.NewLine;
            header += string.Format("- Base folder:{0}", baseFolderPath) + Environment.NewLine;
            var log = header;
            log += GetResultLog(results, isHideInfoMessage ? IssueLevel.Warning : IssueLevel.Info);
            SetMessages(header, results);
            OutLog(log);
            OutLog("Validation complete.");
        }

        private void OnCopyResultLog()
        {
            EditorGUIUtility.systemCopyBuffer = validationLog;
        }

        private void GetMessageBox(Message msg)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox(msg.message, msg.type, true);
            if (msg.issue != null && !string.IsNullOrEmpty(msg.issue.solutionURL))
            {
                CustomGUILayout.URLButton("Help", msg.issue.solutionURL, GUILayout.Width(50));
            }
            else
            {
                GUILayout.Space(55);
            }
            GUILayout.EndHorizontal();
        }

        #region Log
        private void ClearLogs()
        {
            validationLog = "";
            messages = new List<Message>();
        }

        private void OutLog(string log)
        {
            Debug.Log(log);
            validationLog += log + System.Environment.NewLine;
        }

        private string GetResultLog(ValidationResult[] results, IssueLevel level)
        {
            var log = "";
            foreach (var result in results)
            {
                log += result.GetResultLog(true, level) + Environment.NewLine;
            }
            return log;
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

        private MessageType GetMessageType(IssueLevel level)
        {
            switch (level)
            {
                case IssueLevel.Info: return MessageType.Info;
                case IssueLevel.Warning: return MessageType.Warning;
                case IssueLevel.Error: return MessageType.Error;
                case IssueLevel.Fatal: return MessageType.Error;
                default: return MessageType.None;
            }
        }

        private int GetMessageCount(MessageType type)
        {
            var count = 0;
            if (messages != null)
            {
                foreach (var msg in messages)
                {
                    if (msg.type == type)
                        count++;
                }
            }
            return count;
        }

        private void SetMessages(string header, ValidationResult[] results)
        {
            if (!HasFatalError(results))
            {
                messages.Add(new Message("ルールチェックが完了しました。" + Environment.NewLine + header, MessageType.Info));
            }
            else
            {
                messages.Add(new Message("ルールチェックを中断しました。" + Environment.NewLine + header, MessageType.Error));
            }
            foreach (var result in results)
            {
                var ruleResultLog = result.GetResultLog(false);
                if (!string.IsNullOrEmpty(ruleResultLog))
                    messages.Add(new Message(ruleResultLog, MessageType.Info, null));
                foreach (var issue in result.Issues)
                {
                    messages.Add(new Message(result.RuleName + Environment.NewLine + issue.message + Environment.NewLine + issue.solution, GetMessageType(issue.level), issue));
                }
            }
        }
        #endregion

        /// <summary>
        /// HelpBoxに表示するメッセージ
        /// </summary>
        private class Message
        {
            public Message(string message, MessageType type, Issue issue = null)
            {
                this.message = message;
                this.type = type;
                this.issue = issue;
            }
            public Issue issue;
            public string message;
            public MessageType type;
        }
    }
}
