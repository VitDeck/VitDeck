using NUnit.Framework;

namespace VitDeck.Utilities.Tests
{
    public class AssetUtilityTest
    {
        [Test]
        public void TestImagesFolderPath()
        {
            Assert.That(AssetUtility.ImageFolderPath, Is.EqualTo("Assets/VitDeck/Images"));
        }
        [Test]
        public void TestConfigFolderPath()
        {
            Assert.That(AssetUtility.ConfigFolderPath, Is.EqualTo("Assets/VitDeck/Config"));
        }
    }
}