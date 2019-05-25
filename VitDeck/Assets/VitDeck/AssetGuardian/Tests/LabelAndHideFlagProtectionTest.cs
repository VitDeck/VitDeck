using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.AssetGuardian.Tests
{
    public class GurdianTest
    {
        bool globalHandlerActivationState;
        string baseFolderPath = null;
        string protectedAssetPath = null;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            globalHandlerActivationState = Protector.Active;
            Protector.Active = false;

            var baseFolderGUID = AssetDatabase.CreateFolder("Assets", "TestBaseFolder");
            baseFolderPath = AssetDatabase.GUIDToAssetPath(baseFolderGUID);

            var protectedAssetInstance = ScriptableObject.CreateInstance<TestScriptableObject>();
            protectedAssetPath = AssetDatabase.GenerateUniqueAssetPath(baseFolderPath + "/TestScriptableObject.asset");
            AssetDatabase.CreateAsset(protectedAssetInstance, protectedAssetPath);
        }

        [Test]
        public void ProtectionTest()
        {
            var asset = AssetDatabase.LoadAssetAtPath<Object>(protectedAssetPath);

            var protection = new LabelAndHideFlagProtectionMarker();

            Assert.That(protection.IsProtected(asset), Is.False);

            protection.Protect(asset);
            Assert.That(protection.IsProtected(asset), Is.True);

            ReimportAssets(asset);
            protection.RepairProtection(asset);
            Assert.That(protection.IsProtected(asset), Is.True);

            protection.Unprotect(asset);
            Assert.That(protection.IsProtected(asset), Is.False);

            protection.Dispose();

        }

        private static void ReimportAssets(params Object[] assets)
        {
            Selection.objects = assets ;
            EditorApplication.ExecuteMenuItem("Assets/Reimport");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AssetDatabase.DeleteAsset(baseFolderPath);

            Protector.Active = globalHandlerActivationState;
        }
    }
}