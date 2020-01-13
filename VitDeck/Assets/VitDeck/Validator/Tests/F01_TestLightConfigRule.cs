using NUnit.Framework;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestLightConfigRule
    {
        [TestCase(LightType.Point, new[] { LightmapBakeType.Baked, LightmapBakeType.Mixed })]
        [TestCase(LightType.Spot, new[] { LightmapBakeType.Baked, LightmapBakeType.Mixed })]
        [TestCase(LightType.Area, new[] { LightmapBakeType.Baked })]
        public void TestValidate(LightType type, LightmapBakeType[] bakeTypes)
        {
            var rule = new LightConfigRule(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type), type, bakeTypes);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_LightConfigRule", true);
            var result = rule.Validate(target);

            Assert.That(result.RuleName, Is.EqualTo(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type)));
            Debug.Log(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }

        [TestCase(LightType.Point, new[] { LightmapBakeType.Baked, LightmapBakeType.Realtime })]
        [TestCase(LightType.Spot, new[] { LightmapBakeType.Baked, LightmapBakeType.Realtime })]
        public void TestValidateErrorBakeType(LightType type, LightmapBakeType[] bakeTypes)
        {
            var rule = new LightConfigRule(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type), type, bakeTypes);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_LightConfigRule", true);
            var result = rule.Validate(target);

            Assert.That(result.RuleName, Is.EqualTo(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type)));
            Debug.Log(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type));
            Assert.That(result.Issues.Count, Is.EqualTo(1));

            var obj = result.Issues[0].target as GameObject;
            Assert.That(obj.name, Does.EndWith("_NG"));
            var light = obj.GetComponent<Light>();
            var bakeTypeListString = string.Join(", ", bakeTypes.Select(x => x.ToString()).ToArray());
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("{0}LightのModeが{1}以外に設定されています。({2})",
                                                                type, bakeTypeListString, light.lightmapBakeType)));
            Assert.That(result.Issues[0].solution, Is.EqualTo(string.Format("Modeを{0}に設定して下さい。", bakeTypeListString)));
            Debug.Log(result.Issues[0].message);
            Debug.Log(result.Issues[0].solution);
        }

        [TestCase(LightType.Point, new[] { LightmapBakeType.Baked }, 0, 7, 0, 10, 0, 15)]
        [TestCase(LightType.Spot, new[] { LightmapBakeType.Baked }, 0, 7, 0, 10, 0, 15)]
        public void TestValidateErrorDetail(
            LightType type,
            LightmapBakeType[] bakeTypes,
            float minRange, float maxRange,
            float minIntensity, float maxIntensity,
            float minBounceIntensity, float maxBounceIntensity)
        {
            var rule = new LightConfigRule(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type),
                    type, bakeTypes, minRange, maxRange, minIntensity, maxIntensity, minBounceIntensity, maxBounceIntensity);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_LightConfigRule", true);
            var result = rule.Validate(target);

            Assert.That(result.RuleName, Is.EqualTo(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type)));
            Debug.Log(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type));
            Assert.That(result.Issues.Count, Is.EqualTo(4));

            var obj = result.Issues[0].target as GameObject;
            Assert.That(obj.name, Does.EndWith("_NG"));
            var light = obj.GetComponent<Light>();
            var bakeTypeListString = string.Join(", ", bakeTypes.Select(x => x.ToString()).ToArray());
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("{0}LightのModeが{1}以外に設定されています。({2})",
                                                                type, bakeTypeListString, light.lightmapBakeType)));
            Assert.That(result.Issues[0].solution, Is.EqualTo(string.Format("Modeを{0}に設定して下さい。", bakeTypeListString)));
            Debug.Log(result.Issues[0].message);
            Debug.Log(result.Issues[0].solution);

            obj = result.Issues[1].target as GameObject;
            Assert.That(obj.name, Does.EndWith("_NG"));
            light = obj.GetComponent<Light>();
            Assert.That(result.Issues[1].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[1].message, Is.EqualTo(string.Format("{0}LightのRangeが{1}～{2}の範囲を超えています。(設定値：{3})",
                                                                type, minRange, maxRange, light.range)));
            Assert.That(result.Issues[1].solution, Is.EqualTo("Rangeを範囲内になるように設定して下さい。"));
            Debug.Log(result.Issues[1].message);
            Debug.Log(result.Issues[1].solution);

            obj = result.Issues[2].target as GameObject;
            Assert.That(obj.name, Does.EndWith("_NG"));
            light = obj.GetComponent<Light>();
            Assert.That(result.Issues[2].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[2].message, Is.EqualTo(string.Format("{0}LightのIntensityが{1}～{2}の範囲を超えています。(設定値：{3})",
                                                                type, minIntensity, maxIntensity, light.intensity)));
            Assert.That(result.Issues[2].solution, Is.EqualTo("Intensityを範囲内になるように設定して下さい。"));
            Debug.Log(result.Issues[2].message);
            Debug.Log(result.Issues[2].solution);

            obj = result.Issues[3].target as GameObject;
            Assert.That(obj.name, Does.EndWith("_NG"));
            light = obj.GetComponent<Light>();
            Assert.That(result.Issues[3].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[3].message, Is.EqualTo(string.Format("{0}LightのIndirect Multiplierが{1}～{2}の範囲を超えています。(設定値：{3})",
                                                                type, minBounceIntensity, maxBounceIntensity, light.bounceIntensity)));
            Assert.That(result.Issues[3].solution, Is.EqualTo("Indirect Multiplierを範囲内になるように設定して下さい。"));
            Debug.Log(result.Issues[3].message);
            Debug.Log(result.Issues[3].solution);
        }

        [TestCase(LightType.Area, new[] { LightmapBakeType.Baked }, 0, 30, 0, 10, 0, 15)]
        public void TestValidateErrorAreaDetail(
            LightType type,
            LightmapBakeType[] bakeTypes,
            float minRange = LightConfigRule.NO_LIMIT, float maxRange = LightConfigRule.NO_LIMIT,
            float minIntensity = LightConfigRule.NO_LIMIT, float maxIntensity = LightConfigRule.NO_LIMIT,
            float minBounceIntensity = LightConfigRule.NO_LIMIT, float maxBounceIntensity = LightConfigRule.NO_LIMIT)
        {
            var rule = (minRange == LightConfigRule.NO_LIMIT) ?
                new LightConfigRule(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type), type, bakeTypes) :
                new LightConfigRule(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type),
                    type, bakeTypes, minRange, maxRange, minIntensity, maxIntensity, minBounceIntensity, maxBounceIntensity);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_LightConfigRule", true);
            var result = rule.Validate(target);

            Assert.That(result.RuleName, Is.EqualTo(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type)));
            Debug.Log(string.Format("{0}Lightの設定が制限に従っていることを検証するルール", type));
            Assert.That(result.Issues.Count, Is.EqualTo(3));

            var obj = result.Issues[0].target as GameObject;
            Assert.That(obj.name, Does.EndWith("_NG"));
            var light = obj.GetComponent<Light>();
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("{0}LightのRangeが{1}～{2}の範囲を超えています。(設定値：{3})",
                                                                type, minRange, maxRange, light.range)));
            Assert.That(result.Issues[0].solution, Is.EqualTo("Rangeを範囲内になるように設定して下さい。"));
            Debug.Log(result.Issues[0].message);
            Debug.Log(result.Issues[0].solution);

            obj = result.Issues[1].target as GameObject;
            Assert.That(obj.name, Does.EndWith("_NG"));
            light = obj.GetComponent<Light>();
            Assert.That(result.Issues[1].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[1].message, Is.EqualTo(string.Format("{0}LightのIntensityが{1}～{2}の範囲を超えています。(設定値：{3})",
                                                                type, minIntensity, maxIntensity, light.intensity)));
            Assert.That(result.Issues[1].solution, Is.EqualTo("Intensityを範囲内になるように設定して下さい。"));
            Debug.Log(result.Issues[1].message);
            Debug.Log(result.Issues[1].solution);

            obj = result.Issues[2].target as GameObject;
            Assert.That(obj.name, Does.EndWith("_NG"));
            light = obj.GetComponent<Light>();
            Assert.That(result.Issues[2].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[2].message, Is.EqualTo(string.Format("{0}LightのIndirect Multiplierが{1}～{2}の範囲を超えています。(設定値：{3})",
                                                                type, minBounceIntensity, maxBounceIntensity, light.bounceIntensity)));
            Assert.That(result.Issues[2].solution, Is.EqualTo("Indirect Multiplierを範囲内になるように設定して下さい。"));
            Debug.Log(result.Issues[2].message);
            Debug.Log(result.Issues[2].solution);
        }

        [Test]
        public void TestValidateErrorUnavailable()
        {
            var type = LightType.Spot;

            var rule = new LightConfigRule(string.Format("{0}Lightが使用されていないことを検証するルール", type), type, new LightmapBakeType[] { });
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_LightConfigRule", true);
            var result = rule.Validate(target);

            Assert.That(result.RuleName, Is.EqualTo(string.Format("{0}Lightが使用されていないことを検証するルール", type)));
            Debug.Log(string.Format("{0}Lightが使用されていないことを検証するルール", type));
            Assert.That(result.Issues.Count, Is.EqualTo(2));

            foreach (var issue in result.Issues)
            {
                Assert.That(issue.level, Is.EqualTo(IssueLevel.Error));
                Assert.That(issue.message, Is.EqualTo(string.Format("{0}Lightは使用できません。", type)));
                Assert.That(issue.solution, Is.EqualTo("削除するかTypeを変更して他のLightを使用して下さい。"));
                Debug.Log(issue.message);
                Debug.Log(issue.solution);
            }
        }
    }
}
