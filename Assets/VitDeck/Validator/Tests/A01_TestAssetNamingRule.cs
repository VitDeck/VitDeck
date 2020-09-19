using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator.Test
{
    public class TestAssetNamingRule
    {
        [Test]
        public void TestValidateNoAsset()
        {
            var rule = new AssetNamingRule("アセット名使用禁止文字検出", "^[\x21-\x7e]+$");
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: new string[] { });
            var result = rule.Validate(target);

            Assert.That(result.RuleName, Is.EqualTo("アセット名使用禁止文字検出"));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }

        [TestCase("[\x21-\x7e]+", "Assets/VitDeck/Validator/Tests/Data/A01_AssetNamingRule/CorrectName_!#$%&'()+,;=@{}~.prefab")]
        [TestCase(@"[a-zA-Z0-9 _\.\-]+", "Assets/VitDeck/Validator/Tests/Data/A01_AssetNamingRule/CorrectName_-.prefab")]
        [TestCase(@"[a-zA-Z0-9 _\.\-]+", "Assets/VitDeck/Validator/Tests/Data/A01_AssetNamingRule")]
        public void TestValidateCorrectAssetName(string matchPattern, string assetPath)
        {
            var targetAssetPath = assetPath;
            var targetAssetPaths = new string[] { targetAssetPath };
            var pattern = matchPattern;

            var rule = new AssetNamingRule("アセット名使用禁止文字検出", pattern);
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: targetAssetPaths);
            var result = rule.Validate(target);

            Assert.That(result.RuleName, Is.EqualTo("アセット名使用禁止文字検出"));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }

        [TestCase("Assets/VitDeck/Validator/Tests/Data/A01_AssetNamingRule/FailName_あああ.prefab")]
        [TestCase("Assets/VitDeck/Validator/Tests/Data/A01_AssetNamingRule/FailFolderName_あああ")]
        public void TestValidateFailAssetName(string targetAssetPath)
        {
            var targetAssetPaths = new string[] { targetAssetPath };
            var pattern = "[\x21-\x7e]+";
            var prohibition = "あああ";

            var rule = new AssetNamingRule("アセット名使用禁止文字検出", pattern);
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests/Data/A01_AssetNamingRule", assetPaths: targetAssetPaths);
            var result = rule.Validate(target);

            Assert.That(result.RuleName, Is.EqualTo("アセット名使用禁止文字検出"));
            Assert.That(result.Issues.Count, Is.EqualTo(1));

            var issue = result.Issues[0];
            Assert.That(issue.level, Is.EqualTo(IssueLevel.Error));
            Assert.That(issue.target, Is.EqualTo(AssetDatabase.LoadMainAssetAtPath(targetAssetPath)));
            //Assert.That(issue.message,
            //            Is.EqualTo(string.Format("アセット名({0})に使用禁止文字({1})が含まれています。", targetAssetPath, prohibition)));
            Assert.That(issue.solution, Is.Empty);
            Assert.That(issue.solutionURL, Is.Empty);
        }
        [TestCase(@"[0-9a-zA-Z _\-]+", "Assets/VitDeck/Validator/Tests/test.-_test", ".")]
        public void TestValidateMatches(string matchPattern, string assetPath, string matchChars)
        {
            var targetAssetPath = assetPath;
            var targetAssetPaths = new string[] { targetAssetPath };
            var pattern = matchPattern;

            var rule = new AssetNamingRule("マッチ文字列テスト", pattern);
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: targetAssetPaths);
            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.EqualTo(1));
            //Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("アセット名({0})に使用禁止文字({1})が含まれています。", assetPath, matchChars)));
        }
    }
}