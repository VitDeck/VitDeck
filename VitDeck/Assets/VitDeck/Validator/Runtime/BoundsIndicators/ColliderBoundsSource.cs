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

        public bool IsRemoved
        {
            get
            {
                return collider == null;
            }
        }
    }
}