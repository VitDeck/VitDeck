using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public interface IBoothRoot
    {
        Bounds GetBounds();
        Matrix4x4 GetWorldToLocal();
        Matrix4x4 GetLocalToWorld();

        void ClearTransformTemporarily();
        void RestorePosition();

    }
}