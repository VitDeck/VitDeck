#if VRC_SDK_VRCSDK3
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VRC.Udon;

namespace VitDeck.Exporter.Addons.VRCSDK3
{
    public class LinkedUdonManager
    {
        private const string _udonProgramBasePath = "Assets/SerializedUdonPrograms/";
        public static string[] GetLinkedAssetPaths()
        {
            var paths = new List<string>();
            var udonBehaviours = Resources.FindObjectsOfTypeAll<UdonBehaviour>();
            foreach (var udonBehaviour in udonBehaviours)
            {
                var programName = udonBehaviour.programSource.SerializedProgramAsset.name;
                var assetPath = _udonProgramBasePath + programName + ".asset";
                var guid = AssetDatabase.AssetPathToGUID(assetPath);
                if (guid != null && Array.IndexOf(_excludeGUIDs, guid) == -1)
                {
                    paths.Add(assetPath);
                }
            }
            return paths.ToArray();
        }

        private static readonly string[] _excludeGUIDs = new[]
        {
            "2f916e008aa8f294c991c22b42ea5944",  // 73398b290b7c5ec43a2e158bfc1c45db Assets/VketAssets/UdonPrefabs/Udon_PickupObjectSync/Scripts/AutoResetPickup.asset
            "2595ee2141e0fc4408caf75680ef9eb5",  // 0d2cf2386895ff5499a1660a4327ad75 Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Scripts/AvatarPedestal.asset
            "cb458453c6b8c4a4884ba5d3b2f9de56",  // 6ea1e8fa7533f9647996810212fa976e Assets/VketAssets/UdonPrefabs/Udon_CirclePageOpener/Scripts/CirclePageOpener.asset
            "4c879ab359f0cc54984884027c8a015e",  // fe9c6cf6073f2514e82259a4142d6932 Assets/VitDeck/Templates/07_UC/SharedAssets/UC_WorldSetting.asset
        };
    }
}
#endif
