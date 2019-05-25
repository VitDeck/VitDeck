using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace VitDeck.AssetGuardian
{
    public class ProtectedAssetPostProcessor : AssetPostprocessor
    {
        static Mode mode = Mode.Reprotect;

        public static void SetMode(Mode mode)
        {
            ProtectedAssetPostProcessor.mode = mode;
        }

        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            switch (mode)
            {
                case Mode.Reprotect:
                    Reprotect(importedAssets);
                    break;
                case Mode.Unprotect:
                    Unprotect(importedAssets);
                    break;
                default:
                    break;
            }
        }

        static void Reprotect(string[] assets)
        {
            var instances = assets
                .Select(path => AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path));

            foreach (var asset in instances)
            {
                ProtectionLabel.Repair(asset);
            }
        }

        static void Unprotect(string[] assets)
        {
            var instances = assets
               .Select(path => AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path));

            foreach (var asset in instances)
            {
                ProtectionLabel.Detach(asset);
            }
        }

        public enum Mode
        {
            Reprotect,
            Unprotect,
        }
    }
}