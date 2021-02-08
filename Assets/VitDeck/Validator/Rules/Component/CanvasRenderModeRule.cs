using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
	

	public class CanvasRenderModeRule : BaseRule
	{
		public CanvasRenderModeRule(string name) : base(name)
		{
		}

		protected override void Logic(ValidationTarget target)
		{
			var allObjects = target.GetAllObjects();
			foreach (var referenceObject in allObjects)
			{
				var isWorldSpaceRenderMode = referenceObject
					.GetComponents<Canvas>()
					.Any(x => x.renderMode != RenderMode.WorldSpace);
			
				if (isWorldSpaceRenderMode)
				{
					var message = LocalizedMessage.Get("CanvasRenderModeRule.CanvasIsNotInWorldSpace", referenceObject);
					AddIssue(new Issue(referenceObject, IssueLevel.Error, message, string.Empty));
				}
			}
		}
	}
}