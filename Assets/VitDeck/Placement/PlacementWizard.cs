using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using VitDeck.Utilities;
using VitDeck.Validator;
using VitDeck.BuildSizeCalculator;
using VitDeck.Exporter;
using VitDeck.Language;

namespace VitDeck.Placement
{
    public class PlacementWizard : ScriptableWizard
    {
        private static readonly Regex FilePathPattern = new Regex(@"[/\\][^/\\]*?_([1-9][0-9]*)_[^/\\]*\.unitypackage$");

        [SerializeField]
        private ExportSetting exportSetting;

        [SerializeField]
        private SceneAsset location = null;

        private string folderPath;

        [MenuItem("VitDeck/Placement Tool", priority = 120)]
        public static void Open()
        {
            ScriptableWizard.DisplayWizard<PlacementWizard>("VitDeck", "Select folder and Import unitypackages").LoadSettings();
        }

        protected override bool DrawWizardGUI()
        {
            base.DrawWizardGUI();
            EditorGUILayout.HelpBox(
                "選択したフォルダ内に含まれるunitypackageをインポートします。\n\nパッケージ名に含まれる「_」で囲まれた数字をIDとして扱います。",
                MessageType.None
            );

            this.isValid = this.exportSetting != null && this.location != null;
            return true;
        }

        private void OnWizardCreate()
        {
            this.folderPath = EditorUtility.OpenFolderPanel(title: "VitDeck", folder: this.folderPath, defaultName: null);
            if (string.IsNullOrEmpty(this.folderPath))
            {
                return;
            }

            this.SaveSettings();

            var allowedExtensions = this.exportSetting.GetAllowedExtensions();
            IRuleSet ruleSet = null;
            if (string.IsNullOrEmpty(this.exportSetting.ruleSetName))
            {
                Debug.LogWarning(LocalizedMessage.Get("ValidatedExporter.SkipValidation"));
            }
            else
            {
                ruleSet = Validator.Validator.GetRuleSet(this.exportSetting.ruleSetName);
                if (ruleSet == null)
                {
                    throw new Exception($"指定されたルールセット「{this.exportSetting.ruleSetName}」が見つかりません。");
                }
            }
            if (this.exportSetting.MaxBuildByteCount == 0)
            {
                Debug.LogWarning(LocalizedMessage.Get("ValidatedExporter.SkipBuildSizeCheck"));
            }

            var pathsNotMatchingPattern = new List<string>();
            var pathIdPairs = Directory.GetFiles(this.folderPath).ToDictionary(path => path, path => {
                var match = FilePathPattern.Match(path);
                if (!match.Success)
                {
                    pathsNotMatchingPattern.Add(path);
                    return null;
                }

                return FilePathPattern.Match(path).Groups[1].Value;
            });

            if (pathsNotMatchingPattern.Count > 0)
            {
                EditorUtility.DisplayDialog(
                    "VitDeck",
                    "次のファイルは入稿パッケージのファイル名パターンに一致しません:\n" + string.Join("\n", pathsNotMatchingPattern),
                    "OK"
                );
                return;
            }

            var pathsIncludingDuplicatedId = pathIdPairs
                .GroupBy(pathIdPair => pathIdPair.Value, pathIdPair => pathIdPair.Key)
                .Where(idPathsPair => idPathsPair.Count() > 1)
                .SelectMany(idPathsPair => idPathsPair);
            if (pathsIncludingDuplicatedId.Count() > 0)
            {
                EditorUtility.DisplayDialog(
                    "VitDeck",
                    "次のファイルはIDが重複しています:\n" + string.Join("\n", pathsIncludingDuplicatedId),
                    "OK"
                );
                return;
            }

            var idMessagePairs = pathIdPairs.ToDictionary(pathIdPair => pathIdPair.Value, pathIdPair =>
            {
                var (path, id) = pathIdPair;

                // インポート
                try
                {
                    PackageImporter.Import(id, path, allowedExtensions);
                }
                catch (FatalValidationErrorException exception)
                {
                    return exception.Message;
                };

                // 入稿シーンを開く
                var scenePath = $"Assets/{id}/{id}.unity";
                if (AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath) == null)
                {
                    return $"シーン「{scenePath}」が存在しません。";
                }
                EditorSceneManager.OpenScene(scenePath);

                // バリデーション
                if (ruleSet != null)
                {
                    ValidationResult[] validationResults;
                    try
                    {
                        validationResults = Validator.Validator.Validate(ruleSet, "Assets/" + id, forceOpenScene: true);
                    }
                    catch (FatalValidationErrorException exception)
                    {
                        return LocalizedMessage.Get("ValidatedExporter.ProblemOccurredWhileValidating") + "\n" + exception.Message;
                    }
                    var minIssueLevel = this.exportSetting.ignoreValidationWarning ? IssueLevel.Error : IssueLevel.Warning;
                    if (validationResults.SelectMany(result => result.Issues).Any(issue => issue.level >= minIssueLevel))
                    {
                        return LocalizedMessage.Get("ValidatedExporter.IssueFound") + "\n" + string.Join(
                            "\n",
                            validationResults
                                .Where(result => result.Issues.Any(issue => issue.level >= minIssueLevel))
                                .Select(result => result.RuleName + ":\n"
                                    + string.Join("\n", result.Issues.Where(issue => issue.level >= minIssueLevel).Select(issue => "    " + issue.message)))
                        );
                    }
                }

                // ビルド容量チェック
                if (this.exportSetting.MaxBuildByteCount > 0)
                {
                    var buildByteCount = Calculator.ForceRebuild();
                    if (buildByteCount == null)
                    {
                        return LocalizedMessage.Get("ValidatedExporter.ProblemOccurredWhileBuildSizeCheck");
                    }

                    if (buildByteCount > this.exportSetting.MaxBuildByteCount)
                    {
                        return $"ビルド容量 {MathUtility.FormatByteCount((int)buildByteCount)} が {MathUtility.FormatByteCount(this.exportSetting.MaxBuildByteCount)} を超過しています。";
                    }
                }

                // 配置
                Placement.Place(id, this.location);

                return "配置完了";
            });

            var message = string.Join("\n\n", idMessagePairs.Select(idMessagePair => $"[{idMessagePair.Key}]\n{idMessagePair.Value}"));
            Debug.Log("\n" + message);
            EditorUtility.DisplayDialog("VitDeck", message, "OK");
        }

        private void LoadSettings()
        {
            var settings = SettingUtility.GetSettings<PlacementSettings>();
            this.exportSetting = settings.ExportSetting;
            this.location = settings.Location;
            this.folderPath = settings.FolderPath;
        }

        private void SaveSettings()
        {
            var settings = SettingUtility.GetSettings<PlacementSettings>();
            settings.ExportSetting = this.exportSetting;
            settings.Location = this.location;
            settings.FolderPath = this.folderPath;
            SettingUtility.SaveSettings(settings);
        }
    }
}
