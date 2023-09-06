using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    [ExecuteInEditMode]
    public class BoundsRangeOutIndicator : MonoBehaviour
    {
        [System.NonSerialized]
        bool initialized = false;

        IBoundsSource boundsSource;
        private IBoothRoot booth;

        public void Initialize(IBoothRoot booth, IBoundsSource boundsSource, ResetToken token)
        {
            if (booth == null)
            {
                throw new System.ArgumentNullException("booth");
            }
            if (boundsSource == null)
            {
                throw new System.ArgumentNullException("targetRenderer");
            }

            this.booth = booth;
            this.boundsSource = boundsSource;
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
            if (!initialized || boundsSource == null || boundsSource.IsRemoved)
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
            if (booth == null || boundsSource == null || boundsSource.IsRemoved)
            {
                return;
            }

            booth.ClearTransformTemporarily();
            var bounds = boundsSource.Bounds;
            var localBounds = boundsSource.LocalBounds;
            var localToWorldMatrix = boundsSource.LocalToWorldMatrix;
            booth.RestorePosition();

            DrawOverhangGizmos(ref bounds);
            DrawBoundsGizmos(ref bounds);
            DrawLocalBoundsGizmos(ref localBounds, ref localToWorldMatrix);
        }

        Vector3 rangeOutIndicatorPadding = Vector3.one * 0.0005f;

        private void DrawLocalBoundsGizmos(ref Bounds bounds, ref Matrix4x4 localToWorldMatrix)
        {
            Gizmos.matrix = localToWorldMatrix;
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
        
        private void DrawBoundsGizmos(ref Bounds bounds)
        {
            Gizmos.matrix = booth.GetLocalToWorld();
            Gizmos.color = Color.black;
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