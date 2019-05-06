using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// 保護対象のアセット及びフォルダの情報を格納する。
    /// </summary>
    public static class Registry
    {
        private const string readonlyLabel = "VitDeck.Readonly";

        /// <summary>
        /// アセット/ディレクトリを保護対象にする。
        /// </summary>
        /// <remarks>
        /// 対象がディレクトリの場合、再帰的に保護が行われます。
        /// </remarks>
        /// <param name="path">対象のパス</param>
        public static void Register(string path)
        {
            var assets = EnumerateAssets(path);
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
            var assets = EnumerateAssets(path);
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

        /// <summary>
        /// 指定されたファイル/ディレクトリ及び、その子のパスを列挙する。
        /// </summary>
        /// <param name="path">ファイルもしくはディレクトリのパス</param>
        /// <returns>パスの列挙</returns>
        private static IEnumerable<string> EnumerateFileSystemEntries(string path)
        {
            if (Directory.Exists(path))
            {
                yield return path;

                var childFiles = Directory.GetFiles(path);
                foreach (var childFile in childFiles)
                {
                    yield return childFile;
                }

                var childDirectories = Directory.GetDirectories(path);
                foreach (var childDirectory in childDirectories)
                {
                    var progenies = EnumerateFileSystemEntries(childDirectory);
                    foreach (var progeny in progenies)
                        yield return progeny;
                }
            }
            else if (File.Exists(path))
            {
                yield return path;
                yield break;
            }
            else yield break;
        }

        /// <summary>
        /// 指定されたファイル/ディレクトリ及び、あればその子のアセットを列挙する。
        /// </summary>
        /// <param name="path">アセットもしくはディレクトリのパス</param>
        /// <returns>アセットの列挙</returns>
        private static IEnumerable<UnityEngine.Object> EnumerateAssets(string path)
        {
            foreach (var assetPath in EnumerateFileSystemEntries(path))
            {
                if (assetPath.EndsWith(".meta"))
                {
                    continue;
                }
                var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
                if (asset == null)
                {
                    continue;
                }
                yield return asset;
            }
        }
    }
}