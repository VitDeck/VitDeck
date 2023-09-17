using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using VitDeck.Language;
using VitDeck.Utilities;
using VitDeck.Main;

namespace VitDeck.BuildSizeCalculator
{
    /// <summary>
    /// ビルドサイズの計算機能を提供する。
    /// </summary>
    public static class Calculator
    {
        /// <returns>ビルドサイズをバイト数で返す。</returns>
        public static IEnumerator ForceRebuild(string exhibitId)
        {
            var bakeCheck = GUIUtilities.BakeCheckAndRun();
            while (bakeCheck.MoveNext())
            {
                yield return null;
            }

            if (!(bool)bakeCheck.Current)
            {
                yield break;
            }

            int? byteCount = null;
            AssetUtility.TemporaryDestroyObjectsOutsideOfRootObjectAndRunCallback(exhibitId, () =>
            {
                string path = SceneManager.GetActiveScene().path;
                AssetBundleManifest result = null;
                try
                {
                    string bundleName = "vitdeckscene.vrcw";
                    AssetImporter atPath = AssetImporter.GetAtPath(path);
                    if (atPath == null)
                    {
                        EditorUtility.DisplayDialog("Error", LocalizedMessage.Get("BuildSizeCalculator.OpenSceneFile"),
                            "OK");
                        return;
                    }

                    string outPath = Application.temporaryCachePath;
                    if (!Directory.Exists(outPath))
                    {
                        Directory.CreateDirectory(outPath);
                    }

                    atPath.assetBundleName = bundleName;
                    atPath.SaveAndReimport();
                    result = BuildPipeline.BuildAssetBundles(outPath, BuildAssetBundleOptions.ForceRebuildAssetBundle,
                        EditorUserBuildSettings.activeBuildTarget);
                    atPath.assetBundleName = string.Empty;
                    atPath.SaveAndReimport();
                    AssetDatabase.RemoveUnusedAssetBundleNames();
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                    return;
                }

                byteCount = result != null ? GetFileByteCount() : null;
            });

            yield return byteCount;
        }

        private static int? GetFileByteCount()
        {
            try
            {
                string path = Application.temporaryCachePath + "/vitdeckscene.vrcw";
                if (!File.Exists(path))
                {
                    return null;
                }

                FileInfo fileInfo = new FileInfo(path);
                return (int)fileInfo.Length;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return null;
            }
        }
    }
}
