using NUnit.Framework;

namespace VitDeck.Main.Tests
{
    public class LatestReleaseTest
    {
        [Test]
        public void TestLatestRelease()
        {
            string testJsonURL = "https://vkettools.github.io/VitDeckTest/releases/latest.json";
            LatestRelease.FetchReleaseInfo(testJsonURL);
            string latestReleaseURL = LatestRelease.GetReleaseJsonURL();
            Assert.That(latestReleaseURL, Is.EqualTo(testJsonURL));
            Assert.That(LatestRelease.GetPackageName(), Is.EqualTo("VitDeck-1.0.0-alpha1.unitypackage"));
            Assert.That(LatestRelease.GetDownloadURL(),
                Is.EqualTo("https://github.com/vkettools/VitDeckTest/releases/download/1.0.0-alpha1/VitDeck-1.0.0-alpha1.unitypackage"));
        }
    }
}
