using System.IO;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class A02_VRCSDKVersionRule : BaseRule
    {
        /* VRCSDKのフォルダGUIDが変わったみたい？
           ファイルパスが変わる可能性とGUIDが変わる可能性ならファイルパスが変わる可能性の方が低い気がするのでパスを直接指定。*/
        //const string VRCSDKDependenciesFolderGUID = "23868bd667cf64b479fbd8d1039e2cd2";
        const string versionFilePath = "Assets/VRCSDK/version.txt";

        private VRCSDKVersion targetVersion;

        private readonly string downloadURL;

        public A02_VRCSDKVersionRule(string name, VRCSDKVersion version, string downloadURL) : base(name)
        {
            targetVersion = version;
            this.downloadURL = downloadURL;
        }

        protected override void Logic(ValidationTarget target)
        {
            //var dependenciesFolderPath = AssetDatabase.GUIDToAssetPath(VRCSDKDependenciesFolderGUID);
            //var rootFolderPath = Path.GetDirectoryName(dependenciesFolderPath);
            //var versionFilePath = Path.Combine(rootFolderPath, "version.txt");

            /*if (string.IsNullOrEmpty(rootFolderPath) ||
                string.IsNullOrEmpty(versionFilePath) ||
                !File.Exists(versionFilePath))*/
            if (!File.Exists(versionFilePath))
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