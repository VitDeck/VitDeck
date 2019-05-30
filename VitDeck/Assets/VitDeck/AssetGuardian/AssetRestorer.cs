using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// Assetをデフォルトの正常な状態に戻す操作を提供するクラス。
    /// </summary>
    public class AssetRestorer
    {
        private static readonly Dictionary<AssetTypeIdentifier, IRestorer> restoreTools = new Dictionary<AssetTypeIdentifier, IRestorer>();

        private static readonly DefaultRestorer defaultRestorer = new DefaultRestorer();

        static AssetRestorer()
        {
            RegisterAll();
        }

        /// <summary>
        /// アセットの状態をデフォルトに戻す。
        /// </summary>
        /// <param name="asset">対象のアセット</param>
        public static void Restore(Object asset)
        {
            var path = AssetDatabase.GetAssetPath(asset);
            var mainAsset = AssetDatabase.LoadMainAssetAtPath(path);
            var detail = AssetTypeIdentifier.Of(mainAsset);

            IRestorer tool;
            if (!restoreTools.TryGetValue(detail, out tool))
                tool = defaultRestorer;

            tool.Restore(mainAsset);
        }

        private static void RegisterAll()
        {
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(GameObject), PrefabType.Prefab),
                new PrefabRestorer());
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(DefaultAsset)),
                new SimpleRestorer(HideFlags.NotEditable));
        }

        private interface IRestorer
        {
            void Restore(Object asset);
        }

        private class DefaultRestorer : IRestorer
        {
            public void Restore(Object asset)
            {
                asset.hideFlags = HideFlags.None;
            }
        }

        private class PrefabRestorer : IRestorer
        {
            public void Restore(Object asset)
            {
                var rootGameObject = asset as GameObject;
                var rootTransform = rootGameObject.transform;
                foreach (Transform transform in rootGameObject.GetComponentsInChildren<Transform>(true))
                {
                    if (transform == rootTransform || transform.parent == rootTransform)
                    {
                        transform.gameObject.hideFlags = HideFlags.None;
                    }
                    else
                    {
                        transform.gameObject.hideFlags = HideFlags.HideInHierarchy;
                    }
                }
                HideAllComponents(rootGameObject);

            }

            private void HideAllComponents(GameObject gameObject)
            {
                var components = gameObject.GetComponentsInChildren<Component>(true);
                foreach (var component in components)
                {
                    component.hideFlags = HideFlags.HideInHierarchy;
                }
            }
        }

        private class SimpleRestorer : IRestorer
        {
            private readonly HideFlags defaultHideFlags;

            public SimpleRestorer(HideFlags defaultHideFlags)
            {
                this.defaultHideFlags = defaultHideFlags;
            }

            public void Restore(Object asset)
            {
                asset.hideFlags = defaultHideFlags;
            }
        }
    }
}