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
    public class Guardian : UnityEditor.AssetModificationProcessor
    {
        static string[] OnWillSaveAssets(string[] paths)
        {
            return paths
                 .Where(path => !DiscardChangesIfTarget(path))
                 .ToArray();
        }

        static AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            return Registry.Contains(path) ? AssetDeleteResult.FailedDelete : AssetDeleteResult.DidNotDelete;
        }

        static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            return Registry.Contains(sourcePath) ? AssetMoveResult.FailedMove : AssetMoveResult.DidNotMove;
        }
        /// <summary>
        /// アセットが保護対象であれば全ての保存されていない変更を破棄する。
        /// </summary>
        /// <param name="assetPath">アセットへのパス</param>
        /// <returns>アセットが保護されていた場合はtrue、そうでなければfalse。</returns>
        private static bool DiscardChangesIfTarget(string assetPath)
        {
            if (!Registry.Contains(assetPath))
                return false;

            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
            Resources.UnloadAsset(asset);
            Debug.Log("All changes of " + assetPath + " are discarded.");

            return true;
        }

    }
}