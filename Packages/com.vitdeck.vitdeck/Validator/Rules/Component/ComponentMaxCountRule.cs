using System;
using System.Linq;

namespace VitDeck.Validator
{
    /// <summary>
    /// 特定のコンポーネントの合計数を制限します。
    /// </summary>
	public class ComponentMaxCountRule : BaseRule
    {
        private readonly Type type;
        private readonly int limit;

        public ComponentMaxCountRule(string name, Type type, int limit) : base(name)
        {
            this.type = type;
            this.limit = limit;
        }

		protected override void Logic(ValidationTarget target)
		{
			var components = target
				.GetAllObjects()
				.SelectMany(x => x.GetComponents(type));

            var count = components.Count();

			if (count > limit)
			{
				foreach (var component in components)
				{
					AddIssue(new Issue(
						component,
						IssueLevel.Error, 
						message: string.Format("{0}コンポーネントが{1}個あります。", type, count), 
						solution: string.Format("{0}個以下になるよう減らしてください。", limit)));
				}
			}
		}
	}
}
