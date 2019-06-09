using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    /// 実行中Unityのバージョンを検証するルール
    /// </summary>
    public class UnityVersionRule : BaseRule
    {
        private readonly string version;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="version">Unityのバージョン</param>
        /// <remarks>`UnityEngine.Application.unityVersion`で取得した値と`version`で指定した値が同一か検証する。</remarks>
        public UnityVersionRule(string name, string version = "2017.4.15f1") : base(name)
        {
            this.version = version;
        }

        protected override void Logic(string baseFolderPath)
        {
            if (Application.unityVersion != version)
            {
                var message = string.Format("実行中のUnityのバージョン({0})が指定されたバージョンと異なっています。", Application.unityVersion);
                var solution = string.Format("バージョン({0})を使用してください。", version);
                AddIssue(new Issue(null, IssueLevel.Error, message, solution, string.Empty));
            }
        }
    }
}
