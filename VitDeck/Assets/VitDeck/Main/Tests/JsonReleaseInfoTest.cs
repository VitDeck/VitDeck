using NUnit.Framework;

namespace VitDeck.Main.Tests
{
    public class JsonReleaseInfoTest
    {
        [Test]
        public void TestJsonReleaseInfo()
        {
            string testJsonURL = "https://vkettools.github.io/VitDeckTest/releases/latest.json";
            JsonReleaseInfo.FetchInfo(testJsonURL);
            string JsonReleaseInfoURL = JsonReleaseInfo.GetJsonURL();
            Assert.That(JsonReleaseInfoURL, Is.EqualTo(testJsonURL));
            Assert.That(JsonReleaseInfo.GetPackageName(), Is.EqualTo("VitDeck-1.0.0-alpha1.unitypackage"));
            Assert.That(JsonReleaseInfo.GetDownloadURL(),
                Is.EqualTo("https://github.com/vkettools/VitDeckTest/releases/download/1.0.0-alpha1/VitDeck-1.0.0-alpha1.unitypackage"));
        }
    }
}
