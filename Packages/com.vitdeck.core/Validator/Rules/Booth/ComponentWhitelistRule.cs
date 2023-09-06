using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    /// 使用可能なコンポーネントをホワイトリスト検証する。
    /// </summary>
    /// <remarks>リストに載っていないコンポーネントが検出された場合はエラーメッセージを出す。</remarks>
    public class ComponentWhitelistRule : BaseRule
    {
        private readonly ComponentReference[] references;
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="references">コンポーネントのホワイトリスト</param>
        public ComponentWhitelistRule(string name, ComponentReference[] references) : base(name)
        {
            this.references = references ?? new ComponentReference[] { };
        }

        protected override void Logic(ValidationTarget target)
        {
            foreach (var obj in target.GetAllObjects())
            {
                var components = obj.GetComponents<Component>();
                foreach (var cmp in components)
                {
                    if (cmp == null || cmp.GetType() == typeof(Transform))
                        continue;
                    var findFlg = false;
                    var message = "";
                    foreach (var reference in references)
                    {
                        if (reference != null && reference.Exists(cmp))
                        {
                            findFlg = true;
                            switch (reference.level)
                            {
                                case ValidationLevel.ALLOW:
                                    break;
                                case ValidationLevel.DISALLOW:
                                    message = string.Format("{0}:{1}の使用は許可されていません。", reference.name, cmp.GetType().Name);
                                    AddIssue(new Issue(obj, IssueLevel.Error, message, string.Empty, string.Empty));
                                    break;
                            }
                        }
                    }
                    if (!findFlg)
                    {
                        message = string.Format("{0}は使用可能なコンポーネントリストに登録されていません。", cmp.GetType().Name);
                        var solution = "使用をやめるか運営に問い合わせてください。";
                        AddIssue(new Issue(obj, IssueLevel.Error, message, solution, string.Empty));
                    }
                }
            }
        }
    }
}
