using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// UnityEditorの保存処理をフックし、Guardianを呼び出すクラス。
    /// </summary>
    public class Trigger : UnityEditor.AssetModificationProcessor
    {
        static Guardian guardian;

        public static event Action<string> OnSaveCancelled;
        public static event Action<string> OnDeleteCancelled;
        public static event Action<string> OnMoveCancelled;

        [InitializeOnLoadMethod]
        public static void Initialize()
        {
            guardian = new Guardian();
        }

        static string[] OnWillSaveAssets(string[] paths)
        {
            var list = new List<string>();
            foreach (var path in paths)
            {
                var approved = guardian.OnWillSaveAsset(path);
                if (approved)
                    list.Add(path);
                else if (OnSaveCancelled != null)
                    OnSaveCancelled.Invoke(path);
            }

            return list.ToArray();
        }
        static AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            var result = guardian.OnWillDeleteAsset(path, options);
            if (result == AssetDeleteResult.FailedDelete && OnDeleteCancelled != null)
                OnDeleteCancelled.Invoke(path);
            return result;
        }
        static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            var result = guardian.OnWillMoveAsset(sourcePath, destinationPath);
            if (result == AssetMoveResult.FailedMove && OnMoveCancelled != null)
                OnMoveCancelled.Invoke(sourcePath);
            return result;
        }
    }
}