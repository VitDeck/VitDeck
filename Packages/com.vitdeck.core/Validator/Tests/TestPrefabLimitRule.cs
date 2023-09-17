using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestPrefabLimitRule
    {
        [Test]
        public void TestUnderLimit()
        {
            var limit = 4;
            var guids = new string[] { "c4bb7970c870834499aba4a950dd3d73" };
            var rule = new PrefabLimitRule("", guids, limit);
            var finder = new ValidationTargetFinder();
            var target = finder.Find(ValidatorTestUtilities.DataDirectoryPath + "/PrefabLimitRule", true);
            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.Zero);
        }

        [Test]
        public void TestOverLimit()
        {
            var limit = 2;
            var guids = new string[] { "c4bb7970c870834499aba4a950dd3d73" };
            var rule = new PrefabLimitRule("", guids, limit);
            var finder = new ValidationTargetFinder();
            var target = finder.Find(ValidatorTestUtilities.DataDirectoryPath + "/PrefabLimitRule", true);
            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.EqualTo(1));

            foreach (var issue in result.Issues)
            {
                Assert.That(issue.level, Is.EqualTo(IssueLevel.Error));
            }
        }
    }
}
