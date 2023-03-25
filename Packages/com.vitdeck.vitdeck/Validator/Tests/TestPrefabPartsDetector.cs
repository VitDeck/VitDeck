using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VitDeck.Validator.Test
{
    public class TestPrefabPartsDetector
    {
        private const string BaseFolderPath = "Packages/com.vitdeck.vitdeck/Validator/Tests/Data/PrefabPartsDetector/";

        [Test]
        public void Test()
        {
            EditorSceneManager.OpenScene(BaseFolderPath + "PrefabPartsDetector.unity", OpenSceneMode.Single);
            var object1 = GameObject.Find("TestObject1");
            var object2 = GameObject.Find("TestObject2");

            var detector = new PrefabPartsDetector(new string[]
            {
                AssetDatabase.AssetPathToGUID(BaseFolderPath + "TestObject1.prefab")
            });

            Assert.That(detector.IsTargetObject(object1), Is.True);
            foreach (var component in object1.GetComponentsInChildren<Component>(true))
            {
                Assert.That(detector.IsTargetObject(component), Is.True);
            }

            Assert.That(detector.IsTargetObject(object2), Is.False);
            foreach (var component in object2.GetComponentsInChildren<Component>(true))
            {
                Assert.That(detector.IsTargetObject(component), Is.False);
            }


            detector = new PrefabPartsDetector(new string[]
            {
                AssetDatabase.AssetPathToGUID(BaseFolderPath + "TestObject2.prefab")
            });

            Assert.That(detector.IsTargetObject(object1), Is.False);
            foreach (var component in object1.GetComponentsInChildren<Component>(true))
            {
                Assert.That(detector.IsTargetObject(component), Is.False);
            }

            Assert.That(detector.IsTargetObject(object2), Is.True);
            foreach (var component in object2.GetComponentsInChildren<Component>(true))
            {
                Assert.That(detector.IsTargetObject(component), Is.True);
            }

        }
    }
}