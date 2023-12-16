using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// VRCSDKのバージョンを検出するルール
    /// </summary>
    /// <remarks>
    /// GUIDは可変である可能性があるのでファイルパスをチェックする。
    /// </remarks>
    public class VRCSDKVersionRule : BaseRule
    {
        const string manifestFilePath = "Packages/com.vrchat.worlds/package.json";

        private VRCSDKVersion targetVersion;
        private readonly Action _betaAction;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="version">VRCSDKのバージョン</param>
        public VRCSDKVersionRule(string name, VRCSDKVersion version, Action betaAction = null) : base(name)
        {
            targetVersion = version;
            _betaAction = betaAction;
        }

        protected override void Logic(ValidationTarget target)
        {
            if (!File.Exists(manifestFilePath))
            {
                AddIssue(new Issue(null,
                    IssueLevel.Error,
                    LocalizedMessage.Get("VRCSDKVersionRule.NotInstalled"),
                    LocalizedMessage.Get("VRCSDKVersionRule.NotInstalled.Solution")
                ));
                return;
            }

            var manifest = JsonUtility.FromJson<Manifest>(File.ReadAllText(manifestFilePath));
            var version = manifest.version;
            if (Regex.Match(manifest.version, @"-beta.\d+$").Success)
            {
                version = Regex.Replace(manifest.version, @"-beta.\d+", "");
                if (_betaAction != null)
                {
                    _betaAction.Invoke();
                }
            }

            var currentVersion = new VRCSDKVersion(version);

            if (currentVersion < targetVersion)
            {
                AddIssue(new Issue(null,
                    IssueLevel.Error,
                    LocalizedMessage.Get("VRCSDKVersionRule.PreviousVersion"),
                    LocalizedMessage.Get("VRCSDKVersionRule.PreviousVersion.Solution", targetVersion.ToReadableString())
                    ));
            }
        }

        [Serializable]
        private class Manifest
        {
            [SerializeField] public string version;
        }
    }
}
