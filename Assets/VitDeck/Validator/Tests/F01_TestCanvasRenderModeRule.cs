using NUnit.Framework;
using UnityEngine;

namespace VitDeck.Validator.Test
{
	public class TestCanvasRenderModeRule
	{
		[Test]
		public void TestValidate()
		{
			var finder = new ValidationTargetFinder();
			var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_CanvasRenderModeRule", true);
			var rule = new F01_CanvasRenderModeRule("RenderMode.WorldSpaceテスト");
			var result = rule.Validate(target);
			Assert.That(result.RuleName, Is.EqualTo("RenderMode.WorldSpaceテスト"));
			Assert.That(result.Issues.Count, Is.EqualTo(2));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("Canvas_ScreenSpace-Overlay"));
            //Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("{0}においてCanvasのRenderModeがWorldSpaceになっていません。", "Canvas_ScreenSpace-Overlay (UnityEngine.GameObject)")));
            Assert.That(result.Issues[0].solution, Is.Empty);
            Assert.That(result.Issues[1].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[1].target.name, Is.EqualTo("Canvas_ScreenSpace-Camera"));
            //Assert.That(result.Issues[1].message, Is.EqualTo(string.Format("{0}においてCanvasのRenderModeがWorldSpaceになっていません。", "Canvas_ScreenSpace-Camera (UnityEngine.GameObject)")));
            Assert.That(result.Issues[1].solution, Is.Empty);
		}
	}
}