using NUnit.Framework;

namespace VitDeck.Main.Tests
{
    public class JsonReleaseInfoTest
    {
        [Test]
        public void TestJsonReleaseInfo()
        {
            string testJsonURL = "https://vitdeck.github.io/VitDeckTest/releases/latest.json";
            JsonReleaseInfo.FetchInfo(testJsonURL);
            Assert.That(JsonReleaseInfo.GetVersion(), Is.EqualTo("1.0.0"));
            Assert.That(JsonReleaseInfo.GetPackageName(), Is.EqualTo("VitDeck-1.0.0-alpha1.unitypackage"));
            Assert.That(JsonReleaseInfo.GetDownloadURL(),
                Is.EqualTo(
                    "https://github.com/vitdeck/VitDeckTest/releases/download/1.0.0-alpha1/VitDeck-1.0.0-alpha1.unitypackage"));
        }
    }
}
