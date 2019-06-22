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

        [OneTimeSetUp]
        public void SetUp()
        {
            rootFolder = new TestFolderAsset();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            rootFolder.Dispose();
        }

        [Test]
        public void TestValidation()
        {
            var rule = new MissingReferenceRule("missing検出ルール");
            var gameObject = new GameObject("TestObject");
            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", allObjects: new GameObject[] { gameObject });

            var result = rule.Validate(target);

            Assert.That(result.Issues.Count, Is.Zero);
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
        public void TestPrefabReferenceMissing()
        {
            var rule = new MissingReferenceRule("missing検出ルール");
            var prefabAsset = new TestPrefabAsset(rootFolder.Path);
            var gameObject = (GameObject)PrefabUtility.InstantiatePrefab(prefabAsset.Instance);
            AssetDatabase.SaveAssets();

            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", allObjects: new GameObject[] { gameObject });
            prefabAsset.Dispose();

            var result = rule.Validate(target);
            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].message,
                Is.EqualTo(string.Format("missingプレハブが含まれています！（{0}）", gameObject.name)));
            Assert.That(result.Issues[0].target, Is.EqualTo(gameObject));
        }

        [Test]
        public void TestRecursiveReferenceTest()
        {
            var rule = new MissingReferenceRule("missing検出ルール");

            var prefabAsset = new TestPrefabAsset(rootFolder.Path);
            var parentGameObject = new GameObject("TestParentObject", typeof(Rigidbody), typeof(FixedJoint));
            var childGameObject = new GameObject("TestChildObject", typeof(Rigidbody), typeof(FixedJoint));
            childGameObject.GetComponent<FixedJoint>().connectedBody = parentGameObject.GetComponent<Rigidbody>();
            var materialAsset = new TestMaterialAsset(rootFolder.Path);
            childGameObject.AddComponent<TrailRenderer>().material = materialAsset.Instance;

            AssetDatabase.SaveAssets();

            var target = new ValidationTarget("Assets/VitDeck/Validator/Tests", allObjects: new GameObject[] { parentGameObject, childGameObject });
            materialAsset.Dispose();
            var result = rule.Validate(target);
            Assert.That(result.Issues.Count, Is.EqualTo(1));
            Assert.That(result.Issues[0].message,
                Is.EqualTo("missingフィールドが含まれています！（TestChildObject > TrailRenderer > Element 0）"));
        }
    }
}