using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// 特定のパス以下のファイルが変更されることを防ぐ。
    /// </summary>
    /// <remarks>
    /// アセットの保存時の処理をフックし、保存されるアセットに保護登録済みのアセットが含まれていた場合、対象アセットに対して行われた全ての変更を破棄します。
    /// アセットの保護登録はスクリプトコンパイル後に引き継がれない為、<see cref="InitializeOnLoadMethodAttribute"/>等を利用して再登録する必要があります。
    /// </remarks>
    /// <seealso cref="UnityEditor.AssetModificationProcessor"/>
    public class Guardian
    {
        public static event Action<string> OnSaveCancelled;
        public static event Action<string> OnDeleteCancelled;
        public static event Action<string> OnMoveCancelled;

        public bool Protects(string path)
        {
            return Registry.Contains(path);
        }

        public string[] OnWillSaveAssets(string[] paths)
        {
            return paths
                 .Where(path => !DiscardChangesIfTarget(path))
                 .ToArray();
        }

        public AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            bool isProtected = Protects(path);
            if (isProtected && OnDeleteCancelled != null)
            {
                OnDeleteCancelled.Invoke(path);
            }
            return isProtected ? AssetDeleteResult.FailedDelete : AssetDeleteResult.DidNotDelete;
        }

        public AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            bool isProtected = Protects(sourcePath);
            if (isProtected && OnMoveCancelled != null)
            {
                OnMoveCancelled.Invoke(sourcePath);
            }
            return isProtected ? AssetMoveResult.FailedMove : AssetMoveResult.DidNotMove;
        }

        /// <summary>
        /// アセットが保護対象であれば全ての保存されていない変更を破棄する。
        /// </summary>
        /// <param name="assetPath">アセットへのパス</param>
        /// <returns>アセットが保護されていた場合はtrue、そうでなければfalse。</returns>
        private bool DiscardChangesIfTarget(string assetPath)
        {
            if (!Protects(assetPath))
                return false;

            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
            Resources.UnloadAsset(asset);

            if (OnSaveCancelled != null)
                OnSaveCancelled.Invoke(assetPath);

            return true;
        }

    }
}