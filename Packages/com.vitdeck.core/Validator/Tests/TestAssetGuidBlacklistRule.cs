using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestAssetGuidBlacklistRule
    {
        [Test]
        public void TestValidate()
        {
            var rule = new AssetGuidBlacklistRule("AssetGuidBlacklistRule",
                new string[] { "740112f6e77ca914d9c26eef5d68accd", "ae68339621fb41b4f9905188526120ea" });
            var finder = new ValidationTargetFinder();
            var target = finder.Find(ValidatorTestUtilities.DataDirectoryPath + "/AssetGuidBlacklistRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("AssetGuidBlacklistRule"));
            Assert.That(result.GetResultLog(false), Is.Empty);
            Assert.That(result.Issues.Count, Is.EqualTo(2));
            Assert.That(result.Issues[0].target,
                Is.EqualTo(AssetDatabase.LoadMainAssetAtPath(
                    AssetDatabase.GUIDToAssetPath("740112f6e77ca914d9c26eef5d68accd"))));
            Assert.That(result.Issues[1].target,
                Is.EqualTo(AssetDatabase.LoadMainAssetAtPath(
                    AssetDatabase.GUIDToAssetPath("ae68339621fb41b4f9905188526120ea"))));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].message,
                Does.Contain(ValidatorTestUtilities.DataDirectoryPath +
                             "/AssetGuidBlacklistRule/Prohibited material.mat"));
        }

        [Test]
        public void TestValidateNoObject()
        {
            var rule = new AssetGuidBlacklistRule("AssetGuidBlacklistRule",
                new string[] { "740112f6e77ca914d9c26eef5d68accd", "ae68339621fb41b4f9905188526120ea" });
            var finder = new ValidationTargetFinder();
            var target = finder.Find(ValidatorTestUtilities.TestDirectoryPath + "/ValidationTargetFinderNoObject",
                true);
            var result = rule.Validate(target);
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }
    }
}
