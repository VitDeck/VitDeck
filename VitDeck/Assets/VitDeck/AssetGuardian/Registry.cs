using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// 保護対象のアセット及びフォルダの情報を格納する。
    /// </summary>
    public static class Registry
    {
        private const string readonlyLabel = "VitDeck.ReadOnly";

        /// <summary>
        /// アセット/ディレクトリを保護対象にする。
        /// </summary>
        /// <remarks>
        /// 対象がディレクトリの場合、再帰的に保護が行われます。
        /// </remarks>
        /// <param name="path">対象のパス</param>
        public static void Register(string path)
        {
            var assets = AssetUtility.EnumerateAssets(path);
            foreach (var asset in assets)
            {
                if (IsProtected(asset))
                    continue;

                var labels = AssetDatabase.GetLabels(asset);
                labels = labels.Concat(new string[] { readonlyLabel }).ToArray();
                AssetDatabase.SetLabels(asset, labels);
            }
        }

        /// <summary>
        /// アセット/ディレクトリを保護対象から外す。
        /// </summary>
        /// <remarks>
        /// 対象がディレクトリの場合、再帰的に保護解除が行われます。
        /// </remarks>
        /// <param name="path">対象のパス</param>
        public static void Unregister(string path)
        {
            var assets = AssetUtility.EnumerateAssets(path);
            foreach (var asset in assets)
            {
                if (!IsProtected(asset))
                    continue;

                var labels = AssetDatabase.GetLabels(asset);
                labels = labels.Where(label => label != readonlyLabel).ToArray();
                AssetDatabase.SetLabels(asset, labels);
            }
        }

        /// <summary>
        /// パスが保護対象に含まれているかどうか判定する。
        /// </summary>
        /// <param name="assetPath">判定するアセットのパス</param>
        /// <returns>保護対象であればtrue、そうでなければfalse。</returns>
        public static bool Contains(string assetPath)
        {
            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
            return IsProtected(asset);
        }

        private static bool IsProtected(UnityEngine.Object asset)
        {
            var labels = AssetDatabase.GetLabels(asset);

            foreach (var label in labels)
            {
                if (label == readonlyLabel)
                    return true;
            }

            return false;
        }
    }
}