using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEditor;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;
using VitDeck.Validator;

namespace VitDeck.Placement
{
    /// <summary>
    /// 入稿されたunitypackageをバリデート・インポートします。
    /// </summary>
    public static class PackageImporter
    {
        /// <summary>
        /// Unityプロジェクト上の1つのアセット (ファイル、またはフォルダ) を表します。
        /// </summary>
        private class Asset : IDisposable
        {
            internal string Guid { get; set; }
            internal string Path { get; set; }
            internal Stream Meta { get; set; }
            internal Stream Content { get; set; }

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
        /// <param name="id">出展者ID。</param>
        /// <param name="path">unitypackageのパス。</param>
        /// <param name="allowedExtensions">「.」を含む拡張子。</param>
        /// <exception cref="FatalValidationErrorException">許可されていない拡張子を持つアセットが存在する場合。</exception>
        /// <exception cref="FatalValidationErrorException">出展者IDのフォルダ外にアセットが存在する場合。</exception>
        /// <returns></returns>
        public static void Import(string id, string path, IEnumerable<string> allowedExtensions)
        {
            using (var stream = File.OpenRead(path))
            {
                var assets = ExtractUnitypackage(stream);

                try
                {
                    var pathsWithForbiddenExtensions = GetPathsWithForbiddenExtensions(assets, allowedExtensions);
                    if (pathsWithForbiddenExtensions.Count() > 0)
                    {
                        throw new FatalValidationErrorException(
                            "次のファイルは許可されていない拡張子を持っています:\n" + string.Join("\n", pathsWithForbiddenExtensions)
                        );
                    }

                    var pathsOutOfIdFolder = GetPathsOutOfIdFolder(assets, id);
                    if (pathsOutOfIdFolder.Count() > 0)
                    {
                        throw new FatalValidationErrorException(
                            "次のアセットは出展者IDのフォルダ外に存在します:\n" + string.Join("\n", pathsOutOfIdFolder)
                        );
                    }

                    RemoveAssets(id);
                    AssetDatabase.ImportPackage(path, false);
                }
                finally
                {
                    foreach (var asset in assets)
                    {
                        asset.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// unitypackageからアセットを取り出します。
        /// </summary>
        /// <param name="unitypackage"></param>
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
                    var guidNamePair = entry.Name.Split('/');
                    var guid = guidNamePair[0];
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
                    }
                }
            }

            return assets;
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
        /// 指定した出展者IDのフォルダがすでに存在すれば削除します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static void RemoveAssets(string id)
        {
            AssetDatabase.DeleteAsset("Assets/" + id);
            AssetDatabase.Refresh();
        }
    }
}
