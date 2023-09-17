using NUnit.Framework;

namespace VitDeck.Utilities.Tests
{
    public class URLUtilityTest
    {
        [Test]
        public void TestIsValidURL()
        {
            Assert.That(URLUtility.isValidURLString("http://github.com/vitdeck/VitDeck"), Is.True);
            Assert.That(
                URLUtility.isValidURLString(
                    "https://github.com/vitdeck/VitDeck/blob/56b11a7dbbca3b8cf6c4104ca443f78f2beae9c1/LICENSE?query=test#1"),
                Is.True);
            Assert.That(URLUtility.isValidURLString("http://www.google.co.jp/search?q=C"), Is.True);
            Assert.That(URLUtility.isValidURLString("ftp://github.com/"), Is.False);
            Assert.That(URLUtility.isValidURLString(""), Is.False);
            Assert.That(URLUtility.isValidURLString(null), Is.False);
            Assert.That(URLUtility.isValidURLString("Test String"), Is.False);
        }
    }
}
