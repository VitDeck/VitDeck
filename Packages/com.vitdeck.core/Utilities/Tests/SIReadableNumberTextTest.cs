using NUnit.Framework;
using UnityEngine;

namespace VitDeck.Utilities.Tests
{
    public class SIReadableNumberTextTest
    {
        [TestCase(-1, "-1 B")]
        [TestCase(0, "0 B")]
        [TestCase(1, "1 B")]
        [TestCase(999, "999 B")]
        [TestCase(1000, "1 kB")]
        [TestCase(1001, "1.001 kB")]
        [TestCase(2000, "2 kB")]
        [TestCase(1000000, "1 MB")]
        [TestCase(1000400, "1 MB")]
        [TestCase(1000500, "1.001 MB")]
        public void TestDigit(long input, string expected)
        {
            Assert.AreEqual(expected, SIReadableNumberText.Get(input, "B"));
        }

        [TestCase("B", "1 kB")]
        [TestCase("M", "1 kM")]
        public void TestUnit(string unit, string expected)
        {
            Assert.AreEqual(expected, SIReadableNumberText.Get(1000, unit));
        }
    }
}
