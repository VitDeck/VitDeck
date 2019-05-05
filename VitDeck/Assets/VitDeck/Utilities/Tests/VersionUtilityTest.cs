using NUnit.Framework;

namespace VitDeck.Utilities.Tests
{
    public class VersionUtilityTest
    {
        [Test]
        public void TestSemanticVersioning()
        {
            Assert.That(VersionUtility.IsSemanticVersioning("0.0.1"), Is.True);
            Assert.That(VersionUtility.IsSemanticVersioning("0.00.1"), Is.False);
            Assert.That(VersionUtility.IsSemanticVersioning("0.1"), Is.False);
            Assert.That(VersionUtility.IsSemanticVersioning("2.5.8-alpha"), Is.True);
            Assert.That(VersionUtility.IsSemanticVersioning("2.5.8-"), Is.False);
            Assert.That(VersionUtility.IsSemanticVersioning("1.342.1+1.2.3"), Is.True);
            Assert.That(VersionUtility.IsSemanticVersioning("1.342.1+"), Is.False);
            Assert.That(VersionUtility.IsSemanticVersioning("1.342.1-alpha3.2.3+5260032"), Is.True);
            Assert.That(VersionUtility.IsSemanticVersioning("1.342.1+5260032-alpha3.2.3"), Is.False);
        }
    }
}