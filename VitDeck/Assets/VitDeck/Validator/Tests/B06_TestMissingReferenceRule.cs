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
                Is.EqualTo("missingフィールドが含まれています！（TestObject (UnityEngine.MeshFilter)/Mesh）"));
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
                Is.EqualTo("missingプレハブが含まれています！（TestPrefab (UnityEngine.GameObject)）"));
            Assert.That(result.Issues[0].target, Is.EqualTo(gameObject));
        }
    }
}