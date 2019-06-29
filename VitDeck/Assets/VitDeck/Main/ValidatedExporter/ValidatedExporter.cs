using System;
using VitDeck.Exporter;
using VitDeck.Validator;

namespace VitDeck.Main.ValidatedExporter
{
    public class ValidatedExporter
    {
        public static ValidatedExportResult ValidatedExport(string baseFolderPath, ExportSetting setting, bool forceExport = false, bool forceOpenScene = false)
        {
            if (baseFolderPath == null)
                throw new ArgumentNullException("Argument `baseFolderPath` is null.");
            var exportFolderPath = setting.ExportFolderPath;
            if (string.IsNullOrEmpty(exportFolderPath) || !exportFolderPath.StartsWith("Assets"))
                throw new ArgumentNullException("Invalid export folder path:" + exportFolderPath);
            if (setting == null)
                throw new ArgumentNullException("Argument `setting` is null.");
            var result = new ValidatedExportResult();
            //validate
            if (!forceExport)
            {
                if (!string.IsNullOrEmpty(setting.ruleSetName))
                {
                    var ruleSet = GetRuleSet(setting.ruleSetName);
                    try
                    {
                        result.validationResults = Validator.Validator.Validate(ruleSet, baseFolderPath, forceOpenScene);
                    }
                    catch (FatalValidationErrorException e)
                    {
                        result.log += "ルールチェック中に問題が発生しました。" + System.Environment.NewLine + e.Message;
                        return result;
                    }
                    if (!result.HasValidationIssues(setting.ignoreValidationWarning ? IssueLevel.Error : IssueLevel.Warning))
                    {
                        result.log += "ルールチェックで問題が発見されました。" + System.Environment.NewLine;
                        return result;
                    }
                }
                else
                {
                    result.log += "ルールセット指定がないため事前チェックを省略します。" + System.Environment.NewLine;
                }
            }

            //export
            result.exportResult = Exporter.Exporter.Export(baseFolderPath, setting, forceExport);
            if (!result.IsExportSuccess)
            {
                result.log += "エクスポートに失敗しました。" + System.Environment.NewLine;
            }
            return result;
        }

        private static IRuleSet GetRuleSet(string ruleSetName)
        {
            return Validator.Validator.GetRuleSet(ruleSetName);
        }
    }
}
