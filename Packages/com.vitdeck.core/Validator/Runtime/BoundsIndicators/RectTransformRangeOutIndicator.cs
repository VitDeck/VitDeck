using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    [ExecuteInEditMode]
    public class RectTransformRangeOutIndicator : MonoBehaviour
    {
        [System.NonSerialized]
        bool initialized = false;

        RectTransform targetRectTransform;
        private IBoothRoot booth;

        public void Initialize(IBoothRoot booth, RectTransform targetRectTransform, ResetToken token)
        {
            if (booth == null)
            {
                throw new System.ArgumentNullException("booth");
            }
            if (targetRectTransform == null)
            {
                throw new System.ArgumentNullException("targetRenderer");
            }

            this.booth = booth;
            this.targetRectTransform = targetRectTransform;
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
            if (!initialized || targetRectTransform == null)
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

        private Vector3[] cornersCache;

        private void OnDrawGizmosSelected()
        {
            if (booth == null || targetRectTransform == null)
            {
                return;
            }

            booth.ClearTransformTemporarily();
            if (cornersCache == null)
            {
                cornersCache = new Vector3[4];
            }

            targetRectTransform.GetWorldCorners(cornersCache);
            var min = Vector3.Min(Vector3.Min(cornersCache[0], cornersCache[1]), Vector3.Min(cornersCache[2], cornersCache[2]));
            var max = Vector3.Max(Vector3.Max(cornersCache[0], cornersCache[1]), Vector3.Max(cornersCache[2], cornersCache[2]));

            var bounds = new Bounds();
            bounds.min = min;
            bounds.max = max;

            booth.RestorePosition();

            DrawBoundsGizmos(ref bounds);
            DrawOverhangGizmos(ref bounds);
        }

        Vector3 rangeOutIndicatorPadding = Vector3.one * 0.0005f;

        private void DrawBoundsGizmos(ref Bounds bounds)
        {
            Gizmos.matrix = booth.GetLocalToWorld();
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(bounds.center, bounds.size + rangeOutIndicatorPadding);
        }

        private void DrawOverhangGizmos(ref Bounds bounds)
        {
            var limit = booth.GetBounds();
            Gizmos.matrix = booth.GetLocalToWorld();
            Gizmos.color = Color.Lerp(Color.red, Color.yellow, Mathf.PingPong(System.DateTime.Now.Millisecond * 0.002f, 1));

            if (limit.max.x < bounds.max.x)
            {
                var overed = bounds;
                var overedMin = overed.min;
                overedMin.x = Mathf.Max(limit.max.x, bounds.min.x);
                overed.min = overedMin;

                Gizmos.DrawCube(overed.center, overed.size + rangeOutIndicatorPadding);
            }

            if (limit.max.y < bounds.max.y)
            {
                var overed = bounds;
                var overedMin = overed.min;
                overedMin.y = Mathf.Max(limit.max.y, bounds.min.y);
                overed.min = overedMin;

                Gizmos.DrawCube(overed.center, overed.size + rangeOutIndicatorPadding);
            }

            if (limit.max.z < bounds.max.z)
            {
                var overed = bounds;
                var overedMin = overed.min;
                overedMin.z = Mathf.Max(limit.max.z, bounds.min.z);
                overed.min = overedMin;

                Gizmos.DrawCube(overed.center, overed.size + rangeOutIndicatorPadding);
            }

            if (limit.min.x > bounds.min.x)
            {
                var overed = bounds;
                var overedMax = overed.max;
                overedMax.x = Mathf.Min(limit.min.x, bounds.max.x);
                overed.max = overedMax;

                Gizmos.DrawCube(overed.center, overed.size + rangeOutIndicatorPadding);
            }

            if (limit.min.y > bounds.min.y)
            {
                var overed = bounds;
                var overedMax = overed.max;
                overedMax.y = Mathf.Min(limit.min.y, bounds.max.y);
                overed.max = overedMax;

                Gizmos.DrawCube(overed.center, overed.size + rangeOutIndicatorPadding);
            }

            if (limit.min.z > bounds.min.z)
            {
                var overed = bounds;
                var overedMax = overed.max;
                overedMax.z = Mathf.Min(limit.min.z, bounds.max.z);
                overed.max = overedMax;

                Gizmos.DrawCube(overed.center, overed.size + rangeOutIndicatorPadding);
            }
        }
    }
}