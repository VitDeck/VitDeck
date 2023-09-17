using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using VitDeck.Exporter;
using VitDeck.Validator;
using VitDeck.Language;
using VitDeck.BuildSizeCalculator;
using VitDeck.Utilities;

namespace VitDeck.Main.ValidatedExporter
{
    public class ValidatedExporter
    {
        /// <param name="baseFolderPath"></param>
        /// <param name="setting"></param>
        /// <param name="forceExport"></param>
        /// <param name="forceOpenScene"></param>
        /// <returns>
        /// <see cref="ValidatedExportResult"/>。
        /// asyncメソッドを利用すると、<see cref="BuildPipeline.BuildAssetBundles"/>時にasyncメソッドが二重実行されてしまう問題を回避するため、TaskではなくIEnumeratorを返す。
        /// </returns>
        public static IEnumerator ValidatedExport(string baseFolderPath, ExportSetting setting,
            bool forceExport = false, bool forceOpenScene = false)
        {
            if (setting == null)
                throw new ArgumentNullException("Argument `setting` is null.");
            if (baseFolderPath == null)
                throw new ArgumentNullException("Argument `baseFolderPath` is null.");
            var exportFolderPath = setting.ExportFolderPath;
            if (string.IsNullOrEmpty(exportFolderPath) || !exportFolderPath.StartsWith("Assets"))
                throw new ArgumentNullException("Invalid export folder path:" + exportFolderPath);
            ExportSettingStock settingStock = new ExportSettingStock(setting);
            var result = new ValidatedExportResult(forceExport);
            //validate
            if (!forceExport)
            {
                if (!string.IsNullOrEmpty(setting.ruleSetName))
                {
                    var ruleSet = GetRuleSet(setting.ruleSetName);
                    if (ruleSet == null)
                    {
                        result.log += LocalizedMessage.Get("ValidatedExporter.ProblemOccurredWhileValidating") +
                                      LocalizedMessage.Get("ValidatedExporter.RuleNotFound", setting.ruleSetName);
                        yield return result;
                        yield break;
                    }

                    var problemOccurred = false;
                    try
                    {
                        result.validationResults =
                            Validator.Validator.Validate(ruleSet, baseFolderPath, forceOpenScene);
                    }
                    catch (FatalValidationErrorException e)
                    {
                        result.log += LocalizedMessage.Get("ValidatedExporter.ProblemOccurredWhileValidating")
                                      + System.Environment.NewLine + e.Message;
                    }

                    if (problemOccurred)
                    {
                        yield return result;
                        yield break;
                    }

                    if (!result.HasValidationIssues(setting.ignoreValidationWarning
                            ? IssueLevel.Error
                            : IssueLevel.Warning))
                    {
                        result.log += LocalizedMessage.Get("ValidatedExporter.IssueFound") + System.Environment.NewLine;
                        problemOccurred = true;
                        yield return result;
                        yield break;
                    }
                }
                else
                {
                    result.log += LocalizedMessage.Get("ValidatedExporter.SkipValidation") + System.Environment.NewLine;
                }

                // build size check
                if (setting.MaxBuildByteCount > 0)
                {
                    var buildByteCountEnumerator = Calculator.ForceRebuild(Path.GetFileName(baseFolderPath));
                    while (buildByteCountEnumerator.MoveNext())
                    {
                        yield return null;
                    }

                    if (buildByteCountEnumerator.Current == null)
                    {
                        result.log += LocalizedMessage.Get("ValidatedExporter.ProblemOccurredWhileBuildSizeCheck")
                                      + System.Environment.NewLine;
                        yield return result;
                        yield break;
                    }

                    var buildByteCount = (int)buildByteCountEnumerator.Current;

                    var buildSizeValidationResult = new ValidationResult("Build Size Check");
                    var formattedBuildSize = MathUtility.FormatByteCount(buildByteCount);
                    buildSizeValidationResult.AddIssue(new Issue(
                        target: null,
                        IssueLevel.Info,
                        LocalizedMessage.Get("BuildSizeCalculator.BuildSize", SceneManager.GetActiveScene().path,
                            formattedBuildSize)
                    ));
                    result.validationResults =
                        result.validationResults.Concat(new[] { buildSizeValidationResult }).ToArray();
                    if (buildByteCount > setting.MaxBuildByteCount)
                    {
                        buildSizeValidationResult.AddIssue(new Issue(
                            target: null,
                            IssueLevel.Fatal,
                            LocalizedMessage.Get("ValidatedExporter.MaxBuildSize",
                                MathUtility.FormatByteCount(setting.MaxBuildByteCount))
                        ));
                        result.log += LocalizedMessage.Get("ValidatedExporter.IssueFound") + System.Environment.NewLine;
                        yield return result;
                        yield break;
                    }
                }
                else
                {
                    result.log += LocalizedMessage.Get("ValidatedExporter.SkipBuildSizeCheck") +
                                  System.Environment.NewLine;
                }
            }

            //export
            result.exportResult = Exporter.Exporter.Export(
                baseFolderPath,
                settingStock.GetSetting(),
                forceExport,
                setting.GetAllowedExtensions()
            );
            if (!result.IsExportSuccess)
            {
                result.log += LocalizedMessage.Get("ValidatedExporter.Failed") + System.Environment.NewLine;
            }

            yield return result;
        }

        private static IRuleSet GetRuleSet(string ruleSetName)
        {
            return Validator.Validator.GetRuleSet(ruleSetName);
        }

        private class ExportSettingStock
        {
            public string SettingName = "";
            public string Description = "";
            public string ExportFolderPath = "Assets/Exports";
            public string fileNameFormat = "export_file.unitypackage";
            public string ruleSetName = "";
            public bool ignoreValidationWarning = false;
            private ExportSetting setting;

            public ExportSettingStock(ExportSetting setting)
            {
                this.setting = setting;
                this.SettingName = setting.SettingName;
                this.Description = setting.Description;
                this.ExportFolderPath = setting.ExportFolderPath;
                this.fileNameFormat = setting.fileNameFormat;
                this.ruleSetName = setting.ruleSetName;
                this.ignoreValidationWarning = setting.ignoreValidationWarning;
            }

            internal ExportSetting GetSetting()
            {
                if (setting != null)
                    return setting;
                else
                {
                    var newSetting = ScriptableObject.CreateInstance(typeof(ExportSetting)) as ExportSetting;
                    newSetting.SettingName = this.SettingName;
                    newSetting.Description = this.Description;
                    newSetting.ExportFolderPath = this.ExportFolderPath;
                    newSetting.fileNameFormat = this.fileNameFormat;
                    newSetting.ruleSetName = this.ruleSetName;
                    newSetting.ignoreValidationWarning = this.ignoreValidationWarning;
                    return newSetting;
                }
            }
        }
    }
}
