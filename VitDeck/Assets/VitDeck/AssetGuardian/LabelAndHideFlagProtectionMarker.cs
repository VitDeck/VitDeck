using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// アセットの保護フラグを管理する。
    /// </summary>
    public class LabelAndHideFlagProtectionMarker : IAssetProtectionMarker, IDisposable
    {
        private const string readonlyLabel = "VitDeck.ReadOnly";

        private EditorDelayedAction delayedInitialize;

        //TODO: MenuItemAttributeが付いたデバッグ用関数をリリース前に削除する。
        [MenuItem("Assets/Protect")]
        static void Protect()
        {
            var assets = Selection.objects;
            foreach (var asset in assets)
            {
                AttachStatic(asset);
            }
        }

        [MenuItem("Assets/Unprotect")]
        static void Unprotect()
        {
            var assets = Selection.objects;
            foreach (var asset in assets)
            {
                DetachStatic(asset);
            }
        }

        public LabelAndHideFlagProtectionMarker()
        {
            delayedInitialize = new EditorDelayedAction(DelayedInitialize, 0);
            delayedInitialize.Reserve();
        }

        private void DelayedInitialize()
        {
            var assets = EnumerateAllProtectedAssets();
            foreach (var asset in assets)
            {
                SetEditable(asset, false);
            }
        }

        /// <summary>
        /// アセットを保護対象に加える。
        /// </summary>
        /// <param name="asset">対象のアセット</param>
        public void Protect(UnityEngine.Object asset)
        {
            AttachStatic(asset);
        }

        /// <summary>
        /// アセットを保護対象から外す。
        /// </summary>
        /// <param name="asset">対象のアセット</param>
        public void Unprotect(UnityEngine.Object asset)
        {
            DetachStatic(asset);
        }

        /// <summary>
        /// アセットが保護されている場合、保護状態を修復する。
        /// </summary>
        /// <param name="asset"></param>
        public void RepairProtection(UnityEngine.Object asset)
        {
            RepairStatic(asset);
        }

        /// <summary>
        /// アセットが保護対象に含まれているかどうか判定する。
        /// </summary>
        /// <param name="assetPath">判定するアセットのパス</param>
        /// <returns>保護対象であればtrue、そうでなければfalse。</returns>
        public bool IsProtected(UnityEngine.Object asset)
        {
            return IsLabbeled(asset);
        }



        private static void AttachStatic(UnityEngine.Object asset)
        {
            if (IsLabbeled(asset))
                return;
            AddReadonlyLabel(asset);
            SetEditable(asset, false);
        }

        private static void DetachStatic(UnityEngine.Object asset)
        {
            if (!IsLabbeled(asset))
                return;
            RemoveReadonlyLabel(asset);
            SetEditable(asset, true);
        }

        private static void RepairStatic(UnityEngine.Object asset)
        {
            if (IsLabbeled(asset))
            {
                SetEditable(asset, false);
            }
        }

        private static void AddReadonlyLabel(UnityEngine.Object asset)
        {
            var labels = AssetDatabase.GetLabels(asset);
            labels = labels.Concat(new string[] { readonlyLabel }).ToArray();
            AssetDatabase.SetLabels(asset, labels);
        }

        private static void RemoveReadonlyLabel(UnityEngine.Object asset)
        {
            var labels = AssetDatabase.GetLabels(asset);
            labels = labels.Where(label => label != readonlyLabel).ToArray();
            AssetDatabase.SetLabels(asset, labels);
        }

        private static void SetEditable(UnityEngine.Object asset, bool editable)
        {
            if (editable)
                asset.hideFlags &= ~UnityEngine.HideFlags.NotEditable;
            else
                asset.hideFlags |= UnityEngine.HideFlags.NotEditable;

            var prefabType = PrefabUtility.GetPrefabType(asset);
            if (prefabType == PrefabType.Prefab)
            {
                HideSubAsset(asset);
            }
        }

        private static void HideSubAsset(UnityEngine.Object asset)
        {
            var path = AssetDatabase.GetAssetPath(asset);
            var assets = AssetDatabase.LoadAllAssetsAtPath(path);
            foreach (var a in assets)
            {
                if (a == null || AssetDatabase.IsMainAsset(a))
                    continue;
                a.hideFlags |= UnityEngine.HideFlags.HideInHierarchy;
            }
        }

        private static IEnumerable<UnityEngine.Object> EnumerateAllProtectedAssets()
        {
            var assetGUIDs = AssetDatabase.FindAssets("l:" + readonlyLabel);
            foreach (var guid in assetGUIDs)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
                if (asset == null)
                    continue;

                yield return asset;
            }
        }

        private static bool IsLabbeled(UnityEngine.Object asset)
        {
            var labels = AssetDatabase.GetLabels(asset);

            foreach (var label in labels)
            {
                if (label == readonlyLabel)
                    return true;
            }

            return false;
        }

        public void Dispose()
        {
            if (delayedInitialize != null)
            {
                delayedInitialize.Dispose();
                delayedInitialize = null;
            }
        }
    }
}