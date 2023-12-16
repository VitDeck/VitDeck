using NUnit.Framework;

namespace VitDeck.Validator
{
    [TestFixture(TestOf = typeof(VRCSDKVersionRule))]
    public class VRCSDKVersionTest
    {
        [Test]
        public void OperatorTest()
        {
            var version = new VRCSDKVersion("3.5.0");
            var sameVersion = new VRCSDKVersion("3.5.0");
            var prevVersion = new VRCSDKVersion("3.4.9");
            var nextVersion = new VRCSDKVersion("3.5.1");

            Assert.IsTrue(version > prevVersion);
            Assert.IsFalse(version > sameVersion);
            Assert.IsFalse(version > nextVersion);

            Assert.IsFalse(version < prevVersion);
            Assert.IsFalse(version < sameVersion);
            Assert.IsTrue(version < nextVersion);

            Assert.IsTrue(version >= prevVersion);
            Assert.IsTrue(version >= sameVersion);
            Assert.IsFalse(version >= nextVersion);

            Assert.IsFalse(version <= prevVersion);
            Assert.IsTrue(version <= sameVersion);
            Assert.IsTrue(version <= nextVersion);

            Assert.IsFalse(version == prevVersion);
            Assert.IsTrue(version == sameVersion);
            Assert.IsFalse(version == nextVersion);

            Assert.IsTrue(version != prevVersion);
            Assert.IsFalse(version != sameVersion);
            Assert.IsTrue(version != nextVersion);
        }

        [Test]
        public void InterconvertibleTest()
        {
            var version = new VRCSDKVersion("3.5.0");

            var regeneratedVersion = new VRCSDKVersion(version.ToInterconvertibleString());

            Assert.AreEqual(version, regeneratedVersion);
        }

        [Test]
        public void InvalidVersionTest()
        {
            Assert.Throws<InvalidVersionFormatException>(() => new VRCSDKVersion(""));
            Assert.Throws<InvalidVersionFormatException>(() => new VRCSDKVersion("2019.09.18.12.05.01"));
            Assert.Throws<InvalidVersionFormatException>(() => new VRCSDKVersion("3.5.0.1"));
            Assert.Throws<InvalidVersionFormatException>(() => new VRCSDKVersion("3.5"));
            Assert.Throws<InvalidVersionFormatException>(() => new VRCSDKVersion("3.5.abc"));
        }
    }
}
