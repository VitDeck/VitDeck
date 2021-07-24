using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public class SkinnedMeshRendererLocalBoundsProvider : IMeshLocalBoundsProvider
    {
        private readonly SkinnedMeshRenderer skinnedMeshRenderer;
        
        public SkinnedMeshRendererLocalBoundsProvider(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            this.skinnedMeshRenderer = skinnedMeshRenderer;
        }

        public Bounds Bounds
        {
            get
            {
                if(!skinnedMeshRenderer) return new Bounds();
                
                return skinnedMeshRenderer.localBounds;
            }
        }
    }
}