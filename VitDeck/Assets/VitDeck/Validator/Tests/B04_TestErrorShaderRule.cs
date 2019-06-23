using UnityEngine;
using NUnit.Framework;
using UnityEditor;

namespace VitDeck.Validator.Test
{
    public class TestErrorShaderRule
    {
        [Test]
        public void TestValidate()
        {
            var finder = new ValidationTargetFinder();
            var target = finder.Find("Assets/VitDeck/Validator/Tests/Data/B04_ErrorShaderRule", true);
            var rule = new ErrorShaderRule("エラーシェーダー検出");
            var result = rule.Validate(target);
            Assert.That(result.RuleName, Is.EqualTo("エラーシェーダー検出"));
            Assert.That(result.Issues.Count, Is.EqualTo(3));
            Assert.That(result.Issues[0].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[0].target.name, Is.EqualTo("HiddenInternalErrorShaderObject"));
            Assert.That(result.Issues[0].message, Is.EqualTo(string.Format("オブジェクト({0})のマテリアルで正しいシェーダーが参照されていません。", "HiddenInternalErrorShaderObject")));
            Assert.That(result.Issues[0].solution, Is.Empty);
            Assert.That(result.Issues[0].solutionURL, Is.Empty);
            Assert.That(result.Issues[1].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[1].target.name, Is.EqualTo("ErrorShaderObject"));
            Assert.That(result.Issues[1].message, Is.EqualTo(string.Format("オブジェクト({0})でシェーダーエラーが検出されました。", "ErrorShaderObject")));
            Assert.That(result.Issues[1].solution, Is.Empty);
            Assert.That(result.Issues[1].solutionURL, Is.Empty);
            Assert.That(result.Issues[2].level, Is.EqualTo(IssueLevel.Error));
            Assert.That(result.Issues[2].target.name, Is.EqualTo("NoneMaterialObject"));
            Assert.That(result.Issues[2].message, Is.EqualTo(string.Format("オブジェクト({0})のRendererにマテリアルの参照がありません。", "NoneMaterialObject")));
            Assert.That(result.Issues[2].solution, Is.Empty);
            Assert.That(result.Issues[2].solutionURL, Is.Empty);
        }
    }
}