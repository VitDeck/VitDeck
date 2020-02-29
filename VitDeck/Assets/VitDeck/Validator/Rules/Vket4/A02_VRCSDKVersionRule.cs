using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class A02_VRCSDKVersionRule : BaseRule
    {
        const string VRCSDKFolderGUID = "40895a3d0d3ec475c8ff555d0c40f7cb";

        private VRCSDKVersion targetVersion;

        private readonly string downloadURL;

        public A02_VRCSDKVersionRule(string name, VRCSDKVersion version, string downloadURL) : base(name)
        {
            targetVersion = version;
            this.downloadURL = downloadURL;
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootFolderPath = AssetDatabase.GUIDToAssetPath(VRCSDKFolderGUID);
            var versionFilePath = rootFolderPath + "/version.txt";

            if (string.IsNullOrEmpty(rootFolderPath) ||
                string.IsNullOrEmpty(versionFilePath) ||
                !File.Exists(versionFilePath))
            {
                AddIssue(new Issue(null,
                    IssueLevel.Error,
                    LocalizedMessage.Get("A02_VRCSDKVersionRule.NotInstalled"),
                    LocalizedMessage.Get("A02_VRCSDKVersionRule.NotInstalled.Solution"),
                    solutionURL: downloadURL
                    ));
                return;
            }

            var currentVersion = new VRCSDKVersion(File.ReadAllText(versionFilePath));

            if (currentVersion < targetVersion)
            {
                AddIssue(new Issue(null,
                    IssueLevel.Error,
                    LocalizedMessage.Get("A02_VRCSDKVersionRule.PreviousVersion"),
                    LocalizedMessage.Get("A02_VRCSDKVersionRule.PreviousVersion.Solution"),
                    solutionURL: downloadURL
                    ));
            }
        }
    }
}