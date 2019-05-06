using NUnit.Framework;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian.Tests
{
    public class GurdianTest
    {
        const string GuardFolderParentName = "Assets";
        const string GuardFolderName = "Temp";
        const string GuardPath = GuardFolderParentName + "/" + GuardFolderName;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AssetDatabase.DeleteAsset(GuardPath);
            AssetDatabase.CreateFolder(GuardFolderParentName, GuardFolderName);
        }

        [Test]
        public void ModificationGuardTest()
        {
            string defaultValue = "hoge";
            string moddedValue = "fuga";

            TestScriptableObject asset = ScriptableObject.CreateInstance<TestScriptableObject>();
            asset.name = defaultValue;
            asset.value = defaultValue;
            AssetDatabase.CreateAsset(asset, Path.Combine(GuardPath, "TempAsset.asset"));

            SerializedObject serialized = new SerializedObject(asset);
            SerializedProperty valueProp = serialized.FindProperty("value");

            AssetGuardian.Registry.Register(GuardPath);
            WriteAndReload(moddedValue, serialized, valueProp);
            Assert.AreEqual(defaultValue, valueProp.stringValue);

            AssetGuardian.Registry.Unregister(GuardPath);
            WriteAndReload(moddedValue, serialized, valueProp);
            Assert.AreEqual(moddedValue, valueProp.stringValue);
        }

        private static void WriteAndReload(string value, SerializedObject serialized, SerializedProperty valueProp)
        {
            valueProp.stringValue = value;
            serialized.ApplyModifiedProperties();
            AssetDatabase.SaveAssets();
            serialized.Update();
        }

        [Test]
        public void DeleteGuardTest()
        {
            var assetPath = Path.Combine(GuardPath, "TempAsset.asset");
            TestScriptableObject asset = ScriptableObject.CreateInstance<TestScriptableObject>();
            AssetDatabase.CreateAsset(asset, assetPath);

            AssetGuardian.Registry.Register(GuardPath);
            AssetDatabase.DeleteAsset(assetPath);
            asset = AssetDatabase.LoadAssetAtPath<TestScriptableObject>(assetPath);
            Assert.That(asset, Is.Not.Null);

            AssetGuardian.Registry.Unregister(GuardPath);
            AssetDatabase.DeleteAsset(assetPath);
            asset = AssetDatabase.LoadAssetAtPath<TestScriptableObject>(assetPath);
            Assert.That(asset, Is.Null);
        }

        [Test]
        public void MoveOutGuardTest()
        {
            var assetPath = Path.Combine(GuardPath, "TempAsset.asset");
            var movedAssetPath = Path.Combine(GuardPath, "TempAssetMoved.asset");
            TestScriptableObject asset = ScriptableObject.CreateInstance<TestScriptableObject>();
            AssetDatabase.CreateAsset(asset, assetPath);

            AssetGuardian.Registry.Register(GuardPath);
            AssetDatabase.MoveAsset(assetPath, movedAssetPath);
            asset = AssetDatabase.LoadAssetAtPath<TestScriptableObject>(assetPath);
            Assert.That(asset, Is.Not.Null);

            AssetGuardian.Registry.Unregister(GuardPath);
            AssetDatabase.MoveAsset(assetPath, movedAssetPath);
            asset = AssetDatabase.LoadAssetAtPath<TestScriptableObject>(movedAssetPath);
            Assert.That(asset, Is.Not.Null);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AssetGuardian.Registry.Unregister(GuardPath);
            AssetDatabase.DeleteAsset(GuardPath);
        }
    }
}