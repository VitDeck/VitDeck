using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using VitDeck.Exporter;
using VitDeck.Language;
using VitDeck.Utilities;
using VitDeck.Validator;

namespace VitDeck.Main.ValidatedExporter.GUI
{
    /// <summary>
    /// Workflowから呼び出される事を想定した、検証とエクスポートを行うウィンドウ。
    /// </summary>
    public class SimpleValidatedExporterWindow : EditorWindow
    {
        private ExportSetting selectedSetting = null;
        private DefaultAsset baseFolder = null;
        private string ruleSetName = "";

        private ValidatedExportResult result;
        private bool forceExport = false;
        private List<Message> messages;

        private Vector2 messageAreaScroll;
        private string exportLog = "";


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

        public static void ValidateAndExport(ExportSetting setting, DefaultAsset baseFolder)
        {
            var window = GetWindow<SimpleValidatedExporterWindow>(false, "VitDeck");
            window.selectedSetting = setting;
            window.baseFolder = baseFolder;
            window.Show();

            UnityEditorUtility.StartCoroutine(window.ExportCoroutine());
        }

        private void OnGUI()
        {
            EditorGUIUtility.labelWidth = 80;
            EditorGUILayout.LabelField("Exporter");
            EditorGUI.BeginDisabledGroup(true);

            //Rule set dropdown
            EditorGUILayout.ObjectField("Setting:", selectedSetting, typeof(ExportSetting), false);

            //Base folder field
            EditorGUILayout.ObjectField("Base Folder:", baseFolder, typeof(DefaultAsset), true);
            EditorGUI.EndDisabledGroup();

            if (selectedSetting != null)
            {
                if (!string.IsNullOrEmpty(RuleSetName))
                    EditorGUILayout.LabelField("Rule set:", RuleSetName);
                //Setting fields
                GUILayout.TextArea(selectedSetting.Description);
            }

            //ForceExportCheck
            if (result != null && !result.IsExportSuccess
                               && selectedSetting != null && selectedSetting.AllowForceExport)
                forceExport = GUILayout.Toggle(forceExport,
                    LocalizedMessage.Get("ValidatedExporterWindow.ForceExport"));
            //Export button
            EditorGUI.BeginDisabledGroup(selectedSetting == null || baseFolder == null);

            if (GUILayout.Button("Export"))
            {
                UnityEditorUtility.StartCoroutine(ExportCoroutine());
            }

            EditorGUI.EndDisabledGroup();
            //Help message
            if (messages != null)
            {
                messageAreaScroll = EditorGUILayout.BeginScrollView(messageAreaScroll);
                foreach (var msg in messages)
                {
                    GetMessageBox(msg);
                }

                EditorGUILayout.EndScrollView();
            }

            //Copy Button
            if (GUILayout.Button("Copy result log"))
            {
                EditorGUIUtility.systemCopyBuffer = exportLog;
            }
        }

        private void GetMessageBox(Message msg)
        {
            GUILayout.BeginHorizontal();

            var helpBoxRect = EditorGUILayout.BeginHorizontal();
            if (Event.current.type == EventType.MouseUp && helpBoxRect.Contains(Event.current.mousePosition) &&
                msg.issue != null)
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

        private IEnumerator ExportCoroutine()
        {
            if (selectedSetting == null)
                yield break;
            ClearLogs();
            SaveSettings();
            GUIUtilities.OpenPackageScene(AssetUtility.GetId(baseFolder));
            OutLog("Start exporting with validation.");
            var baseFolderPath = AssetDatabase.GetAssetPath(baseFolder);
            var resultEnumerator = ValidatedExporter.ValidatedExport(baseFolderPath, selectedSetting, forceExport);
            while (resultEnumerator.MoveNext())
            {
                yield return null;
            }

            result = (ValidatedExportResult)resultEnumerator.Current;
            Assert.IsNotNull(result);

            AssetDatabase.Refresh();
            var logBuilder = new StringBuilder();
            logBuilder.AppendLine($"- version:{ProductInfoUtility.GetVersion()}");
            logBuilder.AppendLine($"- Rule set:{selectedSetting.SettingName}");
            logBuilder.AppendLine($"- Base folder:{baseFolderPath}");
            if (forceExport)
                logBuilder.AppendLine($"- Force export:{forceExport}");
            forceExport = false;
            SetMessages(logBuilder.ToString(), result);

            logBuilder.AppendLine(result.GetValidationLog());
            logBuilder.AppendLine(result.GetExportLog());
            logBuilder.AppendLine(result.log);
            OutLog(logBuilder.ToString());
            OutLog("Export completed.");
        }

        private void SaveSettings()
        {
            var userSettings = SettingUtility.GetSettings<UserSettings>();
            if (selectedSetting != null)
            {
                userSettings.exporterSettingFileName = selectedSetting.name;
            }

            userSettings.validatorFolderPath = AssetDatabase.GetAssetPath(baseFolder);
            SettingUtility.SaveSettings(userSettings);
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
                messages.Add(new Message(
                    LocalizedMessage.Get("ValidatedExporterWindow.Succeeded") + Environment.NewLine + header,
                    MessageType.Info));
                if (exportResult.GetValidationLog() != "")
                    messages.Add(new Message(exportResult.GetValidationLog(), MessageType.Info));
                if (exportResult.GetExportLog() != "")
                    messages.Add(new Message(exportResult.GetExportLog(), MessageType.Info));
                var package =
                    AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(exportResult.exportResult.exportFilePath);
                var result = new Issue(package, IssueLevel.Info,
                    LocalizedMessage.Get("ValidatedExporterWindow.Succeeded"));
                messages.Add(new Message(
                    LocalizedMessage.Get("ValidatedExporterWindow.SucceededDetail") + Environment.NewLine +
                    exportResult.exportResult.exportFilePath, MessageType.Info, result));
            }
            else
            {
                messages.Add(new Message(
                    LocalizedMessage.Get("ValidatedExporterWindow.Aborted") + Environment.NewLine + header,
                    MessageType.Error));
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
