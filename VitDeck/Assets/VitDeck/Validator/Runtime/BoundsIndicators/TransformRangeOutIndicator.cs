using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    [ExecuteInEditMode]
    public class TransformRangeOutIndicator : MonoBehaviour
    {
        [System.NonSerialized]
        private bool initialized = false;

        private IBoothBoundsProvider booth;

        public void Initialize(IBoothBoundsProvider booth, ResetToken token)
        {
            if (booth == null)
            {
                throw new System.ArgumentNullException("booth");
            }

            this.booth = booth;
            if(token != null)
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

        private void OnDrawGizmosSelected()
        {
            if (booth == null)
            {
                return;
            }

            var limit = booth.GetBounds();
            if (limit.Contains(transform.position))
            {
                return;
            }

            Gizmos.color = Color.red;

            Gizmos.DrawSphere(transform.position, 0.1f);
        }
    }
}