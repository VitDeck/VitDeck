using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestUseLightModeRule
    {
        [TestCase(LightType.Directional, new[] { LightmapBakeType.Baked })]
        [TestCase(LightType.Spot, new[] { LightmapBakeType.Mixed })]
        [TestCase(LightType.Point, new[] { LightmapBakeType.Baked })]
        [TestCase(LightType.Area, new[] { LightmapBakeType.Baked })]
        [TestCase(LightType.Directional, new LightmapBakeType[] {})]
        public void TestValidate(LightType type, LightmapBakeType[] unusableBakeTypes)
        {
            var rule = new UseLightModeRule("特定のLightのModeについて検証するルール", type, unusableBakeTypes);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/UseLightModeRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName,Is.EqualTo("特定のLightのModeについて検証するルール"));
            Assert.That(result.Issues.Count, Is.Zero);
        }

        [TestCase(LightType.Directional, new[] { LightmapBakeType.Realtime })]
        [TestCase(LightType.Spot, new[] { LightmapBakeType.Realtime })]
        [TestCase(LightType.Point, new[] { LightmapBakeType.Realtime })]
        public void TestValidateError(LightType type, LightmapBakeType[] unusableBakeTypes)
        {
            var rule = new UseLightModeRule(string.Format("{0}LightのModeについて検証するルール", type), type, unusableBakeTypes);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/UseLightModeRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo(string.Format("{0}LightのModeについて検証するルール", type)));
            Assert.That(result.Issues.Count, Is.EqualTo(1));
            var obj = result.Issues[0].target as GameObject;
            var light = obj.GetComponent<Light>();
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            //Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("{0}Lightの{1} Modeは使用できません。", type, light.lightmapBakeType)));
            //Assert.That(result.Issues[0].solution, Is.EqualTo("使用申請をするかModeを変更して下さい。"));
            Debug.Log(string.Format("{0}LightのModeについて検証するルール", type));
            Debug.Log(result.Issues[0].message);
        }
    }
}
