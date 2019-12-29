using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using VitDeck.Validator.BoundsIndicators;

namespace VitDeck.Validator.Test
{
    [TestFixture(TestOf = typeof(ResetTokenSource))]
    public class TestResetTokenSource
    {
        [Test]
        public void Test()
        {
            var tokenSource = new ResetTokenSource();

            var token = tokenSource.Token;

            bool isCalled = false;

            token.Reset += () => isCalled = true;

            tokenSource.Reset();

            Assert.IsTrue(isCalled);
        }
    }
}