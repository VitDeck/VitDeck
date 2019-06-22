using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// AssetGuardian内で使う為に、<see cref="AssetModificationProcessor"/>のコールバックをフックする。
    /// </summary>
    public class UnityAssetModificationEvent : UnityEditor.AssetModificationProcessor
    {
        public delegate string[] OnWillSaveAssetsHandler(string[] paths);
        public delegate AssetDeleteResult OnWillDeleteAssetHandler(string path, RemoveAssetOptions options);
        public delegate AssetMoveResult OnWillMoveAssetHandler(string sourcePath, string destinationPath);

        static List<OnWillSaveAssetsHandler> saveHandlers = new List<OnWillSaveAssetsHandler>();
        static List<OnWillDeleteAssetHandler> deleteHandlers = new List<OnWillDeleteAssetHandler>();
        static List<OnWillMoveAssetHandler> moveHandlers = new List<OnWillMoveAssetHandler>();

        public static void AddSaveHandler(OnWillSaveAssetsHandler handler)
        {
            saveHandlers.Add(handler);
        }

        public static void RemoveSaveHandler(OnWillSaveAssetsHandler handler)
        {
            saveHandlers.Remove(handler);
        }

        public static void AddDeleteHandler(OnWillDeleteAssetHandler handler)
        {
            deleteHandlers.Add(handler);
        }

        public static void RemoveDeleteHandler(OnWillDeleteAssetHandler handler)
        {
            deleteHandlers.Remove(handler);
        }

        public static void AddMoveHandler(OnWillMoveAssetHandler handler)
        {
            moveHandlers.Add(handler);
        }

        public static void RemoveMoveHandler(OnWillMoveAssetHandler handler)
        {
            moveHandlers.Remove(handler);
        }

        static string[] OnWillSaveAssets(string[] paths)
        {
            foreach (var handler in saveHandlers)
            {
                paths = handler.Invoke(paths);
            }

            return paths;
        }

        static AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            foreach (var handler in deleteHandlers)
            {
                var result = handler.Invoke(path, options);
                if (result == AssetDeleteResult.DidDelete || result == AssetDeleteResult.FailedDelete)
                    return result;
            }
            return AssetDeleteResult.DidNotDelete;
        }

        static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            foreach (var handler in moveHandlers)
            {
                var result = handler.Invoke(sourcePath, destinationPath);
                if (result == AssetMoveResult.DidMove || result == AssetMoveResult.FailedMove)
                    return result;
            }
            return AssetMoveResult.DidNotMove;
        }
    }
}