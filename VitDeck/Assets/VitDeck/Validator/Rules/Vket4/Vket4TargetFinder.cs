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
                throw new FatalValidationErrorException("入稿フォルダが存在しません。");
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
                throw new FatalValidationErrorException("入稿物が見つかりません。");

            }
            else if (exhibitRootObjects.Length > 1)
            {
                throw new FatalValidationErrorException("入稿物が複数存在します。");
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
                throw new FatalValidationErrorException(string.Format("入稿シーン({0})が見つかりません。", scenePath));
            }
            var targetScene = EditorSceneManager.GetSceneByPath(scenePath);
            Debug.Log(targetScene.name);

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
            targetScene = EditorSceneManager.OpenScene(scenePath);
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