using UnityEditor;

namespace VitDeck.Validator
{
    /// <summary>
    /// 検証ルールの基本となる抽象クラス
    /// </summary>
    public abstract class BaseRule : IRule
    {
        /// <summary>
        /// ルール名
        /// </summary>
        protected string name;
        /// <summary>
        /// 検証結果
        /// </summary>
        protected ValidationResult result;

        public BaseRule(string name)
        {
            this.name = name;
            result = new ValidationResult(name);
        }
        /// <summary>
        /// 検証結果を返す
        /// </summary>
        /// <returns>検証結果</returns>
        public ValidationResult GetResult()
        {
            return result;
        }

        protected void AddResultLog(string log)
        {
            result.AddResultLog(log);
        }

        protected void AddIssue(Issue issue)
        {
            result.AddIssue(issue);
        }
        /// <summary>
        /// 定められたルールに従って検証する。検証後にresultフィールドを結果として返す
        /// </summary>
        /// <param name="baseFolder">ベースフォルダの`Assets/`から始まる相対パス。</param>
        /// <returns>`result`に格納された検証結果</returns>
        public ValidationResult Validate(ValidationTarget target)
        {
            result = new ValidationResult(name);
            try
            {
                var path = target.GetBaseFolderPath();
                if (!AssetDatabase.IsValidFolder(path))
                    throw new FatalValidationErrorException(string.Format("正しいベースフォルダを指定してください。:{0}", path));
                Logic(target);
            }
            catch (FatalValidationErrorException e)
            {
                result.AddIssue(new Issue(null, IssueLevel.Fatal, e.Message));
                throw e;
            }
            return result;
        }
        /// <summary>
        /// ルールの検証ロジック。
        /// </summary>
        /// <param name="baseFolder">ベースフォルダの`Assets/`から始まる相対パス。</param>
        protected abstract void Logic(ValidationTarget target);
    }
}