using NUnit.Framework;
using VitDeck.Utility;

namespace VitDeck.Main.Tests
{
    public class UpdateCheckTest
    {
        private static readonly string test_url = "https://vkettools.github.io/VitDeckTest/releases/latest.json";
        
        [Test]
        public void TestLatestVersioning()
        {
            string tag = UpdateCheck.GetLatestVersion(test_url);
            Assert.That(VersionUtility.IsSemanticVersioning(tag), Is.True);
            Assert.That(tag == "0.0.0");
        }
    }
}