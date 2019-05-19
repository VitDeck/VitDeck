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
		public static bool IsLatest(string release_url)
		{
			var localVersion = VitDeck.GetVersion();
			var latestVersion = GetLatestVersion(release_url);

			return string.Equals(localVersion, latestVersion);
		}

		public static string GetLatestVersion(string release_url)
		{
			var release = ReleaseInfoCoroutine(release_url);
			while (release.MoveNext()) { }
			var version = release.Current.ToString();

			return version;
		}

		static IEnumerator ReleaseInfoCoroutine(string release_url)
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

