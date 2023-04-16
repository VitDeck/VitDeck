using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestLightCountLimitRule
    {
        [TestCase(LightType.Directional, 3)]
        [TestCase(LightType.Area, 3)]
        [TestCase(LightType.Spot, 3)]
        [TestCase(LightType.Point, 3)]
        public void TestValidate(LightType type, int limit)
        {
            var rule = new LightCountLimitRule(
                    string.Format("{0}Lightの個数が制限を超えていることを検出するルール", type),
                    type,
                    limit);

            var finder = new ValidationTargetFinder();
            var target = finder.Find(ValidatorTestUtilities.DataDirectoryPath + "/LightCountLimitRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo(string.Format("{0}Lightの個数が制限を超えていることを検出するルール", type)));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }

        [TestCase(LightType.Directional, 0, 1)]
        [TestCase(LightType.Area, 1, 2)]
        [TestCase(LightType.Spot, 1, 2)]
        [TestCase(LightType.Point, 2, 3)]
        public void TestValidateError(LightType type, int limit, int count)
        {
            var finder = new ValidationTargetFinder();
            var target = finder.Find(ValidatorTestUtilities.DataDirectoryPath + "/LightCountLimitRule", true);

            var rule = new LightCountLimitRule(
                                string.Format("{0}Lightの個数が制限を超えていることを検出するルール", type), 
                                type,
                                limit);
            var result = rule.Validate(target);
            Assert.That(result.RuleName,Is.EqualTo(string.Format("{0}Lightの個数が制限を超えていることを検出するルール", type)));
            Assert.That(result.Issues.Count, Is.EqualTo(count));
            var targetLight = result.Issues[0].target as Light;
            Assert.That(targetLight.type, Is.EqualTo(type));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            //Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("{0} Lightが{1}個を超えています。({2}個)", type, limit, count)));
            //Assert.That(result.Issues[0].solution, Is.EqualTo("別のLightを使用するか、削除して個数を減らして下さい。"));
        }
    }
}
