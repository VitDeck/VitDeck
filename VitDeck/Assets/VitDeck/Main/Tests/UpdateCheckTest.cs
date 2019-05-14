using NUnit.Framework;
using VitDeck.Utility;

namespace VitDeck.Main.Tests
{
    public class UpdateCheckTest
    {
        [Test]
        public void TestVitDeckVersion()
        {
            UpdateCheck check = new UpdateCheck();
            string version = check.GetLatestVersion();
            Assert.That(VersionUtility.IsSemanticVersioning(version), Is.True);
        }
    }
}