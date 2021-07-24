using System.Linq;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
	public class CameraComponentMaxCountRule : BaseRule
	{
		private int limit;

		public CameraComponentMaxCountRule(string name, int limit) : base(name)
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
				var message = LocalizedMessage.Get("CameraComponentMaxCountRule.Exceeded", limit, cameraCount);
				var solution = LocalizedMessage.Get("CameraComponentMaxCountRule.Exceeded.Solution");

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