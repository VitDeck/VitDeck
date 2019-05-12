using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian.Tests
{
    public class GurdianTest
    {
        string testBaseFolder = null;
        string protectedAssetPath = null;
        TestScriptableObject protectedAssetInstance = null;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var guid = AssetDatabase.CreateFolder("Assets", "TestBaseFolder");
            testBaseFolder = AssetDatabase.GUIDToAssetPath(guid);

            protectedAssetInstance = ScriptableObject.CreateInstance<TestScriptableObject>();
            protectedAssetPath = AssetDatabase.GenerateUniqueAssetPath(testBaseFolder + "/TestScriptableObject.asset");
            AssetDatabase.CreateAsset(protectedAssetInstance, protectedAssetPath);

            ProtectionLabel.Attach(testBaseFolder);
        }
        
        [Test]
        public void TestDelete()
        {
            var returnsFail = Is.EqualTo(AssetDeleteResult.FailedDelete);
            Guardian guardian = new Guardian();
            Assert.That(guardian.OnWillDeleteAsset(protectedAssetPath, RemoveAssetOptions.DeleteAssets), returnsFail);
            Assert.That(guardian.OnWillDeleteAsset(protectedAssetPath, RemoveAssetOptions.MoveAssetToTrash), returnsFail);

        }

        [Test]
        public void TestMove()
        {
            var subFolderID = AssetDatabase.CreateFolder(testBaseFolder, "SubFolder");
            var subFolder = AssetDatabase.GUIDToAssetPath(subFolderID);
            var movedPath = AssetDatabase.GenerateUniqueAssetPath(subFolder + "MovedAsset.asset");

            Guardian guardian = new Guardian();
            Assert.That(guardian.OnWillMoveAsset(protectedAssetPath, movedPath), Is.EqualTo(AssetMoveResult.FailedMove));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ProtectionLabel.Detach(testBaseFolder);
            AssetDatabase.DeleteAsset(testBaseFolder);
        }
    }
}