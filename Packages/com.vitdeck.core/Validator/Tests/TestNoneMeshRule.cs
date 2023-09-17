using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator.Test
{
    [TestFixture(TestOf = typeof(NoneMeshRule))]
    public class TestNoneMeshRule
    {
        [Test]
        public void TestNoIssues()
        {
            var rule = new NoneMeshRule("メッシュ未設定検出ルール");
            var finder = new ValidationTargetFinder();
            var target = finder.Find(ValidatorTestUtilities.TestDirectoryPath + "/ValidationTargetFinderNoObject",
                true);

            var result = rule.Validate(target);
            var issues = result.Issues;

            Assert.That(issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestBySampleData()
        {
            var testData = ValidatorTestUtilities.DataDirectoryPath + "/NoneMeshRule";
            var rule = new NoneMeshRule("メッシュ未設定検出ルール");
            var target = new ValidationTargetFinder().Find(testData, true);

            var result = rule.Validate(target);
            var issues = result.Issues;

            Assert.That(issues.Count, Is.EqualTo(4));
            Assert.NotNull(issues.Find(issue =>
                issue.message == "NoneMeshFilterObject (UnityEngine.MeshFilter)にメッシュが設定されていません。"));
            Assert.NotNull(issues.Find(issue =>
                issue.message == "NoneMeshColliderObject (UnityEngine.MeshCollider)にメッシュが設定されていません。"));
            Assert.NotNull(issues.Find(issue =>
                issue.message == "NoneSkinnedMeshRendererObject (UnityEngine.SkinnedMeshRenderer)にメッシュが設定されていません。"));
            Assert.NotNull(issues.Find(issue =>
                issue.message ==
                "NoneMeshShapeParticleSystem (UnityEngine.ParticleSystem)/Shapeがメッシュに依存する設定であるにも関わらず、メッシュが設定されていません。"));
        }
    }
}
