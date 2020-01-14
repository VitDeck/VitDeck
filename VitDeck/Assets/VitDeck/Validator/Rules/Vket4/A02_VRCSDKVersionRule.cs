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
        const string versionFileGUID = "fd020b1f1669bad4199457b1a193a93a";

        const string sdkDownloadURL = "https://www.vrchat.net/download/sdk";

        private VRCSDKVersion targetVersion;

        public A02_VRCSDKVersionRule(string name, VRCSDKVersion version) : base(name)
        {
            targetVersion = version;
        }

        protected override void Logic(ValidationTarget target)
        {

            var versionFilePath = AssetDatabase.GUIDToAssetPath(versionFileGUID);

            if (string.IsNullOrEmpty(versionFilePath) || !File.Exists(versionFilePath))
            {
                AddIssue(new Issue(null,
                    IssueLevel.Error,
                    LocalizedMessage.Get("A02_VRCSDKVersionRule.NotInstalled"),
                    LocalizedMessage.Get("A02_VRCSDKVersionRule.NotInstalled.Solution"),
                    solutionURL: "https://www.vrchat.net/download/sdk"
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
                    solutionURL: "https://www.vrchat.net/download/sdk"
                    ));
            }
        }
    }
}