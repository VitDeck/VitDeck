using NUnit.Framework;


namespace VitDeck.Validator.Test
{
    public class TestAnimatorComponentMaxCountRule
    {
		private readonly int ANIMATOR_MAX_COUNT = 50;
        [Test]
        public void TestValidate()
        {
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_AnimatorComponentMaxCountRule", true);
            var rule = new F01_AnimatorComponentMaxCountRule("AnimatorComponent使用数検出", ANIMATOR_MAX_COUNT);
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("AnimatorComponent使用数検出"));
            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target, Is.EqualTo(null));
            Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("Animatorコンポーネントの使用数が{0}個を超えています。", ANIMATOR_MAX_COUNT)));
            Assert.That(result.Issues[0].solution, Is.Empty);
            Assert.That(result.Issues[0].solutionURL, Is.Empty);
        }
    }
}