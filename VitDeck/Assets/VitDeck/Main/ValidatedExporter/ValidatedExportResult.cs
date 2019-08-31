using VitDeck.Exporter;
using VitDeck.Validator;

namespace VitDeck.Main.ValidatedExporter
{
    public class ValidatedExportResult
    {
        public bool forceExport;
        public string log;
        public ValidationResult[] validationResults;
        public ExportResult exportResult;

        public ValidatedExportResult(bool forceExport)
        {
            this.forceExport = forceExport;
        }

        /// <summary>
        /// ルールチェック結果に指定されたレベル以上のIssueが存在するかチェックする。
        /// </summary>
        public bool HasValidationIssues(IssueLevel level)
        {
            if (validationResults != null)
            {
                foreach (var result in validationResults)
                    foreach (var issue in result.Issues)
                        if (issue.level >= level)
                            return false;
            }
            return true;
        }
        /// <summary>
        /// エクスポートが成功したかどうかを返す
        /// </summary>
        public bool IsExportSuccess
        {
            get
            {
                return exportResult != null ? exportResult.exportResult : false;
            }
        }

        public string GetValidationLog()
        {
            var log = "";
            if (validationResults != null)
            {
                foreach (var result in validationResults)
                {
                    log += result.GetResultLog() + System.Environment.NewLine;
                }
            }
            return log;
        }

        public string GetExportLog()
        {
            return exportResult != null ? exportResult.log : "";
        }
    }
}