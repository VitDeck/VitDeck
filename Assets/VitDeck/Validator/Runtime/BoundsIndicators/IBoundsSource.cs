using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public interface IBoundsSource
    {
        Bounds Bounds { get; }
        
        Bounds LocalBounds { get; }
        
        Matrix4x4 LocalToWorldMatrix { get; }

        bool IsRemoved { get; }
    }
}