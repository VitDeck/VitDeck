using System.Linq;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
	public class F01_ProjectorComponentMaxCountRule : BaseRule
	{
		private int limit;

		public F01_ProjectorComponentMaxCountRule(string name, int limit) : base(name)
		{
			this.limit = limit;
		}

		protected override void Logic(ValidationTarget target)
		{
			var allObjects = target.GetAllObjects();
			var projectorObjects = target
				.GetAllObjects()
				.Where(x => x.GetComponent<Projector>() != null);

			var projectorCount = projectorObjects.Count();

			if (projectorCount > limit)
			{
				var message = LocalizedMessage.Get("F01_ProjectorComponentMaxCountRule.Exceeded", limit, projectorCount);
				var solution = LocalizedMessage.Get("F01_ProjectorComponentMaxCountRule.Exceeded.Solution");

				foreach (var projectorObject in projectorObjects)
				{
					AddIssue(new Issue(
						projectorObject,
						IssueLevel.Error,
						message,
						solution));
				}
			}
		}
	}
}