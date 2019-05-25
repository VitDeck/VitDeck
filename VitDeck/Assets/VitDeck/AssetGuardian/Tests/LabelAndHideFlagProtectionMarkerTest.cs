using NUnit.Framework;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Utilities;

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
                typeof(TestScriptableObjectAsset),
                typeof(TestMaterialAsset)
            };
        }

        [TestCaseSource("SourceOfTestMarking")]
        public void TestMarking(System.Type assetType)
        {
            ITestAsset asset = (ITestAsset)System.Activator.CreateInstance(assetType, baseFolder.Path);
            var marker = new LabelAndHideFlagProtectionMarker();

            marker.Mark(asset.Instance);
            Assert.That(marker.IsMarked(asset.Instance), Is.True);
            Assert.That(asset.Instance.hideFlags &= HideFlags.NotEditable, Is.EqualTo(HideFlags.NotEditable));
            Assert.That(AssetDatabase.GetLabels(asset.Instance).Contains("VitDeck.ReadOnly"), Is.True);

            ReimportAssets(asset.Instance);
            marker.RepairMarking(asset.Instance);
            Assert.That(marker.IsMarked(asset.Instance), Is.True);

            marker.Unmark(asset.Instance);
            Assert.That(marker.IsMarked(asset.Instance), Is.False);
            Assert.That(asset.Instance.hideFlags &= HideFlags.NotEditable, Is.EqualTo(HideFlags.None));
            Assert.That(AssetDatabase.GetLabels(asset.Instance).Contains("VitDeck.ReadOnly"), Is.False);

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