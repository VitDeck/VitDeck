using NUnit.Framework;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator.Test
{
    public class TestValidationTargetFinder
    {
        [Test]
        public void TestFind()
        {
            var testFolder = "Assets/VitDeck/Validator/Tests/ValidationTargetFinder";
            var finder = new ValidationTargetFinder();
            var validationTarget = finder.Find(testFolder);
            Assert.That(validationTarget.GetBaseFolderPath(), Is.EqualTo(testFolder));
            Assert.That(validationTarget.GetAllAssetPaths(), Is.Not.Null);
            Assert.That(validationTarget.GetAllAssetGuids(), Is.Not.Null);
            Assert.That(validationTarget.GetAllAssets(), Is.Not.Null);
            //Assert.That(validationTarget.GetScenes(), Is.Not.Null); //ToDo:実装
            //Assert.That(validationTarget.GetRootObjects(), Is.Not.Null); //ToDo:実装
            //Assert.That(validationTarget.GetAllObjects(), Is.Not.Null); //ToDo:実装
        }
        [Test]
        public void TestFindInvalid()
        {
            var testFolder = "Invalid";
            var finder = new ValidationTargetFinder();
            Assert.That(()=> finder.Find(testFolder),
                 Throws.Exception.TypeOf<FatalValidationErrorException>()
                 .And.Message.EqualTo("正しいベースフォルダを指定してください。:Invalid"));
        }
        [Test]
        public void TestFindAssetPaths()
        {
            var testFolder = "Assets/VitDeck/Validator/Tests/ValidationTargetFinder";
            var finder = new ValidationTargetFinder();
            var assetPaths = finder.FindAssetPaths(testFolder);
            Assert.That(Array.Exists(assetPaths, path => path == testFolder), Is.True);
            Assert.That(Array.Exists(assetPaths, path => path == (testFolder + "/Sample_object.fbx")), Is.True);
            Assert.That(Array.Exists(assetPaths, path => path == (testFolder + "/New Scene.unity")), Is.True);
            Assert.That(Array.Exists(assetPaths, path => path == (testFolder + "/Sub Fonder")), Is.True);
            Assert.That(Array.Exists(assetPaths, path => path == (testFolder + "/Sub Fonder/Scene in sub folder.unity")), Is.True);
            //FBXのサブアセットによりパスが重複取得されない
            Assert.That(assetPaths.Length, Is.EqualTo(assetPaths.Distinct().Count()));
        }
        [Test]
        public void TestFindAssetGuids()
        {
            var testFolder = "Assets/VitDeck/Validator/Tests/ValidationTargetFinder";
            var finder = new ValidationTargetFinder();
            var assetGuids = finder.FindAssetGuids(testFolder);
            //Base Folder
            Assert.That(Array.Exists(assetGuids, guid => guid == "00b620bc0483bf045a4e7cbf4c051f27"), Is.True);
            //New Scene.unity
            Assert.That(Array.Exists(assetGuids, guid => guid == "f1f69f0382468de4284c5b19f5d367e5"), Is.True);
            //Sample_object.fbx 
            Assert.That(Array.Exists(assetGuids, guid => guid == "a4b03051a833cca449d86b3821e3079f"), Is.True);
            //Sub Fonder
            Assert.That(Array.Exists(assetGuids, guid => guid == "de218765854f6bf4ba69502dfe9b1e86"), Is.True);
            //Scene in sub folder.unity
            Assert.That(Array.Exists(assetGuids, guid => guid == "068dc3056368a43488efe92a2c772309"), Is.True);
            //FBXのサブアセットによりGUIDが重複取得されない
            Assert.That(assetGuids.Length, Is.EqualTo(assetGuids.Distinct().Count()));
        }
        [Test]
        public void TestFindAssetObjects()
        {
            var testFolder = "Assets/VitDeck/Validator/Tests/ValidationTargetFinder";
            var finder = new ValidationTargetFinder();
            var assetObjects = finder.FindAssetObjects(testFolder);
            //Base Folder
            Assert.That(Array.Exists(assetObjects, obj => AssetDatabase.GetAssetPath(obj) == testFolder), Is.True);
            //New Scene.unity
            Assert.That(Array.Exists(assetObjects, obj => AssetDatabase.GetAssetPath(obj) == (testFolder + "/New Scene.unity")), Is.True);
            //Sample_object.fbx 
            Assert.That(Array.Exists(assetObjects, obj => AssetDatabase.GetAssetPath(obj) == (testFolder + "/Sample_object.fbx")), Is.True);
            //Sub Fonder
            Assert.That(Array.Exists(assetObjects, obj => AssetDatabase.GetAssetPath(obj) == (testFolder + "/Sub Fonder")), Is.True);
            //Scene in sub folder.unity
            Assert.That(Array.Exists(assetObjects, obj => AssetDatabase.GetAssetPath(obj) == (testFolder + "/Sub Fonder/Scene in sub folder.unity")), Is.True);
            //FBXのサブアセットによりオブジェクトが重複取得されない
            Assert.That(assetObjects.Length, Is.EqualTo(assetObjects.Distinct().Count()));
        }
        [Test]
        public void TestInvalidPath()
        {
            var finder = new ValidationTargetFinder();
            var path = "invalidPath";
            Assert.That(finder.FindAssetPaths(path), Is.Null);
            Assert.That(finder.FindAssetGuids(path), Is.Null);
            Assert.That(finder.FindAssetObjects(path), Is.Null);
            Assert.That(finder.FindScenes(path), Is.Null);
            Assert.That(finder.FindRootObjects(path), Is.Null);
            Assert.That(finder.FindAllObjects(path), Is.Null);
        }
    }
}
