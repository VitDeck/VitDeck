using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Main
{
    /// <summary>
    /// VitDeckのGitHubリポジトリ関連の情報管理クラス。
    /// </summary>
    public class Repository
    {
        private static readonly string Owner = "vkettools";
        private static readonly string RepositoryName = "VitDeck";
        private static readonly string GithubUrl = "https://github.com";
        private static readonly string GithubApi = "https://api.github.com/repos/";
               
        public static string GetLatestReleaseURL()
        {
            return GithubApi + Owner + RepositoryName + "/releases/latest";
        }

        public string GetPackageName(string tag)
        {
            return "VitDeck-" + tag + ".unitypackage";
        }

        public string GetDownloadURL(string tag)
        {
            return String.Format("{0}/{1}/{2]/{3}/{4}/{5}",
                            GithubUrl,
                            Owner,
                            RepositoryName,
                            "releases/download",
                            tag,
                            GetPackageName(tag));
        }
    }
}