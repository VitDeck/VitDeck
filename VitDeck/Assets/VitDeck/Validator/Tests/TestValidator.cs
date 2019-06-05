using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestValidator
    {
        [Test]
        public void TestValidate()
        {
            var ruleSet = new SampleRuleSet();
            var results = Validator.Validate(ruleSet, "Assts/Test");
            foreach (var result in results)
            {
                Debug.Log(result.GetResultLog());
            }
            Assert.That(results.Length, Is.EqualTo(2));
        }
        [Test]
        public void TestValidateException()
        {
            var ruleSet = new SampleRuleSet();
            LogAssert.Expect(LogType.Error, new Regex("^ルールチェックを中断しました:.*ベースフォルダが指定されていません。"));
            var results = Validator.Validate(ruleSet, "");
            Assert.That(results.Length, Is.EqualTo(1));
            Assert.That(results[0].Issues.Count, Is.EqualTo(1));
            Assert.That(results[0].Issues[0].target, Is.EqualTo(null));
            Assert.That(results[0].Issues[0].level, Is.EqualTo(IssueLevel.Fatal));
            Assert.That(results[0].Issues[0].message, Is.EqualTo("ベースフォルダが指定されていません。"));
            Assert.That(results[0].Issues[0].solution, Is.EqualTo(""));
            Assert.That(results[0].Issues[0].solutionURL, Is.EqualTo(""));
        }
        [Test]
        public void TestRuleSet()
        {
            var ruleSet = new SampleRuleSet();
            Assert.That(ruleSet.RuleSetName, Is.EqualTo("サンプルルールセット"));
            Assert.That(ruleSet.GetRules().Length, Is.EqualTo(2));
        }
    }
}
