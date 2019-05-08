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
    /// 与えられたアセットに保護登録済みのアセットが含まれていた場合、対象アセットに対して行われた全ての変更を破棄します。
    /// アセットの保護登録はスクリプトコンパイル後に引き継がれない為、<see cref="InitializeOnLoadMethodAttribute"/>等を利用して再登録する必要があります。
    /// </remarks>
    /// <seealso cref="UnityEditor.AssetModificationProcessor"/>
    public class Guardian
    {
        public bool Protects(string path)
        {
            return Registry.Contains(path);
        }

        public bool OnWillSaveAsset(string path)
        {
            bool isProtected = Protects(path);
            if (isProtected)
            {
                var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
                Resources.UnloadAsset(asset);
            }
            return !isProtected;
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