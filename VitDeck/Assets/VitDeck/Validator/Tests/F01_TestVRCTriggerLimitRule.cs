using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestVRCTriggerLimitRule
    {
        [Test]
        public void TestValidate()
        {
            var limit = 5;

            var rule = new VRCTriggerLimitRule("VRC_Triggerコンポーネントの数が制限を超えていることを検出するルール", limit);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_VRCTriggerLimitRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName,Is.EqualTo("VRC_Triggerコンポーネントの数が制限を超えていることを検出するルール"));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestValidateError()
        {
            var limit = 3;

            var rule = new VRCTriggerLimitRule("VRC_Triggerコンポーネントの数が制限を超えていることを検出するルール", limit);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_VRCTriggerLimitRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("VRC_Triggerコンポーネントの数が制限を超えていることを検出するルール"));
            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("VRC_Triggerコンポーネントの数が使用可能な制限を超えています。制限:{0}, 使用:5", limit)));
            Assert.That(result.Issues[0].solution, Is.EqualTo(string.Format("使用するVRCコンポーネントを{0}個以下にして下さい。", limit)));
        }
    }
}
