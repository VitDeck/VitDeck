using NUnit.Framework;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian.Tests
{
    public class GurdianTest
    {
        string testBaseFolder = null;
        string testAssetPath = null;
        TestScriptableObject testAssetInstance = null;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var guid = AssetDatabase.CreateFolder("Assets", "TestBaseFolder");
            testBaseFolder = AssetDatabase.GUIDToAssetPath(guid);

            testAssetInstance = ScriptableObject.CreateInstance<TestScriptableObject>();
            testAssetPath = AssetDatabase.GenerateUniqueAssetPath(testBaseFolder + "/TestScriptableObject.asset");
            AssetDatabase.CreateAsset(testAssetInstance, testAssetPath);

            Registry.Register(testBaseFolder);
        }

        [Test]
        public void TestModificateSerializedValue()
        {
            SerializedObject serialized = new SerializedObject(testAssetInstance);
            SerializedProperty valueProp = serialized.FindProperty("value");

            var defaultValue = testAssetInstance.value;
            var moddedValue = defaultValue + "hoge";

            valueProp.stringValue = moddedValue;
            serialized.ApplyModifiedProperties();
            AssetDatabase.SaveAssets();
            serialized.Update();

            Assert.That(valueProp.stringValue, Is.Not.EqualTo(moddedValue));
        }

        [Test]
        public void TestDelete()
        {
            AssetDatabase.DeleteAsset(testAssetPath);
            var asset = AssetDatabase.LoadAssetAtPath<TestScriptableObject>(testAssetPath);
            Assert.That(asset, Is.Not.Null);
        }

        [Test]
        public void TestMove()
        {
            var subFolderID = AssetDatabase.CreateFolder(testBaseFolder, "SubFolder");
            var subFolder = AssetDatabase.GUIDToAssetPath(subFolderID);

            var movedPath = AssetDatabase.GenerateUniqueAssetPath(subFolder + "MovedAsset.asset");
            AssetDatabase.MoveAsset(testAssetPath, movedPath);

            var asset = AssetDatabase.LoadAssetAtPath<TestScriptableObject>(testAssetPath);
            Assert.That(asset, Is.EqualTo(testAssetInstance));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AssetGuardian.Registry.Unregister(testBaseFolder);
            AssetDatabase.DeleteAsset(testBaseFolder);
        }
    }
}