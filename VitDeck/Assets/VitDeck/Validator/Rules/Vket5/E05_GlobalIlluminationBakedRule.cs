using System;
using UnityEditor;
using UnityEngine;
using System.Linq;
using VitDeck.Language;

namespace VitDeck.Validator
{
	public class E05_GlobalIlluminationBakedRule : BaseRule
	{
		public E05_GlobalIlluminationBakedRule(string name) : base(name)
		{
		}

		protected override void Logic(ValidationTarget target)
		{
			var allObjects = target.GetAllObjects();
			foreach (var referenceObject in allObjects)
			{
				var isNotBaked = referenceObject
					.GetComponents<Renderer>()
					.Select(x => x.sharedMaterial)
                    .Where(x => x != null)
					.Where(x => x.shader.name == "Standard")
					.Where(x => !AssetDatabase.GetAssetPath(x).StartsWith("Resources/unity_builtin_extra"))
					.Where(x => x.IsKeywordEnabled("_EMISSION"))
					.Any(x => x.globalIlluminationFlags != MaterialGlobalIlluminationFlags.BakedEmissive);

				if (isNotBaked)
				{
					var message = LocalizedMessage.Get("E05_GlobalIlluminationBakedRule.NotBaked", referenceObject);
                    var solution = String.Format("E05_GlobalIlluminationBakedRule.NotBaked.Solution");
                    AddIssue(new Issue(referenceObject, IssueLevel.Error, message, solution));
				}		
			}
		}
	}
}
