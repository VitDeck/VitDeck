using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public interface IMeshLocalBoundsProvider
    {
        Bounds Bounds { get; }
    }
}