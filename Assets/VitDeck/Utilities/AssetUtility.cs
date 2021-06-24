using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace VitDeck.Utilities
{
    /// <summary>
    /// アセットに対する操作を提供するクラス。
    /// </summary>
    public static class AssetUtility
    {
        private static string _imageFolderPath;
        private static string _configFolderPath;
        private static string _rootFolderPath;
        /// <summary>
        /// VitDeck用画像フォルダのパス
        /// </summary>
        /// <remarks>
        /// Unityで`ImagesFolder`ラベルが付与されているアセットの一つ目のパスを返す。
        /// 存在しない場合はDirectoryNotFoundExceptionを返す。
        /// </remarks>
        public static string ImageFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_imageFolderPath))
                {
                    _imageFolderPath = GetFolderPath("VitDeck.ImagesFolder");
                }
                return _imageFolderPath;
            }
        }
        /// <summary>
        /// 設定ファイル用フォルダのパス
        /// </summary>
        /// <remarks>
        /// Unityでラベルが付与されているアセットの一つ目のパスを返す。
        /// 存在しない場合はDirectoryNotFoundExceptionを返す。
        /// </remarks>
        public static string ConfigFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_configFolderPath))
                {
                    _configFolderPath = GetFolderPath("VitDeck.ConfigFolder");
                }
                return _configFolderPath;
            }
        }

        /// <summary>
        /// VitDeckルートフォルダのパス
        /// </summary>
        /// <remarks>
        /// Unityでラベルが付与されているアセットの一つ目のパスを返す。
        /// 存在しない場合はDirectoryNotFoundExceptionを返す。
        /// </remarks>
        public static string RootFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_rootFolderPath))
                {
                    _rootFolderPath = GetFolderPath("VitDeck.RootFolder");
                }
                return _rootFolderPath;
            }
        }

        private static string GetFolderPath(string assetLabel)
        {
            string folderPath = AssetDatabase.FindAssets("l:" + assetLabel)
                 .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                 .Where(path => path != null)
                 .FirstOrDefault();
            if (folderPath != null)
            {
                return folderPath;
            }
            else
            {
                throw new DirectoryNotFoundException(string.Format("folder for {0} not found.", assetLabel));
            }
        }

        /// <summary>
        /// GUIDに対応したアセットパスの配列を返す。
        /// </summary>
        /// <param name="guids">guidの配列</param>
        /// <returns>アセットパスの配列</returns>
        public static string[] GuidsToPaths(string[] guids)
        {
            var names = new List<string>();
            foreach (var guid in guids)
            {
                var name = AssetDatabase.GUIDToAssetPath(guid);
                names.Add(name);
            }
            return names.ToArray();
        }

        /// 指定されたファイル/フォルダ及び、その子のアセットを列挙する。
        /// </summary>
        /// <param name="path">アセットもしくはフォルダのパス</param>
        /// <returns>アセットの列挙可能オブジェクト</returns>
        public static IEnumerable<UnityEngine.Object> EnumerateAssets(string path)
        {
            foreach (var assetPath in IOUtility.EnumerateFileSystemEntries(path))
            {
                if (assetPath.EndsWith(".meta"))
                {
                    continue;
                }
                var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
                if (asset == null)
                {
                    continue;
                }
                yield return asset;
            }
        }

        /// <summary>
        /// <see cref="AssetDatabase.LoadAllAssetsAtPath(string)"/>を安全に呼び出すメソッド。
        /// </summary>
        /// <remarks>
        /// シーン(<see cref="SceneAsset"/>)に対して<see cref="AssetDatabase.LoadAllAssetsAtPath(string)"/>を行うと、<code>Do not use ReadObjectThreaded on scene objects!</code>というエラーが出ます。その回避のために、対象がSceneAssetであればメインアセットのみを読み込むという処理を行っています。
        /// </remarks>
        /// <param name="path"></param>
        /// <returns></returns>
        public static UnityEngine.Object[] LoadAllAssetsWithoutSceneAtPath(string path)
        {
            UnityEngine.Object[] allInstances;
            var mainAsset = AssetDatabase.LoadMainAssetAtPath(path);
            if (mainAsset is SceneAsset)
                allInstances = new UnityEngine.Object[] { mainAsset };
            else
                allInstances = AssetDatabase.LoadAllAssetsAtPath(path);
            return allInstances;
        }

        /// <summary>
        /// メニューの`Assets/Create/`内の項目を選んだ時と同じ結果になるアセット生成処理。
        /// </summary>
        /// <remarks>
        /// このメソッドでアセット生成を行った場合、
        /// - アセット生成時にユーザーが選択していたフォルダ、もしくは選択していたアセットを含むフォルダ内にアセットが生成されます。
        /// - また、アセット生成後に生成アセットにフォーカスが移り、リネーム処理が始まります。
        /// - リネーム処理中にEscキーを押すことで生成をキャンセルする事が出来ます。
        /// </remarks>
        /// <param name="instance">Assetを生成するインスタンス。</param>
        /// <param name="defaultAssetName">Assetの基本名。既存のアセットとパスが重複する場合は連番が振られます。</param>
        public static void CreateAssetInteractivity(UnityEngine.Object instance, string defaultAssetName)
        {
            string targetFolder;
            if (Selection.assetGUIDs.Length > 0)
            {
                var selectedAssetGUID = Selection.assetGUIDs.Last();
                var selectedAssetPath = AssetDatabase.GUIDToAssetPath(selectedAssetGUID);

                if (AssetDatabase.IsValidFolder(selectedAssetPath))
                {
                    targetFolder = selectedAssetPath;
                }
                else
                {
                    targetFolder = System.IO.Path.GetDirectoryName(selectedAssetPath);
                }
            }
            else
            {
                targetFolder = "Assets";
            }

            var path = AssetDatabase.GenerateUniqueAssetPath(targetFolder + "/" + defaultAssetName);

            ProjectWindowUtil.CreateAsset(instance, path);
        }

        /// <summary>
        /// 現在のシーン上で、指定したルートオブジェクト外のオブジェクトを一時的に削除し、コールバック関数を実行する。
        /// </summary>
        /// <remarks>
        /// シーンは保存されている必要がある。
        /// </remarks>
        /// <param name="rootObjectName"></param>
        /// <param name="callback">コールバック関数が指定されていなければ、削除したオブジェクトを復元しない。</param>
        public static void TemporaryDestroyObjectsOutsideOfRootObjectAndRunCallback(string rootObjectName, Action callback = null)
        {
            foreach (var obj in Array.FindAll(Resources.FindObjectsOfTypeAll<GameObject>(), (item) => item.transform.parent == null))
            {
                if (obj.name != rootObjectName && AssetDatabase.GetAssetOrScenePath(obj).Contains(".unity"))
                {
                    Object.DestroyImmediate(obj);
                }
            }

            if (callback != null)
            {
                callback();

                EditorSceneManager.OpenScene(SceneManager.GetActiveScene().path);
            }
        }

        /// <summary>
        /// ベースフォルダを基に、IDを返す。
        /// </summary>
        /// <returns></returns>
        public static string GetId(DefaultAsset baseFolder)
        {
            return Path.GetFileName(AssetDatabase.GetAssetPath(baseFolder));
        }

        /// <summary>
        /// ベースフォルダを基に、シーンのパスを返す。
        /// </summary>
        /// <returns></returns>
        public static string GetScenePath(DefaultAsset baseFolder)
        {
            var id = GetId(baseFolder);
            return $"Assets/{id}/{id}.unity";
        }

        /// <summary>
        /// 入稿用シーンを開く。
        /// </summary>
        /// <returns>シーンが存在しなければ <c>false</c> を返す。</returns>
        public static bool OpenScene(DefaultAsset baseFolder)
        {
            var scenePath = GetScenePath(baseFolder);
            var scene = EditorSceneManager.GetSceneByPath(scenePath);
            if (!scene.IsValid())
            {
                return false;
            }

            if (!scene.isLoaded)
            {
                EditorSceneManager.OpenScene(scenePath);
            }

            return true;
        }
    }
}
