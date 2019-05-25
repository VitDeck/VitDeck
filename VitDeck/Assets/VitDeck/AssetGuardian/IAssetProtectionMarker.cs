using UnityEngine;

namespace VitDeck.AssetGuardian
{
    public interface IAssetProtectionMarker
    {
        void Protect(Object asset);

        void Unprotect(Object asset);

        void RepairProtection(Object asset);

        bool IsProtected(Object asset);
    }
}