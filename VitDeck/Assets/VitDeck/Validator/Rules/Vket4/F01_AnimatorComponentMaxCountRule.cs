using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace VitDeck.Validator
{
	public class F01_AnimatorComponentMaxCountRule : BaseRule
	{
		private int limit;

		public F01_AnimatorComponentMaxCountRule(string name, int limit) : base(name)
		{
			this.limit = limit;
		}

		protected override void Logic(ValidationTarget target)
		{
			var allObjects = target.GetAllObjects();
			var animatorObjects = target
				.GetAllObjects()
				.Where(x => x.GetComponent<Animator>() != null);

			var animatorCount = animatorObjects.Count();

			if (animatorCount > limit)
			{
				var message = string.Format("Animatorコンポーネントの使用数が{0}個を超えています。({1}個)", limit, animatorCount);
				var solution = "Animatorコンポーネントの使用数を減らしてください。";

				foreach (var animatorObject in animatorObjects)
				{
					AddIssue(new Issue(
						animatorObject,
						IssueLevel.Error, 
						message, 
						solution));
				}
			}
		}
	}
}