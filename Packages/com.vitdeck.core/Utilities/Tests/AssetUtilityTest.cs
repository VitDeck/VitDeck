using NUnit.Framework;
using UnityEditor;
using UnityEngine.Windows;

namespace VitDeck.Utilities.Tests
{
    public class AssetUtilityTest
    {
        [Test]
        public void TestImagesFolderPath()
        {
            Assert.That(AssetUtility.ImageFolderPath, Is.EqualTo("Packages/com.vitdeck.core/Images"));
        }

        [Test]
        public void TestConfigFolderPath()
        {
            Assert.That(AssetUtility.ConfigFolderPath, Is.EqualTo("Assets/VitDeck/Config"));
        }

        [Test]
        public void TestRootFolderPath()
        {
            Assert.That(AssetUtility.RootFolderPath, Is.EqualTo("Packages/com.vitdeck.core"));
        }
    }
}
