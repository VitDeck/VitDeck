using VRCSDK2;

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

                new UnityVersionRule("[A-1]Unity 2017.4.28f1で作成すること","2017.4.28f1"),

                new A02_VRCSDKVersionRule("[A-2]VRCSDKは提出時点の最新バージョンを使うこと", new VRCSDKVersion("2019.09.18.12.05")),

                new AssetGuidBlacklistRule("配布アセットを入稿フォルダ内に入れないこと", Vket4OfficialAssetData.GUIDs),

                new AssetNamingRule("[B-1]ファイル名とフォルダ名の使用禁止文字ルール", @"[a-zA-Z0-9 _\.\-\(\)]+"),

                new AssetPathLengthRule("[B-3]ファイルパスはAsset/から数えて184文字以内に収まっていること", 184),
                
                new AssetExtentionBlacklistRule("[B-4]メッシュアセットのファイル形式で特定のものが含まれていないこと",
                                                new string[]{".ma", ".mb", "max", "c4d", ".blend"}
                ),

                new C02_ExhibitStructureRule("[C-2]Static,Dynamicの2つのEmptyオブジェクトを作り、すべてのオブジェクトはこのどちらかの階層下に入れること"),

                new C02_StaticFlagRule("[C-2]Staticオブジェクト以下は特定のStatic設定を行うこと"),

                new VRCTriggerConfigRule("[F-1]配布Prefab以外のVRC_Triggerは許可された設定のみ使うこと",
                            new VRC_EventHandler.VrcBroadcastType []{
                                VRC_EventHandler.VrcBroadcastType.Local },
                            new VRC_Trigger.TriggerType[] {
                                VRC_Trigger.TriggerType.Custom,
                                VRC_Trigger.TriggerType.OnInteract,
                                VRC_Trigger.TriggerType.OnEnterTrigger,
                                VRC_Trigger.TriggerType.OnExitTrigger,
                                VRC_Trigger.TriggerType.OnPickup,
                                VRC_Trigger.TriggerType.OnDrop,
                                VRC_Trigger.TriggerType.OnPickupUseDown,
                                VRC_Trigger.TriggerType.OnPickupUseUp   },
                            new VRC_EventHandler.VrcEventType[] {
                                VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
                                VRC_EventHandler.VrcEventType.AudioTrigger,
                                VRC_EventHandler.VrcEventType.PlayAnimation,
                                VRC_EventHandler.VrcEventType.SetComponentActive,
                                VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                VRC_EventHandler.VrcEventType.AnimationBool,
                                VRC_EventHandler.VrcEventType.AnimationFloat,
                                VRC_EventHandler.VrcEventType.AnimationInt,
                                VRC_EventHandler.VrcEventType.AnimationIntAdd,
                                VRC_EventHandler.VrcEventType.AnimationIntDivide,
                                VRC_EventHandler.VrcEventType.AnimationIntMultiply,
                                VRC_EventHandler.VrcEventType.AnimationIntSubtract,
                                VRC_EventHandler.VrcEventType.AnimationTrigger},
                            Vket4OfficialAssetData.GUIDs),

                new UseMeshColliderRule("[F-1]MeshCollider以外のColliderを使用すること"),
                
            };
        }
    }
}