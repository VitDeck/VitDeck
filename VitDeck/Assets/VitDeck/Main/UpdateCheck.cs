using System;
using System.Collections;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.Main
{
    /// <summary>
    /// VitDeckが最新版になっているかバージョンチェックを行うクラス。
    /// </summary>
    public static class UpdateCheck
    {
        public static bool Enabled
        {
            get
            {
                return !string.IsNullOrEmpty(JsonReleaseInfo.GetReleaseUrl());
            }
        }

        public static string GetLatestVersion()
        {
            JsonReleaseInfo.FetchInfo(JsonReleaseInfo.GetReleaseUrl());
            return JsonReleaseInfo.GetVersion();
        }

        public static void UpdatePackage(string tag)
        {
            string downloadUrl = JsonReleaseInfo.GetDownloadURL();
            string packageName = JsonReleaseInfo.GetPackageName();

            var downloader = new PackageDownloader();
            downloader.Download(downloadUrl, packageName);
            downloader.Import(packageName);
            downloader.Settlement(packageName);
        }

        public static bool IsLatest()
        {
            string localVersion = ProductInfoUtility.GetVersion();
            string latestVersion = JsonReleaseInfo.GetVersion();

            return string.Equals(localVersion, latestVersion);
        }
    }
}