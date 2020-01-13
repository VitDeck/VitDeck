using NUnit.Framework;
using UnityEditor;
using System;
using System.IO;

namespace VitDeck.Validator.Test
{
	public class A04_TestExistInSubmitFolderRule
	{
		[Test]
		public void TestValidateInSubmitFolder()
		{
			var baseFolder = "Assets/VitDeck/Validator/Tests/Data/A04_ExistInSubmitFolderRule/0001";
			var rule = new A04_ExistInSubmitFolderRule("ExistInSubmitFolderRule", Vket4OfficialAssetData.GUIDs);
			var finder = new ValidationTargetFinder();
			var target = finder.Find(baseFolder, true);
			var result = rule.Validate(target);
			Assert.That(result.Issues.Count, Is.EqualTo(2));
			
			var issues = result.Issues;
 			Assert.That(result.RuleName, Is.EqualTo("ExistInSubmitFolderRule"));
			
			Assert.That(issues[0].level, Is.EqualTo(IssueLevel.Error));
			Assert.That(issues[0].message, Is.EqualTo(String.Format("アセット{0}が入稿フォルダ内に含まれていません。", "Assets/VitDeck/Validator/Tests/Data/A04_ExistInSubmitFolderRule/0001_Sub/CubePrefabInWrongFolder.prefab")));
			Assert.That(issues[0].solution, Is.EqualTo(String.Format("入稿するアセットは(運営から配布されたアセットを除いて)すべてAssetsフォルダ直下の「出展者ID」フォルダ以下に配置してください。")));
			Assert.That(issues[0].solutionURL, Is.Empty);

			Assert.That(issues[1].level, Is.EqualTo(IssueLevel.Error));
			Assert.That(issues[1].message, Is.EqualTo(String.Format("アセット{0}が入稿フォルダ内に含まれていません。", "Assets/VitDeck/Validator/Tests/Data/A04_ExistInSubmitFolderRule/0001_Sub/MaterialInWrongFolder.mat")));
			Assert.That(issues[1].solution, Is.EqualTo(String.Format("入稿するアセットは(運営から配布されたアセットを除いて)すべてAssetsフォルダ直下の「出展者ID」フォルダ以下に配置してください。")));
			Assert.That(issues[1].solutionURL, Is.Empty);

		}
	}
}