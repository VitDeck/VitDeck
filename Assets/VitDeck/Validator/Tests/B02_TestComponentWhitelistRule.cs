using NUnit.Framework;
using UnityEditor;

namespace VitDeck.Validator.Test
{
    public class TestComponentWhitelistRule
    {
        [Test]
        public void TestValidate()
        {
            var rule = new ComponentWhitelistRule("コンポーネントホワイトリストルール",
                            new ComponentReference[] { new ComponentReference("ライティング", new string[] { "UnityEngine.Light" }, ValidationLevel.ALLOW),
                                                       new ComponentReference("Jointの使用禁止", new string[] { "UnityEngine.CharacterJoint",
                                                                                                                "UnityEngine.ConfigurableJoint",
                                                                                                                "UnityEngine.FixedJoint",
                                                                                                                "UnityEngine.HingeJoint",
                                                                                                                "UnityEngine.SpringJoint"}, ValidationLevel.DISALLOW)});
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/B02_ComponentWhitelistRule", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("コンポーネントホワイトリストルール"));
            Assert.That(result.Issues.Count, Is.EqualTo(3));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("Main Camera"));
            Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("{0}は使用可能なコンポーネントリストに登録されていません。", "Camera")));
            Assert.That(result.Issues[1].message, Is.EqualTo(string.Format("{0}は使用可能なコンポーネントリストに登録されていません。", "FlareLayer")));
            Assert.That(result.Issues[2].message, Is.EqualTo(string.Format("{0}は使用可能なコンポーネントリストに登録されていません。", "AudioListener")));
        }
        [Test]
        public void TestValidateError()
        {
            var grupeName = "カメラ";
            var rule = new ComponentWhitelistRule("コンポーネントホワイトリストルール",
                new ComponentReference[] { new ComponentReference("ライティング", new string[] { "UnityEngine.Light" }, ValidationLevel.ALLOW),
                                                       new ComponentReference(grupeName, new string[] { "UnityEngine.Camera" }, ValidationLevel.DISALLOW),
                                                       new ComponentReference("Jointの使用禁止", new string[] { "UnityEngine.CharacterJoint",
                                                                                                                "UnityEngine.ConfigurableJoint",
                                                                                                                "UnityEngine.FixedJoint",
                                                                                                                "UnityEngine.HingeJoint",
                                                                                                                "UnityEngine.SpringJoint"}, ValidationLevel.DISALLOW)});
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/B02_ComponentWhitelistRule", true);
            var result = rule.Validate(target);
            Assert.That(result.Issues.Count, Is.EqualTo(3));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("Main Camera"));
            Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("{0}:{1}の使用は許可されていません。", grupeName, "Camera")));
            Assert.That(result.Issues[0].solution, Is.Empty);
            Assert.That(result.Issues[0].solutionURL, Is.Empty);
        }
        [Test]
        public void TestValidateInvalidSetting()
        {
            var invalidRule = new ComponentWhitelistRule(null, new ComponentReference[] { null });
            var invalidRule2 = new ComponentWhitelistRule("コンポーネントホワイトリストルール", null);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/B02_ComponentWhitelistRule", true);
            var result = invalidRule.Validate(target);
            Assert.That(result.Issues.Count, Is.EqualTo(4));
            var failResult = invalidRule2.Validate(target);
            Assert.That(failResult.Issues.Count, Is.EqualTo(4));
        }
    }
}
