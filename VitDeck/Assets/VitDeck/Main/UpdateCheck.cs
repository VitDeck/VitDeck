using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using VitDeck.Utility;

namespace VitDeck.Main
{
    /// <summary>
    /// VitDeckが最新版になっているかバージョンチェックを行うクラス。
    /// </summary>
    public static class UpdateCheck
    {
        public static void UpdatePackage(string tag)
        {

            string downloadUrl = Repository.GetDownloadURL(tag);
            string packageName = Repository.GetPackageName(tag);

            var downloader = new PackageDownloader();
            downloader.Download(downloadUrl, packageName);
            downloader.Import(packageName);
            downloader.Settlement(packageName);
        }

        public static bool IsLatest(string releaseUrl)
        {
            string localVersion = VitDeck.GetVersion();
            string latestVersion = GetLatestVersion(releaseUrl);

            return string.Equals(localVersion, latestVersion);
        }

        public static string GetLatestVersion(string releaseUrl)
        {
            try
            {
                var release = ReleaseInfo(releaseUrl);
                while (release.MoveNext()) { }
                var version = release.Current.ToString();
                return version;
            }
            catch (NullReferenceException e)
            {
                Debug.Log("URL (that can not be got version info): " + releaseUrl);
                Debug.LogWarning(e);
                return "None";
            }
        }

        static IEnumerator ReleaseInfo(string releaseUrl)
        {
            using (var request = UnityWebRequest.Get(releaseUrl))
            {
                request.downloadHandler = new DownloadHandlerBuffer();
                yield return request.SendWebRequest();

                while (!request.isDone)
                {
                    yield return null;
                }

                if (request.isHttpError || request.isNetworkError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    var text = request.downloadHandler.text;
                    var info = JsonUtility.FromJson<Release>(text);
                    yield return info.tag_name;
                }
            }
        }

        [Serializable]
        public class Release
        {
            public string tag_name;
        }
    }
}

