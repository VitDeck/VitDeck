using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    [ExecuteInEditMode]
    public class RendererRangeOutIndicator : MonoBehaviour
    {
        [System.NonSerialized]
        bool initialized = false;

        Renderer targetRenderer;
        private IBoothBoundsProvider booth;

        public void Initialize(IBoothBoundsProvider booth, Renderer targetRenderer, ResetToken token)
        {
            if(booth == null)
            {
                throw new System.ArgumentNullException("booth");
            }
            if(targetRenderer == null)
            {
                throw new System.ArgumentNullException("targetRenderer");
            }

            this.booth = booth;
            this.targetRenderer = targetRenderer;
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
            if(!initialized)
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
            if (booth == null || targetRenderer == null)
            {
                return;
            }

            var bounds = targetRenderer.bounds;

            DrawBoundsGizmos(ref bounds);
            DrawOverhangGizmos(ref bounds);
        }

        private void DrawBoundsGizmos(ref Bounds bounds)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }

        private void DrawOverhangGizmos(ref Bounds bounds)
        {
            var limit = booth.GetBounds();
            Gizmos.color = Color.red;

            if (limit.max.x < bounds.max.x)
            {
                var overed = bounds;
                var overedMin = overed.min;
                overedMin.x = Mathf.Max(limit.max.x, bounds.min.x);
                overed.min = overedMin;

                Gizmos.DrawCube(overed.center, overed.size);
            }

            if (limit.max.y < bounds.max.y)
            {
                var overed = bounds;
                var overedMin = overed.min;
                overedMin.y = Mathf.Max(limit.max.y, bounds.min.y);
                overed.min = overedMin;

                Gizmos.DrawCube(overed.center, overed.size);
            }

            if (limit.max.z < bounds.max.z)
            {
                var overed = bounds;
                var overedMin = overed.min;
                overedMin.z = Mathf.Max(limit.max.z, bounds.min.z);
                overed.min = overedMin;

                Gizmos.DrawCube(overed.center, overed.size);
            }

            if (limit.min.x > bounds.min.x)
            {
                var overed = bounds;
                var overedMax = overed.max;
                overedMax.x = Mathf.Min(limit.min.x, bounds.max.x);
                overed.max = overedMax;

                Gizmos.DrawCube(overed.center, overed.size);
            }

            if (limit.min.y > bounds.min.y)
            {
                var overed = bounds;
                var overedMax = overed.max;
                overedMax.y = Mathf.Min(limit.min.y, bounds.max.y);
                overed.max = overedMax;
                
                Gizmos.DrawCube(overed.center, overed.size);
            }

            if (limit.min.z > bounds.min.z)
            {
                var overed = bounds;
                var overedMax = overed.max;
                overedMax.z = Mathf.Min(limit.min.z, bounds.max.z);
                overed.max = overedMax;

                Gizmos.DrawCube(overed.center, overed.size);
            }
        }
    }
}