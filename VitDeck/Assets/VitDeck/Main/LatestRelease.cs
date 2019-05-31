using UnityEngine;
using System;
using System.Collections;
using VitDeck.Utilities;
using UnityEngine.Networking;

namespace VitDeck.Main
{
    /// <summary>
    /// VitDeckの最新リリース情報を管理するクラス。
    /// <summary>
    public static class LatestRelease
    {
        private static string releaseJsonURL = "https://vkettools.github.io/VitDeckTest/releases/latest.json";
        private static string version = null;
        private static string packageName = null;
        private static string downloadUrl = null;

        public static string GetReleaseJsonURL()
        {
            return releaseJsonURL;
        }

        public static string GetVersion()
        {
            return version;
        }

        public static string GetPackageName()
        {
            return packageName;
        }

        public static string GetDownloadURL()
        {
            return downloadUrl;
        }

        public static void FetchReleaseInfo(string releaseUrl)
        {
            var release = ReleaseEnumerator(releaseUrl);
            while (release.MoveNext()) { }
        }

        static IEnumerator ReleaseEnumerator(string releaseUrl)
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
                    Debug.LogWarning(request.error);
                    Debug.LogWarning("URL (that can not be got version info): " + releaseUrl);
                }
                else
                {
                    var text = request.downloadHandler.text;
                    var info = JsonUtility.FromJson<Release>(text);

                    version = info.version;
                    packageName = info.package_name;
                    downloadUrl = info.download_url;
                }
            }
        }

        [Serializable]
        public class Release
        {
            public string version;
            public string package_name;
            public string download_url;
        }
    }
}