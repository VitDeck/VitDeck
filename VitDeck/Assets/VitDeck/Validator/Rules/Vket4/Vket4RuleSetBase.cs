using UnityEngine;
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

                new BoothBoundsRule("[D-1,2]ブースサイズは規定の範囲内に収めること",
                    size: BoothSizeLimit,
                    margin: 0.01f),

                new AssetExtentionBlacklistRule("[B-4]メッシュアセットのファイル形式で特定のものが含まれていないこと",
                                                new string[]{".ma", ".mb", "max", "c4d", ".blend"}
                ),

                new C02_ExhibitStructureRule("[C-2]Static,Dynamicの2つのEmptyオブジェクトを作り、すべてのオブジェクトはこのどちらかの階層下に入れること"),

                new C02_StaticFlagRule("[C-2]Staticオブジェクト以下は特定のStatic設定を行うこと"),

                new D04_AssetTypeLimitRule(
                    string.Format("[D-4]Material使用数が{0}個以下であること", MaterialUsesLimit),
                    typeof(Material),
                    MaterialUsesLimit,
                    Vket4OfficialAssetData.MaterialGUIDs),

                new E05_GlobalIlluminationBakedRule("[E-5]StandardシェーダでEmissionを使用する場合、Global IlluminationはBakedを設定すること"),

                new UsableComponentListRule("[F-1]コンポーネントの使用可否",
                    GetComponentReferences(),
                    ignorePrefabGUIDs: Vket4OfficialAssetData.GUIDs,
                    unregisteredComponent: ValidationLevel.NEGOTIABLE),

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

                new VRCTriggerCountLimitRule(string.Format("[F-1]VRC_Triggerの使用数が{0}個以下であること", VRCTriggerCountLimit), VRCTriggerCountLimit),

                new LightCountLimitRule("[F-1]DirectionalLightを使用しないこと", UnityEngine.LightType.Directional, 0),

                new LightConfigRule("[F-1]PointLightの設定が制限に従っていること", UnityEngine.LightType.Point, ApprovedPointLightConfig),

                new LightConfigRule("[F-1]SpotLightの設定が制限に従っていること", UnityEngine.LightType.Spot, ApprovedSpotLightConfig),

                new LightConfigRule("[F-1]AreaLightの設定が制限に従っていること", UnityEngine.LightType.Area, ApprovedAreaLightConfig),

                new LightCountLimitRule(
                    string.Format("[F-1]AreaLightの使用数が{0}個以下であること", AreaLightUsesLimit),
                    UnityEngine.LightType.Area,
                    AreaLightUsesLimit),

                new UseLightModeRule("[F-1]DefaultCubeにてPointLightで許可されていないModeを使用しないこと", UnityEngine.LightType.Point, unusablePointLightModes),

                new UseLightModeRule("[F-1]DefaultCubeにてSpotLightで許可されていないModeを使用しないこと", UnityEngine.LightType.Spot, unusableSpotLightModes),

                new F02_PickupObjectSyncPrefabRule("PickupObjectSyncの設定が規定に従っていること", Vket4OfficialAssetData.PickupObjectSyncPrefabGUIDs),

                new F02_AvatarPedestalPrefabRule("AvatarPedestalの設定が規定に従っていること", Vket4OfficialAssetData.AvatarPedestalPrefabGUIDs),

                new F02_AudioSourcePrefabRule("AudioSourceの設定が規定に従っていること",  Vket4OfficialAssetData.AudioSourcePrefabGUIDs),

                new F02_PrefabLimitRule(
                    string.Format("[F-2]Chairの使用数は{0}個に収めること", ChairPrefabUsesLimit),
                    Vket4OfficialAssetData.ChairPrefabGUIDs,
                    ChairPrefabUsesLimit),

                new F02_PrefabLimitRule(
                    string.Format("[F-2]PickupObjectSyncの使用数は{0}個に収めること", PickupObjectSyncUsesLimit),
                    Vket4OfficialAssetData.PickupObjectSyncPrefabGUIDs,
                    PickupObjectSyncUsesLimit,
                    negotiable: true),

                new F02_VideoPlayerComponentRule("VideoPlayerを使用する際は制限に従うこと"),

            };
        }

        protected abstract Vector3 BoothSizeLimit { get; }

        protected abstract int VRCTriggerCountLimit { get; }

        protected abstract int MaterialUsesLimit { get; }

        private ComponentReference[] GetComponentReferences()
        {
            return new ComponentReference[] {
                new ComponentReference("VRC_Trigger", new string[]{"VRCSDK2.VRC_Trigger", "VRCSDK2.VRC_EventHandler"}, AdvancedObjectValidationLevel),
                new ComponentReference("VRC_Object Sync", new string[]{"VRCSDK2.VRC_ObjectSync"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Pickup", new string[]{"VRCSDK2.VRC_Pickup", "UnityEngine.Rigidbody"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Audio Bank", new string[]{"VRCSDK2.VRC_AudioBank"}, ValidationLevel.NEGOTIABLE),
                new ComponentReference("VRC_Avatar Pedestal", new string[]{"VRCSDK2.VRC_AvatarPedestal"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Ui Shape", new string[]{"VRCSDK2.VRC_UiShape"}, AdvancedObjectValidationLevel),
                new ComponentReference("Rigidbody", new string[]{"UnityEngine.Rigidbody"}, ValidationLevel.DISALLOW),
                new ComponentReference("Cloth", new string[]{"UnityEngine.Cloth"}, ValidationLevel.NEGOTIABLE),
                new ComponentReference("Collider", new string[]{"UnityEngine.SphereCollider", "UnityEngine.BoxCollider", "UnityEngine.SphereCollider", "UnityEngine.CapsuleCollider", "UnityEngine.MeshCollider", "UnityEngine.WheelCollider"}, ValidationLevel.ALLOW),
                new ComponentReference("Dynamic Bone", new string[]{"DynamicBone"}, ValidationLevel.ALLOW),
                new ComponentReference("Dynamic Bone Collider", new string[]{"DynamicBoneCollider"}, ValidationLevel.ALLOW),
                new ComponentReference("Skinned Mesh Renderer", new string[]{"UnityEngine.SkinnedMeshRenderer"}, ValidationLevel.ALLOW),
                new ComponentReference("Mesh Renderer ", new string[]{"UnityEngine.MeshRenderer"}, ValidationLevel.ALLOW),
                new ComponentReference("Mesh Filter", new string[]{"UnityEngine.MeshFilter"}, ValidationLevel.ALLOW),
                new ComponentReference("Particle System", new string[]{"UnityEngine.ParticleSystem", "UnityEngine.ParticleSystemRenderer"}, ValidationLevel.ALLOW),
                new ComponentReference("Trail Renderer", new string[]{"UnityEngine.TrailRenderer"}, ValidationLevel.ALLOW),
                new ComponentReference("Line Renderer", new string[]{"UnityEngine.LineRenderer"}, ValidationLevel.ALLOW),
                new ComponentReference("Light", new string[]{"UnityEngine.Light"}, AdvancedObjectValidationLevel),
                new ComponentReference("LightProbeGroup", new string[]{"UnityEngine.LightProbeGroup"}, AdvancedObjectValidationLevel),
                new ComponentReference("ReflectionProbe", new string[]{"UnityEngine.ReflectionProbe"}, AdvancedObjectValidationLevel),
                new ComponentReference("Animator", new string[]{"UnityEngine.Animator"}, ValidationLevel.ALLOW),
                new ComponentReference("Animation", new string[]{"UnityEngine.Animation"}, ValidationLevel.ALLOW),
                new ComponentReference("Audio Source", new string[]{"UnityEngine.AudioSource", "ONSPAudioSource", "VRCSDK2.VRC_SpatialAudioSource"}, ValidationLevel.DISALLOW),
                new ComponentReference("Canvas", new string[]{"UnityEngine.Canvas", "UnityEngine.CanvasGroup", "UnityEngine.RectTransform", "UnityEngine.UI.CanvasScaler", "UnityEngine.UI.GraphicRaycaster", "UnityEngine.UI.AspectRatioFitter", "UnityEngine.UI.LayoutElement", "UnityEngine.UI.ContentSizeFitter", "UnityEngine.UI.HorizontalLayoutGroup", "UnityEngine.UI.VerticalLayoutGroup", "UnityEngine.UI.GridLayoutGroup", "UnityEngine.UI.Text", "UnityEngine.UI.Image", "UnityEngine.UI.RawImage", "UnityEngine.UI.Mask", "UnityEngine.UI.RectMask2D", "UnityEngine.UI.Button", "UnityEngine.UI.InputField", "UnityEngine.UI.Toggle", "UnityEngine.UI.ToggleGroup", "UnityEngine.UI.Slider", "UnityEngine.UI.Scrollbar", "UnityEngine.UI.Dropdown", "UnityEngine.UI.ScrollRect", "UnityEngine.UI.Selectable", "UnityEngine.UI.Shadow", "UnityEngine.UI.Outline", "UnityEngine.UI.PositionAsUV1", "UnityEngine.RectTransform", "UnityEngine.CanvasRenderer"}, ValidationLevel.ALLOW),
                new ComponentReference("VRC_Station", new string[]{"VRCSDK2.VRC_Station"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Mirror", new string[]{ "VRCSDK2.VRC_MirrorCamera", "VRCSDK2.VRC_MirrorReflection" }, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_PlayerAudioOverride", new string[]{"VRCSDK2.VRC_PlayerAudioOverride"}, ValidationLevel.DISALLOW),
                new ComponentReference("EventSystem", new string[]{"UnityEngine.EventSystems.EventSystem", "UnityEngine.EventSystems.StandaloneInputModule"}, ValidationLevel.DISALLOW),
                new ComponentReference("StandaloneInputModule", new string[]{"UnityEngine.EventSystems.StandaloneInputModule"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_SceneResetPosition", new string[]{"VRCSDK2.VRC_SceneResetPosition"}, ValidationLevel.NEGOTIABLE),
                new ComponentReference("PlayableDirector", new string[]{"UnityEngine.Playables.PlayableDirector" }, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Panorama", new string[]{"VRCSDK2.scripts.Scenes.VRC_Panorama" }, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_SyncVideoPlayer", new string[]{"VRCSDK2.VRC_SyncVideoPlayer", "VRCSDK2.VRC_SyncVideoStream" }, ValidationLevel.DISALLOW),
            };
        }

        protected virtual ValidationLevel AdvancedObjectValidationLevel
        {
            get
            {
                return ValidationLevel.ALLOW;
            }
        }

        protected abstract LightConfigRule.LightConfig ApprovedPointLightConfig { get; }

        protected abstract LightConfigRule.LightConfig ApprovedSpotLightConfig { get; }

        protected abstract LightConfigRule.LightConfig ApprovedAreaLightConfig { get; }

        protected abstract LightmapBakeType[] unusablePointLightModes { get; }

        protected abstract LightmapBakeType[] unusableSpotLightModes { get; }

        protected abstract int AreaLightUsesLimit { get; }

        protected abstract int ChairPrefabUsesLimit { get; }

        protected abstract int PickupObjectSyncUsesLimit { get; }

    }
}
