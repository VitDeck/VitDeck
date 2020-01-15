using System.Linq;
using UnityEngine;

namespace VitDeck.Validator
{
	public class F01_AnimatorComponentMaxCountRule : BaseRule
	{
		private int maxCount;

		public F01_AnimatorComponentMaxCountRule(string name, int maxCount = 50) : base(name)
		{
			this.maxCount = maxCount;
		}

		protected override void Logic(ValidationTarget target)
		{
			var allObjects = target.GetAllObjects();
			var animatorCount = allObjects
				.Where(x => x.GetComponent<Animator>() != null)
				.Count();

			if (animatorCount > maxCount)
			{
				var message = string.Format("Animatorコンポーネントの使用数が{0}個を超えています。", maxCount);
				AddIssue(new Issue(null, IssueLevel.Error, message, string.Empty));
			}
		}
	}
}