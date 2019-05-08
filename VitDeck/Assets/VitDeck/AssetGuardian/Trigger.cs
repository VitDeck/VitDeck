using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    public class Trigger : UnityEditor.AssetModificationProcessor
    {
        static Guardian guardian;

        [InitializeOnLoadMethod]
        public static void Initialize()
        {
            guardian = new Guardian();
        }

        static string[] OnWillSaveAssets(string[] paths)
        {
            return guardian.OnWillSaveAssets(paths);
        }
        static AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            return guardian.OnWillDeleteAsset(path, options);
        }
        static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            return guardian.OnWillMoveAsset(sourcePath, destinationPath);
        }
    }
}