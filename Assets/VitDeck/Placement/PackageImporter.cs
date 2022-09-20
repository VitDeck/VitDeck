using System;
using System.Reflection;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEditor;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;
using VitDeck.Utilities;
using VitDeck.Validator;

namespace VitDeck.Placement
{
    /// <summary>
    /// 入稿されたunitypackageをバリデート・インポートします。
    /// </summary>
    public static class PackageImporter
    {
        private static readonly Regex GuidPattern = new Regex("^[0-9a-f]{32}$");

        /// <summary>
        /// Unityプロジェクト上の1つのアセット (ファイル、またはフォルダ) を表します。
        /// </summary>
        private class Asset : IDisposable
        {
            internal string Guid { get; set; }
            internal string Path { get; set; }
            internal MemoryStream Meta { get; set; }
            internal MemoryStream Content { get; set; }

            public void Dispose()
            {
                if (this.Meta != null)
                {
                    this.Meta.Dispose();
                }

                if (this.Content != null)
                {
                    this.Content.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定したパッケージをバリデート・インポートします。
        /// </summary>
        /// <param name="path">unitypackageのパス。</param>
        /// <param name="id">出展者ID。</param>
        /// <param name="allowedExtensions">「.」を含む拡張子。</param>
        /// <exception cref="FatalValidationErrorException">許可されていない拡張子を持つアセットが存在する場合。</exception>
        /// <exception cref="FatalValidationErrorException">出展者IDのフォルダ外にアセットが存在する場合。</exception>
        /// <returns></returns>
        public static void Import(string path, string id = null, IEnumerable<string> allowedExtensions = null)
        {
            using (var stream = File.OpenRead(path))
            {
                var assets = ExtractUnitypackage(stream);

                var tempUnitypackagePath = Path.GetTempPath() + Guid.NewGuid() + ".unitypackage";

                try
                {
                    if (allowedExtensions != null)
                    {
                        var pathsWithForbiddenExtensions = GetPathsWithForbiddenExtensions(assets, allowedExtensions);
                        if (pathsWithForbiddenExtensions.Count() > 0)
                        {
                            throw new FatalValidationErrorException(
                                "次のファイルは許可されていない拡張子を持っています:\n" + string.Join("\n", pathsWithForbiddenExtensions)
                            );
                        }
                    }

                    if (id != null)
                    {
                        var pathsOutOfIdFolder = GetPathsOutOfIdFolder(assets, id);
                        if (pathsOutOfIdFolder.Count() > 0)
                        {
                            throw new FatalValidationErrorException(
                                "次のアセットは出展者IDのフォルダ外に存在します:\n" + string.Join("\n", pathsOutOfIdFolder)
                            );
                        }
                    }

                    ReplaceAllGuids(assets);

                    using (var guidReplacedUnitypackage = PackUnitypackage(assets))
                    {
                        File.WriteAllBytes(tempUnitypackagePath, guidReplacedUnitypackage.ToArray());
                    }

                    ImportPackageImmediately(tempUnitypackagePath);
                }
                finally
                {
                    File.Delete(tempUnitypackagePath);

                    foreach (var asset in assets)
                    {
                        asset.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// <see cref="AssetDatabase.ImportPackageImmediately"/>を呼び出します。
        /// </summary>
        /// <param name="packagePath"></param>
        private static void ImportPackageImmediately(string packagePath)
        {
            var AssetDatabase = typeof(AssetDatabase);
            AssetDatabase
                .GetMethod("ImportPackageImmediately", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(AssetDatabase, new[] { packagePath });
        }

        /// <summary>
        /// unitypackageからアセットを取り出します。
        /// </summary>
        /// <param name="unitypackage"></param>
        /// <exception cref="FatalValidationErrorException">unitypackageに不正なエントリーが含まれていた場合。</exception>
        /// <returns></returns>
        private static IEnumerable<Asset> ExtractUnitypackage(Stream unitypackage)
        {
            var assets = new List<Asset>();

            using (var gzipStream = new GZipInputStream(unitypackage))
            using (var tarStream = new TarInputStream(gzipStream))
            {
                TarEntry entry;
                while ((entry = tarStream.GetNextEntry()) != null)
                {
                    var entryName = entry.Name.Replace("./", ""); // Macでunitypackageを作成すると先頭に「./」が付く問題への対処
                    if (entryName == "")
                    {
                        continue;
                    }

                    var guidNamePair = entryName.Split('/');
                    var guid = guidNamePair[0];
                    if (!GuidPattern.IsMatch(guid))
                    {
                        throw new FatalValidationErrorException($"unitypackageに、不正なGUIDを持つエントリー「{entryName}」が含まれています。");
                    }
                    var archiveFileName = guidNamePair[1];

                    var asset = assets.FirstOrDefault(a => a.Guid == guid);
                    if (asset == null)
                    {
                        asset = new Asset()
                        {
                            Guid = guid,
                        };
                        assets.Add(asset);
                    }

                    switch (archiveFileName)
                    {
                        case "pathname":
                            var bytes = new byte[entry.Size];
                            tarStream.Read(bytes, 0, (int)entry.Size);
                            asset.Path = Encoding.UTF8.GetString(bytes);
                            break;

                        case "asset.meta":
                        case "asset":
                            var stream = new MemoryStream();
                            tarStream.CopyEntryContents(stream);
                            switch (archiveFileName)
                            {
                                case "asset.meta":
                                    asset.Meta = stream;
                                    break;

                                case "asset":
                                    asset.Content = stream;
                                    break;
                            }
                            break;

                        case "": // フォルダエントリー
                        case "preview.png": // プレビュー
                        case "._asset": // Macで生成されるファイル
                        case "._asset.meta": // Macで生成されるファイル
                            break;

                        default:
                            throw new FatalValidationErrorException($"unitypackageに、不正なファイル名のエントリー「{entryName}」が含まれています。");
                    }
                }
            }

            foreach (var asset in assets)
            {
                if (asset.Path == null)
                {
                    throw new FatalValidationErrorException($"unitypackageに、pathnameのエントリーを含まない不正なアセット (GUID: {asset.Guid}) が含まれています。");
                }

                if (asset.Meta == null)
                {
                    throw new FatalValidationErrorException($"unitypackageに、asset.metaのエントリーを含まない不正なアセット (GUID: {asset.Guid}) が含まれています。");
                }
            }

            return assets;
        }

        /// <summary>
        /// アセットをunitypackage化します。
        /// </summary>
        /// <param name="assets"></param>
        /// <returns></returns>
        private static MemoryStream PackUnitypackage(IEnumerable<Asset> assets)
        {
            var unitypackage = new MemoryStream();
            using (var gzipStream = new GZipOutputStream(unitypackage))
            using (var tarStream = new TarOutputStream(gzipStream))
            {
                foreach (var asset in assets)
                {
                    var bytes = Encoding.UTF8.GetBytes(asset.Path);
                    tarStream.PutNextEntry(new TarEntry(new TarHeader()
                    {
                        Name = asset.Guid + "/pathname",
                        Size = bytes.Length,
                    }));
                    tarStream.Write(bytes, 0, bytes.Length);
                    tarStream.CloseEntry();

                    tarStream.PutNextEntry(new TarEntry(new TarHeader()
                    {
                        Name = asset.Guid + "/asset.meta",
                        Size = asset.Meta.Length,
                    }));
                    tarStream.Write(asset.Meta.ToArray(), 0, (int)asset.Meta.Length);
                    tarStream.CloseEntry();

                    if (asset.Content != null)
                    {
                        tarStream.PutNextEntry(new TarEntry(new TarHeader()
                        {
                            Name = asset.Guid + "/asset",
                            Size = asset.Content.Length,
                        }));
                        tarStream.Write(asset.Content.ToArray(), 0, (int)asset.Content.Length);
                        tarStream.CloseEntry();
                    }
                }
            }
            return unitypackage;
        }

        /// <summary>
        /// 許可されていない拡張子を持つファイルのパス一覧を取得します。
        /// </summary>
        /// <param name="assets"></param>
        /// <param name="allowedExtensions">「.」を含む拡張子。</param>
        /// <returns></returns>
        private static IEnumerable<string> GetPathsWithForbiddenExtensions(IEnumerable<Asset> assets, IEnumerable<string> allowedExtensions)
        {
            return assets
                .Where(asset => asset.Content != null && !allowedExtensions.Contains(Path.GetExtension(asset.Path).ToLower()))
                .Select(asset => asset.Path);
        }

        /// <summary>
        /// 出展者IDのフォルダの外にあるアセットのパス一覧を取得します。
        /// </summary>
        /// <param name="assets"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetPathsOutOfIdFolder(IEnumerable<Asset> assets, string id)
        {
            var folderPath = "Assets/" + id;
            return assets
                .Where(asset => asset.Path != folderPath && !asset.Path.StartsWith(folderPath + "/"))
                .Select(asset => asset.Path);
        }

        /// <summary>
        /// 競合防止のため、すべてのアセットのGUIDを置き換えます。
        /// </summary>
        /// <param name="assets"></param>
        /// <returns></returns>
        private static void ReplaceAllGuids(IEnumerable<Asset> assets)
        {
            var oldNewGuidPairs = assets.ToDictionary(asset => asset.Guid, _ => Guid.NewGuid().ToString("N"));
            foreach (var asset in assets)
            {
                asset.Guid = oldNewGuidPairs[asset.Guid];
                asset.Meta = ReplaceStrings(asset.Meta, oldNewGuidPairs);
                if (asset.Content != null)
                {
                    asset.Content = ReplaceStrings(asset.Content, oldNewGuidPairs);
                }
            }
        }

        /// <summary>
        /// Streamに含まれる文字列の置換を行います。
        /// </summary>
        /// <remarks>
        /// バイナリ形式であれば、そのまま返します。
        /// </remarks>
        /// <param name="stream"></param>
        /// <param name="oldNewPairs"></param>
        /// <returns></returns>
        private static MemoryStream ReplaceStrings(MemoryStream stream, IDictionary<string, string> oldNewPairs)
        {
            var utf8Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
            string str;
            try
            {
                str = utf8Encoding.GetString(stream.ToArray());
            }
            catch (ArgumentException)
            {
                return stream;
            }

            stream.Dispose();

            foreach (var (oldValue, newValue) in oldNewPairs)
            {
                str = str.Replace(oldValue, newValue);
            }

            return new MemoryStream(utf8Encoding.GetBytes(str));
        }
    }
}
