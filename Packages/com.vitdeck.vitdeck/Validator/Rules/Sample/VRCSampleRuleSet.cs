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
    /// VRChat向けの基本ルールセット
    /// </summary>
    /// <remarks>
    /// Vket5で利用されたルールセットをベースとしています。
    /// </remarks>
    public class VRCSampleRuleSet : IRuleSet
    {
        public string RuleSetName => "VRCサンプルルールセット";

        protected readonly long MegaByte = 1048576;

        private readonly VRCSampleTargetFinder targetFinder = new VRCSampleTargetFinder();
        public IValidationTargetFinder TargetFinder => targetFinder;

        private readonly IObjectDetector officialPrefabsDetector;

        public VRCSampleRuleSet() : base()
        {
            officialPrefabsDetector = new PrefabPartsDetector(
                VRCSampleOfficialAssetData.AudioSourcePrefabGUIDs,
                VRCSampleOfficialAssetData.AvatarPedestalPrefabGUIDs,
                VRCSampleOfficialAssetData.ChairPrefabGUIDs,
                VRCSampleOfficialAssetData.PickupObjectSyncPrefabGUIDs,
                VRCSampleOfficialAssetData.CanvasPrefabGUIDs,
                VRCSampleOfficialAssetData.PointLightProbeGUIDs);
        }

        public IRule[] GetRules()
        {
            // デフォルトで使っていたAttribute式は宣言時にconst以外のメンバーが利用できない。
            // 継承したプロパティを参照して挙動を変えることが出来ない為、直接リストを返す方式に変更した。
            return new IRule[]
            {
#if VRC_SDK_VRCSDK2

                new UnityVersionRule(LocalizedMessage.Get("VketRuleSetBase.UnityVersionRule.Title", "2018.4.20f1"), "2018.4.20f1"),

                new VRCSDKVersionRule(LocalizedMessage.Get("VketRuleSetBase.VRCSDKVersionRule.Title"),
                    new VRCSDKVersion("2020.05.06.12.14"),
                    "https://files.vrchat.cloud/sdk/VRCSDK2-2020.09.15.11.25_Public.unitypackage"),

                new ExistInSubmitFolderRule(LocalizedMessage.Get("VketRuleSetBase.ExistInSubmitFolderRule.Title"), VRCSampleOfficialAssetData.GUIDs, targetFinder),

                new AssetGuidBlacklistRule(LocalizedMessage.Get("VketRuleSetBase.OfficialAssetDontContainRule.Title"), VRCSampleOfficialAssetData.GUIDs),

                new AssetNamingRule(LocalizedMessage.Get("VketRuleSetBase.NameOfFileAndFolderRule.Title"), @"[a-zA-Z0-9 _\.\-\(\)]+"),

                new AssetPathLengthRule(LocalizedMessage.Get("VketRuleSetBase.FilePathLengthLimitRule.Title", 184), 184),

                new AssetExtentionBlacklistRule(LocalizedMessage.Get("VketRuleSetBase.MeshFileTypeBlacklistRule.Title"),
                                                new string[]{".ma", ".mb", "max", "c4d", ".blend"}
                ),

                new ContainMatOrTexInAssetRule(LocalizedMessage.Get("VketRuleSetBase.ContainMatOrTexInAssetRule.Title")),

                new FolderSizeRule(LocalizedMessage.Get("VketRuleSetBase.FolderSizeRule.Title"), FolderSizeLimit),

                new ExhibitStructureRule(LocalizedMessage.Get("VketRuleSetBase.ExhibitStructureRule.Title")),

                new StaticFlagRule(LocalizedMessage.Get("VketRuleSetBase.StaticFlagsRule.Title")),

                new BoothBoundsRule(LocalizedMessage.Get("VketRuleSetBase.BoothBoundsRule.Title"),
                    size: BoothSizeLimit,
                    margin: 0.01f),

                new AssetTypeLimitRule(
                    LocalizedMessage.Get("VketRuleSetBase.MaterialLimitRule.Title", MaterialUsesLimit),
                    typeof(Material),
                    MaterialUsesLimit,
                    VRCSampleOfficialAssetData.MaterialGUIDs),

                new LightmapSizeLimitRule(
                    LocalizedMessage.Get("VketRuleSetBase.LightMapsLimitRule.Title", LightmapCountLimit, 512),
                    lightmapCountLimit: LightmapCountLimit,
                    lightmapResolutionLimit: 512),

                new GlobalIlluminationBakedRule(LocalizedMessage.Get("VketRuleSetBase.GlobalIlluminationBakedRule.Title")),

                new UsableComponentListRule(LocalizedMessage.Get("VketRuleSetBase.UsableComponentListRule.Title"),
                    GetComponentReferences(),
                    ignorePrefabGUIDs: VRCSampleOfficialAssetData.GUIDs),

                new SkinnedMeshRendererRule(LocalizedMessage.Get("VketRuleSetBase.SkinnedMeshRendererRule.Title")),

                new MeshRendererRule(LocalizedMessage.Get("VketRuleSetBase.MeshRendererRule.Title")),

                new ReflectionProbeRule(LocalizedMessage.Get("VketRuleSetBase.ReflectionProbeRule.Title")),

                new VRCTriggerConfigRule(LocalizedMessage.Get("VketRuleSetBase.VRCTriggerConfigRule.Title"),
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
                            VRCSampleOfficialAssetData.GUIDs),

                new UseMeshColliderRule(LocalizedMessage.Get("VketRuleSetBase.UseMeshColliderRule.Title")),

                new VRCTriggerCountLimitRule(LocalizedMessage.Get("VketRuleSetBase.VRCTriggerCountLimitRule.Title", VRCTriggerCountLimit), VRCTriggerCountLimit),

                new LightCountLimitRule(LocalizedMessage.Get("VketRuleSetBase.DirectionalLightLimitRule.Title"), UnityEngine.LightType.Directional, 0),

                new LightConfigRule(LocalizedMessage.Get("VketRuleSetBase.PointLightConfigRule.Title"), UnityEngine.LightType.Point, ApprovedPointLightConfig),

                new LightConfigRule(LocalizedMessage.Get("VketRuleSetBase.SpotLightConfigRule.Title"), UnityEngine.LightType.Spot, ApprovedSpotLightConfig),

                new LightConfigRule(LocalizedMessage.Get("VketRuleSetBase.AreaLightConfigRule.Title"), UnityEngine.LightType.Area, ApprovedAreaLightConfig),

                new LightCountLimitRule(
                    LocalizedMessage.Get("VketRuleSetBase.AreaLightLimitRule.Title", AreaLightUsesLimit),
                    UnityEngine.LightType.Area,
                    AreaLightUsesLimit),

                new UseLightModeRule(LocalizedMessage.Get("VketRuleSetBase.PointLightModeRule.Title"), UnityEngine.LightType.Point, unusablePointLightModes),

                new UseLightModeRule(LocalizedMessage.Get("VketRuleSetBase.SpotLightModeRule.Title"), UnityEngine.LightType.Spot, unusableSpotLightModes),

                new AnimationMakesMoveCollidersRule(LocalizedMessage.Get("VketRuleSetBase.AnimationMakesMoveCollidersRule.Title")),

                new AnimationClipRule(LocalizedMessage.Get("VketRuleSetBase.AnimationClipRule.Title")),

                new AnimationComponentRule(LocalizedMessage.Get("VketRuleSetBase.AnimationComponentRule.Title"), officialPrefabsDetector),

                new AnimatorComponentRule(LocalizedMessage.Get("VketRuleSetBase.AnimatorComponentRule.Title"),
                    new System.Type[]{
                        typeof(VRC_Pickup),
                        typeof(VRC_ObjectSync)
                    },officialPrefabsDetector),

                new CanvasRenderModeRule(LocalizedMessage.Get("VketRuleSetBase.CanvasRenderModeRule.Title")),

                new CameraComponentRule(LocalizedMessage.Get("VketRuleSetBase.CameraComponentRule.Title"), maxRenderTextureSize: new Vector2(1024, 1024)),

                new CameraComponentMaxCountRule(LocalizedMessage.Get("VketRuleSetBase.CameraComponentMaxCountRule.Title"), limit: 1),

                new ProjectorComponentRule(LocalizedMessage.Get("VketRuleSetBase.ProjectorComponentRule.Title")),

                new ProjectorComponentMaxCountRule(LocalizedMessage.Get("VketRuleSetBase.ProjectorComponentMaxCountRule.Title"), limit: 1),

                new PickupObjectSyncPrefabRule(LocalizedMessage.Get("VketRuleSetBase.PickupObjectSyncRule.Title"), VRCSampleOfficialAssetData.PickupObjectSyncPrefabGUIDs),

                new AvatarPedestalPrefabRule(LocalizedMessage.Get("VketRuleSetBase.AvatarPedestalPrefabRule.Title"), VRCSampleOfficialAssetData.AvatarPedestalPrefabGUIDs),

                new AudioSourcePrefabRule(LocalizedMessage.Get("VketRuleSetBase.AudioSourcePrefabRule.Title"),  VRCSampleOfficialAssetData.AudioSourcePrefabGUIDs),

                new RigidbodyRule(LocalizedMessage.Get("VketRuleSetBase.RigidbodyRule.Title")),

                new PrefabLimitRule(
                    LocalizedMessage.Get("VketRuleSetBase.ChairPrefabLimitRule.Title", ChairPrefabUsesLimit),
                    VRCSampleOfficialAssetData.ChairPrefabGUIDs,
                    ChairPrefabUsesLimit),

                new PrefabLimitRule(
                    LocalizedMessage.Get("VketRuleSetBase.UnusabePrefabRule.Title", ChairPrefabUsesLimit),
                    VRCSampleOfficialAssetData.VRCSDKPrefabGUIDs,
                    0),

                new PrefabLimitRule(
                    LocalizedMessage.Get("VketRuleSetBase.PickupObjectSyncPrefabLimitRule.Title", PickupObjectSyncUsesLimit),
                    VRCSampleOfficialAssetData.PickupObjectSyncPrefabGUIDs,
                    PickupObjectSyncUsesLimit),

                new VideoPlayerComponentRule(LocalizedMessage.Get("VketRuleSetBase.VideoPlayerComponentRule.Title")),

                new VideoPlayerComponentMaxCountRule(LocalizedMessage.Get("VketRuleSetBase.VideoPlayerComponentMaxCountRule.Title"), limit: 1),

                new AnimatorComponentMaxCountRule(LocalizedMessage.Get("VketRuleSetBase.AnimatorComponentMaxCountRule.Title"), limit: 50)
#endif
            };
        }

        private long FolderSizeLimit => 50 * MegaByte;

        private Vector3 BoothSizeLimit => new Vector3(4, 5, 4);

#if VRC_SDK_VRCSDK2 || VRC_SDK_VRCSDK3 
        private VRC_EventHandler.VrcBroadcastType[] VRCTriggerBroadcastTypesWhitelist
        {
            get
            {
                return new VRC_EventHandler.VrcBroadcastType[]{
                    VRC_EventHandler.VrcBroadcastType.Local };
            }
        }

        private VRC_EventHandler.VrcEventType[] VRCTriggerActionWhitelist
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

        private int VRCTriggerCountLimit => 25;

        private int MaterialUsesLimit => 20;

        private int LightmapCountLimit => 1;

        private ComponentReference[] GetComponentReferences()
        {
            return new ComponentReference[] {
                new ComponentReference("VRC_Trigger", new string[]{"VRCSDK2.VRC_Trigger", "VRCSDK2.VRC_EventHandler"}, AdvancedObjectValidationLevel),
                new ComponentReference("VRC_Object Sync", new string[]{"VRCSDK2.VRC_ObjectSync"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Pickup", new string[]{"VRCSDK2.VRC_Pickup"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Audio Bank", new string[]{"VRCSDK2.VRC_AudioBank"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Avatar Pedestal", new string[]{"VRCSDK2.VRC_AvatarPedestal"}, ValidationLevel.DISALLOW),
                new ComponentReference("VRC_Ui Shape", new string[]{"VRCSDK2.VRC_UiShape"}, AdvancedObjectValidationLevel),
                new ComponentReference("Rigidbody", new string[]{"UnityEngine.Rigidbody"}, ValidationLevel.ALLOW),
                new ComponentReference("Cloth", new string[]{"UnityEngine.Cloth"}, MoreAdvancedObjectValidationLevel),
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

        private ValidationLevel AdvancedObjectValidationLevel
        {
            get
            {
                return ValidationLevel.ALLOW;
            }
        }

        private ValidationLevel MoreAdvancedObjectValidationLevel
        {
            get
            {
                return ValidationLevel.DISALLOW;
            }
        }

        private LightConfigRule.LightConfig ApprovedPointLightConfig 
        { 
            get
            {
            return new LightConfigRule.LightConfig(
                new[] { LightmapBakeType.Baked, LightmapBakeType.Realtime },
                new[] { LightShadows.Hard, LightShadows.Soft },
                0, 7,
                0, 10,
                0, 15);
            }
        }

        private LightConfigRule.LightConfig ApprovedSpotLightConfig 
        {
            get
            {
                return new LightConfigRule.LightConfig(
                    new[] { LightmapBakeType.Baked, LightmapBakeType.Realtime },
                    new[] { LightShadows.Hard, LightShadows.Soft },
                    0, 7,
                    0, 10,
                    0, 15);
            }
        }

        private LightConfigRule.LightConfig ApprovedAreaLightConfig 
        {
            get
            {
                return new LightConfigRule.LightConfig(
                    new[] { LightmapBakeType.Baked },
                    null,
                    0, 30,
                    0, 10,
                    0, 15);
            }
        }

        private LightmapBakeType[] unusablePointLightModes
        {
            get
            {
                return new LightmapBakeType[] { };
            }
        }

        private LightmapBakeType[] unusableSpotLightModes 
        {
            get
            {
                return new LightmapBakeType[] { };
            }
        }

        private int AreaLightUsesLimit 
        {
            get
            {
                return 3;
            }
        }

        private int ChairPrefabUsesLimit 
        {
            get
            {
                return 1;
            }
        }

        private int PickupObjectSyncUsesLimit 
        {
            get
            {
                return 5;
            }
        }

    }
}
