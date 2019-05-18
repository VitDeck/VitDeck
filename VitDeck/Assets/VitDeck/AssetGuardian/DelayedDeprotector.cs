using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// 1フレーム開けてからアセットの保護解除を行う機構。
    /// </summary>
    /// <remarks>
    /// UnityEditor上でAssetを複製した時に、複製物の保護を解除する必要があるため作成しました。
    /// </remarks>
    public class DelayedDeprotector : AssetPostprocessor
    {
        static bool watching;

        public static void Reserve(string path)
        {
            if (!watching)
                StartWatching();
        }

        static void StartWatching()
        {
            if (watching)
                return;

            watching = true;
            EditorApplication.update += Update;
            ProtectedAssetPostProcessor.SetMode(ProtectedAssetPostProcessor.Mode.Unprotect);
        }

        static void StopWatching()
        {
            if (!watching)
                return;
            ProtectedAssetPostProcessor.SetMode(ProtectedAssetPostProcessor.Mode.Reprotect);
            EditorApplication.update -= Update;
            watching = false;
        }

        static void Update()
        {
            StopWatching();
        }
    }
}