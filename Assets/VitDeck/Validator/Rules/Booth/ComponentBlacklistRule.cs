using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    /// 使用可能なコンポーネントをブラックリスト検証する。
    /// </summary>
    /// <remarks>リストに載っているコンポーネントが検出された場合にエラーメッセージを出す。</remarks>
    public class ComponentBlacklistRule : BaseRule
    {
        private readonly ComponentReference[] references;
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="references">コンポーネントのブラックリスト</param>
        public ComponentBlacklistRule(string name, ComponentReference[] references) : base(name)
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
                    var message = "";
                    foreach (var reference in references)
                    {
                        if (reference != null && reference.Exists(cmp))
                        {
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
                }
            }
        }
    }
}
