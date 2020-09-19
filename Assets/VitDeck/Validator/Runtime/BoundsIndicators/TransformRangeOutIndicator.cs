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

        private IBoothRoot booth;

        public void Initialize(IBoothRoot booth, ResetToken token)
        {
            if (booth == null)
            {
                throw new System.ArgumentNullException("booth");
            }

            this.booth = booth;
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

        private void OnDrawGizmosSelected()
        {
            if (booth == null)
            {
                return;
            }

            var limit = booth.GetBounds();
            var localPosition = booth.GetWorldToLocal().MultiplyPoint3x4(transform.position);
            if (limit.Contains(localPosition))
            {
                return;
            }

            Gizmos.color = Color.Lerp(Color.red, Color.yellow, Mathf.PingPong(System.DateTime.Now.Millisecond * 0.002f, 1));
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
    }
}