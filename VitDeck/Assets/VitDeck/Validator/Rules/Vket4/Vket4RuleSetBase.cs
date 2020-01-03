using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// Vket4の基本ルールセット。
    /// </summary>
    /// <remarks>
    /// 変数をabstractまたはvirtualプロパティで宣言し、継承先で上書きすることでワールドによる制限の違いを表現する。
    /// </remarks>
    public abstract class Vket4RuleSetBase : IRuleSet
    {
        private const string MustUseUnityVersion = "2017.4.28f1";
        private const int FilePathLengthLimitFromAssetsFolder = 184;

        public abstract string RuleSetName
        {
            get;
        }

        public IValidationTargetFinder TargetFinder { get { return new Vket4TargetFinder(); } }

        public IRule[] GetRules()
        {
            // デフォルトで使っていたAttribute式は宣言時にconst以外のメンバーが利用できない。
            // 継承したプロパティを参照して挙動を変えることが出来ない為、直接リストを返す方式に変更した。

            return new IRule[]
            {

                new DebugTargetEnumerationRule("Debug Enumerate"),

                new UnityVersionRule(
                    LocalizedMessage.Get("Vket4RuleSetBase.UnityVersionRule.Title", MustUseUnityVersion),
                    MustUseUnityVersion),

                new A02_VRCSDKVersionRule(
                    LocalizedMessage.Get("Vket4RuleSetBase.VRCSDKVersionRule.Title"),
                    new VRCSDKVersion("2019.09.18.12.05")),

                new AssetNamingRule(
                    LocalizedMessage.Get("Vket4RuleSetBase.NameOfFileAndFolderRule.Title"),
                    @"[a-zA-Z0-9 _\.\-\(\)]+"),

                new AssetPathLengthRule(
                    LocalizedMessage.Get("Vket4RuleSetBase.FilePathLengthLimitRule.Title", FilePathLengthLimitFromAssetsFolder),
                    FilePathLengthLimitFromAssetsFolder),

                new AssetExtentionBlacklistRule(
                    LocalizedMessage.Get("Vket4RuleSetBase.MeshFileTypeBlacklistRule.Title"),
                    new string[]{".ma", ".mb", "max", "c4d", ".blend"}),

                new C02_ExhibitStructureRule(
                    LocalizedMessage.Get("Vket4RuleSetBase.ExhibitStructureRule.Title")),

                new C02_StaticFlagRule(
                    LocalizedMessage.Get("Vket4RuleSetBase.StaticFlagsRule.Title")),

                new UseMeshColliderRule(
                    LocalizedMessage.Get("Vket4RuleSetBase.ShouldNotUseMeshColliderRule.Title")),

            };
        }
    }
}