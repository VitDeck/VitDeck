using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Exporter;
using VitDeck.Utilities;
using VitDeck.Validator;
using VitDeck.Language;

namespace VitDeck.Main.ValidatedExporter.GUI
{
    /// <summary>
    /// ルールチェック付きエクスポート機能のGUI
    /// </summary>
    public class ValidatedExporterWindow : EditorWindow
    {
        const string prefix = "VitDeck/";
        private static ValidatedExporterWindow window;
        private static ExportSetting[] settings;
        private static string[] settingNames;
        private static ExportSetting[] Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = Exporter.Exporter.GetExportSettings();
                }
                return settings;
            }
        }
        private static string[] SettingNames
        {
            get
            {
                if (settingNames == null)
                {
                    var names = new List<string>();
                    foreach (var setting in Settings)
                        names.Add(setting.SettingName);
                    settingNames = names.Count() > 0 ? names.ToArray() : new string[] { "Settings Not Found" };
                }
                return settingNames;
            }
        }
        private string ruleSetName = "";
        private string RuleSetName
        {
            get
            {
                if (ruleSetName == "" && selectedSetting != null)
                {
                    var ruleSet = Validator.Validator.GetRuleSet(selectedSetting.ruleSetName);
                    ruleSetName = ruleSet != null ? ruleSet.RuleSetName : "";
                }
                return ruleSetName;
            }
        }
        private ExportSetting selectedSetting;
        private DefaultAsset baseFolder;
        private bool forceExport;
        private ValidatedExportResult result;
        private string exportLog;
        private List<Message> messages;
        private Vector2 msaageAreaScroll;

#if !VITDECK_HIDE_MENUITEM
        [MenuItem(prefix + "Export Booth", priority = 104)]
#endif
        static void Open()
        {
            window = GetWindow<ValidatedExporterWindow>(false, "VitDeck");
            window.Init();
            window.Show();
        }

        [InitializeOnLoadMethod]
        private void Init()
        {
            settings = null;
            settingNames = null;
            forceExport = false;
            ruleSetName = "";
            exportLog = "";
            result = null;
            messages = new List<Message>();
            LoadSettings();
        }

        private void LoadSettings()
        {
            var userSettings = UserSettingUtility.GetUserSettings();
            baseFolder = AssetDatabase.LoadAssetAtPath<DefaultAsset>(userSettings.validatorFolderPath);
            var settings = Settings.Where(a => a.name == userSettings.exporterSettingFileName);
            if (settings.Count() > 0)
            {
                selectedSetting = settings.First<ExportSetting>();
            }
        }

        private void SaveSettings()
        {
            var userSettings = UserSettingUtility.GetUserSettings();
            if (selectedSetting != null)
            {
                userSettings.exporterSettingFileName = selectedSetting.name;
            }
            userSettings.validatorFolderPath = AssetDatabase.GetAssetPath(baseFolder);
            UserSettingUtility.SaveUserSettings(userSettings);
        }

        private void OnGUI()
        {
            EditorGUIUtility.labelWidth = 80;
            EditorGUILayout.LabelField("Exporter");
            //Rule set dropdown
            EditorGUI.BeginChangeCheck();
            var index = EditorGUILayout.Popup("Setting:", GetPopupIndex(selectedSetting), SettingNames);
            selectedSetting = Settings.Count() > 0 ? Settings[index] : null;
            if(EditorGUI.EndChangeCheck())
            {
                ruleSetName = "";
            }
            //Base folder field
            DefaultAsset newFolder = (DefaultAsset)EditorGUILayout.ObjectField("Base Folder:", baseFolder, typeof(DefaultAsset), true);
            var path = AssetDatabase.GetAssetPath(newFolder);
            baseFolder = AssetDatabase.IsValidFolder(path) ? newFolder : null;
            if (selectedSetting != null)
            {
                if (!string.IsNullOrEmpty(RuleSetName))
                    EditorGUILayout.LabelField("Rule set:", RuleSetName);
                //Setting fields
                GUILayout.TextArea(selectedSetting.Description);
            }
            //ForceExportCheck
            if (result != null && !result.IsExportSuccess)
                forceExport = GUILayout.Toggle(forceExport, LocalizedMessage.Get("ValidatedExporterWindow.ForceExport"));
            //Export button
            EditorGUI.BeginDisabledGroup(selectedSetting == null || baseFolder == null);

            if (GUILayout.Button("Export"))
            {
                OnExport();
            }

            EditorGUI.EndDisabledGroup();
            //Help message
            if (messages != null)
            {
                msaageAreaScroll = EditorGUILayout.BeginScrollView(msaageAreaScroll);
                foreach (var msg in messages)
                {
                    GetMessageBox(msg);
                }
                EditorGUILayout.EndScrollView();
            }
            //Copy Button
            if (GUILayout.Button("Copy result log"))
                OnCopyResultLog();
        }

        private int GetPopupIndex(ExportSetting setting)
        {
            var index = 0;
            if (setting != null && Array.IndexOf(Settings, setting) > 0)
            {
                index = Array.IndexOf(Settings, setting);
            }
            return index;
        }

        private void OnExport()
        {
            if (selectedSetting == null)
                return;
            ClearLogs();
            SaveSettings();
            OutLog("Start exporting with validation.");
            var baseFolderPath = AssetDatabase.GetAssetPath(baseFolder);
            result = ValidatedExporter.ValidatedExport(baseFolderPath, selectedSetting, forceExport);
            AssetDatabase.Refresh();
            var header = string.Format("- version:{0}", ProductInfoUtility.GetVersion()) + Environment.NewLine;
            header += string.Format("- Rule set:{0}", selectedSetting.SettingName) + Environment.NewLine;
            header += string.Format("- Base folder:{0}", baseFolderPath) + Environment.NewLine;
            if (forceExport)
                header += string.Format("- Force export:{0}", forceExport) + Environment.NewLine;
            var log = header + result.GetValidationLog() + result.GetExportLog() + result.log;
            forceExport = false;
            SetMessages(header, result);
            OutLog(log);
            OutLog("Export completed.");
        }

        private void OnCopyResultLog()
        {
            EditorGUIUtility.systemCopyBuffer = exportLog;
        }

        private void GetMessageBox(Message msg)
        {
            GUILayout.BeginHorizontal();

            var helpBoxRect = EditorGUILayout.BeginHorizontal();
            if (Event.current.type == EventType.MouseUp && helpBoxRect.Contains(Event.current.mousePosition) && msg.issue != null)
                EditorGUIUtility.PingObject(msg.issue.target);
            EditorGUILayout.HelpBox(msg.message, msg.type, true);
            EditorGUILayout.EndHorizontal();
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
            exportLog = "";
            messages = new List<Message>();
        }

        private void OutLog(string log)
        {
            Debug.Log(log);
            exportLog += log + System.Environment.NewLine;
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

        private void SetMessages(string header, ValidatedExportResult exportResult)
        {
            if (exportResult != null && exportResult.validationResults != null)
            {
                foreach (var result in exportResult.validationResults)
                {
                    var ruleResultLog = result.GetResultLog(false);
                    if (!string.IsNullOrEmpty(ruleResultLog))
                        messages.Add(new Message(ruleResultLog, MessageType.Info, null));
                    foreach (var issue in result.Issues)
                    {
                        var txt = result.RuleName + Environment.NewLine;
                        if (issue.target != null)
                            txt += issue.target.name + Environment.NewLine;
                        txt += issue.message + Environment.NewLine + issue.solution;
                        messages.Add(new Message(txt, GetMessageType(issue.level), issue));
                    }
                }
            }
            if (exportResult.IsExportSuccess)
            {
                messages.Add(new Message(LocalizedMessage.Get("ValidatedExporterWindow.Succeeded") + Environment.NewLine + header, MessageType.Info));
                if (exportResult.GetValidationLog() != "")
                    messages.Add(new Message(exportResult.GetValidationLog(), MessageType.Info));
                if (exportResult.GetExportLog() != "")
                    messages.Add(new Message(exportResult.GetExportLog(), MessageType.Info));
                var package = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(exportResult.exportResult.exportFilePath);
                var result = new Issue(package, IssueLevel.Info, LocalizedMessage.Get("ValidatedExporterWindow.Succeeded"));
                messages.Add(new Message(LocalizedMessage.Get("ValidatedExporterWindow.SucceededDetail") + Environment.NewLine + exportResult.exportResult.exportFilePath, MessageType.Info, result));
            }
            else
            {
                messages.Add(new Message(LocalizedMessage.Get("ValidatedExporterWindow.Aborted") + Environment.NewLine + header, MessageType.Error));
                messages.Add(new Message(exportResult.log, MessageType.Info));
                if (exportResult.GetExportLog() != "")
                    messages.Add(new Message(exportResult.GetExportLog(), MessageType.Error));
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
