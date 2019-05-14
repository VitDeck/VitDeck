using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace VitDeck.Main
{
    /// <summary>
    /// VitDeckが最新版になっているかバージョンチェックを行うクラス。
    /// </summary>
    public class UpdateCheck // Latest Check
    {
        public static string github_api = "https://api.github.com/repos";
        public static string owner = "/vrm-c";  // テスト用   "/vkettools"
        public static string repository = "/UniVRM";  // テスト用   "/VitDeck"
        public string release_url = github_api + owner + repository + "/releases/latest";

        public bool IsLatest()
        {
            var localVersion = VitDeck.GetVersion();
            var latestVersion = GetLatestVersion();
            return string.Equals(localVersion, latestVersion);
        }

        public string GetLatestVersion()
        {
            var release = GetReleaseInfo();
            while (release.MoveNext()) { }

            return release.Current.ToString();
        }

        IEnumerator GetReleaseInfo()
        {
            var request = UnityWebRequest.Get(release_url);
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
                var info = JsonUtility.FromJson<ReleaseInfo>(text);
                string version = info.tag_name.Split('v')[1];
                
                yield return version;
            }
        }

        [Serializable]
        public class ReleaseInfo
        {
            public string tag_name;
        }

    }
}

