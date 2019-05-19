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
        private static readonly string owner = "vkettools";
        private static readonly string repository = "VitDeck";
        private static readonly string github_url = "https://github.com";
        private static readonly string github_api = "https://api.github.com/repos/";
               
        public static string GetLatestReleaseURL()
        {
            return github_api + owner + repository + "/releases/latest";
        }

        public string GetPackageName(string tag)
        {
            return "VitDeck-" + tag + ".unitypackage";
        }

        public string GetDownloadURL(string tag)
        {
            return String.Format("{0}/{1}/{2]/{3}/{4}/{5}",
                            github_url,
                            owner,
                            repository,
                            "releases/download",
                            tag,
                            GetPackageName(tag));
        }
    }
}