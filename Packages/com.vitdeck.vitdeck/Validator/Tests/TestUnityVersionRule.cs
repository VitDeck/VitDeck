using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.Validator.Test
{
    public class TestUnityVersionRule
    {
        [Test]
        public void TestValidate()
        {
            var version = UnityEngine.Application.unityVersion;
            var rule = new UnityVersionRule("Unityバージョンテスト", version);
            var target = new ValidationTarget("Packages/com.vitdeck.vitdeck/Validator/Tests");
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("Unityバージョンテスト"));
            Assert.That(result.Issues.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestValidateError()
        {
            var version = UnityEngine.Application.unityVersion;
            var rule = new UnityVersionRule("Unityバージョンテスト", "invalidVersion");
            var target = new ValidationTarget("Packages/com.vitdeck.vitdeck/Validator/Tests");
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("Unityバージョンテスト"));
            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].target, Is.EqualTo(null));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            //Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("実行中のUnityのバージョン({0})が指定されたバージョンと異なっています。", version)));
            //Assert.That(result.Issues[0].solution, Is.EqualTo(string.Format("バージョン({0})を使用してください。", "invalidVersion")));
            Assert.That(result.Issues[0].solutionURL, Is.EqualTo(""));
        }
    }
}
