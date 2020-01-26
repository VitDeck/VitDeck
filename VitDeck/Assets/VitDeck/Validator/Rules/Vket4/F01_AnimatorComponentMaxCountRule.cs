using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using VitDeck.Language;

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
				var message = LocalizedMessage.Get("F01_AnimatorComponentMaxCountRule.Exceeded", limit, animatorCount);
				var solution = "F01_AnimatorComponentMaxCountRule.Exceeded.Solution";

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