using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// UnityEditorのアセットに対する操作をフックし、保護処理を行うクラス。
    /// </summary>
    public static class Protector
    {
        static EditorDelayedAction setReprotectModeAfterEditorUpdate;
        static IAssetProtectionMarker marker;

        private static bool active = true;

        private enum ProtectionRepairMode
        {
            Reprotect,
            Unprotect
        }
        private static ProtectionRepairMode protectionRepairMode;

        public static event Action<string> OnSaveCancelled;
        public static event Action<string> OnDeleteCancelled;
        public static event Action<string> OnMoveCancelled;

        /// <summary>
        /// アセットの保護機能の有効/無効を切り替える。
        /// </summary>
        public static bool Active
        {
            get { return active; }
            set { active = value; }
        }

        /// <summary>
        /// アセットを保護する。
        /// </summary>
        /// <param name="asset">対象のアセット</param>
        public static void Protect(UnityEngine.Object asset)
        {
            marker.Mark(asset);
        }

        /// <summary>
        /// アセットの保護を解除する。
        /// </summary>
        /// <param name="asset">対象のアセット</param>
        public static void Unprotect(UnityEngine.Object asset)
        {
            marker.Unmark(asset);
        }

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            marker = new LabelAndHideFlagProtectionMarker();
            setReprotectModeAfterEditorUpdate = new EditorDelayedAction(SetReprotectMode, 0, false);

            UnityAssetDuplicationEvent.OnAssetWillDuplicate += OnAssetWillDuplicate;
            UnityAssetPostProcessEvent.OnImportedPostProcess += OnAssetsImported;

            UnityAssetModificationEvent.AddSaveHandler(OnWillSaveAssets);
            UnityAssetModificationEvent.AddDeleteHandler(OnWillDeleteAsset);
            UnityAssetModificationEvent.AddMoveHandler(OnWillMoveAsset);
        }

        private static void SetProtectionRepairMode(ProtectionRepairMode mode)
        {
            protectionRepairMode = mode;
        }

        private static void OnAssetsImported(string[] importedAssets)
        {
            switch (protectionRepairMode)
            {
                case ProtectionRepairMode.Reprotect:
                    foreach (var asset in importedAssets.LoadAssetFromPath<UnityEngine.Object>())
                        marker.RepairMarking(asset);
                    break;
                case ProtectionRepairMode.Unprotect:
                    foreach (var asset in importedAssets.LoadAssetFromPath<UnityEngine.Object>())
                        marker.Unmark(asset);
                    break;
                default:
                    break;
            }
        }

        private static void OnAssetWillDuplicate(string assetPath)
        {
            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
            if (marker.IsMarked(asset))
            {
                setReprotectModeAfterEditorUpdate.Reserve();
                SetProtectionRepairMode(ProtectionRepairMode.Unprotect);
            }
        }

        private static void SetReprotectMode()
        {
            SetProtectionRepairMode(ProtectionRepairMode.Reprotect);
        }

        private static string[] OnWillSaveAssets(string[] paths)
        {
            if (!active)
                return paths;

            var approvedPaths = new List<string>();
            foreach (var path in paths)
            {
                var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
                if (marker.IsMarked(asset))
                {
                    if (OnSaveCancelled != null)
                        OnSaveCancelled.Invoke(path);
                }
                else
                {
                    approvedPaths.Add(path);
                }
            }

            return approvedPaths.ToArray();
        }

        private static AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            if (!active)
                return AssetDeleteResult.DidNotDelete;

            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
            var isProtected = marker.IsMarked(asset);

            if (isProtected)
            {
                if (OnDeleteCancelled != null)
                    OnDeleteCancelled.Invoke(path);

                return AssetDeleteResult.FailedDelete;
            }
            else
            {
                return AssetDeleteResult.DidNotDelete;
            }
        }

        private static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            if (!active)
                return AssetMoveResult.DidNotMove;

            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(sourcePath);
            var isProtected = marker.IsMarked(asset);

            if (isProtected)
            {
                if (OnMoveCancelled != null)
                    OnMoveCancelled.Invoke(sourcePath);

                return AssetMoveResult.FailedMove;
            }
            else
            {
                return AssetMoveResult.DidNotMove;
            }
        }
    }
}