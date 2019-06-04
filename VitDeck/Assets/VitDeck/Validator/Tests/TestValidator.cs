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
            Validator.Validate(ruleSet, "");
            
        }
        [Test]
        public void TestRuleSet()
        {
            var ruleSet = new SampleRuleSet();
            Assert.That(ruleSet.ruleSetName, Is.EqualTo("サンプルルールセット"));
            Assert.That(ruleSet.GetRules().Length, Is.EqualTo(2));
        }
    }
}
