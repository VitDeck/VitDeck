using NUnit.Framework;
using System;
using System.Linq;
using UnityEditor;

namespace VitDeck.Validator.Test
{
    public class TestValidationTargetFinder
    {
        [Test]
        public void TestFind()
        {
            var testFolder = "Assets/VitDeck/Validator/Tests/ValidationTargetFinder";
            var finder = new ValidationTargetFinder();
            var validationTarget = finder.Find(testFolder, true);
            Assert.That(validationTarget.GetBaseFolderPath(), Is.EqualTo(testFolder));
            Assert.That(validationTarget.GetAllAssetPaths(), Is.Not.Null);
            Assert.That(validationTarget.GetAllAssetGuids(), Is.Not.Null);
            Assert.That(validationTarget.GetAllAssets(), Is.Not.Null);
            Assert.That(validationTarget.GetScenes(), Is.Not.Null);
            Assert.That(validationTarget.GetRootObjects(), Is.Not.Null);
            Assert.That(validationTarget.GetAllObjects(), Is.Not.Null);
        }
        [Test]
        public void TestFindInvalid()
        {
            var testFolder = "Invalid";
            var finder = new ValidationTargetFinder();
            Assert.That(() => finder.Find(testFolder),
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
            Assert.That(Array.Exists(assetPaths, path => path == (testFolder + "/Sub Folder")), Is.True);
            Assert.That(Array.Exists(assetPaths, path => path == (testFolder + "/Sub Folder/New Prefab in sub folder.prefab")), Is.True);
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
            Assert.That(Array.Exists(assetGuids, guid => guid == "b71fe49e9d4fb154dad657ed2f1022d4"), Is.True);
            //New Prefab in sub folder.prefab
            Assert.That(Array.Exists(assetGuids, guid => guid == "bc38aa664d9d7aa4a947a00a8777c5b9"), Is.True);
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
            Assert.That(Array.Exists(assetObjects, obj => AssetDatabase.GetAssetPath(obj) == (testFolder + "/Sub Folder")), Is.True);
            //New Prefab in sub folder.prefab
            Assert.That(Array.Exists(assetObjects, obj => AssetDatabase.GetAssetPath(obj) == (testFolder + "/Sub Folder/New Prefab in sub folder.prefab")), Is.True);
            //FBXのサブアセットによりオブジェクトが重複取得されない
            Assert.That(assetObjects.Length, Is.EqualTo(assetObjects.Distinct().Count()));
        }
        [Test]
        public void TestFindScenes()
        {
            var testFolder = "Assets/VitDeck/Validator/Tests/ValidationTargetFinder";
            var finder = new ValidationTargetFinder();
            var scenes = finder.FindScenes(testFolder, true);
            //New Scene
            Assert.That(scenes.Length, Is.EqualTo(1));
            Assert.That(Array.Exists(scenes, scene => scene.path == "Assets/VitDeck/Validator/Tests/ValidationTargetFinder/New Scene.unity"), Is.True);
        }
        [Test]
        public void TestFindRootObjects()
        {
            var testFolder = "Assets/VitDeck/Validator/Tests/ValidationTargetFinder";
            var finder = new ValidationTargetFinder();
            var rootObjects = finder.FindRootObjects(testFolder, true);
            //New Scene
            Assert.That(rootObjects.Length, Is.EqualTo(3));
            Assert.That(Array.Exists(rootObjects, obj => obj.name == "Cube(main)"), Is.True);
            Assert.That(Array.Exists(rootObjects, obj => obj.name == "Directional Light"), Is.True);
            Assert.That(Array.Exists(rootObjects, obj => obj.name == "Main Camera"), Is.True);
        }
        [Test]
        public void TestFindObjects()
        {
            var testFolder = "Assets/VitDeck/Validator/Tests/ValidationTargetFinder";
            var finder = new ValidationTargetFinder();
            var allObjects = finder.FindAllObjects(testFolder, true);
            //New Scene
            Assert.That(allObjects.Length, Is.AtLeast(4));
            Assert.That(Array.Exists(allObjects, obj => obj.name == "Cube(main)"), Is.True);
            Assert.That(Array.Exists(allObjects, obj => obj.name == "Cube(child)"), Is.True);
            Assert.That(Array.Exists(allObjects, obj => obj.name == "Capsule"), Is.True);
            Assert.That(Array.Exists(allObjects, obj => obj.name == "Audio Source"), Is.True);
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
        [Test]
        public void TestFindNoObject()
        {
            var testFolder = "Assets/VitDeck/Validator/Tests/ValidationTargetFinderNoObject";
            var finder = new ValidationTargetFinder();
            var rootObjects = finder.FindRootObjects(testFolder, true);
            Assert.That(rootObjects.Length, Is.EqualTo(0));
            var allObjects = finder.FindAllObjects(testFolder, true);
            Assert.That(allObjects.Length, Is.EqualTo(0));
        }
    }
}
