using System;
using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public class LightProbeBoundsSource : IBoundsSource
    {
        private readonly LightProbeGroup group;
        private readonly Transform probeTransform;

        public LightProbeBoundsSource(LightProbeGroup group)
        {
            this.group = group;
            probeTransform = group.transform;
        }

        public Bounds Bounds
        {
            get
            {
                var positions = group.probePositions;
                if (positions.Length == 0)
                {
                    return new Bounds(probeTransform.position, new Vector3(0.01f, 0.01f, 0.01f));
                }

                var transformer = probeTransform.localToWorldMatrix;

                var first = transformer.MultiplyPoint3x4(positions[0]);
                Vector3 min = first;
                Vector3 max = first;
                for (int i = 1; i < positions.Length; i++)
                {
                    var worldPosition = transformer.MultiplyPoint3x4(positions[i]);
                    min = Vector3.Min(min, worldPosition);
                    max = Vector3.Max(max, worldPosition);
                }

                var center = (min + max) * 0.5f;
                var size = max - min;
                return new Bounds(center, size);
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
                return probeTransform == null || group == null;
            }
        }
    }
}