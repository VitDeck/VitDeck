using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using VitDeck.Placement.Components;

namespace VitDeck.Placement
{
    /// <summary>
    /// 入稿されたオブジェクトを自動配置します。
    /// </summary>
    public static class Placement
    {
        /// <summary>
        /// 指定された出展者IDのオブジェクトを自動配置します。
        /// </summary>
        /// <param name="id">出展者ID。</param>
        /// <param name="location">配置先のシーン。</param>
        /// <returns></returns>
        public static void Place(string id, SceneAsset location)
        {
            var scene = OpenScene(location);

            var anchorIdPairs = GetAnchorIdPairs(scene);
            var anchor = anchorIdPairs.FirstOrDefault(anchorIdPair => anchorIdPair.Value == id).Key;
            if (anchor != null)
            {
                // 配置済みなら
                Object.DestroyImmediate(anchor.GetChild(0).gameObject);
            }
            else
            {
                // 未配置のアンカーを取得
                anchor = anchorIdPairs.First(anchorIdPair => anchorIdPair.Value == null).Key;
                foreach (var child in GetChildren(anchor))
                {
                    Object.DestroyImmediate(child.gameObject);
                }
            }

            var idScene = EditorSceneManager.OpenScene(GetScenePath(id), OpenSceneMode.Additive);
            var root = GetRootObject(idScene).transform;
            root.SetParent(anchor);
            root.transform.localPosition = Vector3.zero;
            root.transform.localRotation = Quaternion.identity;
            EditorSceneManager.CloseScene(idScene, removeScene: true);

            EditorSceneManager.SaveScene(scene);
        }

        /// <summary>
        /// 指定したシーンが開いていなければ開きます。
        /// </summary>
        /// <param name="sceneAsset"></param>
        /// <returns></returns>
        public static Scene OpenScene(SceneAsset sceneAsset)
        {
            var scene = SceneManager.GetActiveScene();
            var locationPath = AssetDatabase.GetAssetPath(sceneAsset);
            if (scene.path != locationPath)
            {
                scene = EditorSceneManager.OpenScene(locationPath);
            }
            return scene;
        }

        /// <summary>
        /// シーンから配置先のアンカーと状態を取得します。
        /// </summary>
        /// <param name="unitypackage"></param>
        /// <returns>キーに配置先の親を持つDictionary。配置済みのオブジェクトを持つ場合、値に出展者IDを持ちます。</returns>
        public static IDictionary<Transform, string> GetAnchorIdPairs(Scene location)
        {
            return location.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<PlacementAnchor>(includeInactive: true))
                .Select(anchor => anchor.transform)
                .ToDictionary(anchor => anchor, anchor =>
                {
                    var children = GetChildren(anchor);
                    return children.Count() == 1 && Regex.IsMatch(children.First().name, "^[1-9][0-9]*$")
                        ? children.First().name
                        : null;
                });
        }

        /// <summary>
        /// 指定したTransformの子を取得します。
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        private static IEnumerable<Transform> GetChildren(Transform parent)
        {
            var children = new List<Transform>();
            for (var i = 0; i < parent.childCount; i++)
            {
                children.Add(parent.GetChild(i));
            }
            return children;
        }

        /// <summary>
        /// 入稿されたシーンのパスを取得します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string GetScenePath(string id)
        {
            return $"Assets/{id}/{id}.unity";
        }

        /// <summary>
        /// 入稿されたオブジェクトを取得します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static GameObject GetRootObject(Scene scene)
        {
            return scene.GetRootGameObjects().First(gameObject => gameObject.name == scene.name);
        }
    }
}
