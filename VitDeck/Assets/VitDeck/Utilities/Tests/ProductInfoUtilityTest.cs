using NUnit.Framework;

namespace VitDeck.Utilities.Tests
{
    public class ProductInfoUtilityTest
    {
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
            Assert.That(url, Is.EqualTo("https://github.com/vkettools/VitDeck"));
        }
    }
}