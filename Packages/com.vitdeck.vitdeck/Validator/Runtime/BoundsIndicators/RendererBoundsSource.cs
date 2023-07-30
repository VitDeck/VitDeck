using System;
using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public class RendererBoundsSource : IBoundsSource
    {
        private readonly Renderer renderer;
        private readonly IMeshLocalBoundsProvider localBoundsProvider;

        public RendererBoundsSource(Renderer renderer)
        {
            this.renderer = renderer;
            if (renderer is MeshRenderer)
            {
                var filter = renderer.GetComponent<MeshFilter>();
                localBoundsProvider = new MeshFilterLocalBoundProvider(filter);
            }
            else if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
            {
                localBoundsProvider = new SkinnedMeshRendererLocalBoundsProvider(skinnedMeshRenderer);
            }
        }

        public Bounds Bounds
        {
            get
            {
                return renderer.bounds;
            }
        }

        public Bounds LocalBounds
        {
            get
            {
                return localBoundsProvider?.Bounds ?? new Bounds();
            }
        }

        public Matrix4x4 LocalToWorldMatrix
        {
            get
            {
                return renderer.localToWorldMatrix;
            }
        }

        public bool IsRemoved
        {
            get
            {
                return renderer == null;
            }
        }
    }
}