using NUnit.Framework;

namespace VitDeck.Main.Tests
{
    public class RepositoryTest
    {
        [Test]
        public void TestLatestReleaseURL()
        {
            string testURL = "https://api.github.com/repos/vkettools/VitDeck/releases/latest";
            string latestReleaseURL = Repository.GetLatestReleaseURL();
            Assert.AreEqual(latestReleaseURL, testURL);
        }

        [Test]
        public void TestGetPackageName()
        {
            Assert.That(Repository.GetPackageName("0.0.1"), Is.EqualTo("VitDeck-0.0.1.unitypackage"));
            Assert.That(Repository.GetPackageName("0.1.0"), Is.EqualTo("VitDeck-0.1.0.unitypackage"));
            Assert.That(Repository.GetPackageName("1.0.0"), Is.EqualTo("VitDeck-1.0.0.unitypackage"));
            Assert.That(Repository.GetPackageName("1.0"), Is.Null);
            Assert.That(Repository.GetPackageName("1.0.0.0"), Is.Null);
            Assert.That(Repository.GetPackageName("１．０．０"), Is.Null);
            Assert.That(Repository.GetPackageName("1.０.0"), Is.Null);
            Assert.That(Repository.GetPackageName("v1.0.0"), Is.Null);
            Assert.That(Repository.GetPackageName("ver1.0.0"), Is.Null);
        }

        [Test]
        public void TestDownloadURL()
        {
            Assert.That(Repository.GetDownloadURL("0.0.1"),
                Is.EqualTo("https://github.com/vkettools/VitDeck/releases/download/0.0.1/VitDeck-0.0.1.unitypackage"));
            Assert.That(Repository.GetDownloadURL("0.1.0"),
                Is.EqualTo("https://github.com/vkettools/VitDeck/releases/download/0.1.0/VitDeck-0.1.0.unitypackage"));
            Assert.That(Repository.GetDownloadURL("1.0.0"),
                Is.EqualTo("https://github.com/vkettools/VitDeck/releases/download/1.0.0/VitDeck-1.0.0.unitypackage"));
            Assert.That(Repository.GetDownloadURL("1.0"), Is.Null);
            Assert.That(Repository.GetDownloadURL("1.0.0.0"), Is.Null);
            Assert.That(Repository.GetDownloadURL("１．０．０"), Is.Null);
            Assert.That(Repository.GetDownloadURL("1.０.0"), Is.Null);
            Assert.That(Repository.GetDownloadURL("v1.0.0"), Is.Null);
            Assert.That(Repository.GetDownloadURL("ver1.0.0"), Is.Null);
        }
    }
}