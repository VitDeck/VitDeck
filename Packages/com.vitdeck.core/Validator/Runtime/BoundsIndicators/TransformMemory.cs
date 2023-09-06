using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public class TransformMemory
    {
        private Transform memoryParent;
        private Vector3 memoryPosition;
        private Quaternion memoryRotation;
        private Vector3 memoryScale;

        public static TransformMemory SaveAndReset(Transform transform)
        {
            var memory = new TransformMemory(transform);

            transform.SetParent(null, worldPositionStays: false);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;

            return memory;
        }

        public TransformMemory(Transform transform)
        {
            memoryParent = transform.parent;
            memoryPosition = transform.localPosition;
            memoryRotation = transform.localRotation;
            memoryScale = transform.localScale;
        }

        public void Apply(Transform target)
        {
            target.SetParent(memoryParent, worldPositionStays: false);
            target.localPosition = memoryPosition;
            target.localRotation = memoryRotation;
            target.localScale = memoryScale;
        }
    }
}