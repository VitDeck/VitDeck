using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// AssetGuardian内で使う為に、<see cref="AssetPostprocessor"/>のコールバックをフックする。
    /// </summary>
    public class UnityAssetPostProcessEvent : AssetPostprocessor
    {
        public delegate void ImportedPostProcessDelegate(string[] importedAssets);

        public static event ImportedPostProcessDelegate OnImportedPostProcess;

        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (OnImportedPostProcess != null)
            {
                OnImportedPostProcess.Invoke(importedAssets);
            }
        }
    }
}