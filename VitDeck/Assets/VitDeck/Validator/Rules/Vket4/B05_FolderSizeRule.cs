using UnityEditor;
using System.Text.RegularExpressions;
using System.IO;

namespace VitDeck.Validator
{
    /// <summary>
    /// 入稿データのサイズの超過を検出するルール
    /// </summary>
    /// <remarks>
    /// 入稿フォルダに含まれるファイルサイズの合計を調べる。
    /// </remarks>
    public class FolderSizeRule : BaseRule
    {
        private readonly long limit;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="limit">フォルダのディスクサイズの上限</param>
        public FolderSizeRule(string name, long limit) : base(name)
        {
            this.limit = limit;
        }

        protected override void Logic(ValidationTarget target)
        {
            var path = target.GetBaseFolderPath();

            var di = new DirectoryInfo(path);
            var folderSize = GetDirectorySize(di);

            if (folderSize > limit)
            {
                var reference = AssetDatabase.LoadMainAssetAtPath(path);
                var message = string.Format("入稿フォルダに含まれるファイルサイズの合計が{0}バイトを超えています。", limit);
                AddIssue(new Issue(reference, IssueLevel.Error, message, string.Empty));
            }
        }

        private long GetDirectorySize(DirectoryInfo dirInfo)
        {
            long size = 0;

            foreach (var fi in dirInfo.GetFiles())
            {
                size += fi.Length;
            }

            foreach (var di in dirInfo.GetDirectories())
            {
                size += GetDirectorySize(di);
            }

            return size;
        }
    }
}