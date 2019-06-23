using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using VitDeck.TestUtilities;
using UnityEditor;

namespace VitDeck.Validator.Test
{
    public class TestMissingReferenceRule
    {
        TestFolderAsset rootFolder = null;

        [SetUp]
        public void SetUp()
        {
            rootFolder = new TestFolderAsset();
        }

        [TearDown]
        public void TearDown()
        {
            rootFolder.Dispose();
        }

        [Test]
        public void TestAssetReferenceMissing()
        {
            var rule = new MissingReferenceRule("missing検出ルール");
            var gameObject = new GameObject("TestObject");
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", allObjects: new GameObject[] { gameObject });

            var meshAsset = new TestMeshAsset(rootFolder.Path);
            var meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = AssetDatabase.LoadAssetAtPath<Mesh>(meshAsset.Path);
            meshAsset.Dispose();

            var result = rule.Validate(target);
            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].message,
                Is.EqualTo(string.Format("missingフィールドが含まれています！（{0} > {1} > Mesh）", gameObject.name, typeof(MeshFilter).Name)));
            Assert.That(result.Issues[0].target, Is.EqualTo(meshFilter));
        }

        [Test]
        public void TestBySampleData()
        {
            var testData = "Assets/VitDeck/Validator/Tests/Data/B06_MissingReferenceRule";
            var rule = new MissingReferenceRule("missing検出ルール");
            var target = new ValidationTargetFinder().Find(testData, true);

            var result = rule.Validate(target);

            Assert.NotNull(result.Issues.Find(issue => 
                issue.message == "missingフィールドが含まれています！（B06_MissingTestMaterial > Texture）" && 
                issue.target == AssetDatabase.LoadAssetAtPath<Material>(testData + "/B06_MissingTestMaterial.mat")));
            Assert.NotNull(result.Issues.Find(issue => 
                issue.message == "missingプレハブが含まれています！（Missing Prefab）" &&
                issue.target == GameObject.Find("Missing Prefab")));
        }
    }
}