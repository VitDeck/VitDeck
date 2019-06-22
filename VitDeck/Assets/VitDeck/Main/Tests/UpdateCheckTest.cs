using NUnit.Framework;
using VitDeck.Utilities;

namespace VitDeck.Main.Tests
{
    public class UpdateCheckTest
    {
        private static readonly string testURL = "https://vkettools.github.io/VitDeckTest/releases/latest.json";
        
        [Test]
        public void TestLatestVersioning()
        {
            JsonReleaseInfo.FetchInfo(testURL);
            string version = JsonReleaseInfo.GetVersion();
            Assert.That(VersionUtility.IsSemanticVersioning(version), Is.True);
            Assert.That(version, Is.EqualTo("1.0.0"));
        }
    }
}