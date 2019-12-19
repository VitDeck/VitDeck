using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public interface IBoothBoundsProvider
    {
        Bounds GetBounds();
    }
}