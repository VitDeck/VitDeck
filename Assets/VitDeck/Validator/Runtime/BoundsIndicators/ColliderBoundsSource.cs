using System;
using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public class ColliderBoundsSource : IBoundsSource
    {
        private Collider collider;

        public ColliderBoundsSource(Collider collider)
        {
            this.collider = collider;
        }

        public Bounds Bounds
        {
            get
            {
                return collider.bounds;
            }
        }

        public Bounds LocalBounds
        {
            get
            {
                return new Bounds();
            }
        }

        public Matrix4x4 LocalToWorldMatrix
        {
            get
            {
                return Matrix4x4.identity;
            }
        }

        public bool IsRemoved
        {
            get
            {
                return collider == null;
            }
        }
    }
}