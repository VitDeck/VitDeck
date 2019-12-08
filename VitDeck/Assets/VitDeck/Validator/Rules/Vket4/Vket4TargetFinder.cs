using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
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
                throw new DirectoryNotFoundException("BaseDirectory is not found.");
            }

            var exhibitorID = Path.GetFileName(baseFolder);

            var targetScene = GetPackageScene(exhibitorID);
            targetScene = OpenScene(targetScene);

            scenes = new Scene[] { targetScene };

            var exhibitRootObject = targetScene
                .GetRootGameObjects()
                .Where(obj => obj.name == exhibitorID)
                .Single();

            rootObjects = new GameObject[] { exhibitRootObject };

            allObjects = exhibitRootObject
                .GetComponentsInChildren<Transform>(true)
                .Select(tf => tf.gameObject)
                .ToArray();

            assetObjects = GetAllReferredAssets(baseFolder, allObjects);

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

        private static Object[] GetAllReferredAssets(string baseFolder, GameObject[] gameObjects)
        {
            var searcher = UnityObjectReferenceChain
                .ExploreFrom(
                    Enumerable.Concat(
                        VitDeck.Utilities.AssetUtility.EnumerateAssets(baseFolder),
                        gameObjects
                    ));

            return searcher.Where(obj => AssetDatabase.IsMainAsset(obj)).ToArray();
        }



        private static Scene GetPackageScene(string exhibitorID)
        {
            var scenePath = string.Format("Assets/{0}/{0}.unity", exhibitorID);
            if (!File.Exists(scenePath))
            {
                throw new FileNotFoundException(string.Format("BaseScene({0})が見つかりません。", scenePath));
            }
            var targetScene = EditorSceneManager.GetSceneByPath(scenePath);

            return targetScene;
        }

        private static Scene OpenScene(Scene targetScene)
        {
            if (!targetScene.isLoaded)
            {
                if (!EditorUtility.DisplayDialog(
                    "検証対象のシーンが開かれていません。",
                    "検証を続行する為には検証対象のシーンを開く必要があります。" + Environment.NewLine + targetScene.path,
                    "続行",
                    "中止"))
                {
                    throw new FatalValidationErrorException("検証を中止しました。");
                }
            }
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                throw new FatalValidationErrorException("編集中のシーンファイルをセーブして再実行してください。");
            }
            targetScene = EditorSceneManager.OpenScene(targetScene.path);
            EditorSceneManager.SetActiveScene(targetScene);
            return targetScene;
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