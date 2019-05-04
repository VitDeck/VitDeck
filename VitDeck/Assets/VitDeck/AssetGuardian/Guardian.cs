using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Linq;
using System.IO;

namespace VitDeck.AssetGuardian
{
    public class Guardian : UnityEditor.AssetModificationProcessor
    {
        static HashSet<string> guardPaths = new HashSet<string>();

        static string[] OnWillSaveAssets(string[] paths)
        {
            return paths
                 .Where(path => !DiscardChangesIfTarget(path))
                 .ToArray();
        }

        /// <summary>
        /// アセットが保護対象であれば全ての保存されていない変更を破棄する。
        /// </summary>
        /// <param name="assetPath">アセットへのパス</param>
        /// <returns>アセットが保護されていた場合はtrue、そうでなければfalse。</returns>
        private static bool DiscardChangesIfTarget(string assetPath)
        {
            bool isTarget = false;
            foreach (var guardPath in guardPaths)
            {
                if (assetPath.StartsWith(guardPath))
                {
                    isTarget = true;
                    break;
                }
            }
            if (!isTarget)
                return false;

            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
            Resources.UnloadAsset(asset);
            Debug.Log("All changes of " + assetPath + " are discarded.");

            return true;
        }

        public static void Register(string path)
        {
            guardPaths.Add(path);
        }

        public static void Unregister(string path)
        {
            guardPaths.Remove(path);
        }
    }
}