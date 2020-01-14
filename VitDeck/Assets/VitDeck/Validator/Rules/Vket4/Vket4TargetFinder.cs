using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using VitDeck.Language;
using Object = UnityEngine.Object;

namespace VitDeck.Validator
{
    public class Vket4TargetFinder : IValidationTargetFinder
    {
        bool finded = false;

        string[] assetGUIDs;
        Object[] assetObjects;
        string[] assetPaths;
        GameObject[] rootObjects;
        GameObject[] allObjects;
        Scene[] scenes;
        ValidationTarget target;

        private void FindInternal(string baseFolder, bool forceOpenScene = false)
        {
            if (!Directory.Exists(baseFolder))
            {
                throw new FatalValidationErrorException(LocalizedMessage.Get("Vket4TargetFinder.PackageFolderNotFound"));
            }

            var exhibitorID = Path.GetFileName(baseFolder);

            var targetScene = OpenPackageScene(exhibitorID);

            scenes = new Scene[] { targetScene };
            var exhibitRootObject = GetExhibitRootObject(exhibitorID, targetScene);

            rootObjects = new GameObject[] { exhibitRootObject };

            allObjects = exhibitRootObject
                .GetComponentsInChildren<Transform>(true)
                .Select(tf => tf.gameObject)
                .ToArray();

            assetObjects = GetContainsAndReferredAssets(baseFolder, allObjects);

            assetPaths = assetObjects
                .Select(asset => AssetDatabase.GetAssetPath(asset))
                .ToArray();

            assetGUIDs = assetPaths
                .Select(path => AssetDatabase.AssetPathToGUID(path))
                .ToArray();

            target = new ValidationTarget(
                baseFolder,
                assetGUIDs,
                assetPaths,
                assetObjects,
                scenes,
                rootObjects,
                allObjects);

            finded = true;
        }

        private static GameObject GetExhibitRootObject(string exhibitorID, Scene targetScene)
        {
            var exhibitRootObjects = targetScene
                .GetRootGameObjects()
                .Where(obj => obj.name == exhibitorID)
                .ToArray();

            if (exhibitRootObjects.Length == 0)
            {
                throw new FatalValidationErrorException(LocalizedMessage.Get("Vket4TargetFinder.ExhibitNotFound"));

            }
            else if (exhibitRootObjects.Length > 1)
            {
                throw new FatalValidationErrorException(LocalizedMessage.Get("Vket4TargetFinder.ManyExhibits"));
            }
            else
            {
                return exhibitRootObjects[0];
            }
        }

        private static Object[] GetContainsAndReferredAssets(string baseFolder, GameObject[] gameObjects)
        {
            var searcher = UnityObjectReferenceChain
                .ExploreFrom(
                    Enumerable.Concat(
                        VitDeck.Utilities.AssetUtility.EnumerateAssets(baseFolder),
                        gameObjects
                    ));

            return searcher.Where(obj => AssetDatabase.IsMainAsset(obj)).ToArray();
        }

        private static Scene OpenPackageScene(string exhibitorID)
        {
            var scenePath = string.Format("Assets/{0}/{0}.unity", exhibitorID);
            Debug.Log(scenePath);
            if (!File.Exists(scenePath))
            {
                throw new FatalValidationErrorException(LocalizedMessage.Get("Vket4TargetFinder.SceneNotFound", scenePath));
            }
            var targetScene = EditorSceneManager.GetSceneByPath(scenePath);
            Debug.Log(targetScene.name);

            if (!targetScene.isLoaded)
            {
                if (!EditorUtility.DisplayDialog(
                    LocalizedMessage.Get("Vket4TargetFinder.SceneOpenDialog.Title"),
                    LocalizedMessage.Get("Vket4TargetFinder.SceneOpenDialog") + Environment.NewLine + targetScene.path,
                    LocalizedMessage.Get("Vket4TargetFinder.SceneOpenDialog.Continue"),
                    LocalizedMessage.Get("Vket4TargetFinder.SceneOpenDialog.Abort")))
                {
                    throw new FatalValidationErrorException(LocalizedMessage.Get("Vket4TargetFinder.ValidationAborted"));
                }

                DoSaveIfNecessary();

                targetScene = EditorSceneManager.OpenScene(scenePath);
                EditorSceneManager.SetActiveScene(targetScene);
            }

            return targetScene;
        }

        private static void DoSaveIfNecessary()
        {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                throw new FatalValidationErrorException(LocalizedMessage.Get("Vket4TargetFinder.UserDidntSave"));
            }
        }


        #region Interface Imprements

        public ValidationTarget Find(string baseFolder, bool forceOpenScene = false)
        {
            if (!finded)
            {
                FindInternal(baseFolder, forceOpenScene);
            }

            return target;
        }

        public GameObject[] FindAllObjects(string baseFolderPath, bool forceOpenScene = false)
        {
            if (!finded)
            {
                FindInternal(baseFolderPath, forceOpenScene);
            }

            return allObjects;
        }

        public string[] FindAssetGuids(string baseFolderPath)
        {
            if (!finded)
            {
                FindInternal(baseFolderPath);
            }

            return assetGUIDs;
        }

        public Object[] FindAssetObjects(string baseFolderPath)
        {
            if (!finded)
            {
                FindInternal(baseFolderPath);
            }

            return assetObjects;
        }

        public string[] FindAssetPaths(string baseFolderPath)
        {
            if (!finded)
            {
                FindInternal(baseFolderPath);
            }

            return assetPaths;
        }

        public GameObject[] FindRootObjects(string baseFolderPath, bool forceOpenScene = false)
        {
            if (!finded)
            {
                FindInternal(baseFolderPath, forceOpenScene);
            }

            return rootObjects;
        }

        public Scene[] FindScenes(string baseFolderPath, bool forceOpenScene = false)
        {
            if (!finded)
            {
                FindInternal(baseFolderPath);
            }

            return scenes;
        }

        #endregion
    }
}