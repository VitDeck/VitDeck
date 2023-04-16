using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestSampleRule
    {
        [Test]
        public void TestValidate()
        {
            var rule = new SampleRule("サンプルルール");
            var target = new ValidationTarget(ValidatorTestUtilities.TestDirectoryPath + "/SampleRule");
            var result = rule.Validate(target);
            Assert.That(result.RuleName,Is.EqualTo("サンプルルール"));
            Assert.That(result.Issues.Count, Is.AtLeast(1));
        }
    }
}
