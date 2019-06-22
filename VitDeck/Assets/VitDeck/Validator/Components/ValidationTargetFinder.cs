using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VitDeck.Validator
{
    /// <summary>
    /// 検証対象を検索する機能を提供する。
    /// </summary>
    public class ValidationTargetFinder : IValidationTargetFinder
    {
        private bool showSaveDialogFlag = true;
        public ValidationTargetFinder()
        {
        }
        /// <summary>
        /// 検証対象を検索する
        /// </summary>
        /// <param name="baseFonderPath">ベースフォルダのパス</param>
        /// <param name="forceOpenScene">未保存シーンがある場合でも保存ダイアログを表示せずに対象シーンを開く</param>
        /// <returns>検証対象</returns>
        public ValidationTarget Find(string baseFonderPath, bool forceOpenScene = false)
        {
            if (!AssetDatabase.IsValidFolder(baseFonderPath))
            {
                throw new FatalValidationErrorException(string.Format("正しいベースフォルダを指定してください。:{0}", baseFonderPath));
            }
            return new ValidationTarget(baseFonderPath,
                FindAssetGuids(baseFonderPath),
                FindAssetPaths(baseFonderPath),
                FindAssetObjects(baseFonderPath),
                FindScenes(baseFonderPath, forceOpenScene),
                FindRootObjects(baseFonderPath, forceOpenScene),
                FindAllObjects(baseFonderPath, forceOpenScene));
        }
        /// <summary>
        /// ベースフォルダ内のアセットの全てのGUIDを検索する
        /// </summary>
        /// <remarks>検索結果にベースフォルダ自身を含む。</remarks>
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <returns>ベースフォルダ内のアセットの全てのGUID</returns>
        public string[] FindAssetGuids(string baseFolderPath)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            var baseFolderGuid = AssetDatabase.AssetPathToGUID(baseFolderPath);
            var assetGuids = AssetDatabase.FindAssets("", new string[] { baseFolderPath })
                .Distinct()
                .ToList<string>();
            assetGuids.Insert(0, baseFolderGuid);
            return assetGuids.ToArray();
        }
        /// <summary>
        /// ベースフォルダ内のアセットの全てのパスを検索する
        /// </summary>
        /// <remarks>検索結果にベースフォルダ自身を含む。</remarks>
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <returns>ベースフォルダ内のアセットの全てのパス</returns>
        public string[] FindAssetPaths(string baseFolderPath)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            var assetPaths = AssetDatabase.FindAssets("", new string[] { baseFolderPath })
                .Distinct()
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .ToList<string>();
            assetPaths.Insert(0, baseFolderPath);
            return assetPaths.ToArray();
        }
        /// <summary>
        /// ベースフォルダ内のアセットの全てのオブジェクトを検索する
        /// </summary>
        /// <remarks>検索結果にベースフォルダ自身を含む。</remarks>
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <returns>ベースフォルダ内のアセットのオブジェクト</returns>
        public UnityEngine.Object[] FindAssetObjects(string baseFolderPath)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            var baseFolder = AssetDatabase.LoadMainAssetAtPath(baseFolderPath);
            var assetObjects = AssetDatabase.FindAssets("", new string[] { baseFolderPath })
                .Distinct()
                .Select(guid => AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(guid)))
                .ToList<UnityEngine.Object>();
            assetObjects.Insert(0, baseFolder);
            return assetObjects.ToArray();
        }
        /// <summary>
        /// ベースフォルダ内のシーンファイルを検索する。
        /// </summary>
        /// <remarks>
        /// 1.0.0では見つかった最初のシーンのみを返す。もしロードされていなければシーンをロードする。
        /// シーンがない、または複数シーンがある場合は`FatalValidationErrorException`を発生させる。
        /// </remarks>
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <param name="forceOpenScene">未保存シーンがある場合でも保存ダイアログを表示せずに対象シーンを開く</param>
        /// <returns>ベースフォルダ内のアセットのオブジェクト</returns>
        public Scene[] FindScenes(string baseFolderPath, bool forceOpenScene = false)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            if (!forceOpenScene)
                ConfirmSaveScene();
            var sceneGuids = AssetDatabase.FindAssets("t:Scene", new string[] { baseFolderPath });
            var sceneList = new List<Scene>();
            if (sceneGuids.Length == 0)
            {
                throw new FatalValidationErrorException("シーンファイルが見つかりません。");
            }
            else if (sceneGuids.Length == 1)
            {
                var path = AssetDatabase.GUIDToAssetPath(sceneGuids[0]);
                var scene = SceneManager.GetSceneByPath(path);
                if (scene.path == null)
                {
                    if (forceOpenScene ? true :
                        EditorUtility.DisplayDialog("検証対象のシーンが開かれていません。", "検証対象のシーンを開きますか？" + Environment.NewLine + path, "開く", "中止"))
                    {
                        scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Single);
                        EditorSceneManager.SetActiveScene(scene);
                    }
                    else
                    {
                        throw new FatalValidationErrorException("検証を中止しました。");
                    }
                }
                sceneList.Add(scene);
            }
            else
            {
                var paths = sceneGuids.Select(guid => AssetDatabase.GUIDToAssetPath(guid)).ToArray();
                throw new FatalValidationErrorException("シーンファイルが複数見つかりました。" + Environment.NewLine + string.Join(Environment.NewLine, paths));
            }
            return sceneList.ToArray();
        }

        private void ConfirmSaveScene()
        {
            if (showSaveDialogFlag)
            {
                if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    throw new FatalValidationErrorException("編集中のシーンファイルをセーブして再実行してください。");
                }
                showSaveDialogFlag = false;
            }
        }
        /// <summary>
        /// ベースフォルダ内のシーンから全てのルートオブジェクトを取得する。
        /// </summary>
        /// <remarks>
        /// シーンがない、または複数シーンがある場合は`FatalValidationErrorException`を発生させる。
        /// </remarks>
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <param name="forceOpenScene">未保存シーンがある場合でも保存ダイアログを表示せずに対象シーンを開く</param>
        /// <returns>全てのルートオブジェクト</returns>
        public GameObject[] FindRootObjects(string baseFolderPath, bool forceOpenScene = false)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            var scenes = FindScenes(baseFolderPath, forceOpenScene);
            return scenes[0].GetRootGameObjects();
        }
        /// <summary>
        /// ベースフォルダ内のシーンから全てのゲームオブジェクトを取得する。
        /// </summary>
        /// <remarks>
        /// シーンがない、または複数シーンがある場合は`FatalValidationErrorException`を発生させる。
        /// </remarks>
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <param name="forceOpenScene">未保存シーンがある場合でも保存ダイアログを表示せずに対象シーンを開く</param>
        /// <returns>全てのゲームオブジェクト</returns>
        public GameObject[] FindAllObjects(string baseFolderPath, bool forceOpenScene = false)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            var rootObjects = FindRootObjects(baseFolderPath, forceOpenScene);
            var allObjects = new List<GameObject>();
            foreach (var rootObject in rootObjects)
                allObjects.AddRange(GetAllChildObjects(rootObject));
            return allObjects.ToArray();
        }

        private IEnumerable<GameObject> GetAllChildObjects(GameObject rootObject)
        {
            yield return rootObject;
            if (rootObject.transform.childCount == 0) yield break;
            foreach (Transform childTransform in rootObject.transform)
            {
                var children = GetAllChildObjects(childTransform.gameObject);
                foreach (GameObject child in children)
                {
                    yield return child;
                }
            }
        }
    }
}