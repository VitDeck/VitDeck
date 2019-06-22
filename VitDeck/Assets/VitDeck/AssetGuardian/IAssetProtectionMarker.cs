using UnityEngine;

namespace VitDeck.AssetGuardian
{
    public interface IAssetProtectionMarker
    {
        void Mark(Object asset);

        void Unmark(Object asset);

        void RepairMarking(Object asset);

        bool IsMarked(Object asset);
    }
}