using NUnit.Framework;
using VitDeck.Utilities;

namespace VitDeck.Main.Tests
{
    public class UpdateCheckTest
    {
        private static readonly string testURL = "https://vitdeck.github.io/VitDeckTest/releases/latest.json";

        [Test]
        public void TestLatestVersioning()
        {
            JsonReleaseInfo.FetchInfo(testURL);
            string version = JsonReleaseInfo.GetVersion();
            Assert.That(version, Is.EqualTo("1.0.0"));
        }
        [Test]
        public void TestGetLatestVersion()
        {
            var version = UpdateCheck.GetLatestVersion();
            if(version != null)
                Assert.That(version, Is.Not.Empty);
        }
    }
}