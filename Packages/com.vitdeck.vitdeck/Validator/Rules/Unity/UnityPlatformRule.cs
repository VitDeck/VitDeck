
namespace VitDeck.Validator
{
    /// <summary>
    /// 実行中Unityのプラットフォームを検証するルール
    /// </summary>
    public class UnityPlatformRule : BaseRule
    {
        public enum Platform
        {
            Windows,
            Android,
        }

        private readonly Platform platform;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="platform">Unityエディタのプラットフォーム</param>
        public UnityPlatformRule(string name, Platform platform) : base(name)
        {
            this.platform = platform;
        }

        protected override void Logic(ValidationTarget target)
        {
            var currentPlatform =
#if UNITY_STANDALONE_WIN
                Platform.Windows
#elif UNITY_ANDROID
                Platform.Android
#endif
                ;

            if (currentPlatform != this.platform)
            {
                AddIssue(new Issue(
                    target: null,
                    IssueLevel.Error,
                    message: string.Format("現在のプラットフォームは{0}です。", currentPlatform),
                    solution: string.Format("{0}へ切り替える必要があります。", platform)));
            }
        }
    }
}
