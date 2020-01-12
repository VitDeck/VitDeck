using NUnit.Framework;

namespace VitDeck.Validator.Test
{
    public class E05_TestGlobalIlluminationBakedRule
    {
        [Test]
        public void TestValidate()
        {
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/E05_GlobalIlluminationBakedRule", true);
            var rule = new E05_GlobalIlluminationBakedRule("Global IlluminationのBakedチェックルール");
            var result = rule.Validate(target);

            Assert.That(result.RuleName, Is.EqualTo("Global IlluminationのBakedチェックルール"));
            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("Cube_GINotBaked"));
            Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("アセット{0}でGlobal IlluminationがBakedに設定されていません。", "Cube_GINotBaked (UnityEngine.GameObject)")));
            Assert.That(result.Issues[0].solution, Is.EqualTo("Standard ShaderでEmissionを利用する場合はGlobal Illuminationの設定をBakedにしてください。"));
            Assert.That(result.Issues[0].solutionURL, Is.Empty);
		}
    }
}