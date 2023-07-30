using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestContainMatOrTexInAssetRule
    {
        [Test]
        public void TestValidate()
        {
            var rule = new ContainMatOrTexInAssetRule("アセット内のMaterialやTextureの埋め込みを検証するルール");
            var finder = new ValidationTargetFinder();
            var target = finder.Find(ValidatorTestUtilities.DataDirectoryPath + "/ContainMatOrTexInAssetRule/OK", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("アセット内のMaterialやTextureの埋め込みを検証するルール"));

            Assert.That(result.Issues.Count, Is.Zero);
        }

        [Test]
        public void TestValidateError()
        {
            var rule = new ContainMatOrTexInAssetRule("アセット内のMaterialやTextureの埋め込みを検証するルール");
            var finder = new ValidationTargetFinder();
            var target = finder.Find(ValidatorTestUtilities.DataDirectoryPath + "/ContainMatOrTexInAssetRule/NG", true);
            var result = rule.Validate(target);
            Assert.That(result.RuleName,Is.EqualTo("アセット内のMaterialやTextureの埋め込みを検証するルール"));

            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            //Assert.That(result.Issues[0].message, Is.EqualTo("アセット内に埋め込まれているMaterialが使用されています。"));
            //Assert.That(result.Issues[0].solution, Is.EqualTo("ExtractMaterialsをおこなって出力されたMaterialを使用してください。"));
            Debug.Log(result.Issues[0].message);
            Debug.Log(result.Issues[0].solution);
        }
    }
}
