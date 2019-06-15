using NUnit.Framework;
using System.Text.RegularExpressions;
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
            var rule = new AssetPathLengthRule("アセットパス長テスト");
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: new string[] { });
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("アセットパス長テスト"));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestValidate()
        {
            var targetAssetPath = "Assets/VitDeck/Validator/Tests/A03_TestAssetPathLengthRule.cs";
            var targetAssetPaths = new string[] { targetAssetPath };
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: targetAssetPaths);

            var willPassRule = new AssetPathLengthRule("アセットパス長テスト", targetAssetPath.Length);
            var willFailRule = new AssetPathLengthRule("アセットパス長テスト", targetAssetPath.Length - 1);

            var passedResult = willPassRule.Validate(target);
            Assert.That(passedResult.Issues.Count, Is.EqualTo(0));

            var failedResult = willFailRule.Validate(target);
            Assert.That(failedResult.Issues.Count, Is.EqualTo(1));
            Assert.That(failedResult.Issues[0].level, Is.EqualTo(IssueLevel.Error));
        }
    }
}
