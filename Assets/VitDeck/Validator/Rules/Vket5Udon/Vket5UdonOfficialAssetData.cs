using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public static class Vket5UdonOfficialAssetData
    {
        /// <summary>
        /// 公式配布されたアセット及び前提となるアセットのGUID
        /// <list type="bullet">
        /// <item>DynamicBone</item>
        /// <item>Standard Assets</item>
        /// <item>VRCSDK</item>
        /// <item>Udon</item>
        /// <item>VitDeck</item>
        /// <item>VketAssets</item>
        /// <item>AvatarShowcase Sample</item>
        /// </list>
        /// </summary>
        public static string[] GUIDs = new string[]
        {
            // DynamicBone
            "bdbe6feeda2a62b45ad9a4e311031478",  // Assets/DynamicBone/ReadMe.txt
            "ba128457d0ea5e3439dbe4a53b9d1273",  // Assets/DynamicBone/Demo/c1.fbx
            "902c84bf971339c459ce4b757e333a55",  // Assets/DynamicBone/Demo/Demo1.unity
            "178320cedf292cb4f8d6c0b737b35953",  // Assets/DynamicBone/Demo/DynamicBoneDemo1.cs
            "19015a5957bbaa745a61cba005220542",  // Assets/DynamicBone/Demo/tail.FBX
            "f9ac8d30c6a0d9642a11e5be4c440740",  // Assets/DynamicBone/Scripts/DynamicBone.cs
            "baedd976e12657241bf7ff2d1c685342",  // Assets/DynamicBone/Scripts/DynamicBoneCollider.cs
            "04878769c08021a41bc2d2375e23ec0b",  // Assets/DynamicBone/Scripts/DynamicBoneColliderBase.cs
            "4e535bdf3689369408cc4d078260ef6a",  // Assets/DynamicBone/Scripts/DynamicBonePlaneCollider.cs

            // Standard Assets
            

            // VRCSDK
            "2cdbe2e71e2c46e48951c13df254e5b1",  // Assets/VRCSDK/version.txt
            "820ee6e459999be418b410c7af108bc3",  // Assets/VRCSDK/Dependencies/AWSSDK/AWSSDK.CognitoIdentity.dll
            "17e2ad8740ce0ab4eb1a95a73e362865",  // Assets/VRCSDK/Dependencies/AWSSDK/AWSSDK.CognitoIdentity.dll.mdb
            "aecaffc7454b52e448fc0ea1aef2dd1d",  // Assets/VRCSDK/Dependencies/AWSSDK/AWSSDK.Core.dll
            "027e8b8acf565544d9050219e1521b7e",  // Assets/VRCSDK/Dependencies/AWSSDK/AWSSDK.Core.dll.mdb
            "d4055bfc0cd67d642a7eceaf547c4901",  // Assets/VRCSDK/Dependencies/AWSSDK/AWSSDK.S3.dll
            "0da239ac72288814a9c4b799c7674b25",  // Assets/VRCSDK/Dependencies/AWSSDK/AWSSDK.S3.dll.mdb
            "625a50dd0dd525a49a41cb3e3117fa15",  // Assets/VRCSDK/Dependencies/AWSSDK/AWSSDK.SecurityToken.dll
            "b93a9778ddf074845b1649181fda7e86",  // Assets/VRCSDK/Dependencies/AWSSDK/AWSSDK.SecurityToken.dll.mdb
            "34b0990e1522a284b9666d6821cd601c",  // Assets/VRCSDK/Dependencies/DotZLib/DotZLib.dll
            "b609c54f9d3581e4fa22b3e389fd8d33",  // Assets/VRCSDK/Dependencies/DotZLib/Plugins/x86/zlibwapi.dll
            "54f59547b5261e64f8256d6daaa01b17",  // Assets/VRCSDK/Dependencies/DotZLib/Plugins/x86_64/zlibwapi.dll
            "a2e4b2ce02fa7914895069e5fdbf112d",  // Assets/VRCSDK/Dependencies/librsync/Blake2Sharp.dll
            "912b2ac597cb1ad4c9bdc1a98ec15459",  // Assets/VRCSDK/Dependencies/librsync/librsync.net.dll
            "cb850b86de9091d4db4595959c56f954",  // Assets/VRCSDK/Dependencies/Oculus/Spatializer/Editor/ONSPAudioSourceEditor.cs
            "e503ea6418d27594caa33b93cac1b06a",  // Assets/VRCSDK/Dependencies/Oculus/Spatializer/Scripts/ONSPAudioSource.cs
            "ad074644ff568a14187a3690cfbd7534",  // Assets/VRCSDK/Dependencies/Oculus/Spatializer/Scripts/ONSPSettings.cs
            "5a8cc42eaba7a2a41b6ca3be3c40b315",  // Assets/VRCSDK/Dependencies/SharpZipLib/ICSharpCode.SharpZipLib.dll
            "d471b09e7f06a69458457ec63d3532b8",  // Assets/VRCSDK/Dependencies/VRChat/Settings.asset
            "10d9f721d76e07a47bc9e5f61e2fae72",  // Assets/VRCSDK/Dependencies/VRChat/Editor/EnvConfig.cs
            "c3399613f583f3e46b2df27ae87dd5d6",  // Assets/VRCSDK/Dependencies/VRChat/Editor/HDRColorFixerUtility.cs
            "7b8bb626428d0f341b9ed6a68cb5c9cc",  // Assets/VRCSDK/Dependencies/VRChat/Editor/SDKUpdater.cs
            "679ba0056bf110c4db8b550082e73a5f",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ShaderKeywordsUtility.cs
            "4a9696f3dea8a764f9c4bc6d2e652b74",  // Assets/VRCSDK/Dependencies/VRChat/Editor/VRCCachedWWW.cs
            "cb5d1f9882b08564cae97b2b14ad4e8f",  // Assets/VRCSDK/Dependencies/VRChat/Editor/VRC_EditorTools.cs
            "f4cf5dd705ab67149afaba40b4a8fa7e",  // Assets/VRCSDK/Dependencies/VRChat/Editor/VRC_SdkSplashScreen.cs
            "3d6a1d7b0624f414ba6fb922687a06da",  // Assets/VRCSDK/Dependencies/VRChat/Editor/AWS/S3Manager.cs
            "21332e1f0d937794d916d2402ba1943a",  // Assets/VRCSDK/Dependencies/VRChat/Editor/BuildPipeline/VRC.SDKBase.Editor.BuildPipeline.asmdef
            "0a1d20f4241085e46bdddc71b691465b",  // Assets/VRCSDK/Dependencies/VRChat/Editor/BuildPipeline/Samples/VRCSDKBuildRequestedCallbackSample.cs
            "39cdf3092ab81be4b9e623cb5a8819d8",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/ApiCacheEditor.cs
            "0a364ece829b6234888c59987a305a00",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/AutoAddSpatialAudioComponents.cs
            "89005ebc9543e0a4284893c09ca19b1d",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/EditorCoroutine.cs
            "3d6c2e367eaa9564ebf6267ec163cfbd",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/EditorHandling.cs
            "4810e652e8242384c834320970702290",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/EventHandlerEditor.cs
            "482185bf29f12074dada194ffef6a682",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/OldTriggerEditors.cs
            "5e83254bb97e84795ac882692ae124ba",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRCAvatarDescriptorEditor.cs
            "26a75599848adb449b7aceed5090e35c",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRCObjectSpawnEditor.cs
            "ed4aad2698d3b62408e69b57c7748791",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRCObjectSyncEditor.cs
            "8986a640e24a0754ea0aded12234b808",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRCPlayerModEditorWindow.cs
            "792e7964a56e51f4188e1221751642e9",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRCPlayerModsEditor.cs
            "5262a02c32e41e047bdfdfc3b63db8ff",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRCPlayerStationEditor.cs
            "e9cbc493bbbc443fb92898aa84d221ec",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRCSceneDescriptorEditor.cs
            "eeda995d0ceac6443a54716996eab52e",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_AvatarVariationsEditor.cs
            "0ac7998a36f085844847acbc046d4e27",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_DataStorageEditor.cs
            "3b63b118c0591b548ba1797e6be4292e",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_DestructibleStandardEditor.cs
            "e19a7147a2386554a8e4d6e414f190a2",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_ObjectSyncEditor.cs
            "4aff4e5c0d600c845b29d7b8b7965d68",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_PickupEditor.cs
            "5c545625e0bf93045ac1c5864141c5c1",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_PlayerAudioOverrideEditor.cs
            "0d2d4cba733f5eb4ba170368e67710d2",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_SpatialAudioSourceEditor.cs
            "ae0e74693b7899f47bd98864f94b9311",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_SyncVideoPlayerEditor.cs
            "3f9dccfed0b072f49a307b3f20a7e768",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_SyncVideoStreamEditor.cs
            "3aecd666943878944a811acb9db2ace7",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_TriggerEditor.cs
            "d09b36020f697be4d9a0f5a6a48cfa83",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_WebPanelEditor.cs
            "764e26c1ca28e2e45a30c778c1955a47",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components/VRC_YouTubeSyncEditor.cs
            "d57b23c04034119448f23c5fdbc57662",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components3/VRCDestructibleUdonEditor.cs
            "8901d07a685ca424492a3cabff506184",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components3/VRCPlayerStationEditor3.cs
            "4b2b9ac625bc5b04c887ff9ee9b5fdbe",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components3/VRCSceneDescriptorEditor3.cs
            "a8cc4c1876b26174fbaeb062178a6bda",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components3/VRC_PickupEditor3.cs
            "3f8f999a8e1ebee4588f94a8a618d7c6",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Components3/VRC_SpatialAudioSourceEditor3.cs
            "310a760e312f2984e85eece367bab19a",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ControlPanel/IVRCSdkControlPanelBuilder.cs
            "20b4cdbdda9655947aab6f8f2c90690f",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanel.cs
            "5066cd5c1cc208143a1253cac821714a",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanelAccount.cs
            "4c73e735ee0380241b186a8993fa56bf",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanelBuilder.cs
            "c768b42ca9a2f2b48afeb1fa03d5e1bf",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanelBuilderAttribute.cs
            "c7333cdb3df19724b84b4a1b05093fe0",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanelContent.cs
            "f3507a74e4b8cfd469afac127fa5f4e5",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanelHelp.cs
            "8357b9b7ef2416946ae86f465a64c0e0",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanelSettings.cs
            "f2a720a30f1043247af7742fdfd0b8e5",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanelWorldBuilder.cs
            "93710d221addc0243ba90dd20369844b",  // Assets/VRCSDK/Dependencies/VRChat/Editor/SDK3Compatibility/VRCSdk3Analysis.cs
            "c18570190ea21fa4babc80af77d4d766",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ShaderStripping/StripPostProcessing.cs
            "b1e8486f7c7c81a4ea45be9776971082",  // Assets/VRCSDK/Dependencies/VRChat/Editor/ShaderStripping/VRC.SDKBase.Editor.ShaderStripping.asmdef
            "62d40cc4e8f8494695f0102c58b3ea60",  // Assets/VRCSDK/Dependencies/VRChat/Editor/Validation/Performance/SDKPerformanceDisplay.cs
            "da07ab9b78cb0432e95e11e2cb619ea7",  // Assets/VRCSDK/Dependencies/VRChat/Materials/BlueprintCam.mat
            "94b649c2bd1ac4cac95049605dc5333d",  // Assets/VRCSDK/Dependencies/VRChat/Materials/BlueprintCam.renderTexture
            "2166f6bbfce69594fad494087eca58e8",  // Assets/VRCSDK/Dependencies/VRChat/Materials/damageGrey.mat
            "e13e96301b7c8214dac6883be5b82bfa",  // Assets/VRCSDK/Dependencies/VRChat/Models/damageSphere.fbx
            "841c3ce718e8b61408005c1cfce6b7de",  // Assets/VRCSDK/Dependencies/VRChat/Models/Materials/lambert2.mat
            "4acdf7b3eb426480bb5acf58638bd493",  // Assets/VRCSDK/Dependencies/VRChat/Resources/awsconfig.xml
            "dd5614b710e774040ab715161f7dfaca",  // Assets/VRCSDK/Dependencies/VRChat/Resources/endpoints.customizations.json
            "37b4abef7420c4c7ea71dbe76757498a",  // Assets/VRCSDK/Dependencies/VRChat/Resources/endpoints.json
            "be98467dc5d3c4eb1aeef22952913b0e",  // Assets/VRCSDK/Dependencies/VRChat/Resources/VRCCam.prefab
            "dce0dda226bd1f147a34f9b4660f5992",  // Assets/VRCSDK/Dependencies/VRChat/Resources/VRCProjectSettings.prefab
            "b14e1b78a061f8543b2f4120b5c369fa",  // Assets/VRCSDK/Dependencies/VRChat/Resources/VRCSDKAvatar.prefab
            "248f850c58993ed43bcaad6b934b7c92",  // Assets/VRCSDK/Dependencies/VRChat/Resources/vrcSdkBottomHeader.png
            "551946bfd2b165f419f297805d1e1256",  // Assets/VRCSDK/Dependencies/VRChat/Resources/vrcSdkBottomHeader_Oculus_Quest.png
            "d2244637721b4f3458280ffc1f9dd7cc",  // Assets/VRCSDK/Dependencies/VRChat/Resources/vrcSdkClDialogNewIcon.png
            "38956f4b67ba0984587b1a913d05beea",  // Assets/VRCSDK/Dependencies/VRChat/Resources/vrcSdkHeader.png
            "ff7f4f4963793a340bde459bc9975c07",  // Assets/VRCSDK/Dependencies/VRChat/Resources/vrcSdkHeaderWithCommunityLabs.png
            "1d151b29d1d1c704daa27e4921e39129",  // Assets/VRCSDK/Dependencies/VRChat/Resources/vrcSdkSplashUdon1.png
            "8458230047d35d4498b2de453f2cabda",  // Assets/VRCSDK/Dependencies/VRChat/Resources/vrcSdkSplashUdon2.png
            "fc887d4eeb5a941ed86bca0135b05e2b",  // Assets/VRCSDK/Dependencies/VRChat/Resources/VRCSDKWorld.prefab
            "e8e780ff40c6a484294bfec8711ced23",  // Assets/VRCSDK/Dependencies/VRChat/Resources/VRC_PlayerVisualDamage.prefab
            "43066d8a73c579048891e3c123e252a0",  // Assets/VRCSDK/Dependencies/VRChat/Resources/2FAIcons/SDK_Warning_Triangle_icon.png
            "f310c3dbad3125d4e8fc2e00bdc2acb4",  // Assets/VRCSDK/Dependencies/VRChat/Resources/CL_Icons/CL_Lab_Icon_256.png
            "36349feed06587e479724a1a09c0b267",  // Assets/VRCSDK/Dependencies/VRChat/Resources/CL_Icons/Icon_New.png
            "4109d4977ddfb6548b458318e220ac70",  // Assets/VRCSDK/Dependencies/VRChat/Resources/PerformanceIcons/Perf_Good_32.png
            "644caf5607820c7418cf0d248b12f33b",  // Assets/VRCSDK/Dependencies/VRChat/Resources/PerformanceIcons/Perf_Great_32.png
            "2886eb1248200a94d9eaec82336fbbad",  // Assets/VRCSDK/Dependencies/VRChat/Resources/PerformanceIcons/Perf_Horrible_32.png
            "9296abd40c7c1934cb668aae07b41c69",  // Assets/VRCSDK/Dependencies/VRChat/Resources/PerformanceIcons/Perf_Medium_32.png
            "e561d0406779ab948b7f155498d101ee",  // Assets/VRCSDK/Dependencies/VRChat/Resources/PerformanceIcons/Perf_Poor_32.png
            "8ae6e7ea5b8982143aa8c2c4e2fe81c6",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/AnimatorPerformanceScanner.asset
            "c2ca835e9f95b464b8a2df5c181ba44e",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/AudioPerformanceScanner.asset
            "d162a2d08d890e644b79b605f1d1120e",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/ClothPerformanceScanner.asset
            "371dfb95b91b4684eb1ad68d37d81ac9",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/DynamicBonePerformanceScanner.asset
            "69c7115984bf82e46af96d6f144fe463",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/LightPerformanceScanner.asset
            "07199be0cf1b2a34f8dff60d486129ea",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/LineRendererPerformanceScanner.asset
            "e750aae2c41768e4485dfb9a6de00454",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/MeshPerformanceScanner.asset
            "f4004220746a95a4e84a3909a49d844b",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/ParticlePerformanceScanner.asset
            "18ec5f6f963b6774fa1b84c5bff0246f",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/PhysicsPerformanceScanner.asset
            "986c284df70b4c34dad7e5ef27a86156",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/Scanners/TrailRendererPerformanceScanner.asset
            "bf50321b92d503d4a823939356ce856d",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/ScannerSets/PerformanceScannerSet_Quest.asset
            "b0d7b483809dd6441bb36507c9f64040",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/ScannerSets/PerformanceScannerSet_Windows.asset
            "f0f530dea3891c04e8ab37831627e702",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Quest/AvatarPerformanceStatLevels_Quest.asset
            "e750436d0bab192489da0debe67ee879",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Quest/Excellent_Quest.asset
            "b25db21b17fba3d49a7248568fdb9870",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Quest/Good_Quest.asset
            "31feb7417182a80469408649071d10ac",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Quest/Medium_Quest.asset
            "171503e8193e15447967be1e3ca1e714",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Quest/Poor_Quest.asset
            "438f83f183e95f740877d4c22ed91af2",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Windows/AvatarPerformanceStatLevels_Windows.asset
            "88c46902276e7624e8adda9020bef28b",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Windows/Excellent_Windows.asset
            "38957d57ab5a7f145b954d20fc24b1d4",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Windows/Good_Windows.asset
            "65edaefdc2f87414594559cb89383b5b",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Windows/Medium_Windows.asset
            "595049d4e162571489f2437524d98a31",  // Assets/VRCSDK/Dependencies/VRChat/Resources/Validation/Performance/StatsLevels/Windows/Poor_Windows.asset
            "36c0d886a26373c46be857f2fc441071",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/ApiFileHelper.cs
            "acadc6659c5ab3446ad0d5de2563f95f",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/AudioManagerSettings.cs
            "8d047eaa3325d654aa62ccad6f73eb93",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/CommunityLabsConstants.cs
            "e1c693656bf5d584b87df969efeb5536",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/ContentUploadedDialog.cs
            "a3132e0ab7e16494a9d492087a1ca447",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/RuntimeAPICreation.cs
            "1e5ebf65c5dceeb4c909aa7812bd2999",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/RuntimeBlueprintCreation.cs
            "2bd5ee5d69ee0f3449bf2f81fcb7f4e3",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/RuntimeWorldCreation.cs
            "0d49300ad532d4ae6b569b28de5b7dac",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/SceneSaver.cs
            "10121679f780956408f9a434a526f553",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/MaterialFallback/FallbackMaterialCache.cs
            "bef0a8d1d2c547119a62b7d7a5c512ea",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/ShaderValidation.cs
            "8a90ec11b51863c4cb2d8a8cee31c2fb",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/ValidationUtils.cs
            "9b03724cd556cb047b2da80492ea28a5",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/WorldValidation.cs
            "15ecac6f7fdc1bc4fb723fee6f4635dd",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/AvatarPerformance.cs
            "f1ce994297384ff1bc330196df61b7ca",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/AvatarPerformanceCategory.cs
            "f28c978154794266b38d686139c6b872",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/MeshUtils.cs
            "8cdca9d06d1b4732b9ccb82a38bb8d9c",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/PerformanceFilterSet.cs
            "a5ed7498cb1a46c78eab031f5f32448c",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/PerformanceInfoDisplayLevel.cs
            "5019a55ee9e2404c81bc61a39a010d8d",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/PerformanceRating.cs
            "4afb61f36d144fc381114cd7f78d13e7",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/PerformanceScannerSet.cs
            "abda65e062e44213aa3e1f4c82b400a8",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Filters/AbstractPerformanceFilter.cs
            "0bd0691a021844f49444a04a959d6328",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/AbstractPerformanceScanner.cs
            "08c8e931d0544866a0f626855d9c1841",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/AnimatorPerformanceScanner.cs
            "b3a8bba736414d1aaa9e766da27b56b5",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/AudioPerformanceScanner.cs
            "0cec88b5a46f459195f10a2f11fddb2f",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/ClothPerformanceScanner.cs
            "a226df494ef04404a9a47c714822ab9f",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/DynamicBonePerformanceScanner.cs
            "405778fdc32c44c1bb9fdd0476fb0007",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/LightPerformanceScanner.cs
            "ec87392b85844f7bb526a48ec866a8f0",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/LineRendererPerformanceScanner.cs
            "38bca10261df4ddfa10cff3b3bbb9428",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/MeshPerformanceScanner.cs
            "10723e354ff14f98a49ab797b3f005e6",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/ParticlePerformanceScanner.cs
            "6a94ecdeecd04f85824cc3244be5712a",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/PhysicsPerformanceScanner.cs
            "2efd714b564547b4be1ebd1f2700668b",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Scanners/TrailRendererPerformanceScanner.cs
            "1bf4fb79a49d4b109c4dce6b38e5548e",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Stats/AvatarPerformanceStats.cs
            "f742c36dce5730f4d96e37d82c330584",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Stats/AvatarPerformanceStatsLevel.cs
            "468554b1bfc447f41a20a2f5bae65d16",  // Assets/VRCSDK/Dependencies/VRChat/Scripts/Validation/Performance/Stats/AvatarPerformanceStatsLevelSet.cs
            "9ae7399f0cf902a41a20f3487af8322a",  // Assets/VRCSDK/Dependencies/VRChat/SdkGraphics/SDK_Panel_Banner.png
            "13d3efffb839ced4c8426a88a0c3e98c",  // Assets/VRCSDK/Dependencies/VRChat/Textures/damageGreyNoAlpha.png
            "8d95767408d35544c98f92ef7279b8db",  // Assets/VRCSDK/Dependencies/VRChat/Textures/damageGRNoAlpha.png
            "861bc2dd35aa1534d89330ffa4434b61",  // Assets/VRCSDK/Dependencies/VRChat/Textures/VRChatBanner.png
            "1fe93258fe621c344be8713451c5104f",  // Assets/VRCSDK/Examples3/Animation/BlendTrees/vrc_CrouchingLocomotion.asset
            "667633d86ecc9c0408e81156d77d9a83",  // Assets/VRCSDK/Examples3/Animation/BlendTrees/vrc_ProneLocomotion.asset
            "b7ff0bc6ae31ce4458992fa6ce9f6897",  // Assets/VRCSDK/Examples3/Animation/BlendTrees/vrc_StandingLocomotion.asset
            "3e479eeb9db24704a828bffb15406520",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3ActionLayer.controller
            "d40be620cf6c698439a2f0a5144919fe",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3FaceLayer.controller
            "404d228aeae421f4590305bc4cdaba16",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3HandsLayer.controller
            "5ecf8b95a27552840aef66909bdf588f",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3HandsLayer2.controller
            "573a1373059632b4d820876efe2d277f",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3IdleLayer.controller
            "4e4e1a372a526074884b7311d6fc686b",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3LocomotionLayer.controller
            "1268460c14f873240981bf15aa88b21a",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3SittingLayer.controller
            "74c2e15937e5c95478edd251f20e126f",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3SittingLayer2.controller
            "a9b90a833b3486e4b82834c9d1f7c4ee",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3UtilityIKPose.controller
            "00121b5812372b74f9012473856d8acf",  // Assets/VRCSDK/Examples3/Animation/Controllers/vrc_AvatarV3UtilityTPose.controller
            "7ff0199655202a04eb175de45a6e078a",  // Assets/VRCSDK/Examples3/Animation/Masks/vrc_Hand Left.mask
            "903ce375d5f609d44b9f00b425d6eda9",  // Assets/VRCSDK/Examples3/Animation/Masks/vrc_Hand Right.mask
            "b2b8bad9583e56a46a3e21795e96ad92",  // Assets/VRCSDK/Examples3/Animation/Masks/vrc_HandsOnly.mask
            "2bd8e9669f928cb47854a2dd69b5c54f",  // Assets/VRCSDK/Examples3/Animation/Masks/vrc_MusclesOnly.mask
            "806c242c97b686d4bac4ad50defd1fdb",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_afk.anim
            "2af7e07b1514ac14bafe50d6b79cd07e",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_backflip.anim
            "703c82944d4b65e46942be9025df2266",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_crouch_still.anim
            "3457094102e371c42a1dc43cd659accf",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_crouch_walk_forward.anim
            "8466eec7b1f616648a737ed487def1f0",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_crouch_walk_right.anim
            "5ea269fcea5866f46a7acd87566ae0a1",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_crouch_walk_right_135.anim
            "1aa8b70341eb1a548819ab2de0a3dd15",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_crouch_walk_right_45.anim
            "0d2e5f9cc00d88a48b7bbe6e2898a4b4",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_dance.anim
            "4cf06429686164a45adaedb6a6e520a5",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_die.anim
            "4683658a0ca6b4a48af55ae194794444",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_eyes_die.anim
            "55a22d4581cf3d64e92350671bb2fe40",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_eyes_open.anim
            "fd4321937ed74e74687a3dd18e80c500",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_eyes_shut.anim
            "704174e3f5fd50044a762a02753e8bee",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_fall_long.anim
            "a5f9dea4a0261414ab29c975b6f70fda",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_fall_short.anim
            "523de46ec8739104f91a2b54fa49cdc7",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_hands_fist.anim
            "fe8651e0359eacb49af5f71cc04eadd5",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_hands_gun.anim
            "14980fc5fe40191418954549174fe63e",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_hands_idle.anim
            "61a99b5de5e4b6d4c8ed51d9dfd9ddc7",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_hands_idle2.anim
            "e519e4ad96b4b4b49901f99adce46a64",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_hands_open.anim
            "c24dee443c8cd15498f706a6571d400f",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_hands_peace.anim
            "db055938a2cca0849b43d69957171c7a",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_hands_point.anim
            "219afa41c622312419dc6ac65e3657c3",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_hands_rock.anim
            "9bad171d3023a114c8f42ea671be2af4",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_hands_thumbs_up.anim
            "b0f4aa27579b9c442a87f46f90d20192",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_idle.anim
            "cdfe66cfb0b9e46408c8f38b7757200f",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_idle2.anim
            "6336cc377c311c048922181f5de686ac",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_idle3.anim
            "953422a77c1bdb946918dd93e2b20d43",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_ikpose.anim
            "6b72ff6fb01b52d42af614751aa23f73",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_landing.anim
            "6c9ee9cc637173d49b2993bca08c631a",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_low_crawl_forward.anim
            "e0189b85de4288b41a06fd5989c433ae",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_low_crawl_idle.anim
            "116d68f15e1f2f1498404645567c69d6",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_low_crawl_right.anim
            "3bffcd80512ef7046a4c6115aec47613",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_low_crawl_still.anim
            "5034c34f0db7b7241a6a603dee661088",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_mood_angry.anim
            "56c4f9f62d8edd546860e8b2af6b8073",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_mood_happy.anim
            "08a3d9aacf60bfa40acb1f1191287dd3",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_mood_neutral.anim
            "55810ce54768ff948991b08d1f179210",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_mood_sad.anim
            "8dd5ffc1566396e4195927189c7e65ef",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_mood_surprised.anim
            "a299d75af8134bf44a4b904115b12f82",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_rotate90_left.anim
            "a11f128eaefdccb469249c6e14c7a899",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_rotate90_right.anim
            "918c44c9b072e6549b41f11912f44876",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_run_backward.anim
            "b6d456f2ed810364ebe3be917824b2e7",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_run_forward.anim
            "e8f272970e172914e8e134af1a1a337e",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_run_strafe_right.anim
            "83bb232deb6e1f345abe776aa2ea85ce",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_run_strafe_right_135.anim
            "7f5045c3393abd04083addcb73707c1b",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_run_strafe_right_45.anim
            "390816a8c9a0e634c8eb94e9907a8a81",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_seated_clap.anim
            "593e00f8a0060b14ea6b289eb12f0db1",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_seated_disapprove.anim
            "385699e4f9531f8468264ffc7c48d9ed",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_seated_disbelief.anim
            "3aa84c817614d9a4e83d0250b9ac214e",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_seated_drum.anim
            "b405e069574439846861d02dc0b5ee62",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_seated_laugh.anim
            "f7da25fc68cda2748bf78e7ed01e28a4",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_seated_point.anim
            "1791a673b68e05943baa8b96f0d44bd7",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_seated_raise_hand.anim
            "fda92038a2576ec43ad296fc2b6528f6",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_seated_shake_fist.anim
            "caf2eb9e8c4fad3428fc46f53055320c",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_shuffle_forward_lfoot.anim
            "a95d7eb14daadb040b4817def41d0e21",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_shuffle_forward_rfoot.anim
            "478a7c651713a5a479ddead5e2ef0c30",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_shuffle_left.anim
            "2cad17ca38c82974382d5127885bce8b",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_shuffle_right.anim
            "970f39cfa8501c741b71ad9eefeeb83d",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_sit.anim
            "c91ab643200feef4fae5d09a7fdd410c",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_sit2.anim
            "7ec73497c6b2ea64b9d33c28a07d8b2f",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_sit_down.anim
            "71a823a501a027b4fae01ad327f23ce2",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_sit_getup.anim
            "23dba0ec7d8ff8443bdfe3434c6b3130",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_sprint_forward.anim
            "7359fa5b13647ba4986416b105f0d6dd",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_stand_cheer.anim
            "44ce16481749f4c4baf0549d1bf3b3f3",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_stand_clap.anim
            "498e9dfd6d870064184180c5e4a3fc59",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_stand_point.anim
            "762c2cb22a9e6cc45803bd200a00c634",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_stand_sadkick.anim
            "91e5518865a04934b82b8aba11398609",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_stand_still.anim
            "09f2544a21594ef44925887662e24be6",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_stand_still2.anim
            "c6a07915cc1a9a644af7a5a358a6d3f1",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_stand_still3.anim
            "60873c431a64a744d87a5ad1e20bf886",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_stand_wave.anim
            "954b4bdbab2834743b2e07d6621629e5",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_strafe_right.anim
            "036e18dc9d3a7dd428f7d83bf5c65db4",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_strafe_right_135.anim
            "95ec853e6c7731048be077df8b455bd0",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_strafe_right_45.anim
            "ef56f98d2522d6b4387a112b015c6478",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_supine_getup.anim
            "645a7092829eff9478fb3a29f959a6fa",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_tpose.anim
            "3f1f10bf927cb5f47bfabbaf080f5952",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_turn_180.anim
            "3f5e872b50a268c41a98ee9d299d2153",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_walk_backward.anim
            "37dab4a2c63deb643bc9de4da0d212ed",  // Assets/VRCSDK/Examples3/Animation/ProxyAnim/proxy_walk_forward.anim
            "03a6d797deb62f0429471c4e17ea99a7",  // Assets/VRCSDK/Examples3/Expressions Menu/DefaultExpressionParameters.asset
            "024fb8ef5b3988c46b446863c92f4522",  // Assets/VRCSDK/Examples3/Expressions Menu/DefaultExpressionsMenu.asset
            "48e41265a34c05d45b49ca189dc1a992",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/face_angry.png
            "50865644fb00f2b4d88bf8a8186039f5",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/face_gasp.png
            "7f83deb51b30514499addc7b843db4e1",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/face_happy.png
            "b6958ecb7fc1e3941ae0b1b47b4c56c0",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/face_meh.png
            "af1ba8919b0ccb94a99caf43ac36f97d",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/face_smile.png
            "70532155452b91149bd82125c362ca6b",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/hand_normal.png
            "b4a615d4b1248c9499b06aa6ea7adaf3",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/hand_rock.png
            "5acca5d9b1a37724880f1a1dc1bc54d3",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/hand_waving.png
            "ab6dae33d7a158a44a4fff12d8567a91",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/item_flashlight.png
            "a06282136d558c54aa15d533f163ff59",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/item_folder.png
            "cc4c13c05f8c4e943885903095b7474a",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/item_light.png
            "82c01b48b015b5649be2902336c2c386",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/item_pistol.png
            "8b4cc96dcc6fb484cb2b3d55c4997d99",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/item_sword.png
            "0ff9333af28b8224893850e22c95e496",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/item_wand.png
            "9a20b3a6641e1af4e95e058f361790cb",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/person_dance.png
            "44b822c693fbd174d8f994ee312dd8e4",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/person_running.png
            "011229dd2f6f5f64f8965a08d3434654",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/person_wave.png
            "30891e000b76dfc4db977fc2238911a0",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/symbol_colors.png
            "0539e25eba635ce41a401580788a2c77",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/symbol_heart.png
            "16e0846165acaa1429417e757c53ef9b",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/symbol_magic.png
            "7943de274b5317f4883f3ed9aeb7868f",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/symbol_music.png
            "29b4286f41c93f84f9ffc6ca7551f2d3",  // Assets/VRCSDK/Examples3/Expressions Menu/Icons/symbol_paw.png
            "3bb6d22e89000724b90fb830af69384b",  // Assets/VRCSDK/Plugins/sqlite3.dll
            "4ecd63eff847044b68db9453ce219299",  // Assets/VRCSDK/Plugins/VRCCore-Editor.dll
            "b0e1c0f72d838fe49bfe88b987a471bd",  // Assets/VRCSDK/Plugins/VRCCore-Standalone.dll
            "215be632cb025bd429dd50a3fa942168",  // Assets/VRCSDK/Plugins/VRCSDK3-Editor.dll
            "661092b4961be7145bfbe56e1e62337b",  // Assets/VRCSDK/Plugins/VRCSDK3.dll
            "d09383607271b19468447945fda29e86",  // Assets/VRCSDK/Plugins/VRCSDK3Base-Editor.dll
            "bdccfb093344e7545a49b72a64499682",  // Assets/VRCSDK/Plugins/VRCSDK3Base.dll
            "dc5cab6c932db3247aab9f50c5f3bd5f",  // Assets/VRCSDK/Plugins/VRCSDKBase-Editor.dll
            "db48663b319a020429e3b1265f97aff1",  // Assets/VRCSDK/Plugins/VRCSDKBase.dll
            "bb15d88e30f9fae428df916379b289b2",  // Assets/VRCSDK/Sample Assets/Editor/RealtimeEmissiveGammaGUI.cs
            "68be9f0f6e5adbd44a76bf6bf69fda7b",  // Assets/VRCSDK/Sample Assets/Materials/BrightButton.mat
            "9414e644b0d9d4c4cb1d863093f0284c",  // Assets/VRCSDK/Sample Assets/Materials/Chair.mat
            "b6099d83d6f02e34ea589e768df4173b",  // Assets/VRCSDK/Sample Assets/Materials/Green.mat
            "34348aa1b91e32f48bda8333f82f6335",  // Assets/VRCSDK/Sample Assets/Materials/GUI_Gradient_Ground.mat
            "4546b0ec54086e840800d63eb723acd2",  // Assets/VRCSDK/Sample Assets/Materials/GUI_Zone_Holo.mat
            "c815f7613a04b724089c206857e57c6a",  // Assets/VRCSDK/Sample Assets/Materials/MirrorReflection.mat
            "7a2568654af4bef4cad7a3dfa02c31b2",  // Assets/VRCSDK/Sample Assets/Materials/Red.mat
            "4a04f8d3981104848915e66f7a02ec72",  // Assets/VRCSDK/Sample Assets/Materials/Screen.mat
            "1278163a2a3ba2b4cad540a862292784",  // Assets/VRCSDK/Sample Assets/PanoViewer/Panosphere.shader
            "26803b57669325843a97b0ae43031082",  // Assets/VRCSDK/Sample Assets/PanoViewer/Sphere.mat
            "4876fc9dc009bbe4493553020a561611",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_black_grid.mat
            "eae9c11350249284e8400a100179e0b2",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_blue_grid.mat
            "1ab66d94bde8cce46bb35638099bfd31",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_grey_smooth.mat
            "76ff537c8e1a84345868e6aeee938ab3",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_navy_grid.mat
            "1032d41f900276c40a9dd24f55b7d420",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_navy_smooth.mat
            "8c19a618a0bd9844583b91dca0875a34",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_pink_grid.mat
            "fed4e78bda2b3de45954637fee164b8c",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_pink_smooth.mat
            "5aa95b3fa56e28f43a84e301c3d19e08",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_white_grid.mat
            "799167b062f9e2944a302eea855166b4",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_white_smooth.mat
            "82096aab38f01cb40a1cbf8629a810ba",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_yellow_grid.mat
            "6e1d36c4bbd37d54f9ea183e4f5fd656",  // Assets/VRCSDK/Sample Assets/Prototyping/Materials/prototype_yellow_smooth.mat
            "622a87b3379022740be7e2efea3ebd33",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_block_04x04x04.fbx
            "00718395eefb6084bb25555f962f25c0",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_coin_01x01x01.fbx
            "df4796b594b970842b69211cb0078c5d",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_cube_02x02x02.fbx
            "3f79402ff4ca9c54d96a09d1a77540d5",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_cube_04x04x04.fbx
            "c09052c9b19f0ea4987bc4f4f981252f",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_cube_08x08x08.fbx
            "16fb769c0394c36469ed40a4f35c1eec",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_floor_08x01x08.fbx
            "080bc076ed19adb4091adca05de83d66",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_floor_4x1x4.FBX
            "fadddc63520db414bbc9126cbf4743ad",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_floor_64x01x64.fbx
            "ce7348d724aa0fc44aaf53391b9bae9b",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_house_16x16x24.fbx
            "f45b6695d6226cd48abfc605723cc3ae",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_join_inner_01x06x01.fbx
            "40384240c1c82b94db82531689571ab0",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_join_mid_04x06x01.fbx
            "6386a10e23c45d040a22051e6ae3b70f",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_join_outer_02x06x02.fbx
            "25712b9d3dd0eb4439390fb8fea8043e",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_pillar_01x02x01.fbx
            "66a13889798137c498eae4b3acdafe19",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_pillar_02x08x02.fbx
            "38a9d3cc5c1e0aa4f92ff3445b73ed7f",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_platform_02x01x02.fbx
            "bc2ed85df3924a4458576f17e8b10057",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_platform_04x01x04.fbx
            "879dd62cbfd65314d812354e257fc5cc",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_platform_8x1x8.FBX
            "b9d7ac1a0f551404f8d32e1e02b64325",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_ramp_04x02x02.fbx
            "900e53dd850c9cc4281be6fa21bdfea5",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_steps_4x2x2.FBX
            "b5290684820a94548bedb95083785116",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/prototype_wall_8x8x1.FBX
            "4cfb7ae289eb1e546b751d287bc1ee62",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/Materials/NavyGrid.mat
            "22a917a65630c404e8ebe2c26a9c7d5e",  // Assets/VRCSDK/Sample Assets/Prototyping/Models/Materials/PinkSmooth.mat
            "a196fd6788131ec459bfb26012466fc1",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/GridEmissive.png
            "efaaea7f6a25a4d4fafa9fce85bf947f",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/prototype_black_dff.png
            "3cae02495b88d2d4fbf19382b7993691",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/prototype_blue_dff.png
            "33a18574a1737ab42a75137c3b83c9be",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/prototype_white_dff.png
            "c3edc74ae8207fd45a93c4ed8ee27567",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/SwatchMauveAlbedo.png
            "86e4aa9207c9e2740b6ace599d659c05",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/SwatchNavyAlbedo.png
            "a336ccf90791f9841b7e680c010d1e88",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/SwatchNavyDarkAlbedo.png
            "8b939c5b46fae7e49af7d85f731ba4ec",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/SwatchOrangeAlbedo.png
            "580615edf5e29d245af58fc5fe2b06ac",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/SwatchPinkDAlbedo.png
            "590546bcbd472d94e874f6e0c76cc266",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/SwatchTealAlbedo.png
            "9c4d7ee42c7d4f944b2ce9d370fa265c",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/SwatchTurquoiseAlbedo.png
            "9d0b29cecf2678b41982d2173d3670ff",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/SwatchWhiteAlbedo.png
            "b4646ae63b0bcca40b1bdde3b87e01bf",  // Assets/VRCSDK/Sample Assets/Prototyping/Textures/SwatchYellowAlbedo.png
            "693137b858e4dc64c83be531351f45e6",  // Assets/VRCSDK/Sample Assets/Shaders/Mirror.shader
            "9788d723ed7eac946a9a599e4a6ba940",  // Assets/VRCSDK/Sample Assets/Shaders/Video-RealtimeEmissiveGamma.shader
            "5f8fef09682fab74fb7a29d783391edb",  // Assets/VRCSDK/Sample Assets/Shaders/VRChat-Sprites-Default.shader
            "9ae8ad653e1d98940bbc79866b9170f3",  // Assets/VRCSDK/Sample Assets/Shaders/VRChat-Sprites-Diffuse.shader
            "f8c1f8ac363df824899534a0b30eef00",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-BumpedDiffuse.shader
            "528d55c4e8adab14b974ca665ed1b996",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-BumpedMappedSpecular.shader
            "584dc70fbb9834e48beb29e3206e3ca0",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-BumpedSpecular.shader
            "2dcd9e0568e0a6f45b92c60ba2eb16a0",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-Diffuse.shader
            "b1f7ecc80417c414b9d62ce541d5bcbf",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-Lightmapped.shader
            "3ad043b7f9839cb48a75a9238d433dec",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-MatCapLit.shader
            "9200bec112b65ec4fbbbd33fa89c20f4",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-Particle-Add.shader
            "8b39b95ac85682040beff730e0cfc77a",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-Particle-Alpha.shader
            "d5b89f0c74ccf5049ba803c14a090378",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-Particle-Multiply.shader
            "c0d3cb006bb294142bef136f492f2568",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-Skybox.shader
            "0b7113dea2069fc4e8943843eff19f70",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-StandardLite.shader
            "affc81f3d164d734d8f13053effb1c5c",  // Assets/VRCSDK/Sample Assets/Shaders/Mobile/VRChat-Mobile-ToonLit.shader

            // Udon
            "45115577ef41a5b4ca741ed302693907",  // Assets/Udon/UdonBehaviour.cs
            "530bdb25a3862ff4c8be42f678c53527",  // Assets/Udon/UdonManager.cs
            "473737f63e15e204aa3a3df7a3a173e3",  // Assets/Udon/version.txt
            "3c1bc1267eab5884ebe7f232c09ee0d9",  // Assets/Udon/VRC.Udon.asmdef
            "84de2da7fe8ad8e439c084731189bc12",  // Assets/Udon/Editor/UdonBehaviourEditor.cs
            "66ebdaa27f6d2d54cbb62abddc493674",  // Assets/Udon/Editor/UdonEditorManager.cs
            "627c4d5cd580ddf41bd320e784fe8b9d",  // Assets/Udon/Editor/VRC.Udon.Editor.asmdef
            "8b6535096cfa29340897276abbdd015f",  // Assets/Udon/Editor/External/VRC.Udon.Compiler.dll
            "585dd63e377866248b16bdba915820ed",  // Assets/Udon/Editor/External/VRC.Udon.EditorBindings.dll
            "b335798a4f28bec40ba9b3d4a15acee7",  // Assets/Udon/Editor/External/VRC.Udon.Graph.dll
            "21dcba1a47cc8c84381629950b692129",  // Assets/Udon/Editor/External/VRC.Udon.UAssembly.dll
            "161140ecae894b84ba7bdd6e44ff4371",  // Assets/Udon/Editor/External/VRC.Udon.VRCGraphModules.dll
            "19cff77330d183441a69ff6c69e07629",  // Assets/Udon/Editor/External/VRC.Udon.VRCTypeResolverModules.dll
            "cac80b40f57c41d4b941dc5059271583",  // Assets/Udon/Editor/GraphModules/VRCInstantiateNodeRegistry.cs
            "e1b5b45f24b268b42826fc5c5497dc15",  // Assets/Udon/Editor/ProgramSources/SerializedUdonProgramAssetEditor.cs
            "0e5ced9511d591140b191bbd9e948e61",  // Assets/Udon/Editor/ProgramSources/Attributes/UdonProgramSourceNewMenuAttribute.cs
            "22203902d63dec94194fefc3e155c43b",  // Assets/Udon/Editor/ProgramSources/UdonAssemblyProgram/UdonAssemblyProgramAsset.cs
            "3df823f3ab561fc43bcb81286e14b91d",  // Assets/Udon/Editor/ProgramSources/UdonAssemblyProgram/UdonAssemblyProgramAssetEditor.cs
            "3c0638314c289c24193b47d1c53c9fca",  // Assets/Udon/Editor/ProgramSources/UdonAssemblyProgram/UdonAssemblyProgramAssetImporter.cs
            "4f11136daadff0b44ac2278a314682ab",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UdonGraphProgramAsset.cs
            "31d6811854f59254aa1a263a8d566eb2",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UdonGraphProgramAssetEditor.cs
            "57422d3fdb0cc124189c68f87b7157cd",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/UdonGraphExtensions.cs
            "e2f2300f99ce0ea4a8d9a20b464384df",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/TypeExtension.cs
            "9214873dab0ea8a4b91861cd5a04dae3",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/UdonGraph.cs
            "f166d8f1c152ef34899019ab9a4fd0f2",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/UdonGraphElementData.cs
            "54dd824c6c614b94183d92710efe4f5f",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/UdonGraphStatus.cs
            "87e2044d3bcb715499ac68cc7380a9ed",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/UdonGraphViewSettings.cs
            "c6f017dc2674fec4da54a57b2655a948",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/UdonGraphWindow.cs
            "5dcd92112af21784ba5bf6383abab768",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/UdonParameterField.cs
            "70616b8b964e3664780fc03f65f27f4f",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/UdonParameterProperty.cs
            "fddc146e8502d7b49a294b6264d66dfd",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/UdonProgramSourceView.cs
            "e5786fc577943ae45953c6f54c97116b",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/UdonWelcomeView.cs
            "aabdd863f82551d40bd3a1b0835d2fc3",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/VideoPlayerElement.cs
            "469db50616185d04e8a46dcd75db12d2",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/GraphElementExtension.cs
            "f4f0ade55ae13b6468a765826f1f2540",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/UdonArrayInspector.cs
            "7e5916b8dd19e4445a9156a457b82ee4",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/UdonComment.cs
            "ba3ecc4c46929404d8c2ec920743b823",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/UdonGraphElement.cs
            "1b8045222a10ce04b815642b9cd5ca17",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/UdonGroup.cs
            "b006d67642298f04e895b6709ef12429",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/UdonMinimap.cs
            "dcd657bc1dcf357448d27bcfa8c5dc36",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/UdonNode.cs
            "8f83d1d3578dd28498c71a980bca86dd",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/UdonPort.cs
            "c5cfbbfcd7bb5ad4487f1f9388a3a168",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/UdonStackNode.cs
            "2d0a4730c5f61b247b27b54f280300b5",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/GraphElements/UdonVariablesBlackboard.cs
            "6581176c97993bb40976acff208bd0b1",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/Search/UdonFocusedSearchWindow.cs
            "b721120e6c1d320448a55fe87a7de824",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/Search/UdonFullSearchWindow.cs
            "e94c084f399869b42a21244fd07778c4",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/Search/UdonPortSearchWindow.cs
            "6a6c453fae11b5349a33399e258d1578",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/Search/UdonRegistrySearchWindow.cs
            "e5a10bb1987c27944bd08a88119b2844",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/Search/UdonSearchManager.cs
            "d825ed3ba6aa7f14294e73efefc217d0",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/Search/UdonSearchWindowBase.cs
            "16fc7a7a059deeb458fdcdf719b467a4",  // Assets/Udon/Editor/ProgramSources/UdonGraphProgram/UI/GraphView/Search/UdonVariableTypeWindow.cs
            "264ec3c8a1d423f42a144da0df6c5ebe",  // Assets/Udon/Editor/ProgramSources/UdonProgram/UdonProgramAsset.cs
            "41d70977fa7936441afe41442f1862b2",  // Assets/Udon/Editor/ProgramSources/UdonProgram/UdonProgramAssetEditor.cs
            "9e84f8ee45862f04ca6b9f8d5c7f5897",  // Assets/Udon/Editor/Resources/CornerResize.png
            "632470b93f35ec64ab6e3efd639c986c",  // Assets/Udon/Editor/Resources/DarkButtonBG.png
            "d4ca7f47895ab36408e28f4f742fba99",  // Assets/Udon/Editor/Resources/DropdownBG.png
            "f43fd332539599c47b3bb05ea38d5d0d",  // Assets/Udon/Editor/Resources/ToolbarBG.png
            "5cbfe49b858635b44844a178cb934b68",  // Assets/Udon/Editor/Resources/ToolbarButtonBG.png
            "7dade49b2f58f734f8db0983d8e7fb60",  // Assets/Udon/Editor/Resources/UdonChangelog.uxml
            "927841c571a405846b3442bc0aa56220",  // Assets/Udon/Editor/Resources/UdonFlowSlot.png
            "3803fec4c7b065042891595e749524cc",  // Assets/Udon/Editor/Resources/UdonFlowSlotFilled.png
            "7c75c00422f12124faed19bfb8dd96df",  // Assets/Udon/Editor/Resources/UdonFlowSlotFilledLight.png
            "610088fc92e5fc64b8c7f9e9c51f2939",  // Assets/Udon/Editor/Resources/UdonFlowSlotLight.png
            "d47fd176596dfbe4e9e78964b40c93ee",  // Assets/Udon/Editor/Resources/UdonGraphNeonStyle.uss
            "815baa9989198624aa5fec5ecdb42bd0",  // Assets/Udon/Editor/Resources/UdonGraphStyle.uss
            "0e2cfcbd717e75441b108d3ad9de2d29",  // Assets/Udon/Editor/Resources/UdonLogo.png
            "8cf68553c5a4bb140a6341072891aa88",  // Assets/Udon/Editor/Resources/UdonLogoAlpha.png
            "d0608d33a4043b2499adb1fee18f2a64",  // Assets/Udon/Editor/Resources/UdonLogoAlphaWhite.png
            "17102758d03099542afc7a1808745eaf",  // Assets/Udon/Editor/Resources/UdonNodeAccent.png
            "c0230adfeb2abe242b8d64c7e3bd2adc",  // Assets/Udon/Editor/Resources/UdonNodeActiveBackground.png
            "8289cc16393cd3040a9920e71bfe10bc",  // Assets/Udon/Editor/Resources/UdonNodeActiveBackgroundLight.png
            "f47842ead2f80fa46ab6e5bbde409193",  // Assets/Udon/Editor/Resources/UdonNodeBackground.png
            "c9235631e37566447ae4567624755326",  // Assets/Udon/Editor/Resources/UdonNodeBackgroundLight.png
            "2d2675a75fea1d2438859bdb320d544d",  // Assets/Udon/Editor/Resources/UdonNodeInlay.png
            "12f29a8be9fc52640b40f6ffa59336c6",  // Assets/Udon/Editor/Resources/UdonNodeInlayLight.png
            "1ed47570201e1854d9e455e38eecbcf7",  // Assets/Udon/Editor/Resources/UdonSettings.uxml
            "91b7c8d7d899ec04e9568e9385aba34d",  // Assets/Udon/Editor/Resources/UdonSlot.png
            "3a1ab76e09365f14cab0665b40da8843",  // Assets/Udon/Editor/Resources/UdonSlotFilled.png
            "add07ab72e2fc3d4d81143ab77d121f5",  // Assets/Udon/Editor/Resources/UdonSlotFilledLight.png
            "1badb339ed4f23541b6db8a9420aeea9",  // Assets/Udon/Editor/Resources/UdonSlotLight.png
            "37bd184e5e9b13945840f70329f2e0f6",  // Assets/Udon/Editor/Resources/videoStill.png
            "c041fa712f66a5d4f8525cd447dc8b29",  // Assets/Udon/Editor/TypeResolvers/UdonBehaviourTypeResolver.cs
            "02e7e7f5f9fc2c24ab3af0b8780f3623",  // Assets/Udon/Editor/UnityEditorTests/UICompilerTests.cs
            "3c3c5a3876474c648a47177c1875f447",  // Assets/Udon/Editor/UnityEditorTests/UnityEditorTests.asmdef
            "80455fb15755bfd47b1803c8fe84e16e",  // Assets/Udon/External/VRC.Udon.ClientBindings.dll
            "a5e7b2f5005f10e44b082e7c18871cc6",  // Assets/Udon/External/VRC.Udon.Common.dll
            "9d86dc4a513809149af3856eab191a3d",  // Assets/Udon/External/VRC.Udon.Security.dll
            "ecb1eec40b5e47047891ee46e739186a",  // Assets/Udon/External/VRC.Udon.VM.dll
            "92886df353bf1f14489cf2c4578e58af",  // Assets/Udon/External/VRC.Udon.VRCWrapperModules.dll
            "a3a3dda899277cc4ea6aebe18c6b5736",  // Assets/Udon/External/VRC.Udon.Wrapper.dll
            "bf61d954ecb803046953c666facfb904",  // Assets/Udon/ProgramSources/SerializedUdonProgramAsset.cs
            "2fad63ba312d5f44a8ab215c3f5b18f1",  // Assets/Udon/ProgramSources/Abstract/AbstractSerializedUdonProgramAsset.cs
            "7fa64b2d7df72fb4cbf7898a400e86ef",  // Assets/Udon/ProgramSources/Abstract/AbstractUdonProgramSource.cs
            "e8b579cfa887081429902be9dc3c7382",  // Assets/Udon/ReferenceDocs/genindex.html
            "55b96853bb4e4e84db1b88d636d6fc69",  // Assets/Udon/ReferenceDocs/index.html
            "9ceffa9ed67b8954f9b627e4a077cabd",  // Assets/Udon/ReferenceDocs/objects.inv
            "24d0a6869e3c3ca449a7b44190c65d98",  // Assets/Udon/ReferenceDocs/search.html
            "f3a172973e43fac43a2e57967634eae4",  // Assets/Udon/ReferenceDocs/searchindex.js
            "67310d7e71d0ab14c80590c8a51d5864",  // Assets/Udon/ReferenceDocs/nodes/Events/index.html
            "6bd7163305eaaa64ab013be0e9cd4fc4",  // Assets/Udon/ReferenceDocs/nodes/Special/index.html
            "e2aa71a4dd85d1147bf904b02053d092",  // Assets/Udon/ReferenceDocs/nodes/System/index.html
            "0db02bf3a3ddce447b49a98d41a57756",  // Assets/Udon/ReferenceDocs/nodes/System/Boolean/index.html
            "66328d9586add9647a61b7481d5181ac",  // Assets/Udon/ReferenceDocs/nodes/System/Byte/index.html
            "b0e403478f1101c4ba4ed942f9b4cf10",  // Assets/Udon/ReferenceDocs/nodes/System/Char/index.html
            "9d9e035ccd0a543419b60366cb8c64a7",  // Assets/Udon/ReferenceDocs/nodes/System/Convert/index.html
            "66d25dbaef9c59f4db95100345f47047",  // Assets/Udon/ReferenceDocs/nodes/System/DateTime/index.html
            "3f6fa871dc1bff14981277dee2588104",  // Assets/Udon/ReferenceDocs/nodes/System/Double/index.html
            "220dc0f32b1e3534f850c214296e7d02",  // Assets/Udon/ReferenceDocs/nodes/System/Float/index.html
            "b82eafba4ebd2554faf97037c0dacad7",  // Assets/Udon/ReferenceDocs/nodes/System/Int/index.html
            "a984fe503aedb1d43a00ee7a45f9d2e4",  // Assets/Udon/ReferenceDocs/nodes/System/Int16/index.html
            "9612c88c065e8c94091977586e3fd33a",  // Assets/Udon/ReferenceDocs/nodes/System/Int64/index.html
            "c7d32ca1c9b0a8e4f86f1ea273195a37",  // Assets/Udon/ReferenceDocs/nodes/System/Object/index.html
            "32280285518874642bff291b42865fd2",  // Assets/Udon/ReferenceDocs/nodes/System/SByte/index.html
            "264be828e2446c347ac683d4a01f694d",  // Assets/Udon/ReferenceDocs/nodes/System/String/index.html
            "375f9b4e557f7724aa5e7afa7b906b68",  // Assets/Udon/ReferenceDocs/nodes/System/TimeZoneInfo/index.html
            "ccb1b895201060642a6d43a1704a7c5f",  // Assets/Udon/ReferenceDocs/nodes/System/Type/index.html
            "d1efd01083b27fb4aa6bd27f581195c0",  // Assets/Udon/ReferenceDocs/nodes/System/Uint/index.html
            "5f6479bc59b886a458deef28b091e517",  // Assets/Udon/ReferenceDocs/nodes/System/UInt16/index.html
            "804c632171819974e98fe5e891e8ea57",  // Assets/Udon/ReferenceDocs/nodes/System/UInt64/index.html
            "3952c2b5679c2394d95b33fe52f96675",  // Assets/Udon/ReferenceDocs/nodes/Types/index.html
            "f796e7a2b29007e4780340fd73e02d67",  // Assets/Udon/ReferenceDocs/nodes/UdonBehaviour/index.html
            "da1d315343d3e7c49922893eb69f8789",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/index.html
            "b8c7f288fa316134ea580389a83a518c",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AINavMesh/index.html
            "4697ee4218ea2c34ab7b6a7d300ff9bc",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AINavMeshAgent/index.html
            "055a5602e75f69a41957f305f9be7458",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AINavMeshData/index.html
            "9435852b6a1be7f43ae395cc646076d7",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AINavMeshObstacle/index.html
            "34b4442cf5cd1124ca04b5add565ceec",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AINavMeshPath/index.html
            "a68bba266455ba942880fe5e1ccee9eb",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AIOffMeshLink/index.html
            "1dec9dab5d2e09048a4c7a831b0cd4fd",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Animation/index.html
            "b0f83e5a0b0b04a4e9fcb676fe5a99c9",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimationClip/index.html
            "83615eed15ad31d439522b67549bd24f",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimationsAimConstraint/index.html
            "c4a4938610b26be4b9afe5e8e194dcc0",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimationsConstraintSource/index.html
            "a5a40db69e345ca41ac784a731be00c7",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimationsLookAtConstraint/index.html
            "82a9b6410ba945a47b3c1fda665d8c40",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimationsParentConstraint/index.html
            "b11a2feab95df57449a965f1ed1e0d19",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimationsPositionConstraint/index.html
            "ffbd3e2fa30c9bd49baac5c0045ec7c6",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimationsRotationConstraint/index.html
            "a3f28689cb209a643bcec893b57abac5",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimationsScaleConstraint/index.html
            "cd4db6d9dfa0d914b8d483c8d937d60a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimationState/index.html
            "f506655c92d4c314ab8195a623663f42",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Animator/index.html
            "740dd89d0d2b0644b8e49d9707feea63",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimatorClipInfo/index.html
            "c5c20b1ae78bd2048996c2eff25da741",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimatorControllerParameter/index.html
            "902673c03206c084487046ec914eaa9f",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimatorOverrideController/index.html
            "401bfb0857e72ef4cb2c676820b01725",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimatorStateInfo/index.html
            "978d15107957b26489c0177904fd5958",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimatorTransitionInfo/index.html
            "2caa96fe9cb94ad41b8a2e059dcdab24",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AnimatorUtility/index.html
            "ee5bbaaacd7ae7549bb74698516e7d7a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AreaEffector2D/index.html
            "b0cd089c148c8424daff7cea1a13769f",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AudioChorusFilter/index.html
            "4829c1f3a40785c4eb520f2cd9114d6a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AudioClip/index.html
            "fb2a0a04b979fad47b4bdaf49d841a86",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AudioDistortionFilter/index.html
            "8de8465af6ff9be4bac3970bf7cc7e16",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AudioEchoFilter/index.html
            "63c8a73eb341b3843ac62900a787d302",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AudioHighPassFilter/index.html
            "85666fd2620428a49ac21ad450a0d86e",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AudioLowPassFilter/index.html
            "268c8ced4384a234ba561da25781e232",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AudioReverbFilter/index.html
            "28dd7845b1728614a9aa4f765b1f7de9",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AudioReverbZone/index.html
            "e41fd811e3713544980a0f7628f8f9ed",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AudioSource/index.html
            "7de479e7666ea6844871fcd045f3a37f",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Avatar/index.html
            "749b35c7fc835c74586bc1a954cc31bd",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AvatarBuilder/index.html
            "2df062918ea9c604dbe2659d52e11954",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/AvatarMask/index.html
            "41af2b7868754bd4ea2a3c40b9c712be",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/BillboardRenderer/index.html
            "808836244461fae4a8c19702ede69ba8",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Bounds/index.html
            "3ffd6a3c30ba3894b9ec63f2fcf8ee9c",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/BoxCollider/index.html
            "542fd115213186d4c81960115906eeb5",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/BoxCollider2D/index.html
            "636a2986ae2cf82468309269bf40643e",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Camera/index.html
            "dec7f3ff3b2e07f4ab3c47a675df8dce",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Canvas/index.html
            "16d8e29f841fbbf478d43dcdd2026d4a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/CanvasRenderer/index.html
            "6a1328ce0d1fe5e4faa8edde04fa127c",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/CapsuleCollider/index.html
            "e942bd15306b6944cb6831c06d291a76",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/CapsuleCollider2D/index.html
            "726293544ac95e243a551f85ed413d03",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/CircleCollider2D/index.html
            "e02d2f5645191a944b4f84408ade8c82",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Collider/index.html
            "cc3d0c155ee3110488e200a268d6b0b2",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Collider2D/index.html
            "41f6224aa426695409ac0cd63d7391e4",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Collision/index.html
            "637a5b49407d427429785f2ab11e7711",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Collision2D/index.html
            "54ac96c3c9a24594abec16ea04082d74",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Color/index.html
            "f86de7224f3b33f4c959986b16d506e6",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Component/index.html
            "32265db69f7551048836885a30d3b2d7",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/CompositeCollider2D/index.html
            "0fea6627276f6f84292300d8b944b88b",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ConfigurableJoint/index.html
            "42c2b50a92625b6408296c0f45c1a7b7",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ConstantForce/index.html
            "40686aaf88de8b4408b11f7d3833752c",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ConstantForce2D/index.html
            "1603d4f17c247d846b4e245fb05d5736",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ContactPoint/index.html
            "0da47c6495186d745a861c85aec090f4",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ContactPoint2D/index.html
            "e1d75acd100ddd04fb9b8f0d17b806e1",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Debug/index.html
            "481b27157d1d21c4382397cd4728a954",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/DistanceJoint2D/index.html
            "d0c7d94c095a7fa4ca37eb81eac2d63d",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/EdgeCollider2D/index.html
            "5c09d241381d94845bd340f1f09d4e87",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Effector2D/index.html
            "8890a4cebdb98384cb27dc542c1ddc47",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ExperimentalAnimationsMuscleHandle/index.html
            "bcb7611416bc8ba46b1e572168436a0b",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/FixedJoint/index.html
            "dd45f42e2f63e2740a6efc1b36c001e3",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/FixedJoint2D/index.html
            "1cd97221102b9414595c6bcf71135bed",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/FrictionJoint2D/index.html
            "56f579d84de3cc848946bcff5f407785",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/GameObject/index.html
            "2d44196a7efe8a841a94bd29835cef89",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Gizmos/index.html
            "8f06b871c2f190a4da915eec1c47d0e7",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/HingeJoint/index.html
            "ddacd4c3fbd6768449c571e49fddb1d1",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/HingeJoint2D/index.html
            "2a9c7fd5f05bd174a85a633968d6b1a6",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/HumanBone/index.html
            "5fde616b88dc6ef488e9c00bd0f16b1f",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/HumanDescription/index.html
            "7bf0045cf2c1f574e859f987267adb47",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/HumanLimit/index.html
            "7000647be86988143bb6eb3b5ebedd09",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/HumanPose/index.html
            "0d4bc81c7d0bf4644a2213b5c039f074",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/HumanPoseHandler/index.html
            "39c0aa177752d724c8bc62468ddeaa8b",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/HumanTrait/index.html
            "76e6f03435afe364a84140e931f211df",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Input/index.html
            "68291d60565ae2841be7a5ec5b9854ce",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Joint/index.html
            "be85e469b34b48c4e80c1ab5dea218ed",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Joint2D/index.html
            "a585f201899c17546b9eaefaedce4075",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/LayerMask/index.html
            "8a5d7d157495aa043aab776a9b1cb123",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Light/index.html
            "34c67f7bfb102b34f87978259ab31293",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/LineRenderer/index.html
            "b40ed7fff1f2f3844bf9bc6172ce0510",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/MatchTargetWeightMask/index.html
            "e2bb1b365810f9e42a063286575a9ec3",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Material/index.html
            "725b893a3f1d1814a8a8e0d55e53059b",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/MaterialPropertyBlock/index.html
            "04958e03ef4ab554d911633c4b562ec5",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Mathf/index.html
            "c1b12b974ecb67a42a82de8de76310f7",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Matrix4x4/index.html
            "ccea9285a931ba44389730510d527942",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Mesh/index.html
            "2a832bf04ce05374dbe2d8f502737f60",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/MeshCollider/index.html
            "8d6a3ab10ce2aa349a3d111a924941cd",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/MeshFilter/index.html
            "605313f4bd7bf954394c7244f0131aec",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/MeshRenderer/index.html
            "00ee5b07b1e362f44aa968b9065ca6c0",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Motion/index.html
            "56ca3da25d7775a4ea1cb701077a384e",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Object/index.html
            "986cf78df4f81994da3c8e50b5b8fae6",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystem/index.html
            "369f8a0eeff76db46bda53cfda47fb7a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemBurst/index.html
            "d0550e4d7d256a34b9f585b49315bae9",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemCollisionModule/index.html
            "3ad6de39b58d38846a40986f9a5427a1",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemColorBySpeedModule/index.html
            "870b93589e08d5b4485459eb7c5b9c35",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemColorOverLifetimeModule/index.html
            "a24cae8151c645a4d8129de105c57f8f",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemCustomDataModule/index.html
            "05d3147c80335b64684714ec4c650f97",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemEmissionModule/index.html
            "ea698c98379c5534b876098f733890d0",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemEmitParams/index.html
            "d12fc2cc71f08cc4a9579e338b8d7c16",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemExternalForcesModule/index.html
            "61df4696f1df2d548af78e7b671f2ae1",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemForceOverLifetimeModule/index.html
            "4ad62402436079244a3b53a0ff1ba727",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemInheritVelocityModule/index.html
            "38c1546cb07664b48b18cb1f4827fc77",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemLightsModule/index.html
            "6260fe5fc1b82464ba7fbf4acfa75425",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemLimitVelocityOverLifetimeModule/index.html
            "e68a5329379c06544b73aab1662e2098",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemMainModule/index.html
            "1e2d5138ef7185d4eae5e464bd67021f",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemMinMaxCurve/index.html
            "ee5020ccee37b074c829de1064303d17",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemMinMaxGradient/index.html
            "7de929635b6162d4b847de68b27f3720",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemNoiseModule/index.html
            "80c3089bb90039e42ba3ca14ef0d6898",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemParticle/index.html
            "ca18a3ce3e6a75e48b1aa9dd93b70c73",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemRotationBySpeedModule/index.html
            "24e181bd85e28a943891f3a0ddb70941",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemRotationOverLifetimeModule/index.html
            "67aed52253945eb449de361c6b1ba7fa",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemShapeModule/index.html
            "52c48e0e7fe328b43b84837974a4b708",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemSizeBySpeedModule/index.html
            "cb850f3f0adc27c40928b2f0827aca9a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemSizeOverLifetimeModule/index.html
            "02c33870a9df5844a9300d1332ce2682",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemSubEmittersModule/index.html
            "4f019e48af52e59438dabd6eb9cb06fd",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemTextureSheetAnimationModule/index.html
            "936f3021b3c10d34c92414d81af578a4",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemTrailModule/index.html
            "791c67b299132c94fa0cea6abcb6c29d",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemTriggerModule/index.html
            "28712cf8313802c44ae2fc7869ba99fa",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/ParticleSystemVelocityOverLifetimeModule/index.html
            "8b4a0f55c8c23294998cc8daff0260a7",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/PhysicMaterial/index.html
            "7b6a6396841fde844ae4c6b6a429414a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Physics/index.html
            "0067d82cd0004b84784f2fd394170100",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Physics2D/index.html
            "36c3468974105fc4ab2adeb21b650933",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/PhysicsMaterial2D/index.html
            "3f6f055420aeb7a45ac364f48805a41c",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/PlatformEffector2D/index.html
            "b9b5c2a739e9bc043acae5f7731bd1a3",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/PointEffector2D/index.html
            "7c951ae832a607a4082047158d956ab2",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/PolygonCollider2D/index.html
            "ec09c7fc5dd3b5c40af90abd44b7af4e",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/QualitySettings/index.html
            "941f0a29c9e5fe5488f6f58e16da7d6b",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Quaternion/index.html
            "0ca84a463ef9a024487191d2c3c499e7",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Random/index.html
            "669dcc6f3e8055244bc8382debf6d201",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Ray/index.html
            "5a4d887bd6d039e4fbd5757070ae3b84",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/RaycastHit/index.html
            "14f6c5bc7b2b48d4eb74548e4785827f",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/RaycastHit2D/index.html
            "eaad272ebddfac34482872405a299712",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/RectTransform/index.html
            "4bd95ddbfb29bd74bbbbe97386d365fc",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/RelativeJoint2D/index.html
            "535588011cd699a47af94fd31ea4e406",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Renderer/index.html
            "31204994871a4634eb511375ed72f804",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/RendererExtensions/index.html
            "d3ab7ffa6c6982e42aa1840d8c888a19",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/RenderSettings/index.html
            "59a83c130a4289843b394484ff147220",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Rigidbody/index.html
            "d0b64363ac3e1784db3e8cac7aeafe11",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Rigidbody2D/index.html
            "0d281747fb365914dae72ac05faf7b23",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/RuntimeAnimatorController/index.html
            "5f9fe15e9d5e1564a9745071d0deeadb",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/SkeletonBone/index.html
            "ea8a5e9cfef9f17418fc7d69c1c7825e",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/SkinnedMeshRenderer/index.html
            "e120f42ed5f6561488483fad9598e559",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/SliderJoint2D/index.html
            "9980269db4e9fe449b701b8da426c88a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/SphereCollider/index.html
            "0269c8b5f40d0f34a96764f81b90b9eb",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/SpringJoint/index.html
            "5751567cbd2f153409912cc67a913dbc",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/SpriteRenderer/index.html
            "276629076e8aafe4695c2861eafc24a8",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/SurfaceEffector2D/index.html
            "18e13ec801491404abc0466a3d1d50a4",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/TargetJoint2D/index.html
            "2c7d878085d09474686123cc6ad3c6c3",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/TextAsset/index.html
            "92fd1afbc6b606c439485e0227ce5d3a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Time/index.html
            "28bdd3c96b176a04896d883d8bece5b8",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/TrailRenderer/index.html
            "e18b4c9ab98a1b447bee1a66e4ce5ac3",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Transform/index.html
            "9f3a410d8b8334240a80ade7b4778c19",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIAnimationTriggers/index.html
            "06874cebc6186b84aa60a1b79a2427da",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIAspectRatioFitter/index.html
            "138b4a9e150af4c40a78e4cc7561efe3",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIBaseMeshEffect/index.html
            "b9d0d5a117e0bff4886a73feb9e8c3dc",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIButton/index.html
            "a0e04ac6ab6f58540af03063b8ab6ab1",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIButtonButtonClickedEvent/index.html
            "d18170443c78b3b4b939f21b432acda4",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UICanvasScaler/index.html
            "e174898e0b9a1a641a8dbee9affa181e",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIClipping/index.html
            "0e37485950f2a2740b11200d8ca34696",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIColorBlock/index.html
            "9322864599b0b214bbec73f01e2b5f08",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIContentSizeFitter/index.html
            "a5dff08776a156e419ea5aaf958a8d66",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIDefaultControls/index.html
            "fd8eebc81fd4ce24ebb36071e06b712e",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIDefaultControlsResources/index.html
            "8b7967384dbed2849a44211cc5b5d3a1",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIDropdown/index.html
            "c69ea48d581c2e747a62962c353ef682",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIDropdownDropdownEvent/index.html
            "e7c47463862fea042a41283fd47fea5c",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIDropdownOptionData/index.html
            "32c1eff54b8791245b129dba1b386324",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIDropdownOptionDataList/index.html
            "4ab89dde2fe8f7545b44b33803db1a03",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIFontData/index.html
            "b23f78ddf50da524eb379d7dae926235",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIGraphic/index.html
            "b87a1a723a10958499e8fc49326a0be9",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIGraphicRaycaster/index.html
            "7414df96eae683d48a592363c4fb31f5",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIGridLayoutGroup/index.html
            "f1b873969271ec5428052d688a015f2d",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIHorizontalLayoutGroup/index.html
            "39e3bd3270daeb74b85a0517c199fbb7",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIHorizontalOrVerticalLayoutGroup/index.html
            "42e3d0207a6435a43bfb927f815b1ea5",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIImage/index.html
            "e04a12757bd63934cb1df7c7b0c78f67",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIInputField/index.html
            "815e771e7bcf5e7468eca2d7183d5f3a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIInputFieldOnChangeEvent/index.html
            "7e09ccdbcc3366a4b9f6e9e82147e721",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIInputFieldSubmitEvent/index.html
            "a9738abeea9348a489fc9e276aaccbde",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UILayoutElement/index.html
            "cbef14b8f24e9df47bdfed4807cdcc44",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UILayoutGroup/index.html
            "8b07a5b2d6dca5340b60e4f3573a34d1",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UILayoutRebuilder/index.html
            "8610eb1c58601284dac463941f337f78",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UILayoutUtility/index.html
            "d0987cca180df184c959395a7eefe696",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIMask/index.html
            "e53b753ca5b30ba4f97124cfbca0bdf2",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIMaskableGraphic/index.html
            "b7acccd2dc79eeb40b5e7763d2800dcc",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIMaskUtilities/index.html
            "0a9da179ecc08fb43a06bc8c2c44c973",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UINavigation/index.html
            "15258de0f4478a24fbc3778441cfbb21",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIOutline/index.html
            "853903d4cac9c9d4ca3c09456ab54fb2",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIPositionAsUV1/index.html
            "7291350951bcb9b4e95fbc50076ad17d",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIRawImage/index.html
            "db2b9ad4a38cfc147b996748f8e64477",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIRectMask2D/index.html
            "7d2a64886286f724e849f7a6b2272cf8",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIScrollbar/index.html
            "1ea9e85af21af804383b680a8ebe77bc",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIScrollbarScrollEvent/index.html
            "aa12cea18e43ebc4ca8efaacac3acc81",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIScrollRect/index.html
            "31463b30d32df684cb993863abba233d",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIScrollRectScrollRectEvent/index.html
            "d30abf22d6ca41a4381a88efe5278c57",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UISelectable/index.html
            "a2b03c68afe3e9d4980ebc33c9922339",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIShadow/index.html
            "141a289003f62ae4ba268c7ba3a66053",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UISlider/index.html
            "852f15b2358aeb74cbdd8e8fc4c79d22",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UISliderSliderEvent/index.html
            "58e9ed8d2b5185c41b19bc6b23e7ca81",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UISpriteState/index.html
            "9ddc5aabb18781940a5d87aaf25080cd",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIText/index.html
            "238768a52b014e841bcc3df1e6205992",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIToggle/index.html
            "8133c8cecd8ed2c44b3b04b24bba836a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIToggleGroup/index.html
            "1284c0d981971a14793b57450f21a24b",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIToggleToggleEvent/index.html
            "cd9213b0bdf3ae047b53c4e6ec3beefb",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIVertexHelper/index.html
            "59d0a62ed0331f24d8e44bea94e35bf0",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/UIVerticalLayoutGroup/index.html
            "d3cf53528005ad942bc8a17e25065b5c",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Vector2/index.html
            "22393a39b80e1454bbd8e5f73705374f",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Vector3/index.html
            "e7e3fb36b1a319a4eb80b88bce1cbe6a",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/Vector4/index.html
            "61254195f21014d478bb013a03e8302e",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/WheelCollider/index.html
            "1be251a17c5376841a61189f3267d025",  // Assets/Udon/ReferenceDocs/nodes/UnityEngine/WheelJoint2D/index.html
            "9540081bc42b90847807d3ac45ab9ecb",  // Assets/Udon/ReferenceDocs/nodes/VRC/index.html
            "916b7e90da6febc4986210e6392810a6",  // Assets/Udon/ReferenceDocs/nodes/VRC/Instantiate/index.html
            "e5080b82152fcef498a65e94be53e4ac",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/index.html
            "57380db1ca124a74bbd114e3062ec18c",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/ComponentsTrackingData/index.html
            "1cb98cccea7bee042b478b300a585717",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/ComponentsVRCAvatarPedestal/index.html
            "a9240530eb0ffdd4a9ea47db1a06a806",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/ComponentsVRCMirrorReflection/index.html
            "dca04c2d52987364db0348cc433f4095",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/ComponentsVRCPickup/index.html
            "3a055e0be64b63345bcafb14c6dd95cb",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/ComponentsVRCPortalMarker/index.html
            "4e55ff32d7c5fa9449f8118af66a8524",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/ComponentsVRCStation/index.html
            "88b0aa68229ed4b44be094311ca1f59a",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/VRCSDKBaseInputManager/index.html
            "bbf7428354a1ea647a734f24caffbc7a",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/VRCSDKBaseNetworking/index.html
            "bfe3ad74761759345b2764c6a93343e8",  // Assets/Udon/ReferenceDocs/nodes/VRCSDK3/VRCSDKBaseVRCPlayerApi/index.html
            "b534435a2487d4b48bf627219ba3d79b",  // Assets/Udon/ReferenceDocs/_sources/index.rst.txt
            "57c0091de6612004697779f0ab5c8ce3",  // Assets/Udon/ReferenceDocs/_sources/nodes/Events/index.rst.txt
            "77be14115106f33488a2d1bdbac8cdd8",  // Assets/Udon/ReferenceDocs/_sources/nodes/Special/index.rst.txt
            "1caaa18202541204190f654e715bd2cd",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/index.rst.txt
            "d043b66b3a4a4ce42a22e0a66c9d3657",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Boolean/index.rst.txt
            "267d9859745bc2c4b94f59c612f8fe51",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Byte/index.rst.txt
            "d5c40be577c557a498601aff3908dd47",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Char/index.rst.txt
            "b83b3879eb5f2c74d963e3a11c600b99",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Convert/index.rst.txt
            "ad1874fcd58ce5d4a93b66cbd5c46d46",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/DateTime/index.rst.txt
            "a717bfeda447f04419162d4843d8b24a",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Double/index.rst.txt
            "b56cfc0355a28334e9ef90f52fd5378e",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Float/index.rst.txt
            "4213eea2eb1dd6941a9171eec50bb5c0",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Int/index.rst.txt
            "0dff631b9d9657244b119743f4efbc1b",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Int16/index.rst.txt
            "dff2e9b48fdcb804bb39bab05ef0dfa6",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Int64/index.rst.txt
            "276e4b329e802ff4da09c2e627bffaaa",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Object/index.rst.txt
            "540abebf7766b6642b59638860233f1a",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/SByte/index.rst.txt
            "c70a1d82e707ff74f89355e3922b32c1",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/String/index.rst.txt
            "429aacb796bc464418b9e08f58f7e16e",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/TimeZoneInfo/index.rst.txt
            "18c6a8642d0239e44b875b8996077921",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Type/index.rst.txt
            "7020dc24723cbcd4da0091f8f32a55da",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/Uint/index.rst.txt
            "bd5535975819c5644a85d19da6151689",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/UInt16/index.rst.txt
            "a826a09d4b3f47c46b9bfb33c5e4909e",  // Assets/Udon/ReferenceDocs/_sources/nodes/System/UInt64/index.rst.txt
            "f4f386bad17618246ae051c756edccbc",  // Assets/Udon/ReferenceDocs/_sources/nodes/Types/index.rst.txt
            "a95b0aa01bd4a8b4aa19a683638effd1",  // Assets/Udon/ReferenceDocs/_sources/nodes/UdonBehaviour/index.rst.txt
            "c760a575f30b8d849ab6b1b14d271011",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/index.rst.txt
            "9ea9d78d656cf1b4686474926a89bcff",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AINavMesh/index.rst.txt
            "f66c1d34cf1ee09479c5799fcef7b0a6",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AINavMeshAgent/index.rst.txt
            "725df829fd417f646a53c50fc48c5e61",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AINavMeshData/index.rst.txt
            "d5d42e0e001c4114f972d84b36ec634b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AINavMeshObstacle/index.rst.txt
            "fc11e0420f1d91044a6e807dc9f73565",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AINavMeshPath/index.rst.txt
            "7b9bb5f9f7ac742438eaf112c6b00897",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AIOffMeshLink/index.rst.txt
            "a94dcb8b0d27ce24fba70eecf19d966b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Animation/index.rst.txt
            "c7c3f4607412eb3459545c1215c93067",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimationClip/index.rst.txt
            "7157e6836cb519242894005d369a9155",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimationsAimConstraint/index.rst.txt
            "b04155b52870d5b4198561eb3daac283",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimationsConstraintSource/index.rst.txt
            "77612856707fd10468a93d15d512f892",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimationsLookAtConstraint/index.rst.txt
            "71f4cc904f1eea545894f2f95fa3f5c3",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimationsParentConstraint/index.rst.txt
            "adfcfcdaba504d846a65febc2be19688",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimationsPositionConstraint/index.rst.txt
            "e5a439b9e1b126d4091b0a630d65339d",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimationsRotationConstraint/index.rst.txt
            "3de4dca97ad903d4483de9298b0b79d8",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimationsScaleConstraint/index.rst.txt
            "a39a2e051d91c164595edf1f6c500258",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimationState/index.rst.txt
            "1442bfd509ee1c542ad4d3a170a1df70",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Animator/index.rst.txt
            "53b94e40ef3ac314d82801141e040b59",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimatorClipInfo/index.rst.txt
            "488e0192736438b4187d683f1d2d1724",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimatorControllerParameter/index.rst.txt
            "ccee89517edd4f74094d380f743e8511",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimatorOverrideController/index.rst.txt
            "5c39c0082e3655343a56341e045fe0de",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimatorStateInfo/index.rst.txt
            "918518422f2b81a4983a8ad73cc8a407",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimatorTransitionInfo/index.rst.txt
            "89df5579bb4d3f64ab77439060c6da9c",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AnimatorUtility/index.rst.txt
            "f772e5600669fe5489e52f2ce5854e06",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AreaEffector2D/index.rst.txt
            "299a4bc470681cb44881ff48d80ec4ad",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AudioChorusFilter/index.rst.txt
            "422e9918760bd1441a4250d946f22278",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AudioClip/index.rst.txt
            "1c875ab676691a4439f6ca5ce48a6d05",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AudioDistortionFilter/index.rst.txt
            "367d928d7e1ea2a48a3cbf58d699019e",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AudioEchoFilter/index.rst.txt
            "e26a5ffe78ec0f148a3460d90c031c48",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AudioHighPassFilter/index.rst.txt
            "2b57174a8556f0742ad8ae2460064c85",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AudioLowPassFilter/index.rst.txt
            "d5da26f265184a64085009fa9e217f64",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AudioReverbFilter/index.rst.txt
            "c0911b8c64543474fbdbe585692ef5b4",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AudioReverbZone/index.rst.txt
            "178e7a7c3e43dea48bc9a5d6aecb67ed",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AudioSource/index.rst.txt
            "e76fe84d289c4ba4e83d55c03b8b02ae",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Avatar/index.rst.txt
            "5793ca30304b920419c9b628ea15437b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AvatarBuilder/index.rst.txt
            "1dd2c6a33ee8ec84b85f36f378240c09",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/AvatarMask/index.rst.txt
            "4b11415781af5d9489fc1fb9a61710a5",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/BillboardRenderer/index.rst.txt
            "6a7e413dd8e3aba42bcafc66a48cdacd",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Bounds/index.rst.txt
            "4c7344cddf8b60c4e8898d2a8ff17579",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/BoxCollider/index.rst.txt
            "3cad762c292daa7469efbce079621d5b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/BoxCollider2D/index.rst.txt
            "b839e20ad19c90247ab0f9854c2373b3",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Camera/index.rst.txt
            "a1652543ae01c2640a543062c76c3f1d",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Canvas/index.rst.txt
            "1fdca4e846f21104f88b1cf6ded8a982",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/CanvasRenderer/index.rst.txt
            "80728e0a641ab2b4a92d22674c96e20f",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/CapsuleCollider/index.rst.txt
            "8e149625bd07bc34896662bdf6380340",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/CapsuleCollider2D/index.rst.txt
            "2096c0ad5cea8924cbe8a134d291fac5",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/CircleCollider2D/index.rst.txt
            "a4692b11a364c6e4bbe98482de5028ac",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Collider/index.rst.txt
            "f54aff4401eb4d048a67042ec168e269",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Collider2D/index.rst.txt
            "90bf7da1c723f4d4ca06fdd7b3969cf2",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Collision/index.rst.txt
            "ddaffcbe18b86cc4ca14329ae99c7adb",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Collision2D/index.rst.txt
            "fb2a0c35bf1959040a373dcdf0ff8df3",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Color/index.rst.txt
            "30722b15cd1806f429c7254603a5c1fc",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Component/index.rst.txt
            "8aee2d4b0daec0b499a8484530cb2f61",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/CompositeCollider2D/index.rst.txt
            "8946f3d552605ed419772ed08e1ec621",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ConfigurableJoint/index.rst.txt
            "d69b0caeb0315c64bb68cb1a740b08dc",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ConstantForce/index.rst.txt
            "654de41c7e555b84d860c25cc23994e4",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ConstantForce2D/index.rst.txt
            "69d2840bc49c5d44b8a504abf3635770",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ContactPoint/index.rst.txt
            "4d1b3c56ed4ba3c409b24dd3eb47c551",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ContactPoint2D/index.rst.txt
            "10a4c19cf98e55144a95ee7fe9d9e75a",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Debug/index.rst.txt
            "0c05afc8ba8796241b44774e7ca8e99c",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/DistanceJoint2D/index.rst.txt
            "f85cf04c99afc8340acbe9a863c8d627",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/EdgeCollider2D/index.rst.txt
            "5a4387e9bf63f704998da06d5b1ec675",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Effector2D/index.rst.txt
            "812925a35b6db6641b2dbb6093386b7d",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ExperimentalAnimationsMuscleHandle/index.rst.txt
            "5d4e2e7ac9fc95f47924ebfab3da5510",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/FixedJoint/index.rst.txt
            "6608676f671f51540b7e1698bd39f9a1",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/FixedJoint2D/index.rst.txt
            "f7fddd03b1278d84f841e22dd620b018",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/FrictionJoint2D/index.rst.txt
            "7cd1cbb2616e6f145a668fddeaff72ed",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/GameObject/index.rst.txt
            "b415b599cc4ed91419072349a6d950f0",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Gizmos/index.rst.txt
            "8c3132316ba89ba43bccf77b09fb315a",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/HingeJoint/index.rst.txt
            "fa1ee89ec65b53e468b8406b28c53221",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/HingeJoint2D/index.rst.txt
            "ef3dd653ed25601488d04274941dfa00",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/HumanBone/index.rst.txt
            "ef59448d3e20e7d459763c7d078b0f94",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/HumanDescription/index.rst.txt
            "53754eaf8eaa4c94ba7aa6dbfd71e63b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/HumanLimit/index.rst.txt
            "fa1b5e73b4f1f8249ab75918a1755562",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/HumanPose/index.rst.txt
            "1e3c51a0730b5634e802512b114df87e",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/HumanPoseHandler/index.rst.txt
            "9e7b5e3d81aba68408ff058882bde565",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/HumanTrait/index.rst.txt
            "b82451f68ce664a4ba9a2c1ea4a7f60a",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Input/index.rst.txt
            "4d5bf19f64a3a6a4b82b51fceb56334d",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Joint/index.rst.txt
            "75732989dffae3d4999628d90d7d7f39",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Joint2D/index.rst.txt
            "628260598150fe34b904c77bcbcae424",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/LayerMask/index.rst.txt
            "98ea5834e708a9d4a8f60e70252e89c3",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Light/index.rst.txt
            "d2d3e008b906f79439f274889b6c6cbe",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/LineRenderer/index.rst.txt
            "e04b81b2601f1aa4d948a3d20265bf28",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/MatchTargetWeightMask/index.rst.txt
            "4514ba392b99fbc468be2305f50dd9c5",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Material/index.rst.txt
            "dee1496481bc6934291720c27287b85b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/MaterialPropertyBlock/index.rst.txt
            "716c54017dd018442ae2b391142b865b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Mathf/index.rst.txt
            "888a5a84ca5c54347a085d9ce7b258bc",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Matrix4x4/index.rst.txt
            "86bceee490a540b43a80e3564150f75d",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Mesh/index.rst.txt
            "bc55a6609145eb74fa8c16a29f4ed76e",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/MeshCollider/index.rst.txt
            "a2697ab58024fd84d800bdbf8d28e476",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/MeshFilter/index.rst.txt
            "bcfdc8b2ac4abeb4683616ecc50a5ea0",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/MeshRenderer/index.rst.txt
            "ea4f371e57846914590beb2d8eb86dce",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Motion/index.rst.txt
            "2dfb000453051c84e8b7dd3ff8d091af",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Object/index.rst.txt
            "1dd441631e8d4f043905c0ebddbc444c",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystem/index.rst.txt
            "c4ec21480a7ca4043a87c1ce497c8f06",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemBurst/index.rst.txt
            "83473eaddc3637f4f9c64bd36d209bc3",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemCollisionModule/index.rst.txt
            "c577b3d04353e0943be4a81fbd8c0194",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemColorBySpeedModule/index.rst.txt
            "f9a268381171cb94aa6f616e724f57de",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemColorOverLifetimeModule/index.rst.txt
            "35be3cb42429b08488fc1ac6981d436f",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemCustomDataModule/index.rst.txt
            "bd409d31be556734987d2860de1351de",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemEmissionModule/index.rst.txt
            "24cf10b8f1147dd43ad71b31690779c2",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemEmitParams/index.rst.txt
            "7499d3c3462dccc4e91e2f90d5bbf265",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemExternalForcesModule/index.rst.txt
            "f094c57b354c2264d9c3a99d02e44d39",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemForceOverLifetimeModule/index.rst.txt
            "035564775b6e9f046b94c85e21a96abe",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemInheritVelocityModule/index.rst.txt
            "f881ee728c2faef43961a7c4a243f186",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemLightsModule/index.rst.txt
            "81cc380b2440eb9488c991a1c16ee5a2",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemLimitVelocityOverLifetimeModule/index.rst.txt
            "e5e194839568c7242bca842da210eaf3",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemMainModule/index.rst.txt
            "6a819b703938c2649b17d79a9e9736ac",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemMinMaxCurve/index.rst.txt
            "8055968cae30f9d42b77d73cd5b9d6f3",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemMinMaxGradient/index.rst.txt
            "c501ae96ac309ff4ab3e6cffcc387ad6",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemNoiseModule/index.rst.txt
            "fd1e559a735e1fe4ba2853b65d0b6309",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemParticle/index.rst.txt
            "9e5617a47caae5440822100df2792d7d",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemRotationBySpeedModule/index.rst.txt
            "3c650766d74f60048a1dfc4a5f3e2402",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemRotationOverLifetimeModule/index.rst.txt
            "e81d7639273df3e4e9291253d8c80e37",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemShapeModule/index.rst.txt
            "9cef583594939e1439612faf5792a298",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemSizeBySpeedModule/index.rst.txt
            "7680620fc828ac74ab11f863de764370",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemSizeOverLifetimeModule/index.rst.txt
            "80f5cd3e6f6c85040b9487ca5d234619",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemSubEmittersModule/index.rst.txt
            "50257978b46a39b4ea760e13c6027bcc",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemTextureSheetAnimationModule/index.rst.txt
            "d564310ec25fe3c4bb1cb6a6ef226cfe",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemTrailModule/index.rst.txt
            "22c6f764d70948b44903c884f38bdde0",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemTriggerModule/index.rst.txt
            "f34649253f33cee42a547873780b284d",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/ParticleSystemVelocityOverLifetimeModule/index.rst.txt
            "37fbf68bff6fe784fa92e2dbf7e652f9",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/PhysicMaterial/index.rst.txt
            "2a5e28294df0a3346b3235deef014a08",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Physics/index.rst.txt
            "06a68096a835cd3429f4bf3126d20899",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Physics2D/index.rst.txt
            "140e2a5c2350dc94d9a98a4703c1a467",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/PhysicsMaterial2D/index.rst.txt
            "489f69ed802d7a84f954871c7569c0c9",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/PlatformEffector2D/index.rst.txt
            "09d1e7d5e7f807745ab33e2aed109f21",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/PointEffector2D/index.rst.txt
            "5da2adfb21e5aee48abf036fc24186ac",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/PolygonCollider2D/index.rst.txt
            "4cdff6a799490e24ebb86f8af4fa36f9",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/QualitySettings/index.rst.txt
            "568c0f2e43198674aa30096369b70881",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Quaternion/index.rst.txt
            "f7c007b0b3a77d44d98850cbdf49e942",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Random/index.rst.txt
            "c6650dd6439957c439fd7cda063373e7",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Ray/index.rst.txt
            "ceee931b4fef7c4429ee74af6b5374e7",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/RaycastHit/index.rst.txt
            "2a953da7d792ce74ca23bfca813c9165",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/RaycastHit2D/index.rst.txt
            "b30fd2e645984744d8bf8972d908e221",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/RectTransform/index.rst.txt
            "fcd31a510fb9ba64ea3086ab0994665c",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/RelativeJoint2D/index.rst.txt
            "19ac127e3f61c854cacd8a040b40655a",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Renderer/index.rst.txt
            "ec2ce1fe3400d724daef3eb96032ad6b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/RendererExtensions/index.rst.txt
            "4b74aa48cab68484497b9afad966be3a",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/RenderSettings/index.rst.txt
            "be9161289a9b22a42adc186e108d35a5",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Rigidbody/index.rst.txt
            "b4ae198b33519544fa7ec4333319af4c",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Rigidbody2D/index.rst.txt
            "794844485a22037498a671d43257b802",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/RuntimeAnimatorController/index.rst.txt
            "a63a3d4bfb378294099fa76ee5205337",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/SkeletonBone/index.rst.txt
            "431722df1e6b10441beef3b7a4ee4dea",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/SkinnedMeshRenderer/index.rst.txt
            "7adf1ad6e39c1624b80c25c2d0783600",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/SliderJoint2D/index.rst.txt
            "3ee7259edc8a5664ba186f47162ef364",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/SphereCollider/index.rst.txt
            "67715780e508b4e4087d8534ea332c1b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/SpringJoint/index.rst.txt
            "6147d659431ef39469d996da5e02be74",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/SpriteRenderer/index.rst.txt
            "8f02662a135f2354eb461befa2a2372c",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/SurfaceEffector2D/index.rst.txt
            "52ed798af40f64149bb02a6486a684b7",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/TargetJoint2D/index.rst.txt
            "cbd25f00dd6c81c438d1e65b64aef918",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/TextAsset/index.rst.txt
            "8719db817787fff419d0f52b51888d2f",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Time/index.rst.txt
            "1e2d8d5ffba9870459745b9c3ff97f0a",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/TrailRenderer/index.rst.txt
            "4f05355b658da014f82867956b0f73d0",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Transform/index.rst.txt
            "c78749ac6eedca047a927e64a6524fcd",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIAnimationTriggers/index.rst.txt
            "bd1437e8ab094084e8c309115f2076d5",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIAspectRatioFitter/index.rst.txt
            "ef55345b36086e642885012eb7b818fe",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIBaseMeshEffect/index.rst.txt
            "1aad8cf2d92f976418c0697d10adcf4e",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIButton/index.rst.txt
            "149f67677659cb84d9da6d2c56d05192",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIButtonButtonClickedEvent/index.rst.txt
            "9029ea1af9c99ff40b01834b1e2b3480",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UICanvasScaler/index.rst.txt
            "570f86b3b5741c04a91d1dc28b81370e",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIClipping/index.rst.txt
            "3e24032bc4698264aa22113b2bbf6876",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIColorBlock/index.rst.txt
            "77489b99307bb7f48a43820014058a15",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIContentSizeFitter/index.rst.txt
            "110c9518057b4c0458e08db139dd3d08",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIDefaultControls/index.rst.txt
            "46869a96aa510ce468a001834b3995ea",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIDefaultControlsResources/index.rst.txt
            "ee737c9a3f38a4042bc7ac86dbad85d4",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIDropdown/index.rst.txt
            "83bb10bd7c348174897432e035e6f2ab",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIDropdownDropdownEvent/index.rst.txt
            "5d740b6e74d432743b1fac17f6f794be",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIDropdownOptionData/index.rst.txt
            "24e3bd6698e781543b07597fc161b339",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIDropdownOptionDataList/index.rst.txt
            "ef359a668b6e95242884e871d6a9f6f3",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIFontData/index.rst.txt
            "1baf2d9ef0e55ea4da652265a7b6b4da",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIGraphic/index.rst.txt
            "c8239b05086707845bb977a6b03dddb4",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIGraphicRaycaster/index.rst.txt
            "8e64616b88987be4aaf533473bc2b498",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIGridLayoutGroup/index.rst.txt
            "3b98ca11d6de2b845b4e7fc7e3bc4d22",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIHorizontalLayoutGroup/index.rst.txt
            "c88137867d57a4e47b72ba7b172426f1",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIHorizontalOrVerticalLayoutGroup/index.rst.txt
            "9d925b2dc2b332547928bb61df0d7746",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIImage/index.rst.txt
            "3e5a01b9925da8944a9734988e77f930",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIInputField/index.rst.txt
            "c794cd1112851ed4bb218cb7658d86c7",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIInputFieldOnChangeEvent/index.rst.txt
            "b8cd30789105d90488ef4133fa4df421",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIInputFieldSubmitEvent/index.rst.txt
            "78ca532da974a37488a6f288f26c3ed8",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UILayoutElement/index.rst.txt
            "57473adc7489cb34aaf435b6820cd8ab",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UILayoutGroup/index.rst.txt
            "021b32e68290ca340a82607601fb6167",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UILayoutRebuilder/index.rst.txt
            "523dfde51f041be4596fe4fc258c89e6",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UILayoutUtility/index.rst.txt
            "32775f4fb893e8444b9c58596aa969f6",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIMask/index.rst.txt
            "88988ebbd0cf9e54da99c657d86334fa",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIMaskableGraphic/index.rst.txt
            "064f44847159be04091f5a1f58070e61",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIMaskUtilities/index.rst.txt
            "3913322a23b418f458828016b9fc1eee",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UINavigation/index.rst.txt
            "24f30bee3d40f3c4bb7e21697fa85387",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIOutline/index.rst.txt
            "8c655ae9ae6af39488aff61ae1560871",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIPositionAsUV1/index.rst.txt
            "5ddce4a3c0a94c346afcba5153d400ab",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIRawImage/index.rst.txt
            "fd3c10f68669afd4183d06a0ef786093",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIRectMask2D/index.rst.txt
            "1d05d67abe151144aad044185a0fd62e",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIScrollbar/index.rst.txt
            "b71591cd01b3e5946b94559cc8e9d703",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIScrollbarScrollEvent/index.rst.txt
            "ce144bf40db26ed4a85a7d0323523b50",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIScrollRect/index.rst.txt
            "601db346a4cae7544a7cb2443ca68e76",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIScrollRectScrollRectEvent/index.rst.txt
            "2129f74ada0081a40a041f0d5a9d36d0",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UISelectable/index.rst.txt
            "1485b2568a924fa43a01f794ca7c3b59",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIShadow/index.rst.txt
            "70d98844a1ec4cd45a590a59bd9f8eee",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UISlider/index.rst.txt
            "262a6749fcc27224a94924d84b54ed67",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UISliderSliderEvent/index.rst.txt
            "f8e01d33fa5411a4eb28be886e3fa79a",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UISpriteState/index.rst.txt
            "ffc3d48732570ea4a863f64e804b06dd",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIText/index.rst.txt
            "30690ecd908d0ba46b534c4d34229a2b",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIToggle/index.rst.txt
            "b51368ee60bc4df4680d5fe169039f18",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIToggleGroup/index.rst.txt
            "5fb1a7c6277099e4eb9163280e7e4019",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIToggleToggleEvent/index.rst.txt
            "bfd5624f63360ac49935f864a26103d1",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIVertexHelper/index.rst.txt
            "62efbd1dc91062346b277114eb4f79d9",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/UIVerticalLayoutGroup/index.rst.txt
            "d0b55e54a1ade1f4fa090a5b1b5e1d02",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Vector2/index.rst.txt
            "0ad08dd97cf95f744b47dd79d1e1bf77",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Vector3/index.rst.txt
            "13bd99a2f84f0ae4a844691920470498",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/Vector4/index.rst.txt
            "7daf90a8e662816439d2994bdf29a367",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/WheelCollider/index.rst.txt
            "f90a0b3a0d7efb2498aea460fb6a0196",  // Assets/Udon/ReferenceDocs/_sources/nodes/UnityEngine/WheelJoint2D/index.rst.txt
            "a7579995c9a96e146abbe26ee7023409",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRC/index.rst.txt
            "9cc1d4d02117d1f4693f6c484af8563b",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRC/Instantiate/index.rst.txt
            "aa6c0185976e45545bdfbed832d442bc",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/index.rst.txt
            "45d3176e8f3d1354198b482dae1197ef",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/ComponentsTrackingData/index.rst.txt
            "d39ee082ffe9fd948bc38685ff18893c",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/ComponentsVRCAvatarPedestal/index.rst.txt
            "cb0083e6780d2f2429f06f40da5eaa1b",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/ComponentsVRCMirrorReflection/index.rst.txt
            "d74d268398c9c3142ac7329441aebb85",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/ComponentsVRCPickup/index.rst.txt
            "6a29b6f42ab9add4287cd003f3a81485",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/ComponentsVRCPortalMarker/index.rst.txt
            "465008e11f984904c8c1e5bd5c41a672",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/ComponentsVRCStation/index.rst.txt
            "558ad20173fab0e439a0f732b83531bd",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/VRCSDKBaseInputManager/index.rst.txt
            "c0003e1bbf1e99c42b4e8409056e07ec",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/VRCSDKBaseNetworking/index.rst.txt
            "485d2ad296becb5478e9639391251b3e",  // Assets/Udon/ReferenceDocs/_sources/nodes/VRCSDK3/VRCSDKBaseVRCPlayerApi/index.rst.txt
            "e46bdd45e5b42ea49bdf7d69f1837426",  // Assets/Udon/ReferenceDocs/_static/basic.css
            "17e343820a83eac4ca6b849fc0f0993f",  // Assets/Udon/ReferenceDocs/_static/doctools.js
            "455b6455c7a4a0b4d95b2d11b5fd1364",  // Assets/Udon/ReferenceDocs/_static/documentation_options.js
            "7f6ca0ee9d10d7d4da94d7d16f2d6eab",  // Assets/Udon/ReferenceDocs/_static/file.png
            "9f9fca788822d57458584aac0824c6f1",  // Assets/Udon/ReferenceDocs/_static/glpi.css
            "f34239773db556f41a100e54edb6c0ff",  // Assets/Udon/ReferenceDocs/_static/jquery-3.4.1.js
            "24201a4b83fbae14bb2fd8e405e67217",  // Assets/Udon/ReferenceDocs/_static/jquery.fancybox.min.css
            "aae75c2781a58f542868b8b86ec348be",  // Assets/Udon/ReferenceDocs/_static/jquery.fancybox.min.js
            "6a2c238ce4a4fb44e8b1efb7e8f89500",  // Assets/Udon/ReferenceDocs/_static/jquery.js
            "09034fa4b481f824e99c4661ceaac86d",  // Assets/Udon/ReferenceDocs/_static/language_data.js
            "fdab9985a13099e479941f0a47eca70e",  // Assets/Udon/ReferenceDocs/_static/minus.png
            "669be1803c5a0a04391d3e0c3105c418",  // Assets/Udon/ReferenceDocs/_static/plus.png
            "1ce9d1e7501bfa449ac0d7d716ecd377",  // Assets/Udon/ReferenceDocs/_static/pygments.css
            "9267d901678a38045a1b52d1ebe64421",  // Assets/Udon/ReferenceDocs/_static/searchtools.js
            "57b717769c0f5c046ac96a7b9faf3e3b",  // Assets/Udon/ReferenceDocs/_static/underscore-1.3.1.js
            "832acbf018ac87e4293111e55828bc68",  // Assets/Udon/ReferenceDocs/_static/underscore.js
            "a21b0262f2088e844a0382f9ab317e2e",  // Assets/Udon/ReferenceDocs/_static/css/badge_only.css
            "17d316ac4af30b640939501f1dc2f310",  // Assets/Udon/ReferenceDocs/_static/css/theme.css
            "958b822f881cee94fa3ce9e448ce0163",  // Assets/Udon/ReferenceDocs/_static/fonts/fontawesome-webfont.eot
            "7b0e2552919dc70488a6d4a342b928a5",  // Assets/Udon/ReferenceDocs/_static/fonts/fontawesome-webfont.svg
            "6cb934e9a1d9ea6448040aad7dbeac81",  // Assets/Udon/ReferenceDocs/_static/fonts/fontawesome-webfont.ttf
            "157434a595e08d248a65d0700ba86a66",  // Assets/Udon/ReferenceDocs/_static/fonts/fontawesome-webfont.woff
            "7facddc01811f7b4aae49393880e1384",  // Assets/Udon/ReferenceDocs/_static/fonts/fontawesome-webfont.woff2
            "452f7d8d1a7418943b69d2df35655ebe",  // Assets/Udon/ReferenceDocs/_static/fonts/Inconsolata-Bold.ttf
            "e3027d149d2f75647b130d9ed7f7014c",  // Assets/Udon/ReferenceDocs/_static/fonts/Inconsolata-Regular.ttf
            "d8a7948bc83b01f45ab5078c10dd8e04",  // Assets/Udon/ReferenceDocs/_static/fonts/Lato-Bold.ttf
            "98baae691215eb546a697ff7d942a5bb",  // Assets/Udon/ReferenceDocs/_static/fonts/Lato-Regular.ttf
            "79f72428ef5a94f44a224932dfc8bc22",  // Assets/Udon/ReferenceDocs/_static/fonts/RobotoSlab-Bold.ttf
            "f23c08f75b40f494b9b74462d7310dfb",  // Assets/Udon/ReferenceDocs/_static/fonts/RobotoSlab-Regular.ttf
            "3aaee8d59be89024aaf6ddeb191374ff",  // Assets/Udon/ReferenceDocs/_static/images/glpi.png
            "2f81dd9a21f155b48929d8e1eaef7941",  // Assets/Udon/ReferenceDocs/_static/js/modernizr.min.js
            "93bdb8f1738ae5649aa3cf3d60e181e7",  // Assets/Udon/ReferenceDocs/_static/js/theme.js
            "b1d0b8aa8084bcd44a572d524d7a31bb",  // Assets/Udon/Serialization/Formatters/UdonGameObjectComponentReferenceFormatter.cs
            "f2626352b2a60eb41adc3580ae44c750",  // Assets/Udon/Serialization/Formatters/UdonProgramFormatter.cs
            "ec4e6da38017fe7df076afceb30fa17c",  // Assets/Udon/Serialization/OdinSerializer/LICENSE
            "2105a6c0e5c0955d2d4a704c5e9c9b8f",  // Assets/Udon/Serialization/OdinSerializer/Version.txt
            "f70a94b0bedfa8ec50ed757f72032810",  // Assets/Udon/Serialization/OdinSerializer/VRC.Udon.Serialization.OdinSerializer.asmdef
            "bfaf18dca1f68cc99ebeb0b862179265",  // Assets/Udon/Serialization/OdinSerializer/Config/GlobalSerializationConfig.cs
            "4ac1e1612275111bd50db8a3de8ba9c4",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/BaseDataReader.cs
            "501a7e1356f5fdc8e9bbefcd61a56490",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/BaseDataReaderWriter.cs
            "9638b18c6b6b6532b3b3cd3a73fefc2a",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/BaseDataWriter.cs
            "dc1fe25e670cf981ed66b3e85c3e4249",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/IDataReader.cs
            "af6696e41807b3c3f9a1d73667f76701",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/IDataWriter.cs
            "ee0465a1838833eb878447b34339d4f4",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/Binary/BinaryDataReader.cs
            "1bc9e2503afdd0290574ebc14cf4a16d",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/Binary/BinaryDataWriter.cs
            "1361420bc2b384389a065fd2fe59fb22",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/Binary/BinaryEntryType.cs
            "7a3a6dce9e0b8317b3804b35f48f6a97",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/Json/JsonConfig.cs
            "2ecc39ef0dc55ec10f83bb7eefd4f1db",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/Json/JsonDataReader.cs
            "3e05b98a26be61fa9203d4a45bfc1e95",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/Json/JsonDataWriter.cs
            "aad0a34e801ae645b359e4800ef7f636",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/Json/JsonTextReader.cs
            "6a0f5e01b82ae0763f6f907157a2c9c8",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/SerializationNodes/SerializationNode.cs
            "eab5938e837a8de93ce64c25399edde6",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/SerializationNodes/SerializationNodeDataReader.cs
            "9321fb650525f4bed18119d187111569",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/SerializationNodes/SerializationNodeDataReaderWriterConfig.cs
            "dd54f07c359d141095a031192c5ca084",  // Assets/Udon/Serialization/OdinSerializer/Core/DataReaderWriters/SerializationNodes/SerializationNodeDataWriter.cs
            "0bdecd79f568c8a3252bb5a9f3e2acdc",  // Assets/Udon/Serialization/OdinSerializer/Core/FormatterLocators/ArrayFormatterLocator.cs
            "c4228cdbba89e2a5d52357b998c3387d",  // Assets/Udon/Serialization/OdinSerializer/Core/FormatterLocators/DelegateFormatterLocator.cs
            "cf715e98fa96d74c81b4d3f4491d2592",  // Assets/Udon/Serialization/OdinSerializer/Core/FormatterLocators/FormatterLocator.cs
            "d35d0d1eb290f5d00e273d65e5db09d7",  // Assets/Udon/Serialization/OdinSerializer/Core/FormatterLocators/GenericCollectionFormatterLocator.cs
            "f2a9beaeecdd6eb929ddb049d7846a14",  // Assets/Udon/Serialization/OdinSerializer/Core/FormatterLocators/IFormatterLocator.cs
            "cdd12b278851bfdc68ca0d9e1e4f2d28",  // Assets/Udon/Serialization/OdinSerializer/Core/FormatterLocators/ISerializableFormatterLocator.cs
            "876ae9a404abe412e663fd9bc03d3525",  // Assets/Udon/Serialization/OdinSerializer/Core/FormatterLocators/SelfFormatterLocator.cs
            "00e10f526d476731ebc596ceb66271a6",  // Assets/Udon/Serialization/OdinSerializer/Core/FormatterLocators/TypeFormatterLocator.cs
            "9aaf14140a26e04b861b027d5ddb8fb6",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/ArrayFormatter.cs
            "3f5dc00eb17e568de42119a7f0f30ee8",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/ArrayListFormatter.cs
            "9598679c29f3e3696941746c26f1ccf8",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/BaseFormatter.cs
            "dff51bfb9b4d71aa78b3e5c8fec8c924",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/DateTimeFormatter.cs
            "3480954e7eecdc9745c1d08721b2f8b3",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/DateTimeOffsetFormatter.cs
            "4f17b17e986ae6f3be6a2ea1b716fcaf",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/DelegateFormatter.cs
            "4402da708267c579874c808a813bfe62",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/DerivedDictionaryFormatter.cs
            "b80567603fe814a8b4341584f8c3b4a6",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/DictionaryFormatter.cs
            "5c21ee7e54dff531da57563e2f81fff5",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/DoubleLookupDictionaryFormatter.cs
            "54578488936f8484c97ba7c52bfb0563",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/EasyBaseFormatter.cs
            "e226537cbfa910681132da3718f41c34",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/EmittedFormatterAttribute.cs
            "149c482b2ab9c601b8bc2ecc20bbd8d9",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/EmptyTypeFormatter.cs
            "b7da6bf97199e0bb743f7639c17112ac",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/FormatterEmitter.cs
            "06ccb8250c692f2695d28bfd6bcd4273",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/GenericCollectionFormatter.cs
            "f1eaa1b43658215b6d81013928eac19e",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/HashSetFormatter.cs
            "0fcb040f1c493dc2a5224e446be8b3c9",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/IFormatter.cs
            "5cae1c5d1116a090d70b6d0289061d21",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/KeyValuePairFormatter.cs
            "ba4ee6777a44f6e9a8e2e0a222c0f7db",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/ListFormatter.cs
            "21078ce134ce87231526dee77088e7ab",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/MethodInfoFormatter.cs
            "ae604bc0ef4ef9938100804f05decb21",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/MinimalBaseFormatter.cs
            "dc1b5b3148988d0d4fc2dab60a5c146c",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/MultiDimensionalArrayFormatter.cs
            "f9ea00de8051ca957d994e11630671d9",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/NullableFormatter.cs
            "6b6a62ea2fe943a4b261f832e8a1f3dd",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/PrimitiveArrayFormatter.cs
            "8045e4edca7c27f5b16bd90d7101c935",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/QueueFormatter.cs
            "15fa864c9e3363220ceac4ec93c7f5b8",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/ReflectionFormatter.cs
            "dde0095df6bea6624dfa72a31127bc48",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/ReflectionOrEmittedBaseFormatter.cs
            "12a47dd574302b77ba3c5ac05cd04541",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/SelfFormatterFormatter.cs
            "0f59404c810d015ed87c7e1557188435",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/SerializableFormatter.cs
            "087303d0d43cf7ce5af060a0cc0b5d38",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/StackFormatter.cs
            "4b0676b49f03cc50a1e532cf23e3988e",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/TimeSpanFormatter.cs
            "c6529471b992ba4080a123aa504ef9ea",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/TypeFormatter.cs
            "4a7c8e71a3ef1124db10e72af34e1724",  // Assets/Udon/Serialization/OdinSerializer/Core/Formatters/VersionFormatter.cs
            "23fa5d3fed3b4b9de502257a594b00de",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/AllowDeserializeInvalidDataAttribute.cs
            "92726834b08002d525b86fbb012e184f",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/AlwaysFormatsSelfAttribute.cs
            "72783638708ea644ba5c3e1b91f827f6",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/ArchitectureInfo.cs
            "ad4e17831e9503c1f11149997c609477",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/Buffer.cs
            "e7e73146f1e861c27c5608bff4142402",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/CachedMemoryStream.cs
            "4fd6ff4077bbbef9b366d8ffd9236173",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/CustomFormatterAttribute.cs
            "e02123fad495d06f2a89e5335f00126c",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/CustomGenericFormatterAttribute.cs
            "97e9e01eb36fd43879b166b6b3c2469b",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/CustomLogger.cs
            "95bb5531b6c1d1a5eab8400ea1bd6167",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/CustomSerializationPolicy.cs
            "c2a40a3e6a114e5a50c0af209b8ae35e",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/DataFormat.cs
            "0bd9ab6cf3bd913588b6652279b7a6ba",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/DefaultLoggers.cs
            "996e793dcc0920d2590cb61f0761d498",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/DefaultSerializationBinder.cs
            "c79df97337d89089be40beb2e272df0b",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/DeserializationContext.cs
            "ae849a3e6d277006f3b4dd58a5765955",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/EmittedAssemblyAttribute.cs
            "3b06b106636f38afbb25ddd11e0c597c",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/EntryType.cs
            "c73435dff291e72c0d9ce55b59c39145",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/ErrorHandlingPolicy.cs
            "df06475ac5299f402ca1bdee3cf7e702",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/ExcludeDataFromInspectorAttribute.cs
            "08528593c8dd764b6d928dcee6daca9f",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/FormatterLocationStep.cs
            "30194d27b77855bf09b9af809a761ca5",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/FormatterUtilities.cs
            "32f94aca65b8d09ddd7b3db72e08db3f",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/IAskIfCanFormatTypes.cs
            "7ef6b6dd5e3be66c3a66753cc7e799de",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/IExternalGuidReferenceResolver.cs
            "d1eaa1a505a876bebb9cad40d01989e9",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/IExternalIndexReferenceResolver.cs
            "9414cf6a3ea9a51afcf648fe9ea02bed",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/IExternalStringReferenceResolver.cs
            "8bab352682356b8a2b02842520a68a11",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/ILogger.cs
            "106ca47adfa52732b129015337a1c8cd",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/ISelfFormatter.cs
            "90bcbfdc0286ca48d51fc578a1e15b8f",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/ISerializationPolicy.cs
            "7de3f23805ad9d4b3d033eef45e3b59b",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/LoggingPolicy.cs
            "10eb7be2b7c363367c46bc5699a361a8",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/NodeInfo.cs
            "766bbafe64ad16f63af4b81eb430e380",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/OdinSerializeAttribute.cs
            "3db8c00661ec222984427ab12295940f",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/PrefabModification.cs
            "23ceed712f987034deb8e92c561a1d3b",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/PrefabModificationType.cs
            "96fec6c04f13e378def42ea5ad5dc940",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/PreviouslySerializedAsAttribute.cs
            "989e99cd5b8f922edc1b13bbc22f4289",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/ProperBitConverter.cs
            "82702718797409c332f9174bdad57bbc",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/RegisterFormatterAttribute.cs
            "a000ffc63858a974eb63d9ef6f91adac",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/RegisterFormatterLocatorAttribute.cs
            "dca124a461001ad1494664ed95539612",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/SerializationAbortException.cs
            "eba33c8e77e2084c660af46be1b547dd",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/SerializationConfig.cs
            "1e93880e733f9a6a084cf4061634e7fb",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/SerializationContext.cs
            "67a19021ff9e6b27d8e9257ad075055a",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/SerializationPolicies.cs
            "08607b6e9c39ec19c1b61341583c2f3e",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/SerializationUtility.cs
            "bc69d8fd9d15913a491a45d1e040faf6",  // Assets/Udon/Serialization/OdinSerializer/Core/Misc/TwoWaySerializationBinder.cs
            "0e8d8c5a97fdc322a8b8471aaf02f469",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/BooleanSerializer.cs
            "8aa9f52771b0e4e6f8f0c438a4f0430b",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/ByteSerializer.cs
            "d44d1ae83013328d7b855275fa1cfad7",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/CharSerializer.cs
            "5a2a43b51cef79fd0e85028650394b55",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/ComplexTypeSerializer.cs
            "50c67937d611e4749188b838e4cff5dc",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/DecimalSerializer.cs
            "9fc4716f683bc313c24bfa537cdd97f6",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/DoubleSerializer.cs
            "7a5d23b139cd8e692702aa431b071d07",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/EnumSerializer.cs
            "19dcfa9f6a40979fc2b6c3ae0f24b67c",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/GuidSerializer.cs
            "d280b44f7c75a9a18484a84745998130",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/Int16Serializer.cs
            "eafebb70813195e03b1ba467931eb686",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/Int32Serializer.cs
            "afe45c48508431a62aba886d943d8501",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/Int64Serializer.cs
            "6ccaffe3090611c2ada67d49cf834771",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/IntPtrSerializer.cs
            "88f3ec418fdfdd7eabd6134f1de91991",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/SByteSerializer.cs
            "29261eaea99f2d34c42cdc0b04f95daa",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/Serializer.cs
            "7aa356971fd0b66eb59875b278fa7f03",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/SingleSerializer.cs
            "85996580a8691185d06ec342c5c43747",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/StringSerializer.cs
            "3936194ea64890e11a7db8474eb0bbcf",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/UInt16Serializer.cs
            "f30e426f88b471e498dd1853b7bbaee6",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/UInt32Serializer.cs
            "f55c085325e12800428d01e3535cb297",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/UInt64Serializer.cs
            "0ee9dd19c234e4b16c835b9188459e36",  // Assets/Udon/Serialization/OdinSerializer/Core/Serializers/UIntPtrSerializer.cs
            "94a6cc2044fcd2cb317b1cdb1e8fcdaf",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/AOTSupportScanner.cs
            "f5fe153775edbadfa2b659e0e35dc881",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/AOTSupportUtilities.cs
            "aaf2f90207414827b53b85dae0eae82e",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/OdinPrefabSerializationEditorUtility.cs
            "de5584f66ccc5e072681a310c5987b8c",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/UnityReferenceResolver.cs
            "f670c1f9aa9ab0c5988e81802c005767",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/UnitySerializationInitializer.cs
            "9eb15f2339819bb651c7872d73c89776",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/UnitySerializationUtility.cs
            "864fb1c011715f9df2998d71ac8716f6",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/DictionaryKeySupport/BaseDictionaryKeyPathProvider.cs
            "ef6f699f176c2dfdea788982526f989a",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/DictionaryKeySupport/DictionaryKeyUtility.cs
            "b513c156933d8b833ccd40d717bf7e2b",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/DictionaryKeySupport/IDictionaryKeyPathProvider.cs
            "54f653ed4a4e15c07057283c11dce4d9",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/DictionaryKeySupport/RegisterDictionaryKeyPathProviderAttribute.cs
            "0405ef103432161dff609e75f71f3f55",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/DictionaryKeySupport/Vector2DictionaryKeyPathProvider.cs
            "1d61e235c606c1c9d7269f7e68471e38",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/DictionaryKeySupport/Vector3DictionaryKeyPathProvider.cs
            "51bb2cf369b5ea90948a20e4f2ebae48",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/DictionaryKeySupport/Vector4DictionaryKeyPathProvider.cs
            "3d2976bd61cccf62b11b4d3f02762465",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/AnimationCurveFormatter.cs
            "6ff1b29d64402a15d020739becd8661e",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/BoundsFormatter.cs
            "0878ec68b6ab3c9ebc365b6d139e4840",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/Color32Formatter.cs
            "25e35581ce6d1febd9ac41864a76ecdb",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/ColorBlockFormatter.cs
            "484768ba343a6a05522c29d81a4ce61d",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/ColorFormatter.cs
            "c3968bef792c5668478ac01be7645b30",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/CoroutineFormatter.cs
            "b5b415c00da8157ac50b8f5543f0b1d9",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/GradientAlphaKeyFormatter.cs
            "8936a3e43078251682f18923139f7aee",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/GradientColorKeyFormatter.cs
            "d5b54660d5342fd45e2e43775538879d",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/GradientFormatter.cs
            "68ac0b27f571616d3ed26c23eef40c8c",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/KeyframeFormatter.cs
            "afc596cd95a1ac316024d16f6fec6536",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/LayerMaskFormatter.cs
            "558323987bf9b75943382a5faa093ee3",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/QuaternionFormatter.cs
            "196809b991e565a48e3d4ad08cb30b5e",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/RectFormatter.cs
            "c934302874ac3315ed322feefefa1f9c",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/UnityEventFormatter.cs
            "70c675a7b4c71c685ee39d745ccb058b",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/Vector2Formatter.cs
            "da2644647af1368176103aa87de1dbaf",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/Vector3Formatter.cs
            "60afa8ede3981c383782a01ddc55e943",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/Formatters/Vector4Formatter.cs
            "ff1ca109149d83b03b39644f8045275e",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/IOverridesSerializationFormat.cs
            "8942002e9ac41c2bfd27c4fbedf93f09",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/IOverridesSerializationPolicy.cs
            "7279ec8ad7837f13ec833193ab4282cc",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/ISupportsPrefabSerialization.cs
            "ea095023abd05a7af0da4166dcefdee8",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/SerializationData.cs
            "c3cecb461cebbc940ede3b5ddb72382e",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/SerializedBehaviour.cs
            "56b88cfe9935184fe250bda018144f26",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/SerializedComponent.cs
            "d1b9fa6342beb9fdfc2c4bc1d8e5e971",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/SerializedMonoBehaviour.cs
            "6cb9325ffffee5d6ed94d71590b4049a",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/SerializedScriptableObject.cs
            "eefcd68a84ee7903b08c6254c17fafe3",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/SerializedStateMachineBehaviour.cs
            "d62f7ab4e5aa075b819d6c71e929686b",  // Assets/Udon/Serialization/OdinSerializer/Unity Integration/SerializedUnityObjects/SerializedUnityObject.cs
            "78ce67c0b3c1975c520a08d1ff9fd24e",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/FieldInfoExtensions.cs
            "068f5645a5c3f9ce36a580ec57e775d1",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/GarbageFreeIterators.cs
            "0f84614827ff91701149564447a3932b",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/LinqExtensions.cs
            "62088a9c188c943eb4035de16eb6ec32",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/MemberInfoExtensions.cs
            "63a9a0384a6fe66fb04f82f325895b30",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/MethodInfoExtensions.cs
            "1df9513f03131466eecad22d1b19c4d8",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/Operator.cs
            "da8aea12015a2df5402c9e2d4f1cec5c",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/PathUtilities.cs
            "7f13450d6fd82372ffa7ee075a8eb4c9",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/PropertyInfoExtensions.cs
            "b554cbd9469011b544a2d92ae85a3b60",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/StringExtensions.cs
            "a6a172cef14a88c7fb714df37bbecedb",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/TypeExtensions.cs
            "eb77f5278e425e91b71e186df29a5f16",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Extensions/UnityExtensions.cs
            "787c97af872124f748a4a9b366f325d3",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/AssemblyImportSettingsUtilities.cs
            "146b6bd1e3b0f0926205abf839ec9e6f",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/Cache.cs
            "1bd625694c606aab0cb7895da4911c6a",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/DoubleLookupDictionary.cs
            "bda92ec6156282448e883bf8f6a781fd",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/EmitUtilities.cs
            "570028979953bd2c60b7e89ff7cef92e",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/FastTypeComparer.cs
            "42e5d977e21c7a6524213a8a7dbee24a",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/Flags.cs
            "783316da32d87acfae14953e341732a3",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/ICacheNotificationReceiver.cs
            "1bc635f3755c60fe69f1895dd53974e2",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/ImmutableList.cs
            "000592e93b119574207ea3bf59f659e4",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/MemberAliasFieldInfo.cs
            "c1e85c1ef449ccb40e05f0afd3dd717f",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/MemberAliasMethodInfo.cs
            "00bf47593f2a330c1bb41552bdc1233f",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/MemberAliasPropertyInfo.cs
            "5ad884ed6013d621a310ceb4c954f62a",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/ReferenceEqualityComparer.cs
            "0fe3820fb4651e200f17905245ec8be2",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/UnityVersion.cs
            "93b4d01199b118896c756b09a9206fc0",  // Assets/Udon/Serialization/OdinSerializer/Utilities/Misc/UnsafeUtilities.cs
            "f6cfa3d8ec4f885468d17f5b023d2529",  // Assets/Udon/WrapperModules/ExternVRCInstantiate.cs

            // UdonSharp
            

            // VitDeck
            

            // VketAssets
            "0de3ccc1017c4a045a4fed5f810c2748",  // Assets/VketAssets/Prefabs/AvatarPedestal/Materials/UI-Lookat.mat
            "d35acdd70bdcab445bbbd6deac832a3b",  // Assets/VketAssets/Prefabs/AvatarPedestal/Shaders/UI-Lookat.shader
            "834f21d704cafe3498f4d2ecc38dc5ea",  // Assets/VketAssets/Prefabs/AvatarPedestal/Textures/Background.png
            "86487b9f4f81a774a9c49d53278c76cf",  // Assets/VketAssets/Prefabs/AvatarPedestal/Textures/Button.png
            "62f7352a395147043809a2d315af37ae",  // Assets/VketAssets/Prefabs/AvatarPedestal/Textures/Change Avatar.png
            "96c692c63aeba764081c1e04790fd3f1",  // Assets/VketAssets/Prefabs/AvatarPedestal/Textures/Sample.png
            "59261512e4100df488de6ddd9b530829",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_2D_L.prefab
            "3e6652d46d6d66d4092650094b064987",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_2D_M.prefab
            "87a721a2eb0c25643a5eb305781dc3a8",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_2D_S.prefab
            "104b8771f1874de40bf91473c2afb5ec",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_3D_L.prefab
            "2cdd22b46ff13f2409e7dd60e077eed7",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_3D_M.prefab
            "045501f8edaa2e748857c6c17a96b2f1",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_3D_S.prefab
            "d7a2d6aa4218cdd45854cd81900deba6",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_Default_L.prefab
            "8134e8c0ab5943a479b31c509f2325fb",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_Default_M.prefab
            "fb107661b9b479d4fa95452f7fd46426",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_Default_S.prefab
            "0294f3138a383d44188238141e43a0d2",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Animation/Active_2D.anim
            "8ecf1c1367fda5c45b707eaaf1e6e300",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Animation/Active_3D.anim
            "826602674183e284685c8212ca89f3ca",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Animation/AvatarPedestal_2D.controller
            "8dd57fafbfdbd5146b2e808a8b28a2ea",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Animation/AvatarPedestal_3D.controller
            "cc64c7910ebf50249bc5cfdc65ba4729",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Animation/Deactive_2D.anim
            "68bbad9fbab0708449c847419d62a17e",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Animation/Deactive_3D.anim
            "6b468349f6cba0248a76b7d33570fbad",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Animation/Idle_2D.anim
            "8d5e148b91b24cf4dae7e22e010f7603",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Animation/Idle_3D.anim
            "0d2cf2386895ff5499a1660a4327ad75",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/Scripts/AvatarPedestal.asset
            "304812fb2352c7c419581d8f68b23f94",  // Assets/VketAssets/UdonPrefabs/Udon_PickupObjectSync/PickupObjectSync.prefab
            "73398b290b7c5ec43a2e158bfc1c45db",  // Assets/VketAssets/UdonPrefabs/Udon_PickupObjectSync/Scripts/AutoResetPickup.asset

        };

        public static string[] MaterialGUIDs = new string[]
        {
            "272ba847f100d4251bb8260575189042",
            "6fd099d339b4ae34692c8258e4f87531",
            "4b5dce0492bdfb648a389fe390071625",
            "621e901dcf5ebaf46bce29d18f67194c",
            "f62b52b2d4b721742a0bc5c6b4db468d",
            "848918a99d11f25f110026ca44295342",
            "a6dbb96b9d112024d000e929e39e7c39",
            "c7d1a73cf0f423947bae4e238665d9c5",
            "c8c80c5b03f5c7e40b07eb2170e667e5",
            "e30ff3588e719f34bbf0c66f22d97487",
            "a3384ef3e2313034f9016ad8a1f3999f",
            "26d8bdbc8646bde48b05fbaacaaa6577",
            "06893cec523208643a91b7a393737700",
            "84b9e1d19d11078d11005b9844295342",
            "215977489d11178d11005b9844295342",
            "c9e6294c9d11cb8d11006bf944295342",
            "5d69df9d9d11e49d110086ba44295342",
            "d68104aea3d1d084385a1acc7c896247",
            "89bc4a04979629642988a379a429608a",
            "e621ee108fde15148a5e4b4ab67667b9",
            "d5b20def9c5c05748a01627738b94531",
            "e6a8e6ae86a5b904eb64f573f145ecde",
            "19d7ece9e3def3745a0f6e75d984fdf6",
            "4be5b19d42487c24f830c4ee36849a95",
            "97ad51f0a4aed0a4289f5462ce6dc18f",
            "9938463bcd729fe41b4937cb6d2d692b",
            "57225f817366f704fb9b710e3865030d",
            "21b01056ea59b814f9ae15d8e6bb3aac",
            "b0d5705176a0d36419d034e2ea46491a",
            "639aa87a96d586c4e84838574ce20ca3",
            "d5222114580affc49a2af92470232e23",
            "ee0b78d572fcec249860ad38970b7888",
            "355b3169750599e4f957a9d54675c3fa",
            "8c1755df5f552e843b9f8485f72e71f8",
            "bfc1dabf45016eb46b99df1a78054924",
            "6c3b3265bf0f7e547a1ada8555f850a5",
            "1092dd21af768cb499771bf88709dbbd",
            "a940b48d553d9c74f9ca0a3b4cf74336",
            "cd764ab8662bea6468202df8741bcfd3",
            "f568ca8b20ae095418f3e2a3b341d8f6",
            "e625f56663597ef4899f86b588b4d506",
            "d4880c932a8e12b48a3039233e9634a0",
            "fdb77c3917027234db7a7792019eda2e",
            "0aa00c0212e047047aa5a1ce93b07f49",
            "2bcb00d145ec17e4cad096cedfd84138",
            "54ee8e39b634b6d45aae528b6b24e879",
            "fecc9f713338e4943a8c38775af8c046",
            "e183610e060210e44ac38d34e83c54d1",
            "e6751882f7503bd4f9c6c3902e8b6188",
            "dffa6c1325fd30b41819f03be58b91e7",
            "57df284b8a7c87b4894ac5f9c86e0be9",
            "c487fc8e98a2a42488a6c0a36ccaec27",
            "6e680dda9368db5418f19388474277a2",
            "39baceec69bb1ee4fb4194d50e1a6d10",
            "fa40ba727cdc90245aac11f0ff5ead8e",
            "1cb3f0c5c8637644dae1816a674f7e10",
            "a6b21b8c372827345a11bae2fb736e36",
            "46160e8fc1456bc4d9fb3de64ba88c31",
            "654a2c1b911b36647b211a44a46e6d09",
            "9cc6d6e9e3fe9154890a6f9caa77c955",
            "5c6bda52f548c164381f24c22067e446",
            "9b49c2e157c705944beb6767e25cd742",
            "f1bc741ea0e69a241896582ddb633d55",
            "7350b65a6431f604a8496c39db1ac9c5",
            "e633a20421c47426aa04444234225b69",
            "a437a9b380909fa4d98f929428f70388",
            "a5f2339f242f6cc41a982ec55ea3c201",
            "656fde119942645aa8e062e04c119aa1",
            "52b7d70b1de7c4ce09662b77c14d9fda",
            "c55afdc4a8a3b4890b07cc7d176510bb",
            "30abebfd9bf1c49d8a2d26e61e66bc15",
            "89ff19d667a6a5d4bb76df1fcb718402",
            "7911795df27dd464190eed77dda90191",
            "26ea534dcd83fe14c9173a52e151cce8",
            "77d08210df254d845885518314593544",
            "9f3080141f1f64197825663e067f94f8",
            "30289309b0c21224ea5b6fcc73b07d59",
            "3bfa2f095c911d649bf4cb92a55ac974",
            "c10b1630d5621ec48a17223c3c102023",
            "fc626cffedc907848a7b47b87aa5e34f",
            "473d6d3ec0d161b4a85e466c8c6da3fb",
            "225843b6084e75440a6ea970a17c93aa",
            "c50d77affeb31e14c9c062c282f13fc8",
            "f63c576739a709747a1a571260d4fabd",
            "ff6663d927968dc4482d24a8495316de",
            "3062613153ea47f42a262f065fec69d1",
            "60d4adad90a8b164abbb7d8ff5b4118a",
            "ed1b89d39279f564ea077ad8e46f3595",
            "09a99b10658931c46a438c586a49ec65",
            "141b5bb76b8b39342a5a787acbeaabfd",
            "6f36a222811073946936cf1cdeb78f9c",
            "42672579dbdf2c8449598d21e2c569ec",
            "365a29a7757a91544b92d59a78390495",
            "d5b08f0e43171dd468f4fed8bb5d0cea",
            "f5a209142cf260f4a96ca747e0e4dadf",
            "9cc96cc80c50454429965171ff4e500d",
            "ef1216aa37a0cc249a6a6f5abbd25665",
            "33574fa1b36c9244ebeedb7e591ed39b",
            "6f57e3384acd5dc45bb4df479f10466b",
            "7a474fad7982a8e42af709db5f90c4f6",
            "32314ba6cfa407640bffbb7b20708949",
            "c617e7cbee0d2344a9b5e53116c43a2c",
            "d425c5c4cb38fd44f95b13e9f94575c2",
            "6ec41f7c0e0d3fb40933551a4124b211",
            "bf5faaa3a8e23de45bf1350be2893dd7",
            "bedcbcc4d577778478a5f01fe1415af1",
            "3682f7747d485db4586750a832808b31",
            "965a4c3cf8f0acb408f15384c947b3fd",
            "6021947067b9d6c4bac8d9e085a71558",
            "f4dd0bba6decdd5418fd3d541ff5f7f0",
            "0de3ccc1017c4a045a4fed5f810c2748",
            "0bfe6778f100206489baf9dbd0c24646",
            "88581c9aef71ea549b2f133599cb89bf",
            "88728f426bf72d74b9abd9ceb8ecbd2c",
            "112ba1c1df66b5e47b93c5c355fb8e69",
            "27f323571b8327e409c9b9669fb84d93",
            "7d4ac9335e1cc82488a383bd849a380c",
            "eb0465484fd24bd458c85ad5c6554747",
            "d6390657f902d1142a20b5cc7f92ffe2",
            "119d5edced9d6bf469181f8497c65731",
            "2f2236791569d124eb4b48f19730cb06",
            "f651c02bf9fdac1408c87c0e4f6cdd2b",
            "345659f361c837b4cab35176f8c8d671",
            "57338689439fb4a4fa1a42ebf3816059",
            "86c25d309b5f3114ab3f949d7655aea3",
            "a2d8565e76f62d14e9c149040f122c19",
            "a87e62033b0ad4848838ebcf5f89858f",
            "b407561bc3f21de4c8808646f3a719ca",
            "5ebfcc9cd374c614dba1f903f8de36ba",
            "130e4ea006e957749a3e19016c5b918a",
            "6182e5d390ecba149a1f8d75312e956e",
            "4329612c3238cc44091f699ba05da324",
            "5cdca66777e3963468a57b44e76b86c4",
            "63000287678da044197a3ff745d75c25",
            "c2c262af144c1b042adc2954103f4e22",
            "e9bfebf98ae9cae45b922038482fc4da",
            "ce62de801b8ad824bbf9ea504e021a28",
            "9309c7b0890455a4a8f08654e29e9dde",
            "94a96e9ef149f41dba67feba5e821642",
            "d513bc147cb99443cac08125bc7b07a3",
            "fcba9c984fc1146d1a6040e5356cecce",
            "be0a309963e2a4c2aadf9e7f0c6f67d0",
            "4a91f2f2fa6c34023a979b7c09f122fb",
            "8a758f41de96147d29c0b9d92ce2a3c5",
            "bee4cfbf3d15cba4db1eb2194e6a3523",
            "b7aea302419e848208876c3110d87629",
            "12308bfd4d8d1364e850d65072468fab",
            "a8cce4d8c5d03442da6ab5d844a0ef3c",
            "ac9e81b9fcc2206488e4a6af9aafa8fa",
            "34604f31e7357c640bccb727ace0f411",
            "049484920c0cd48568fe4a6e8df94859",
            "cbdd696bd322449e79455923a4f20130",
            "08a3af2fbc23c4bcaae0c29e0708051b",
            "7cd93faf0379a454f8fab9a5b4cf5d2d",
            "ca7d34d59a8424cc5a2fecb099a96a5c",
            "77e89506ce5a642a19e38f3580d9be66",
            "eb554719301d24a27a03d90e35702330",
            "440d6a9870aca7b4d94eebb649da8773",
            "035a48a539312914f8762cf7100ec0cb",
            "88532a819aae1c040be0f9988d58122d",
            "dcca7a3502858e84ab6d5f11a14518e0",
            "aec38ac1f2b4b994f9fe780ff5de7217",
            "7e451a94e6eaac34db05cedecc3e0202",
            "d7b90495f0f98874dbdbafc334023f9a",
            "f8ce3b3f786c145e397f3c275f706895",
            "523bdc8357b5b4c0085f428e42283e9f",
            "c7cf1644632654b25826f171555081f1",
            "aae886dd0d5d59844b4ec40cc2d96918",
            "d2985de4f27bfa340a12c3ef95d47167",
            "01c04496878436140922b19f5220712b",
            "338dbf9d35df70d428453cc78f8eaa18",
            "297e3a11e7d07fc48b4f71056b4f927f",
            "bccdb449802ea144b8709da9bac60356",
            "a24037aa2dae5b145b048dcaf948032a",
            "efb74a60b37f60a41add571d33f34fff",
            "9335c65f42a781d4c881b93bec5412b9",
            "a8934a77ad83e0f4a9e9d40b3917880b",
            "bf1bf92a3ce592e40b898be6c21cc2fa",
            "ee9f7b84e86227a4fadc5e7f42e84b97",
            "735665606fda0c14cb12bc536aa26dc7",
            "616853845a4a54949ac851f2f807aa2a",
            "432d27f28c1251041bd6d1753602d5f0",
            "61bcea22404bda2469670dd9255037db",
            "ace554b28b3c23448817bd8c63e751ff",
            "c45f0afbf9669834d9bac06fb9f06fb7",
            "35e2b94eb1006514abf8ae501b17f4d1",
            "3c010df6cb2c96b4aaad25516d628e3b",
            "e9115a14465af3541a37d00fd436469b",
            "da07ab9b78cb0432e95e11e2cb619ea7",
            "2166f6bbfce69594fad494087eca58e8",
            "841c3ce718e8b61408005c1cfce6b7de",
            "68be9f0f6e5adbd44a76bf6bf69fda7b",
            "9414e644b0d9d4c4cb1d863093f0284c",
            "b6099d83d6f02e34ea589e768df4173b",
            "34348aa1b91e32f48bda8333f82f6335",
            "4546b0ec54086e840800d63eb723acd2",
            "c815f7613a04b724089c206857e57c6a",
            "7a2568654af4bef4cad7a3dfa02c31b2",
            "4a04f8d3981104848915e66f7a02ec72",
            "45ad7d65a659f4adaa95c017f788b513",
            "26803b57669325843a97b0ae43031082",
            "76ff537c8e1a84345868e6aeee938ab3",
            "1032d41f900276c40a9dd24f55b7d420",
            "8c19a618a0bd9844583b91dca0875a34",
            "fed4e78bda2b3de45954637fee164b8c",
            "4876fc9dc009bbe4493553020a561611",
            "eae9c11350249284e8400a100179e0b2",
            "1ab66d94bde8cce46bb35638099bfd31",
            "5aa95b3fa56e28f43a84e301c3d19e08",
            "799167b062f9e2944a302eea855166b4",
            "82096aab38f01cb40a1cbf8629a810ba",
            "6e1d36c4bbd37d54f9ea183e4f5fd656",
            "30da1dea3940b3944bef696b5a0c0349",
            "3e400cf5dce017245bd117c8438837c7",
            "bbeadce146b7c1c41bea63eceabbae31",
            "d6327473f08dde54dada700bf88812c3",
            "d675dc4b793d5ec4bbe0c56a70bee55e",
            "d943b283c535741428aba133ba785ccf",

        };

        public static string[] ChairPrefabGUIDs = new string[]
        {
        };

        public static string[] PickupObjectSyncPrefabGUIDs = new string[]
        {
            "304812fb2352c7c419581d8f68b23f94",  // Assets/VketAssets/UdonPrefabs/Udon_PickupObjectSync/PickupObjectSync.prefab
        };

        public static string[] AvatarPedestalPrefabGUIDs = new string[]
        {
            "59261512e4100df488de6ddd9b530829",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_2D_L.prefab
            "3e6652d46d6d66d4092650094b064987",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_2D_M.prefab
            "87a721a2eb0c25643a5eb305781dc3a8",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_2D_S.prefab
            "104b8771f1874de40bf91473c2afb5ec",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_3D_L.prefab
            "2cdd22b46ff13f2409e7dd60e077eed7",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_3D_M.prefab
            "045501f8edaa2e748857c6c17a96b2f1",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_3D_S.prefab
            "d7a2d6aa4218cdd45854cd81900deba6",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_Default_L.prefab
            "8134e8c0ab5943a479b31c509f2325fb",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_Default_M.prefab
            "fb107661b9b479d4fa95452f7fd46426",  // Assets/VketAssets/UdonPrefabs/Udon_AvatarPedestal/AvatarPedestal_Default_S.prefab
        };

        public static string[] AudioSourcePrefabGUIDs = new string[]
        {
        };

        public static string[] CanvasPrefabGUIDs = new string[]
        {
        };

        public static string[] PointLightProbeGUIDs = new string[]
        {
        };

        public static string[] VRCSDKPrefabGUIDs = new string[]
        {
        };
    }
}