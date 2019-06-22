using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using VitDeck.Utilities;
using VitDeck.TestUtilities;

namespace VitDeck.AssetGuardian.Tests
{
    public class LabelAndHideFlagProtectionMarkerTest
    {
        bool globalHandlerActivationState;
        ITestAsset baseFolder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            globalHandlerActivationState = Protector.Active;
            Protector.Active = false;

            baseFolder = new TestFolderAsset();
        }

        public static object[] SourceOfTestMarking()
        {
            return new object[] 
            {
                typeof(TestFolderAsset),
                typeof(TestPrefabAsset),
                typeof(TestAnimationClipAsset),
                typeof(TestAnimationOverrideControllerAsset),
                typeof(TestAudioClipAsset),
                typeof(TestModelAsset),
                typeof(TestLightMapDataAsset),
                typeof(TestMaterialAsset),
                typeof(TestMeshAsset),
                typeof(TestReflectionProbeAsset),
                typeof(TestScriptableObjectAsset<TestScriptableObject>),
                typeof(TestShaderAsset),
                typeof(TestSkyboxAsset),
                typeof(TestSpriteAsset),
                typeof(TestTextAsset),
                typeof(TestTextureAsset),
                typeof(TestAnimatiorControllerAsset),
                typeof(TestSceneAsset),
            };
        }

        [TestCaseSource("SourceOfTestMarking")]
        public void TestMarking(System.Type assetType)
        {
            ITestAsset asset = (ITestAsset)System.Activator.CreateInstance(assetType, baseFolder.Path);
            var marker = new LabelAndHideFlagProtectionMarker();

            // Get Default HideFlags
            var allInstances = AssetUtility.LoadAllAssetsWithoutSceneAtPath(asset.Path);
            var hideFlagStore = new Dictionary<Object, HideFlags>();
            foreach (var instance in allInstances)
            {
                hideFlagStore.Add(instance, instance.hideFlags);
            }

            // Mark
            marker.Mark(asset.Instance);
            Assert.That(marker.IsMarked(asset.Instance), Is.True);
            Assert.That(asset.Instance.hideFlags &= HideFlags.NotEditable, Is.EqualTo(HideFlags.NotEditable));
            Assert.That(AssetDatabase.GetLabels(asset.Instance).Contains("VitDeck.ReadOnly"), Is.True);

            // Repair
            ReimportAssets(asset.Instance);
            marker.RepairMarking(asset.Instance);
            Assert.That(marker.IsMarked(asset.Instance), Is.True);

            // Unmark
            marker.Unmark(asset.Instance);
            Assert.That(marker.IsMarked(asset.Instance), Is.False);
            Assert.That(AssetDatabase.GetLabels(asset.Instance).Contains("VitDeck.ReadOnly"), Is.False);

            // Check HideFlags
            foreach (var instance in allInstances)
            {
                if (instance == null)
                    continue;
                Assert.That(instance.hideFlags, Is.EqualTo(hideFlagStore[instance]));
            }

            marker.Dispose();
        }

        private static void ReimportAssets(params Object[] assets)
        {
            Selection.objects = assets;
            EditorApplication.ExecuteMenuItem("Assets/Reimport");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            baseFolder.Dispose();

            Protector.Active = globalHandlerActivationState;
        }
    }
}