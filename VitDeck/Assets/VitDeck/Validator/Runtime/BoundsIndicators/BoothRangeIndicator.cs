using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    [ExecuteInEditMode]
    public class BoothRangeIndicator : MonoBehaviour, IBoothBoundsProvider
    {
        [System.NonSerialized]
        bool initialized = false;

        private Bounds bounds;

        public void Initialize(Bounds bounds, ResetToken token)
        {
            this.bounds = bounds;
            if (token != null)
            {
                token.Reset += Token_Reset;
            }
            initialized = true;
        }

        private void Token_Reset()
        {
            SafeDestroy();
        }

        private void Update()
        {
            if (!initialized)
            {
                SafeDestroy();
            }
        }

        private void SafeDestroy()
        {
            if (Application.isPlaying)
            {
                Destroy(this);
            }
            else
            {
                DestroyImmediate(this);
            }
        }

        public Bounds GetBounds()
        {
            return GetActiveBounds();
        }

        private void OnDrawGizmos()
        {
            var activeBounds = GetActiveBounds();
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(activeBounds.center, activeBounds.size);
        }

        Bounds GetActiveBounds()
        {
            var activeBounds = bounds;
            activeBounds.center = activeBounds.center + transform.position;
            return activeBounds;
        }
    }
}