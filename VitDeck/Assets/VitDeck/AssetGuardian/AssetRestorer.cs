using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// Assetをデフォルトの正常な状態に戻す操作を提供するクラス。
    /// </summary>
    public class AssetRestorer
    {
        private static readonly Dictionary<AssetTypeIdentifier, IRestorer> restoreTools = new Dictionary<AssetTypeIdentifier, IRestorer>();

        private static readonly IRestorer defaultRestorer = new SimpleRestorer(HideFlags.None);

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
                new AssetTypeIdentifier(typeof(DefaultAsset)),
                new SimpleRestorer(HideFlags.NotEditable));
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(GameObject), true),
                new PrefabRestorer(HideFlags.None, false));
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(AudioClip)),
                new SimpleRestorer(HideFlags.NotEditable));
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(GameObject), false),
                new PrefabRestorer(HideFlags.NotEditable, true));
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(Shader)),
                new SimpleRestorer(HideFlags.NotEditable));
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(TextAsset)),
                new SimpleRestorer(HideFlags.NotEditable));
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(LightingDataAsset)),
                new SimpleRestorer(HideFlags.None, HideFlags.HideInHierarchy | HideFlags.NotEditable));
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(SceneAsset)),
                new SimpleRestorer(HideFlags.NotEditable));
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(AnimatorController)),
                new SimpleRestorer(HideFlags.None, HideFlags.HideInHierarchy));
            restoreTools.Add(
                new AssetTypeIdentifier(AudioMixerRestorer.AudioMixerMainAssetType),
                new AudioMixerRestorer());
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(UnityEngine.ComputeShader)),
                new SimpleRestorer(HideFlags.NotEditable));
            restoreTools.Add(
                new AssetTypeIdentifier(typeof(UnityEngine.Video.VideoClip)),
                new SimpleRestorer(HideFlags.NotEditable));
        }

        private interface IRestorer
        {
            void Restore(Object asset);
        }

        private class PrefabRestorer : IRestorer
        {
            private readonly HideFlags baseHideFlags;
            private bool isModel;
            public PrefabRestorer(HideFlags baseHideFlags, bool isModel)
            {
                this.baseHideFlags = baseHideFlags;
                this.isModel = isModel;
            }

            public void Restore(Object asset)
            {
                var rootGameObject = asset as GameObject;
                var rootTransform = rootGameObject.transform;
                foreach (Transform transform in rootGameObject.GetComponentsInChildren<Transform>(true))
                {
                    if (IsShownInProjectView(rootTransform, transform))
                    {
                        transform.gameObject.hideFlags = baseHideFlags;
                    }
                    else
                    {
                        transform.gameObject.hideFlags = baseHideFlags | HideFlags.HideInHierarchy;
                    }
                }
                // コンポーネントのHideFlagsのセットは後でやらないとGameObject側に対する処理で上書きされてしまう。
                HideAllComponents(rootGameObject);
            }

            private bool IsShownInProjectView(Transform rootTransform, Transform transform)
            {
#if UNITY_2018_3_OR_NEWER
                if (isModel)
                {
                    return transform == rootTransform || transform.parent == rootTransform;
                }
                else
                {
                    return transform == rootTransform;
                }
#else
                return transform == rootTransform || transform.parent == rootTransform;
#endif
            }

            private void HideAllComponents(GameObject gameObject)
            {
                var components = gameObject.GetComponentsInChildren<Component>(true);
                foreach (var component in components)
                {
                    if (component == null)
                        continue;
                    component.hideFlags = baseHideFlags | HideFlags.HideInHierarchy;
                }
            }
        }

        private class SimpleRestorer : IRestorer
        {
            private readonly HideFlags defaultMainHideFlags;
            private readonly HideFlags defaultSubHideFlags;

            public SimpleRestorer(HideFlags defaultHideFlags) : this(defaultHideFlags, defaultHideFlags) { }

            public SimpleRestorer(HideFlags defaultMainHideFlags, HideFlags defaultSubHideFlags)
            {
                this.defaultMainHideFlags = defaultMainHideFlags;
                this.defaultSubHideFlags = defaultSubHideFlags;
            }

            public virtual void Restore(Object asset)
            {
                var path = AssetDatabase.GetAssetPath(asset);
                var assets = AssetUtility.LoadAllAssetsWithoutSceneAtPath(path);
                foreach (var subAssets in assets)
                {
                    subAssets.hideFlags = defaultSubHideFlags;
                }
                asset.hideFlags = defaultMainHideFlags;
            }
        }

        private class AudioMixerRestorer : IRestorer
        {
            public static readonly System.Type AudioMixerMainAssetType;
            public static readonly System.Type AudioMixerHiddenAssetType;

            static AudioMixerRestorer()
            {
                // Internalなのでリフレクションで取得する。
                var assembly = System.Reflection.Assembly.Load("UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
                AudioMixerMainAssetType = assembly.GetType("UnityEditor.Audio.AudioMixerController");
                AudioMixerHiddenAssetType = assembly.GetType("UnityEditor.Audio.AudioMixerEffectController");
            }

            public void Restore(Object mainAsset)
            {
                var path = AssetDatabase.GetAssetPath(mainAsset);
                var allassets = AssetDatabase.LoadAllAssetsAtPath(path);

                foreach (var asset in allassets)
                {
                    if (asset.GetType() == AudioMixerHiddenAssetType)
                    {
                        asset.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
                    }
                    else
                    {
                        asset.hideFlags = HideFlags.None;
                    }
                }
            }
        }
    }
}