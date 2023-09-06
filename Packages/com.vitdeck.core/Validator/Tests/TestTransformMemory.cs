using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using VitDeck.Validator.BoundsIndicators;

namespace VitDeck.Validator.Test
{
    [TestFixture(TestOf = typeof(TransformMemory))]
    public class TestTransformMemory
    {
        [Test]
        public void MemoryTest()
        {
            var parentObject = new GameObject("TestTransformMemory-ParentObject");
            var gameObject0 = new GameObject("TestTransformMemory-GameObject0");
            var gameObject1 = new GameObject("TestTransformMemory-GameObject1");
            Transform transform0 = gameObject0.transform;
            Transform transform1 = gameObject1.transform;

            transform0.SetParent(parentObject.transform);
            transform0.position = new Vector3(1, 2, 3);
            transform0.rotation = Quaternion.Euler(1f, 2f, 3f);
            transform0.localScale = new Vector3(4, 5, 6);
            var memory = new TransformMemory(transform0);

            memory.Apply(transform1);

            Assert.AreEqual(transform0.parent, transform1.parent);
            Assert.AreEqual(transform0.position, transform1.position);
            Assert.AreEqual(transform0.rotation, transform1.rotation);
            Assert.AreEqual(transform0.localScale, transform1.localScale);
        }

        [Test]
        public void ResetTest()
        {
            var parentObject = new GameObject("TestTransformMemory-ParentObject");
            var gameObject = new GameObject("TestTransformMemory-GameObject");
            var transform = gameObject.transform;

            transform.SetParent(parentObject.transform);
            transform.position = new Vector3(1, 2, 3);
            transform.rotation = Quaternion.Euler(1f, 2f, 3f);
            transform.localScale = new Vector3(4, 5, 6);

            var memory = TransformMemory.SaveAndReset(gameObject.transform);

            Assert.IsNull(transform.parent);
            Assert.AreEqual(Vector3.zero, gameObject.transform.position);
            Assert.AreEqual(Quaternion.identity, gameObject.transform.rotation);
            Assert.AreEqual(Vector3.one, gameObject.transform.localScale);
        }
    }
}