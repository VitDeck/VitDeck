using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestVRCTriggerCountLimitRule
    {
        [Test]
        public void TestValidate()
        {
            var limit = 5;

            var rule = new VRCTriggerCountLimitRule("VRC_Triggerコンポーネントの数が制限を超えていることを検出するルール", limit);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_VRCTriggerCountLimitRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName,Is.EqualTo("VRC_Triggerコンポーネントの数が制限を超えていることを検出するルール"));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestValidateError()
        {
            var limit = 3;

            var rule = new VRCTriggerCountLimitRule("VRC_Triggerコンポーネントの数が制限を超えていることを検出するルール", limit);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_VRCTriggerCountLimitRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("VRC_Triggerコンポーネントの数が制限を超えていることを検出するルール"));
            Assert.That(result.Issues.Count, Is.EqualTo(5));

            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("Cube"));
            //Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("VRC_Triggerコンポーネントの数が{0}個を超えています。(5個)", limit)));
            //Assert.That(result.Issues[0].solution, Is.EqualTo("使用個数を減らして下さい。"));

            Assert.That(result.Issues[1].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[1].target.name, Is.EqualTo("Cube (2)"));
            //Assert.That(result.Issues[1].message, Is.EqualTo(string.Format("VRC_Triggerコンポーネントの数が{0}個を超えています。(5個)", limit)));
            //Assert.That(result.Issues[1].solution, Is.EqualTo("使用個数を減らして下さい。"));

            Assert.That(result.Issues[2].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[2].target.name, Is.EqualTo("Cube (4)"));
            //Assert.That(result.Issues[2].message, Is.EqualTo(string.Format("VRC_Triggerコンポーネントの数が{0}個を超えています。(5個)", limit)));
            //Assert.That(result.Issues[2].solution, Is.EqualTo("使用個数を減らして下さい。"));

            Assert.That(result.Issues[3].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[3].target.name, Is.EqualTo("Cube (1)"));
            //Assert.That(result.Issues[3].message, Is.EqualTo(string.Format("VRC_Triggerコンポーネントの数が{0}個を超えています。(5個)", limit)));
            //Assert.That(result.Issues[3].solution, Is.EqualTo("使用個数を減らして下さい。"));

            Assert.That(result.Issues[4].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[4].target.name, Is.EqualTo("Cube (3)"));
            //Assert.That(result.Issues[4].message, Is.EqualTo(string.Format("VRC_Triggerコンポーネントの数が{0}個を超えています。(5個)", limit)));
            //Assert.That(result.Issues[4].solution, Is.EqualTo("使用個数を減らして下さい。"));
        }
    }
}
