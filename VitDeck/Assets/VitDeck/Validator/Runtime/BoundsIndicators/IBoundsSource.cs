using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public interface IBoundsSource
    {
        Bounds Bounds { get; }
    }
}