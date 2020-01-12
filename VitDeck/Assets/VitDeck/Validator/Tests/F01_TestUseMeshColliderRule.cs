using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestUseMeshColliderRule
    {
        [Test]
        public void TestValidate()
        {
            var rule = new UseMeshColliderRule("MeshColliderの使用を検証するルール");
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_UseMeshColliderRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName,Is.EqualTo("MeshColliderの使用を検証するルール"));
            Assert.That(result.Issues.Count, Is.AtLeast(1));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Warning));
            Assert.That(result.Issues[0].message, Is.EqualTo("MeshColliderは非推奨です。"));
            Assert.That(result.Issues[0].solution, Is.EqualTo("他のColliderを使用してください。"));
            Assert.That(result.Issues[0].solutionURL, Is.Empty);
        }
    }
}
