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
		private static readonly string github_api = "https://api.github.com/repos";
		private static readonly string owner = "/vkettools";
		private static readonly string repository = "/VitDeck";
		private static readonly string release_url = github_api + owner + repository + "/releases/latest";
		// テスト用URL
		public static string test_url = "https://vkettools.github.io/VitDeckTest/releases/latest.json";

		public bool IsLatest()
		{
			var localVersion = VitDeck.GetVersion();
			var latestVersion = GetLatestVersion();
			return string.Equals(localVersion, latestVersion);
		}

		public string GetLatestVersion()
		{
			var release = ReleaseInfoCoroutine();
			while (release.MoveNext()) { }
			var version = release.Current.ToString();
			
			Debug.Log("info: " + version);
			return version;
		}

		IEnumerator ReleaseInfoCoroutine()
		{
			var request = UnityWebRequest.Get(test_url);
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
				yield return info.tag_name;
			}
		}

		[Serializable]
		public class ReleaseInfo
		{
			public string tag_name;
		}
	}
}

