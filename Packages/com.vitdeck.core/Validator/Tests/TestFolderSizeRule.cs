using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestFolderSizeRule
    {
        [Test]
        public void TestValidate()
        {
            long limit = 5000;

            var rule = new FolderSizeRule("入稿サイズテスト", limit);
            var target = new ValidationTarget(ValidatorTestUtilities.DataDirectoryPath + "/FolderSizeRule");
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("入稿サイズテスト"));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestValidateError()
        {
            long limit = 1000;

            var rule = new FolderSizeRule("入稿サイズテスト", limit);
            var target = new ValidationTarget(ValidatorTestUtilities.DataDirectoryPath + "/FolderSizeRule");
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("入稿サイズテスト"));
            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("FolderSizeRule"));
        }
    }
}
