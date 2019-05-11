using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// 特定のファイルが変更されることを防ぐ。
    /// </summary>
    /// <remarks>
    /// 与えられたアセットが保護登録済みだった場合、対象アセットに対して行われた全ての変更を破棄します。
    /// </remarks>
    public class Guardian
    {
        public bool Protects(string path)
        {
            return ProtectionLabel.IsAttachedTo(path);
        }

        public bool OnWillSaveAsset(string path)
        {
            bool isProtected = Protects(path);
            if (isProtected)
            {
                DiscardDirtyChanges(path);
            }
            return !isProtected;
        }

        public static void DiscardDirtyChanges(string path)
        {
            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
            Resources.UnloadAsset(asset);
        }

        public AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            bool isProtected = Protects(path);
            return isProtected ? AssetDeleteResult.FailedDelete : AssetDeleteResult.DidNotDelete;
        }

        public AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            bool isProtected = Protects(sourcePath);
            return isProtected ? AssetMoveResult.FailedMove : AssetMoveResult.DidNotMove;
        }
    }
}