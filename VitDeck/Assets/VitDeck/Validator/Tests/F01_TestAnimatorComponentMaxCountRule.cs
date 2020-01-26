using NUnit.Framework;


namespace VitDeck.Validator.Test
{
    public class TestAnimatorComponentMaxCountRule
    {
		private readonly int ANIMATOR_LIMIT_COUNT = 50;
        [Test]
        public void TestValidate()
        {
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/F01_AnimatorComponentMaxCountRule", true);
            var rule = new F01_AnimatorComponentMaxCountRule("AnimatorComponent使用数検出", ANIMATOR_LIMIT_COUNT);
            var result = rule.Validate(target);
            var issues = result.Issues;
            Assert.That(result.RuleName, Is.EqualTo("AnimatorComponent使用数検出"));
            Assert.That(issues.Count, Is.EqualTo(ANIMATOR_LIMIT_COUNT + 1));
            for (int i = 0; i < issues.Count; i++)
            {
                Assert.That(issues[i].level, Is.EqualTo(IssueLevel.Error));
                if (i == 0)
                {
                    Assert.That(result.Issues[i].target.name, Is.EqualTo(string.Format("AnimatorObject")));
                }
                else
                {
                    Assert.That(issues[i].target.name, Is.EqualTo(string.Format("AnimatorObject ({0})", i)));
                }
                Assert.That(issues[i].message, Is.EqualTo(string.Format("Animatorコンポーネントの使用数が{0}個を超えています。({1}個)", ANIMATOR_LIMIT_COUNT, 51)));
                Assert.That(issues[i].solution, Is.EqualTo("Animatorコンポーネントの使用数を減らしてください。"));
                Assert.That(issues[i].solutionURL, Is.Empty);
            }
        }
    }
}
