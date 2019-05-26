using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VitDeck.Utilities;

namespace VitDeck.Main
{
    /// <summary>
    /// VitDeckのGitHubリポジトリ関連の情報管理クラス。
    /// </summary>
    public static class Repository
    {
        private static readonly string Owner = "vkettools";
        private static readonly string RepositoryName = "VitDeck";
        private static readonly string GithubUrl = "https://github.com";
        private static readonly string GithubApi = "https://api.github.com/repos";
        private static readonly string ReleaseURL = "https://vkettools.github.io/VitDeckTest/releases/latest.json";

        public static string GetLatestReleaseURL()
        {
            return ReleaseURL;
        }

        public static string GetReleaseURLByGitHubAPI()
        {
            return String.Format("{0}/{1}/{2}/{3}", 
                            GithubApi,
                            Owner,
                            RepositoryName,
                            "releases/latest");
        }

        public static string GetPackageName(string tag)
        {
            return String.Format("VitDeck-{0}.unitypackage", tag);
        }

        public static string GetDownloadURL(string tag)
        {
            return String.Format("{0}/{1}/{2}/{3}/{4}/{5}",
                            GithubUrl,
                            Owner,
                            RepositoryName,
                            "releases/download",
                            tag,
                            GetPackageName(tag));
        }
    }
}