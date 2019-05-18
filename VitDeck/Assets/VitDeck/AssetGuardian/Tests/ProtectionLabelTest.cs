using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian.Tests
{
    public class ProtectionLabelTest
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
            ProtectionLabel.Attach(testBaseFolder);
            Assert.That(ProtectionLabel.IsAttachedTo(testBaseFolder), Is.True);

            var assetInstance = ScriptableObject.CreateInstance<TestScriptableObject>();
            var assetPath = AssetDatabase.GenerateUniqueAssetPath(testBaseFolder + "/TempAsset.asset");
            AssetDatabase.CreateAsset(assetInstance, assetPath);
            ProtectionLabel.Attach(testBaseFolder);
            Assert.That(ProtectionLabel.IsAttachedTo(assetPath), Is.True);

            ProtectionLabel.Detach(testBaseFolder);
            Assert.That(ProtectionLabel.IsAttachedTo(testBaseFolder), Is.False);
            Assert.That(ProtectionLabel.IsAttachedTo(assetPath), Is.False);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ProtectionLabel.Detach(testBaseFolder);
            AssetDatabase.DeleteAsset(testBaseFolder);
        }
    }
}