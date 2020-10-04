using UnityEngine;
using VitDeck.Language;

#if VRC_SDK_VRCSDK3
using VRC.SDKBase;
#elif VRC_SDK_VRCSDK2
using VRCSDK2;
#endif

namespace VitDeck.Validator
{

    /// <summary>
    /// Vket5の基本ルールセット。
    /// </summary>
    /// <remarks>
    /// 変数をabstractまたはvirtualプロパティで宣言し、継承先で上書きすることでワールドによる制限の違いを表現する。
    /// </remarks>
    public abstract class Vket5RuleSetBase : IRuleSet
    {
        public abstract string RuleSetName
        {
            get;
        }

        protected readonly long MegaByte = 1048576;

        private readonly Vket5TargetFinder targetFinder = new Vket5TargetFinder();
        public IValidationTargetFinder TargetFinder => targetFinder;

        private readonly IObjectDetector officialPrefabsDetector;

        public Vket5RuleSetBase() : base()
        {
            officialPrefabsDetector = new PrefabPartsDetector(
                Vket5OfficialAssetData.AudioSourcePrefabGUIDs,
                Vket5OfficialAssetData.AvatarPedestalPrefabGUIDs,
                Vket5OfficialAssetData.ChairPrefabGUIDs,
                Vket5OfficialAssetData.PickupObjectSyncPrefabGUIDs,
                Vket5OfficialAssetData.CanvasPrefabGUIDs,
                Vket5OfficialAssetData.PointLightProbeGUIDs);
        }

        public IRule[] GetRules()
        {
            // デフォルトで使っていたAttribute式は宣言時にconst以外のメンバーが利用できない。
            // 継承したプロパティを参照して挙動を変えることが出来ない為、直接リストを返す方式に変更した。
            return new IRule[]
            {
#if VRC_SDK_VRCSDK2

                new UnityVersionRule(LocalizedMessage.Get("Vket5RuleSetBase.UnityVersionRule.Title", "2018.4.20f1"), "2018.4.20f1"),

                new A02_VRCSDKVersionRule(LocalizedMessage.Get("Vket5RuleSetBase.VRCSDKVersionRule.Title"),
                    new VRCSDKVersion("2020.05.06.12.14"),
                    "https://files.vrchat.cloud/sdk/VRCSDK2-2020.09.15.11.25_Public.unitypackage"),

                new A04_ExistInSubmitFolderRule(LocalizedMessage.Get("Vket5RuleSetBase.ExistInSubmitFolderRule.Title"), Vket5OfficialAssetData.GUIDs, targetFinder),

                new AssetGuidBlacklistRule(LocalizedMessage.Get("Vket5RuleSetBase.OfficialAssetDontContainRule.Title"), Vket5OfficialAssetData.GUIDs),

                new AssetNamingRule(LocalizedMessage.Get("Vket5RuleSetBase.NameOfFileAndFolderRule.Title"), @"[a-zA-Z0-9 _\.\-\(\)]+"),

                new AssetPathLengthRule(LocalizedMessage.Get("Vket5RuleSetBase.FilePathLengthLimitRule.Title", 184), 184),

                new AssetExtentionBlacklistRule(LocalizedMessage.Get("Vket5RuleSetBase.MeshFileTypeBlacklistRule.Title"),
                                                new string[]{".ma", ".mb", "max", "c4d", ".blend"}
                ),

                new ContainMatOrTexInAssetRule(LocalizedMessage.Get("Vket5RuleSetBase.ContainMatOrTexInAssetRule.Title")),

                new FolderSizeRule(LocalizedMessage.Get("Vket5RuleSetBase.FolderSizeRule.Title"), FolderSizeLimit),

                new C02_ExhibitStructureRule(LocalizedMessage.Get("Vket5RuleSetBase.ExhibitStructureRule.Title")),

                new C02_StaticFlagRule(LocalizedMessage.Get("Vket5RuleSetBase.StaticFlagsRule.Title")),

                new BoothBoundsRule(LocalizedMessage.Get("Vket5RuleSetBase.BoothBoundsRule.Title"),
                    size: BoothSizeLimit,
                    margin: 0.01f),

                new D04_AssetTypeLimitRule(
                    LocalizedMessage.Get("Vket5RuleSetBase.MaterialLimitRule.Title", MaterialUsesLimit),
                    typeof(Material),
                    MaterialUsesLimit,
                    Vket5OfficialAssetData.MaterialGUIDs),

                new D08_LightmapSizeLimitRule(
                    LocalizedMessage.Get("Vket5RuleSetBase.LightMapsLimitRule.Title", LightmapCountLimit, 512),
                    lightmapCountLimit: LightmapCountLimit,
                    lightmapResolutionLimit: 512),

                new E05_GlobalIlluminationBakedRule(LocalizedMessage.Get("Vket5RuleSetBase.GlobalIlluminationBakedRule.Title")),

                new UsableComponentListRule(LocalizedMessage.Get("Vket5RuleSetBase.UsableComponentListRule.Title"),
                    GetComponentReferences(),
                    ignorePrefabGUIDs: Vket5OfficialAssetData.GUIDs),

                new SkinnedMeshRendererRule(LocalizedMessage.Get("Vket5RuleSetBase.SkinnedMeshRendererRule.Title")),

                new MeshRendererRule(LocalizedMessage.Get("Vket5RuleSetBase.MeshRendererRule.Title")),

                new ReflectionProbeRule(LocalizedMessage.Get("Vket5RuleSetBase.ReflectionProbeRule.Title")),

                new VRCTriggerConfigRule(LocalizedMessage.Get("Vket5RuleSetBase.VRCTriggerConfigRule.Title"),
                            VRCTriggerBroadcastTypesWhitelist,
                            new VRC_Trigger.TriggerType[] {
                                VRC_Trigger.TriggerType.Custom,
                                VRC_Trigger.TriggerType.OnInteract,
                                VRC_Trigger.TriggerType.OnEnterTrigger,
                                VRC_Trigger.TriggerType.OnExitTrigger,
                                VRC_Trigger.TriggerType.OnPickup,
                                VRC_Trigger.TriggerType.OnDrop,
                                VRC_Trigger.TriggerType.OnPickupUseDown,
                                VRC_Trigger.TriggerType.OnPickupUseUp   },
                            VRCTriggerActionWhitelist,
                            Vket5OfficialAssetData.GUIDs),

                new UseMeshColliderRule(LocalizedMessage.Get("Vket5RuleSetBase.UseMeshColliderRule.Title")),

                new VRCTriggerCountLimitRule(LocalizedMessage.Get("Vket5RuleSetBase.VRCTriggerCountLimitRule.Title", VRCTriggerCountLimit), VRCTriggerCountLimit),

                new LightCountLimitRule(LocalizedMessage.Get("Vket5RuleSetBase.DirectionalLightLimitRule.Title"), UnityEngine.LightType.Directional, 0),

                new LightConfigRule(LocalizedMessage.Get("Vket5RuleSetBase.PointLightConfigRule.Title"), UnityEngine.LightType.Point, ApprovedPointLightConfig),

                new LightConfigRule(LocalizedMessage.Get("Vket5RuleSetBase.SpotLightConfigRule.Title"), UnityEngine.LightType.Spot, ApprovedSpotLightConfig),

                new LightConfigRule(LocalizedMessage.Get("Vket5RuleSetBase.AreaLightConfigRule.Title"), UnityEngine.LightType.Area, ApprovedAreaLightConfig),

                new LightCountLimitRule(
                    LocalizedMessage.Get("Vket5RuleSetBase.AreaLightLimitRule.Title", AreaLightUsesLimit),
                    UnityEngine.LightType.Area,
                    AreaLightUsesLimit),

                new UseLightModeRule(LocalizedMessage.Get("Vket5RuleSetBase.PointLightModeRule.Title"), UnityEngine.LightType.Point, unusablePointLightModes),

                new UseLightModeRule(LocalizedMessage.Get("Vket5RuleSetBase.SpotLightModeRule.Title"), UnityEngine.LightType.Spot, unusableSpotLightModes),

                new AnimationMakesMoveCollidersRule(LocalizedMessage.Get("Vket5RuleSetBase.AnimationMakesMoveCollidersRule.Title")),

                new F01_AnimationClipRule(LocalizedMessage.Get("Vket5RuleSetBase.F01_AnimationClipRule.Title")),

                new F01_AnimationComponentRule(LocalizedMessage.Get("Vket5RuleSetBase.F01_AnimationComponentRule.Title"), officialPrefabsDetector),

                new F01_AnimatorComponentRule(LocalizedMessage.Get("Vket5RuleSetBase.F01_AnimatorComponentRule.Title"),
                    new System.Type[]{
                        typeof(VRC_Pickup),
                        typeof(VRC_ObjectSync)
                    },officialPrefabsDetector),

                new F01_CanvasRenderModeRule(LocalizedMessage.Get("Vket5RuleSetBase.CanvasRenderModeRule.Title")),

                new F01_CameraComponentRule(LocalizedMessage.Get("Vket5RuleSetBase.F01_CameraComponentRule.Title"), maxRenderTextureSize: new Vector2(1024, 1024)),

                new F01_CameraComponentMaxCountRule(LocalizedMessage.Get("Vket5RuleSetBase.F01_CameraComponentMaxCountRule.Title"), limit: 1),

                new F01_ProjectorComponentRule(LocalizedMessage.Get("Vket5RuleSetBase.F01_ProjectorComponentRule.Title")),

                new F01_ProjectorComponentMaxCountRule(LocalizedMessage.Get("Vket5RuleSetBase.F01_ProjectorComponentMaxCountRule.Title"), limit: 1),

                new F02_PickupObjectSyncPrefabRule(LocalizedMessage.Get("Vket5RuleSetBase.PickupObjectSyncRule.Title"), Vket5OfficialAssetData.PickupObjectSyncPrefabGUIDs),

                new F02_AvatarPedestalPrefabRule(LocalizedMessage.Get("Vket5RuleSetBase.AvatarPedestalPrefabRule.Title"), Vket5OfficialAssetData.AvatarPedestalPrefabGUIDs),

                new F02_AudioSourcePrefabRule(LocalizedMessage.Get("Vket5RuleSetBase.AudioSourcePrefabRule.Title"),  Vket5OfficialAssetData.AudioSourcePrefabGUIDs),

                new F02_RigidbodyRule(LocalizedMessage.Get("Vket5RuleSetBase.F02_RigidbodyRule.Title")),

                new F02_PrefabLimitRule(
                    LocalizedMessage.Get("Vket5RuleSetBase.ChairPrefabLimitRule.Title", ChairPrefabUsesLimit),
                    Vket5OfficialAssetData.ChairPrefabGUIDs,
                    ChairPrefabUsesLimit),

                new F02_PrefabLimitRule(
                    LocalizedMessage.Get("Vket5RuleSetBase.UnusabePrefabRule.Title", ChairPrefabUsesLimit),
                    Vket5OfficialAssetData.VRCSDKPrefabGUIDs,
                    0),

                new F02_PrefabLimitRule(
                    LocalizedMessage.Get("Vket5RuleSetBase.PickupObjectSyncPrefabLimitRule.Title", PickupObjectSyncUsesLimit),
                    Vket5OfficialAssetData.PickupObjectSyncPrefabGUIDs,
                    PickupObjectSyncUsesLimit),

                new F02_VideoPlayerComponentRule(LocalizedMessage.Get("Vket5RuleSetBase.VideoPlayerComponentRule.Title")),

                new F02_VideoPlayerComponentMaxCountRule(LocalizedMessage.Get("Vket5RuleSetBase.F02_VideoPlayerComponentMaxCountRule.Title"), limit: 1),

                new F01_AnimatorComponentMaxCountRule(LocalizedMessage.Get("Vket5RuleSetBase.AnimatorComponentMaxCountRule.Title"), limit: 50)
#endif
            };
        }

        protected abstract long FolderSizeLimit { get; }

        protected abstract Vector3 BoothSizeLimit { get; }

#if VRC_SDK_VRCSDK2 || VRC_SDK_VRCSDK3 
        protected virtual VRC_EventHandler.VrcBroadcastType[] VRCTriggerBroadcastTypesWhitelist
        {
            get
            {
                return new VRC_EventHandler.VrcBroadcastType[]{
                    VRC_EventHandler.VrcBroadcastType.Local };
            }
        }

        protected virtual VRC_EventHandler.VrcEventType[] VRCTriggerActionWhitelist
        {
            get
            {
                return new VRC_EventHandler.VrcEventType[] {
                    VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
                    VRC_EventHandler.VrcEventType.AudioTrigger,
                    VRC_EventHandler.VrcEventType.PlayAnimation,
                    VRC_EventHandler.VrcEventType.SetParticlePlaying,
                    VRC_EventHandler.VrcEventType.SetComponentActive,
                    VRC_EventHandler.VrcEventType.SetGameObjectActive,
                    VRC_EventHandler.VrcEventType.AnimationBool,
                    VRC_EventHandler.VrcEventType.AnimationFloat,
                    VRC_EventHandler.VrcEventType.AnimationInt,
                    VRC_EventHandler.VrcEventType.AnimationIntAdd,
                    VRC_EventHandler.VrcEventType.AnimationIntDivide,
                    VRC_EventHandler.VrcEventType.AnimationIntMultiply,
                    VRC_EventHandler.VrcEventType.AnimationIntSubtract,
                    VRC_EventHandler.VrcEventType.AnimationTrigger};
            }
        }
#endif

        protected abstract int VRCTriggerCountLimit { get; }

        protected abstract int MaterialUsesLimit { get; }

        protected abstract int LightmapCountLimit { get; }

        private ComponentReference[] GetComponentReferences()
        {
            return new ComponentReference[] {
                new ComponentReference("VRC_Trigger", new string[]{"VRCSDK2.VRC_Trigger", "VRCSDK2.VRC_EventHandler"}, AdvancedObjectValidationLevel),
                new ComponentReference("VRC_Object Sync", new string[]{"VRCSDK2.VRC_ObjectSync"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Pickup", new string[]{"VRCSDK2.VRC_Pickup"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Audio Bank", new string[]{"VRCSDK2.VRC_AudioBank"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Avatar Pedestal", new string[]{"VRCSDK2.VRC_AvatarPedestal"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Ui Shape", new string[]{"VRCSDK2.VRC_UiShape"}, AdvancedObjectValidationLevel),
                new ComponentReference("Rigidbody", new string[]{"UnityEngine.Rigidbody"}, ValidationLevel.DISALLOW),
                new ComponentReference("Cloth", new string[]{"UnityEngine.Cloth"}, ValidationLevel.DISALLOW),
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
                new ComponentReference("Camera", new string[]{"UnityEngine.Camera"}, MoreAdvancedObjectValidationLevel),
                new ComponentReference("Projector", new string[]{"UnityEngine.Projector"}, MoreAdvancedObjectValidationLevel),
                new ComponentReference("LookatTarget", new string[]{"UnityStandardAssets.Cameras.LookatTarget" }, MoreAdvancedObjectValidationLevel),
                new ComponentReference("FollowTarget", new string[]{"UnityStandardAssets.Utility.FollowTarget" }, MoreAdvancedObjectValidationLevel),
                new ComponentReference("Suspension", new string[]{"UnityStandardAssets.Vehicles.Car.Suspension" }, MoreAdvancedObjectValidationLevel),
                new ComponentReference("Animator", new string[]{"UnityEngine.Animator"}, ValidationLevel.ALLOW),
                new ComponentReference("Animation", new string[]{"UnityEngine.Animation"}, ValidationLevel.ALLOW),
                new ComponentReference("Audio Source", new string[]{"UnityEngine.AudioSource", "ONSPAudioSource", "VRCSDK2.VRC_SpatialAudioSource"}, ValidationLevel.DISALLOW),
                new ComponentReference("Canvas", new string[]{"UnityEngine.Canvas", "UnityEngine.CanvasGroup", "UnityEngine.RectTransform", "UnityEngine.UI.CanvasScaler", "UnityEngine.UI.GraphicRaycaster", "UnityEngine.UI.AspectRatioFitter", "UnityEngine.UI.LayoutElement", "UnityEngine.UI.ContentSizeFitter", "UnityEngine.UI.HorizontalLayoutGroup", "UnityEngine.UI.VerticalLayoutGroup", "UnityEngine.UI.GridLayoutGroup", "UnityEngine.UI.Text", "UnityEngine.UI.Image", "UnityEngine.UI.RawImage", "UnityEngine.UI.Mask", "UnityEngine.UI.RectMask2D", "UnityEngine.UI.Button", "UnityEngine.UI.InputField", "UnityEngine.UI.Toggle", "UnityEngine.UI.ToggleGroup", "UnityEngine.UI.Slider", "UnityEngine.UI.Scrollbar", "UnityEngine.UI.Dropdown", "UnityEngine.UI.ScrollRect", "UnityEngine.UI.Selectable", "UnityEngine.UI.Shadow", "UnityEngine.UI.Outline", "UnityEngine.UI.PositionAsUV1", "UnityEngine.RectTransform", "UnityEngine.CanvasRenderer"}, ValidationLevel.ALLOW),
                new ComponentReference("VideoPlayer", new string[]{"UnityEngine.Video.VideoPlayer" }, MoreAdvancedObjectValidationLevel),
                new ComponentReference("VRC_Station", new string[]{"VRCSDK2.VRC_Station"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Mirror", new string[]{ "VRCSDK2.VRC_MirrorCamera", "VRCSDK2.VRC_MirrorReflection" }, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_PlayerAudioOverride", new string[]{"VRCSDK2.VRC_PlayerAudioOverride"}, ValidationLevel.DISALLOW),
                new ComponentReference("EventSystem", new string[]{"UnityEngine.EventSystems.EventSystem", "UnityEngine.EventSystems.StandaloneInputModule"}, ValidationLevel.DISALLOW),
                new ComponentReference("StandaloneInputModule", new string[]{"UnityEngine.EventSystems.StandaloneInputModule"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_SceneResetPosition", new string[]{"VRCSDK2.VRC_SceneResetPosition"}, ValidationLevel.DISALLOW),
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

        protected virtual ValidationLevel MoreAdvancedObjectValidationLevel
        {
            get
            {
                return ValidationLevel.DISALLOW;
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
