using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator.Test
{
    public class TestUsableComponentListRule
    {
        [Test]
        public void TestValidate()
        {
            var rule = new UsableComponentListRule("",
                new ComponentReference[]
                {
                    new ComponentReference("ライティング", new string[] { "UnityEngine.Light" }, ValidationLevel.ALLOW),
                    new ComponentReference("Jointの使用禁止", new string[]
                    {
                        "UnityEngine.CharacterJoint",
                        "UnityEngine.ConfigurableJoint",
                        "UnityEngine.FixedJoint",
                        "UnityEngine.HingeJoint",
                        "UnityEngine.SpringJoint"
                    }, ValidationLevel.DISALLOW)
                });
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/UsableComponentListRule", true);
            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("GameObjectWithJoint"));
        }

        [Test]
        public void TestValidateError()
        {
            var rule = new UsableComponentListRule("",
                new ComponentReference[]
                {
                    new ComponentReference("ライティング", new string[] { "UnityEngine.Light" }, ValidationLevel.ALLOW),
                    new ComponentReference("カメラ", new string[] { "UnityEngine.Camera" }, ValidationLevel.DISALLOW),
                    new ComponentReference("Jointの使用禁止", new string[] {
                        "UnityEngine.CharacterJoint",
                        "UnityEngine.ConfigurableJoint",
                        "UnityEngine.FixedJoint",
                        "UnityEngine.HingeJoint",
                        "UnityEngine.SpringJoint"
                    }, ValidationLevel.DISALLOW)
                });
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/UsableComponentListRule", true);
            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.EqualTo(2));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("Main Camera"));
        }

        [Test]
        public void TestValidateInvalidSetting()
        {
            var invalidRule = new UsableComponentListRule(null, new ComponentReference[] { null });
            var invalidRule2 = new UsableComponentListRule("", null);
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/UsableComponentListRule", true);
            var result = invalidRule.Validate(target);
            Assert.That(result.Issues.Count, Is.Zero);
            var failResult = invalidRule2.Validate(target);
            Assert.That(failResult.Issues.Count, Is.Zero);
        }

        [Test]
        public void TestUnregisteredComponent()
        {
            var target = new ValidationTargetFinder()
                .Find("Assets/VitDeck/Validator/Tests/Data/UsableComponentListRule", true);

            var allowed = new UsableComponentListRule("",
                new ComponentReference[] { },
                unregisteredComponent: ValidationLevel.ALLOW)
                .Validate(target);

            Assert.That(allowed.Issues.Count, Is.Zero);


            var disallowed = new UsableComponentListRule("",
                new ComponentReference[] { },
                unregisteredComponent: ValidationLevel.DISALLOW)
                .Validate(target);

            Assert.That(disallowed.Issues.Count, Is.Not.Zero);
            foreach (var issue in disallowed.Issues)
            {
                Assert.That(issue.level, Is.EqualTo(IssueLevel.Error));
            }
        }

        [Test]
        public void TestIgnoreAsset()
        {
            var target = new ValidationTargetFinder()
                .Find("Assets/VitDeck/Validator/Tests/Data/UsableComponentListRule", true);

            var ignoredPrefabGUID = AssetDatabase
                .AssetPathToGUID("Assets/VitDeck/Validator/Tests/Data/UsableComponentListRule/Directional Light Prefab.prefab");

            Debug.Log(ignoredPrefabGUID);
            var result = new UsableComponentListRule("",
                new ComponentReference[]
                {
                    new ComponentReference("", new string[]{ typeof(Light).FullName }, ValidationLevel.DISALLOW)
                },
                ignorePrefabGUIDs: new string[] { ignoredPrefabGUID })
                .Validate(target);

            Assert.That(Object.FindObjectsOfType<Light>().Length, Is.EqualTo(2));

            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("Directional Light"));
        }
    }
}
