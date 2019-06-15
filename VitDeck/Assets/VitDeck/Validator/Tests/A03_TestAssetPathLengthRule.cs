using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestAssetPathLengthRule
    {
        [Test]
        public void TestValidateNoTargets()
        {
            var version = UnityEngine.Application.unityVersion;
            var rule = new AssetPathLengthRule("アセットパス長制限テスト");
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: new string[] { });
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("アセットパス長制限テスト"));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestValidate()
        {
            var targetAssetPath = "Assets/VitDeck/Validator/Tests/A03_TestAssetPathLengthRule.cs";
            var targetAssetPaths = new string[] { targetAssetPath };
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: targetAssetPaths);

            var willPassRule = new AssetPathLengthRule("アセットパス長制限テスト", targetAssetPath.Length);
            var willFailRule = new AssetPathLengthRule("アセットパス長制限テスト", targetAssetPath.Length - 1);

            var passedResult = willPassRule.Validate(target);
            Assert.That(passedResult.Issues.Count, Is.EqualTo(0));

            var failedResult = willFailRule.Validate(target);
            Assert.That(failedResult.Issues.Count, Is.EqualTo(1));
            var issue = failedResult.Issues[0];
            Assert.That(issue.level, Is.EqualTo(IssueLevel.Error));
            Assert.That(issue.target, Is.EqualTo(AssetDatabase.LoadAssetAtPath<Object>(targetAssetPath)));
            Assert.That(issue.message, Is.EqualTo(System.String.Format("アセットのパスが長すぎます。（制限={0}, 超過={1}, パス={2}）", targetAssetPath.Length - 1, 1, targetAssetPath)));
            Assert.That(issue.solution, Is.Empty);
            Assert.That(issue.solutionURL, Is.Empty);

        }
    }
}
