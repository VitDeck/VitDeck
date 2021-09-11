using System;
using System.IO;
using System.Linq;
using UnityEditor;
using VitDeck.Exporter;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// 指定した拡張子を持たないファイルを、エクスポートされないファイルとして警告を出します。
    /// </summary>
    public class AllowedExtensionsForExportRule : BaseRule
    {
        private readonly ExportSetting exportSetting;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="exportSetting">対象のExportSetting。</param>
        public AllowedExtensionsForExportRule(string name, ExportSetting exportSetting) : base(name)
        {
            this.exportSetting = exportSetting;
        }

        protected override void Logic(ValidationTarget target)
        {
            var allowedExtensions = this.exportSetting.GetAllowedExtensions();
            if (allowedExtensions == null)
            {
                return;
            }

            var baseFolderPath = target.GetBaseFolderPath();
            var forbiddenPaths = target.GetAllAssetPaths().Where(path => path.StartsWith(baseFolderPath)
                && !AssetDatabase.IsValidFolder(path)
                && !allowedExtensions.Contains(Path.GetExtension(path).ToLower()));
            if (forbiddenPaths.Count() == 0)
            {
                return;
            }

            this.AddIssue(new Issue(
                AssetDatabase.LoadAssetAtPath<DefaultAsset>(baseFolderPath),
                IssueLevel.Warning,
                LocalizedMessage.Get("AllowedExtensionsForExportRule.ForbiddenPaths") + "\n" + string.Join("\n", forbiddenPaths)
            ));
        }
    }
}