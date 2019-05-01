using System.Text.RegularExpressions;

namespace VitDeck.Utility
{
    public static class VersionUtility
    {
        /// <summary>
        /// 与えられた文字列がセマンティック バージョニングに準拠しているかどうかを判定します。
        /// </summary>
        /// <remarks>
        /// セマンティック バージョニングの制約に関しては https://semver.org/lang/ja/ を参照してください。
        /// </remarks>
        /// <param name="version">調査対象のバージョン文字列</param>
        /// <returns><paramref name="version"/>がセマンティック バージョニングに準拠していればtrue。そうでない場合はfalse。</returns>
        public static bool IsSemanticVersioning(string version)
        {
            return Regex.IsMatch(version, @"^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(-\w+(\.\w+)*)?(\+\w+(\.\w+)*)?$");
        }
    }
}
