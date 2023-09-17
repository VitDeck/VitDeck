using NUnit.Framework;

namespace VitDeck.Utilities.Tests
{
    public class ProductInfoUtilityTest
    {
        [Test]
        public void TestGetVersion()
        {
            var version = ProductInfoUtility.GetVersion();
            Assert.That(version, Is.EqualTo("2.0.0-exp.2"));
        }

        [Test]
        public void TestGetDeveloperLinkTitle()
        {
            var title = ProductInfoUtility.GetDeveloperLinkTitle();
            Assert.That(title, Is.EqualTo("VitDeck on GitHub"));
        }

        [Test]
        public void TestGetDeveloperLinkURL()
        {
            var url = ProductInfoUtility.GetDeveloperLinkURL();
            Assert.That(url, Is.EqualTo("https://github.com/vitdeck/VitDeck"));
        }
    }
}
