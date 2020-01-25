using NUnit.Framework;

namespace VitDeck.Validator.Test
{
    public class F01_TestAnimationComponentRule
    {
        [Test]
        public void EnableAlwaysAnimateTest()
        {
            var target = new ValidationTargetFinder().Find("Assets/VitDeck/Validator/Tests/Data/F01_AnimationComponentRule/EnableAlwaysAnimate", true);
            var issues = new F01_AnimationComponentRule("").Validate(target).Issues;

            Assert.That(issues.Count, Is.EqualTo(1));
            Assert.That(issues[0].level, Is.EqualTo(IssueLevel.Warning));
        }

        [Test]
        public void DisableAlwaysAnimateTest()
        {
            var target = new ValidationTargetFinder().Find("Assets/VitDeck/Validator/Tests/Data/F01_AnimationComponentRule/DisableAlwaysAnimate", true);
            var issues = new F01_AnimationComponentRule("").Validate(target).Issues;

            Assert.That(issues.Count, Is.EqualTo(0));
        }

    }
}