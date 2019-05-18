using System.Collections.Generic;
using System.IO;

namespace VitDeck.Utilities
{
    /// <summary>
    /// <see cref="System.IO"/>を拡張するユーティリティクラス。
    /// </summary>
    public static class IOUtility
    {
        /// <summary>
        /// 指定されたファイル/ディレクトリ及び、その子のパスを列挙する。
        /// </summary>
        /// <param name="path">ファイルもしくはディレクトリのパス</param>
        /// <returns>パスの列挙</returns>
        public static IEnumerable<string> EnumerateFileSystemEntries(string path)
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
    }
}