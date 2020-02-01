using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public class RendererBoundsSource : IBoundsSource
    {
        private readonly Renderer renderer;

        public RendererBoundsSource(Renderer renderer)
        {
            this.renderer = renderer;
        }

        public Bounds Bounds
        {
            get
            {
                return renderer.bounds;
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