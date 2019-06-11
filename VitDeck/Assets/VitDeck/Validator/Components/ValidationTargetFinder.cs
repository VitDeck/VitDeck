using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VitDeck.Validator
{
    /// <summary>
    /// 検証対象を検索する機能を提供する。
    /// </summary>
    public class ValidationTargetFinder : IValidationTargetFinder
    {
        public ValidationTargetFinder()
        {
        }
        /// <summary>
        /// 検証対象を検索する
        /// </summary>
        /// <param name="baseFonderPath"></param>
        /// <returns>検証対象</returns>
        public ValidationTarget Find(string baseFonderPath)
        {
            return new ValidationTarget(baseFonderPath,
                FindAssetGuids(baseFonderPath),
                FindAssetPaths(baseFonderPath),
                FindAssetObjects(baseFonderPath),
                FindScenes(baseFonderPath),
                FindRootObjects(baseFonderPath),
                FindAllObjects(baseFonderPath));
        }
        /// <summary>
        /// ベースフォルダ内のアセットの全てのGUIDを検索する
        /// </summary>
        /// <remarks>検索結果にベースフォルダは含まれない。</remarks>
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <returns>ベースフォルダ内のアセットの全てのGUID</returns>
        public string[] FindAssetGuids(string baseFolderPath)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            var assetGuids = AssetDatabase.FindAssets("", new string[] { baseFolderPath })
                .Distinct()
                .ToArray<string>();
            return assetGuids;
        }
        /// <summary>
        /// ベースフォルダ内のアセットの全てのパスを検索する
        /// </summary>
        /// <remarks>検索結果にベースフォルダは含まれない。</remarks>
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <returns>ベースフォルダ内のアセットの全てのパス</returns>
        public string[] FindAssetPaths(string baseFolderPath)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            var assetPaths = AssetDatabase.FindAssets("", new string[] { baseFolderPath })
                .Distinct()
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .ToArray<string>();
            return assetPaths;
        }
        /// <summary>
        /// ベースフォルダ内のアセットの全てのオブジェクトを検索する
        /// </summary>
        /// <remarks>検索結果にベースフォルダは含まれない。</remarks>
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <returns>ベースフォルダ内のアセットのオブジェクト</returns>
        public UnityEngine.Object[] FindAssetObjects(string baseFolderPath)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            var assetObjects = AssetDatabase.FindAssets("", new string[] { baseFolderPath })
                .Distinct()
                .Select(guid => AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(guid)))
                .ToArray<UnityEngine.Object>();
            return assetObjects;
        }

        public Scene[] FindScenes(string baseFolderPath)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            //Todo:実装
            return null;
        }

        public GameObject[] FindRootObjects(string baseFolderPath)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            //Todo:実装
            return null;
        }

        public GameObject[] FindAllObjects(string baseFolderPath)
        {
            if (!AssetDatabase.IsValidFolder(baseFolderPath))
                return null;
            //Todo:実装
            return null;
        }
    }
}