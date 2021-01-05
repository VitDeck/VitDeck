using System.Linq;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
	public class ProjectorComponentMaxCountRule : BaseRule
	{
		private int limit;

		public ProjectorComponentMaxCountRule(string name, int limit) : base(name)
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
				var message = LocalizedMessage.Get("ProjectorComponentMaxCountRule.Exceeded", limit, projectorCount);
				var solution = LocalizedMessage.Get("ProjectorComponentMaxCountRule.Exceeded.Solution");

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