using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.Exporter.GUI
{
    /// <summary>
    /// エクスポート機能のGUI
    /// </summary>
    public class ExporterWindow : EditorWindow
    {
        const string prefix = "VitDeck/";
        private static ExporterWindow window;
        private static ExportSetting[] settings;
        private static string[] settingNames;
        private static ExportSetting[] Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = Exporter.GetExportSettings();
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
        private ExportSetting selectedSetting;
        private DefaultAsset baseFolder;
        private ExportResult result;
        private string exportLog;
        private List<Message> messages;
        private Vector2 msaageAreaScroll;

        [MenuItem(prefix + "Export Booth", priority = 102)]
        static void Open()
        {
            window = GetWindow<ExporterWindow>(false, "VitDeck");
            window.Init();
            window.Show();
        }

        [InitializeOnLoadMethod]
        private void Init()
        {
            settings = null;
            settingNames = null;
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
            //Export Setting fields
            //ToDo

            //Check button
            EditorGUI.BeginDisabledGroup(selectedSetting == null || baseFolder == null);
            if (GUILayout.Button("Export"))
            {
                OnExport();
            }
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
            OutLog("Start exporting");
            var baseFolderPath = AssetDatabase.GetAssetPath(baseFolder);
            result = Exporter.Export(new string[] { baseFolderPath }, selectedSetting);
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

        private void SetMessages(string header, ExportResult result)
        {
            if (!HasFatalError(result))
            {
                messages.Add(new Message("エクスポートが完了しました。" + Environment.NewLine + header, MessageType.Info));
            }
            else
            {
                messages.Add(new Message("エクスポートを中断しました。" + Environment.NewLine + header, MessageType.Error));
            }
        }

        private bool HasFatalError(ExportResult result)
        {
            return false;
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
