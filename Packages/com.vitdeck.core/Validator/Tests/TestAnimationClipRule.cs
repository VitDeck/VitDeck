using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator.Test
{
    public class TestAnimationClipRule
    {
        private static string BaseFolder = ValidatorTestUtilities.DataDirectoryPath + "/AnimationClipRule";

        [Test]
        public void MaterialChangeAnimationTest()
        {
            var targetClip = AssetDatabase.LoadAssetAtPath<AnimationClip>(BaseFolder + "/TestMateralChangeAnimation.anim");
            var validationTarget = new ValidationTarget(BaseFolder, assetObjects: new Object[] { targetClip });

            var issues = new AnimationClipRule("").Validate(validationTarget).Issues;

            Assert.That(issues.Count, Is.EqualTo(1));
            Assert.That(issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(issues[0].target, Is.EqualTo(targetClip));
        }

        [Test]
        public void ParentObjectControlTest()
        {
            var targetClip = AssetDatabase.LoadAssetAtPath<AnimationClip>(BaseFolder + "/TestParentItemAnimation.anim");
            var validationTarget = new ValidationTarget(BaseFolder, assetObjects: new Object[] { targetClip });

            var issues = new AnimationClipRule("").Validate(validationTarget).Issues;

            Assert.That(issues.Count, Is.EqualTo(1));
            Assert.That(issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(issues[0].target, Is.EqualTo(targetClip));
        }
    }
}