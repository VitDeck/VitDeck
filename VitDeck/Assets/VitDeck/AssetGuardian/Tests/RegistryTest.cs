using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace VitDeck.AssetGuardian.Tests
{
    public class RegistryTest
    {
        string testBaseFolder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var guid = AssetDatabase.CreateFolder("Assets", "TestBaseFolder");
            testBaseFolder = AssetDatabase.GUIDToAssetPath(guid);
        }

        [Test]
        public void TestRegisterAndUnregister()
        {
            Registry.Register(testBaseFolder);
            Assert.That(Registry.Contains(testBaseFolder), Is.True);

            var assetInstance = ScriptableObject.CreateInstance<TestScriptableObject>();
            var assetPath = AssetDatabase.GenerateUniqueAssetPath(testBaseFolder + "/TempAsset.asset");
            AssetDatabase.CreateAsset(assetInstance, assetPath);
            Registry.Register(testBaseFolder);
            Assert.That(Registry.Contains(assetPath), Is.True);

            Registry.Unregister(testBaseFolder);
            Assert.That(Registry.Contains(testBaseFolder), Is.False);
            Assert.That(Registry.Contains(assetPath), Is.False);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Registry.Unregister(testBaseFolder);
            AssetDatabase.DeleteAsset(testBaseFolder);
        }
    }
}