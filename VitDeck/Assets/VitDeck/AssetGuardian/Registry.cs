using System.Collections.Generic;

namespace VitDeck.AssetGuardian
{
    /// <summary>
    /// 保護対象のアセット及びフォルダの情報を格納する。
    /// </summary>
    public static class Registry
    {
        private static HashSet<string> guardPaths = new HashSet<string>();

        /// <summary>
        /// パスを保護対象にする。
        /// </summary>
        /// <param name="path"></param>
        public static void Register(string path)
        {
            guardPaths.Add(path);
        }

        /// <summary>
        /// パスを保護対象から外す。
        /// </summary>
        /// <param name="path"></param>
        public static void Unregister(string path)
        {
            guardPaths.Remove(path);
        }

        /// <summary>
        /// パスが保護対象に含まれているかどうか判定する。
        /// </summary>
        /// <param name="assetPath">対象のパス</param>
        /// <returns>保護対象であればtrue、そうでなければfalse。</returns>
        public static bool Contains(string assetPath)
        {
            foreach (var guardPath in guardPaths)
            {
                if (assetPath.StartsWith(guardPath))
                {
                    return true;
                }
            }

            return false;
        }
    }
}