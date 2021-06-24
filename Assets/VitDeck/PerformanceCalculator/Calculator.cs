using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;
using UnityEditor;
using VitDeck.Utilities;
using VitDeck.Language;
using System.Collections;

namespace VitDeck.PerformanceCalculator
{
    /// <summary>
    /// 負荷計算機能を提供する。
    /// </summary>
    public static class Calculator
    {
        public enum SpaceSize
        {
            Small,
            Large,
        }

        private static readonly string ProgressTitle = "SetPassCalls and Batches Check.";

        private static readonly TimeSpan frameTimeSpan = TimeSpan.FromSeconds(1f / 60);

        public static void EditorPlay()
        {
            EditorApplication.isPlaying = true;

            if (EditorApplication.isPaused)
            {
                EditorApplication.isPaused = false;
            }

            EditorUtility.DisplayProgressBar(ProgressTitle, "Initializing...", 0);
        }

        public static IEnumerator Calculate(string rootObjectName, SpaceSize spaceSize)
        {
            float progress = 0;

            Scene scene = SceneManager.GetActiveScene();

            if (EditorApplication.isPaused)
            {
                EditorApplication.isPaused = false;
            }

            AssetUtility.TemporaryDestroyObjectsOutsideOfRootObjectAndRunCallback(rootObjectName);

            if (EditorApplication.isPaused)
            {
                EditorApplication.isPaused = false;
            }

            foreach (Camera cam in Camera.allCameras.Union(SceneView.sceneViews.ToArray().Select(s => ((SceneView)s).camera)))
            {
                cam.enabled = false;
            }

            int space = spaceSize == SpaceSize.Small ? -4 : 8;

            GameObject checkParentObj = new GameObject("SetPassCheck");
            checkParentObj.transform.position = new Vector3(0, 0, 0);
            GameObject cameraObj = new GameObject("CheckCamera");
            Camera checkCam = cameraObj.AddComponent<Camera>();
            cameraObj.AddComponent<AudioListener>();
            checkCam.depth = 100;
            cameraObj.transform.SetParent(checkParentObj.transform);
            float rate = spaceSize == SpaceSize.Small ? 0.5f : 2;
            cameraObj.transform.position = new Vector3(0, 2.5f * rate, -(10 + space));

            List<int> setPassCallsList = new List<int>();
            List<int> batchesList = new List<int>();
            float rotation = 0;
            for (int i = 0; i < 360; i++)
            {
                if (EditorApplication.isPaused)
                {
                    EditorApplication.isPaused = false;
                }
                progress = (float)i / 360;
                if (EditorUtility.DisplayCancelableProgressBar(ProgressTitle, (progress * 100).ToString("F2") + "%", progress))
                {
                    EditorApplication.isPlaying = false;
                    EditorUtility.ClearProgressBar();
                    yield break;
                }
                checkParentObj.transform.rotation = Quaternion.Euler(0, rotation, 0);
                setPassCallsList.Add(UnityStats.setPassCalls);
                batchesList.Add(UnityStats.batches);
                rotation++;
                yield return null;
            }

            Object.DestroyImmediate(cameraObj);
            Object.DestroyImmediate(checkParentObj);

            int setPassCalls = (int)setPassCallsList.Average();
            int batches = (int)batchesList.Average();

            EditorUtility.ClearProgressBar();

            yield return (setPassCalls, batches);
        }
    }
}
