using System.Linq;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
	public class F01_CameraComponentMaxCountRule : BaseRule
	{
		private int limit;

		public F01_CameraComponentMaxCountRule(string name, int limit) : base(name)
		{
			this.limit = limit;
		}

		protected override void Logic(ValidationTarget target)
		{
			var allObjects = target.GetAllObjects();
			var cameraObjects = target
				.GetAllObjects()
				.Where(x => x.GetComponent<Camera>() != null);

			var cameraCount = cameraObjects.Count();

			if (cameraCount > limit)
			{
				var message = LocalizedMessage.Get("F01_CameraComponentMaxCountRule.Exceeded", limit, cameraCount);
				var solution = LocalizedMessage.Get("F01_CameraComponentMaxCountRule.Exceeded.Solution");

				foreach (var cameraObject in cameraObjects)
				{
					AddIssue(new Issue(
						cameraObject,
						IssueLevel.Error,
						message,
						solution));
				}
			}
		}
	}
}