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
            LatestRelease.FetchReleaseInfo(testURL);
            string version = LatestRelease.GetVersion();
            Assert.That(VersionUtility.IsSemanticVersioning(version), Is.True);
            Assert.That(version, Is.EqualTo("1.0.0"));
        }
    }
}