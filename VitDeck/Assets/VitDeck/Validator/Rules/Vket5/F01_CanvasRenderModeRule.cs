using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
	

	public class F01_CanvasRenderModeRule : BaseRule
	{
		public F01_CanvasRenderModeRule(string name) : base(name)
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
					var message = LocalizedMessage.Get("F01_CanvasRenderModeRule.CanvasIsNotInWorldSpace", referenceObject);
					AddIssue(new Issue(referenceObject, IssueLevel.Error, message, string.Empty));
				}
			}
		}
	}
}