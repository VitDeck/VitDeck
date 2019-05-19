using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEditor;

namespace VitDeck.Main
{
   	/// <summary>
	/// unitypackageのダウンロードを行うクラス。
	/// </summary>
    public class PackageDownloader
    {
        public float loading = 0.0f;
        
        public void Download(string download_url, string package_name)
        {
            var downloader = DownloadCoroutine(download_url, package_name);
            while (downloader.MoveNext()) { }
            
        }
        
        IEnumerator DownloadCoroutine(string download_url, string package_name)
        {
            var request = UnityWebRequest.Get(download_url);
            request.SendWebRequest();

            while (!request.isDone)
            {
                loading = request.downloadProgress;
                yield return null;
            }

            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                File.WriteAllBytes(Application.dataPath + "/" + package_name,
                    request.downloadHandler.data);
            }
        }
    }

}