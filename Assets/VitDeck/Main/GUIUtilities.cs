using System;
using System.IO;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using VitDeck.Language;
using VitDeck.Validator;

namespace VitDeck.Main
{
    public static class GUIUtilities
    {
        public static Scene OpenPackageScene(string exhibitorID)
        {
            var scenePath = string.Format("Assets/{0}/{0}.unity", exhibitorID);
            if (!File.Exists(scenePath))
            {
                throw new FatalValidationErrorException(LocalizedMessage.Get("VketTargetFinder.SceneNotFound", scenePath));
            }
            var targetScene = EditorSceneManager.GetSceneByPath(scenePath);

            if (!targetScene.isLoaded)
            {
                if (!EditorUtility.DisplayDialog(
                    LocalizedMessage.Get("VketTargetFinder.SceneOpenDialog.Title"),
                    LocalizedMessage.Get("VketTargetFinder.SceneOpenDialog") + Environment.NewLine + targetScene.path,
                    LocalizedMessage.Get("VketTargetFinder.SceneOpenDialog.Continue"),
                    LocalizedMessage.Get("VketTargetFinder.SceneOpenDialog.Abort")))
                {
                    throw new FatalValidationErrorException(LocalizedMessage.Get("VketTargetFinder.ValidationAborted"));
                }

                DoSaveIfNecessary();

                targetScene = EditorSceneManager.OpenScene(scenePath);
                EditorSceneManager.SetActiveScene(targetScene);
            }
            else
            {
                DoSaveIfNecessary();
            }

            return targetScene;
        }

        private static void DoSaveIfNecessary()
        {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                throw new FatalValidationErrorException(LocalizedMessage.Get("VketTargetFinder.UserDidntSave"));
            }
        }

        /// <summary>
        /// 開いているシーンをベイクする。
        /// </summary>
        /// <returns>asyncメソッドを利用すると、<see cref="BuildPipeline.BuildAssetBundles"/>時にasyncメソッドが二重実行されてしまう問題を回避するため、TaskではなくIEnumeratorを返す。</returns>
        public static IEnumerator BakeCheckAndRun()
        {
            EditorUtility.DisplayProgressBar("Bake", "Baking...", 0);
            bool bakeFlag = Lightmapping.BakeAsync();
            if (!bakeFlag)
            {
                EditorUtility.DisplayDialog("Error", LocalizedMessage.Get("Main.Baker.LightBakeFailed"), "OK");
            }

            while (Lightmapping.isRunning)
            {
                EditorUtility.DisplayProgressBar("Bake", "Baking...", Lightmapping.buildProgress);
                yield return null;
            }

            EditorUtility.ClearProgressBar();

            if (bakeFlag)
            {
                EditorSceneManager.SaveOpenScenes();
            }

            yield return bakeFlag;
        }
    }
}
