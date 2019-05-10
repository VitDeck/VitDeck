using System;
using System.Collections.Generic;
using UnityEditor;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// UnityEditorの保存処理をフックし、Guardianを呼び出すクラス。
    /// </summary>
    public class Handler : UnityEditor.AssetModificationProcessor
    {
        static Guardian guardian;

        public static event Action<string> OnSaveCancelled;
        public static event Action<string> OnDeleteCancelled;
        public static event Action<string> OnMoveCancelled;

        private static bool active;

        /// <summary>
        /// アセットの保護機能の有効/無効を切り替える。
        /// </summary>
        /// <param name="active">監視を行うかどうか。</param>
        public static void SetActive(bool active)
        {
            Handler.active = active;
        }

        [InitializeOnLoadMethod]
        public static void Initialize()
        {
            guardian = new Guardian();
        }

        static string[] OnWillSaveAssets(string[] paths)
        {
            if (!active)
                return paths;

            var list = new List<string>();
            foreach (var path in paths)
            {
                var approved = guardian.OnWillSaveAsset(path);
                if (approved)
                    list.Add(path);
                else
                {
                    if (OnSaveCancelled != null)
                        OnSaveCancelled.Invoke(path);
                }
            }

            return list.ToArray();
        }

        static AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            if (!active)
                return AssetDeleteResult.DidNotDelete;

            var result = guardian.OnWillDeleteAsset(path, options);

            if (result == AssetDeleteResult.FailedDelete)
            {
                if (OnDeleteCancelled != null)
                    OnDeleteCancelled.Invoke(path);
            }
            return result;
        }

        static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            if (!active)
                return AssetMoveResult.DidNotMove;

            var result = guardian.OnWillMoveAsset(sourcePath, destinationPath);

            if (result == AssetMoveResult.FailedMove)
            {
                if (OnMoveCancelled != null)
                    OnMoveCancelled.Invoke(sourcePath);
            }
            return result;
        }
    }
}