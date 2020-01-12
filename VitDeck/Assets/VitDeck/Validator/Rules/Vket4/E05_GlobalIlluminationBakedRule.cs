using System;
using UnityEditor;
using UnityEngine;
using System.Linq;

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
					.Select(x => x.material)
					.Where(x => x.shader.name == "Standard")
					.Where(x => x.IsKeywordEnabled("_EMISSION"))
					.Any(x => x.globalIlluminationFlags != MaterialGlobalIlluminationFlags.BakedEmissive);
				
				if (isNotBaked)
				{
					var assetPath = AssetDatabase.GetAssetPath(referenceObject);
                    var message = String.Format("アセット{0}でGlobal IlluminationがBakedに設定されていません。", assetPath);
                    var solution = String.Format("Standard ShaderでEmissionを利用する場合はGlobal Illuminationの設定をBakedにしてください。");
                    AddIssue(new Issue(referenceObject, IssueLevel.Error, message, solution));
				}		
			}
		}
	}
}
