using NUnit.Framework;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestAssetExtentionBlacklistRule
    {
        [Test]
        public void TestValidate()
        {
            var rule = new AssetExtentionBlacklistRule("拡張子テスト", new string[] { "TXT", ".prefab", ".FBX" });
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: new string[] { });
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("拡張子テスト"));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestValidateError()
        {
            var rule = new AssetExtentionBlacklistRule("拡張子テスト", new string[] { "TXT", ".prefab", ".Fbx" });
            var path = "Assets/VitDeck/Validator/Tests/Data/A04_AssetExtentionBlacklistRule/TestData.txt";
            var targetPaths = new string[] {
                path ,
                "Assets/VitDeck/Validator/Tests/test dummy data.prefab" ,
                "Assets/VitDeck/Validator/Tests/test dummy data.fake.FBX",
                "Assets/VitDeck/Validator/Tests/test_dummy_OK.fbx2" };
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: targetPaths);
            var result = rule.Validate(target);
            Assert.That(result.Issues.Count, Is.EqualTo(3));
            var issue = result.Issues[0];
            Assert.That(issue.level, Is.EqualTo(IssueLevel.Error));
            Assert.That(issue.target, Is.EqualTo(AssetDatabase.LoadMainAssetAtPath(path)));
            var expectedMessage = string.Format("拡張子が`{0}`のアセットが検出されました。", Path.GetExtension(path)) + Environment.NewLine + path;
            Assert.That(issue.message, Is.EqualTo(expectedMessage));
            Assert.That(issue.solution, Is.Empty);
            Assert.That(issue.solutionURL, Is.Empty);
        }
        [Test]
        public void TestValidateInvalidSetting()
        {
            var invalidRule = new AssetExtentionBlacklistRule("空文字拡張子テスト", new string[] { "", ".txt" });
            var path = "Assets/VitDeck/Validator/Tests/Data/A04_AssetExtentionBlacklistRule/TestData.txt";
            var targetPaths = new string[] {
                path ,
                "Assets/VitDeck/Validator/Tests/test_dummy_OK.text" };
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", assetPaths: targetPaths);
            var result = invalidRule.Validate(target);
            Assert.That(result.Issues.Count, Is.EqualTo(2));
            var issue = result.Issues[0];
            Assert.That(issue.level, Is.EqualTo(IssueLevel.Warning));
            Assert.That(issue.target, Is.Null);
            Assert.That(issue.message, Is.EqualTo("設定された拡張子は空文字のため無視されます。"));
            Assert.That(issue.solution, Is.Empty);
            Assert.That(issue.solutionURL, Is.Empty);
        }
    }
}
