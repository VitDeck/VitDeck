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
        public float Loading = 0.0f;
        string DirectoryPath = Path.GetTempPath();

        public void Download(string downloadUrl, string packageName)
        {
            var downloader = Downloader(downloadUrl, packageName);
            while (downloader.MoveNext()) { }
        }

        IEnumerator Downloader(string downloadUrl, string packageName)
        {
            using (var request = UnityWebRequest.Get(downloadUrl))
            {
                request.SendWebRequest();

                while (!request.isDone)
                {
                    Loading = request.downloadProgress;
                    yield return null;
                }

                if (request.isHttpError || request.isNetworkError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    File.WriteAllBytes(DirectoryPath + "/" + packageName,
                        request.downloadHandler.data);
                }
            }
        }

        public void Import(string packageName)
        {
            var filePath = DirectoryPath + "/" + packageName;
            var fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
            {
                AssetDatabase.ImportPackage(filePath, true);
            }
        }

        public void Settlement(string packageName)
        {
            var filePath = DirectoryPath + "/" + packageName;
            var fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
    }
}