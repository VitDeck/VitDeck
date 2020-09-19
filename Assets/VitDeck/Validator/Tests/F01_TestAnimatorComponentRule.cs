using NUnit.Framework;
using UnityEngine;

namespace VitDeck.Validator.Test
{
    public class F01_TestAnimatorComponentRule
    {
        const string BaseFolder = "Assets/VitDeck/Validator/Tests/Data/F01_AnimatorComponentRule/";

        [Test]
        public void ApplyRootMotionTest()
        {
            var target = new ValidationTargetFinder().Find(BaseFolder + "ApplyRootMotion", true);
            var issues = new F01_AnimatorComponentRule("", new System.Type[] { }).Validate(target).Issues;

            Assert.That(issues.Count, Is.EqualTo(1));
            Assert.That(issues[0].level, Is.EqualTo(IssueLevel.Error));
        }

        [Test]
        public void SetAlwaysMotionTest()
        {
            var target = new ValidationTargetFinder().Find(BaseFolder + "SetAlwaysAnimate", true);
            var issues = new F01_AnimatorComponentRule("", new System.Type[] { }).Validate(target).Issues;

            Assert.That(issues.Count, Is.EqualTo(1));
            Assert.That(issues[0].level, Is.EqualTo(IssueLevel.Warning));
        }

        [Test]
        public void WithAnyComponentTest()
        {
            // ここでは例としてBoxColliderをmustUseSeparatelyComponentsに設定
            var target = new ValidationTargetFinder().Find(BaseFolder + "WithBoxColliderComponent", true);
            var issues = new F01_AnimatorComponentRule("", new System.Type[] { typeof(BoxCollider) }).Validate(target).Issues;

            Assert.That(issues.Count, Is.EqualTo(1));
            Assert.That(issues[0].level, Is.EqualTo(IssueLevel.Error));
        }
    }
}