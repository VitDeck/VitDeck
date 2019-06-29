using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;
using VitDeck.Main;
using VitDeck.Exporter;
using VitDeck.Main.ValidatedExporter;

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
                    ruleSetName = Validator.Validator.GetRuleSet(selectedSetting.ruleSetName).RuleSetName;
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

        [MenuItem(prefix + "Export Booth", priority = 102)]
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
            var index = EditorGUILayout.Popup("Setting:", GetPopupIndex(selectedSetting), SettingNames);
            selectedSetting = Settings.Count() > 0 ? Settings[index] : null;
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
                forceExport = GUILayout.Toggle(forceExport, "エラーを無視して再エクスポートする");
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
            forceExport = false;
            var header = string.Format("- version:{0}", VersionUtility.GetVersion()) + Environment.NewLine;
            header += string.Format("- Rule set:{0}", selectedSetting.SettingName) + Environment.NewLine;
            header += string.Format("- Base folder:{0}", baseFolderPath) + Environment.NewLine;
            var log = header + result.log;
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
            EditorGUILayout.HelpBox(msg.message, msg.type, true);
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

        private void SetMessages(string header, ValidatedExportResult result)
        {
            if (result.IsExportSuccess)
            {
                messages.Add(new Message("エクスポートが完了しました。" + Environment.NewLine + header, MessageType.Info));
                if (result.GetValidationLog() != "")
                    messages.Add(new Message(result.GetValidationLog(), MessageType.Info));
                if (result.GetExportLog() != "")
                    messages.Add(new Message(result.GetExportLog(), MessageType.Info));
                messages.Add(new Message("以下のunitypackageをエクスポートしました。" + Environment.NewLine + result.exportResult.exportFilePath, MessageType.Info));
            }
            else
            {
                messages.Add(new Message("エクスポートを中断しました。" + Environment.NewLine + header, MessageType.Error));
                messages.Add(new Message(result.log, MessageType.Info));
                if (result.GetValidationLog() != "")
                    messages.Add(new Message(result.GetValidationLog(), MessageType.Error));
                if (result.GetExportLog() != "")
                    messages.Add(new Message(result.GetExportLog(), MessageType.Error));
            }
        }
        #endregion

        /// <summary>
        /// HelpBoxに表示するメッセージ
        /// </summary>
        private class Message
        {
            public Message(string message, MessageType type)
            {
                this.message = message;
                this.type = type;
            }
            public string message;
            public MessageType type;
        }
    }
}
