using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// 特定の拡張子を持つアセットを検出する
    /// </summary>
    public class AssetExtentionBlacklistRule : BaseRule
    {
        private readonly string[] extentions;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="extentions">検出したい拡張子の配列 (例：`.blend`,`TXT`)</param>
        /// <remarks>
        /// `extentions`の設定文字列は大文字/小文字を考慮しない。
        /// `.`から始まっていない場合は先頭に`.`があるものとして解釈する。
        /// </remarks>
        public AssetExtentionBlacklistRule(string name, string[] extentions) : base(name)
        {
            this.extentions = extentions;
        }

        protected override void Logic(ValidationTarget target)
        {
            var extList = new List<string>();
            foreach (var extention in extentions)
            {
                if (!string.IsNullOrEmpty(extention))
                {
                    var ext = extention.StartsWith(".") ? extention : "." + extention;
                    extList.Add(ext);
                }
                else
                {
                    // ユーザーが対処できるメッセージではないのでコメントアウト
                    //AddIssue(new Issue(null, IssueLevel.Warning, "設定された拡張子は空文字のため無視されます。", string.Empty, string.Empty));
                }
            }
            var hitPaths = target.GetAllAssetPaths()
                .Where(targetPath => extList.Exists(ext => ext.Equals(Path.GetExtension(targetPath), StringComparison.InvariantCultureIgnoreCase)));
            foreach (var path in hitPaths)
            {
                if (AssetDatabase.IsValidFolder(path))
                    continue;
                var obj = AssetDatabase.LoadMainAssetAtPath(path);
                var message = LocalizedMessage.Get("AssetExtentionBlacklistRule.UnauthorizedExtention", Path.GetExtension(path)) + Environment.NewLine + path;
                AddIssue(new Issue(obj, IssueLevel.Error, message, string.Empty, string.Empty));
            }
        }
    }
}