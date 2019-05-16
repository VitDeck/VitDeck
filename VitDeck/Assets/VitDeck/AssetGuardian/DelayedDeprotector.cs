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

        private static IEnumerable<Object> reserveAssets;

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
        }

        static void StopWatching()
        {
            if (!watching)
                return;

            EditorApplication.update -= Update;
            watching = false;
        }

        static void Update()
        {
            StopWatching();

            var assets = reserveAssets.ToArray();
            reserveAssets = null;

            foreach (var asset in assets)
            {
                ProtectionLabel.Detach(asset);
            }

            Selection.objects = assets;
            EditorApplication.ExecuteMenuItem("Assets/Reimport");
        }

        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (!watching)
                return;

            var instances = importedAssets
                .Select(path => AssetDatabase.LoadAssetAtPath<Object>(path))
                .Where(asset => asset != null);

            if (reserveAssets == null)
                reserveAssets = instances;
            else
                reserveAssets = reserveAssets.Concat(instances);
        }
    }
}