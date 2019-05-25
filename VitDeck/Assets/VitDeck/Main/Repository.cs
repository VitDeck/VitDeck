using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VitDeck.Utility;

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

        public static string GetLatestReleaseURL()
        {
            return String.Format("{0}/{1}/{2}/{3}", 
                            GithubApi,
                            Owner,
                            RepositoryName,
                            "releases/latest");
        }

        public static string GetPackageName(string tag)
        {
            if (!VersionUtility.IsSemanticVersioning(tag))
                return null;

            return String.Format("VitDeck-{0}.unitypackage", tag);
        }

        public static string GetDownloadURL(string tag)
        {
            if (!VersionUtility.IsSemanticVersioning(tag))
                return null;

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