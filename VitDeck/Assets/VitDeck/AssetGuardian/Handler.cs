using System;
using System.Collections.Generic;
using UnityEditor;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// UnityEditorのアセットに対する操作をフックし、Guardianを呼び出すクラス。
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
        private static void Initialize()
        {
            guardian = new Guardian();
        }

        /// <summary>
        /// UnityEditor上でアセットを保存する直前に呼び出される。
        /// </summary>
        /// <seealso cref="AssetModificationProcessor"/>
        /// <param name="paths">保存しようとしているパスの配列。</param>
        /// <returns>実際に保存されるパスの配列。</returns>
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

        /// <summary>
        /// UnityEditor上でアセットを削除する直前に呼び出される。
        /// </summary>
        /// <seealso cref="AssetModificationProcessor"/>
        /// <param name="path">削除しようとしているパス。</param>
        /// <param name="options">削除の方法。</param>
        /// <returns>アセットを削除したかどうか。</returns>
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

        /// <summary>
        /// UnityEditor上でアセットの移動が行われる直前に呼び出される。
        /// </summary>
        /// <param name="sourcePath">移動元のパス。</param>
        /// <param name="destinationPath">移動先のパス。</param>
        /// <returns>アセットを移動したかどうか。</returns>
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