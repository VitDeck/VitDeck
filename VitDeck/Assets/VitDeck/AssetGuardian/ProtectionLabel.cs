using System.Linq;
using UnityEditor;
using VitDeck.Utilities;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// アセットを保護する/しないを管理する。
    /// </summary>
    public static class ProtectionLabel
    {
        private const string readonlyLabel = "VitDeck.ReadOnly";

        /// <summary>
        /// アセット/ディレクトリを保護対象にする。
        /// </summary>
        /// <remarks>
        /// 対象がディレクトリの場合、全ての子を保護対象にします。
        /// </remarks>
        /// <param name="path">対象のパス</param>
        public static void Attach(string path)
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
        /// 対象がディレクトリの場合、全ての子が保護対象から外れます。
        /// </remarks>
        /// <param name="path">対象のパス</param>
        public static void Detach(string path)
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
        public static bool IsAttachedTo(string assetPath)
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