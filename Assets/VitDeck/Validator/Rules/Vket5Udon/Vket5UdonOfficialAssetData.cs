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

            // Text Mesh Pro
            "6e59c59b81ab47f9b6ec5781fa725d2c",  // Assets/TextMesh Pro/Fonts/LiberationSans - OFL.txt
            "e3265ab4bf004d28a9537516768c1c75",  // Assets/TextMesh Pro/Fonts/LiberationSans.ttf
            "fade42e8bc714b018fac513c043d323b",  // Assets/TextMesh Pro/Resources/LineBreaking Following Characters.txt
            "d82c1b31c7e74239bff1220585707d2b",  // Assets/TextMesh Pro/Resources/LineBreaking Leading Characters.txt
            "3f5b5dff67a942289a9defa416b206f3",  // Assets/TextMesh Pro/Resources/TMP Settings.asset
            "e73a58f6e2794ae7b1b7e50b7fb811b0",  // Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF - Drop Shadow.mat
            "2e498d1c8094910479dc3e1b768306a4",  // Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF - Fallback.asset
            "79459efec17a4d00a321bdcc27bbc385",  // Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF - Outline.mat
            "8f586378b4e144a9851e7b34d9b748ee",  // Assets/TextMesh Pro/Resources/Fonts & Materials/LiberationSans SDF.asset
            "407bc68d299748449bbf7f48ee690f8d",  // Assets/TextMesh Pro/Resources/Shaders/TMPro.cginc
            "3997e2241185407d80309a82f9148466",  // Assets/TextMesh Pro/Resources/Shaders/TMPro_Properties.cginc
            "d930090c0cd643c7b55f19a38538c162",  // Assets/TextMesh Pro/Resources/Shaders/TMPro_Surface.cginc
            "48bb5f55d8670e349b6e614913f9d910",  // Assets/TextMesh Pro/Resources/Shaders/TMP_Bitmap-Custom-Atlas.shader
            "1e3b057af24249748ff873be7fafee47",  // Assets/TextMesh Pro/Resources/Shaders/TMP_Bitmap-Mobile.shader
            "128e987d567d4e2c824d754223b3f3b0",  // Assets/TextMesh Pro/Resources/Shaders/TMP_Bitmap.shader
            "dd89cf5b9246416f84610a006f916af7",  // Assets/TextMesh Pro/Resources/Shaders/TMP_SDF Overlay.shader
            "bc1ede39bf3643ee8e493720e4259791",  // Assets/TextMesh Pro/Resources/Shaders/TMP_SDF-Mobile Masking.shader
            "a02a7d8c237544f1962732b55a9aebf1",  // Assets/TextMesh Pro/Resources/Shaders/TMP_SDF-Mobile Overlay.shader
            "fe393ace9b354375a9cb14cdbbc28be4",  // Assets/TextMesh Pro/Resources/Shaders/TMP_SDF-Mobile.shader
            "85187c2149c549c5b33f0cdb02836b17",  // Assets/TextMesh Pro/Resources/Shaders/TMP_SDF-Surface-Mobile.shader
            "f7ada0af4f174f0694ca6a487b8f543d",  // Assets/TextMesh Pro/Resources/Shaders/TMP_SDF-Surface.shader
            "68e6db2ebdc24f95958faec2be5558d6",  // Assets/TextMesh Pro/Resources/Shaders/TMP_SDF.shader
            "cf81c85f95fe47e1a27f6ae460cf182c",  // Assets/TextMesh Pro/Resources/Shaders/TMP_Sprite.shader
            "c41005c129ba4d66911b75229fd70b45",  // Assets/TextMesh Pro/Resources/Sprite Assets/EmojiOne.asset
            "f952c082cb03451daed3ee968ac6c63e",  // Assets/TextMesh Pro/Resources/Style Sheets/Default Style Sheet.asset
            "381dcb09d5029d14897e55f98031fca5",  // Assets/TextMesh Pro/Sprites/EmojiOne Attribution.txt
            "8f05276190cf498a8153f6cbe761d4e6",  // Assets/TextMesh Pro/Sprites/EmojiOne.json
            "dffef66376be4fa480fb02b19edbe903",  // Assets/TextMesh Pro/Sprites/EmojiOne.png

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
            "3bb6d22e89000724b90fb830af69384b",  // Assets/VRCSDK/Plugins/sqlite3.dll
            "4ecd63eff847044b68db9453ce219299",  // Assets/VRCSDK/Plugins/VRCCore-Editor.dll
            "b0e1c0f72d838fe49bfe88b987a471bd",  // Assets/VRCSDK/Plugins/VRCCore-Standalone.dll
            "215be632cb025bd429dd50a3fa942168",  // Assets/VRCSDK/Plugins/VRCSDK3-Editor.dll
            "661092b4961be7145bfbe56e1e62337b",  // Assets/VRCSDK/Plugins/VRCSDK3.dll
            "d09383607271b19468447945fda29e86",  // Assets/VRCSDK/Plugins/VRCSDK3Base-Editor.dll
            "bdccfb093344e7545a49b72a64499682",  // Assets/VRCSDK/Plugins/VRCSDK3Base.dll
            "dc5cab6c932db3247aab9f50c5f3bd5f",  // Assets/VRCSDK/Plugins/VRCSDKBase-Editor.dll
            "db48663b319a020429e3b1265f97aff1",  // Assets/VRCSDK/Plugins/VRCSDKBase.dll

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

            // VketShaderPack
            "6a1bea8b3245cd44a879612d2d6f40d6",  // Assets/VketShaderPack/arktoon Shaders/LICENSE
            "25bd5054a4b6ffb47b73f6fd436e0f56",  // Assets/VketShaderPack/arktoon Shaders/README_ja.txt
            "1dc24fdcb830de545be12a31d953349b",  // Assets/VketShaderPack/arktoon Shaders/Editor/ArktoonInspector.cs
            "4d5d0929a993a6543b9de355f69555d6",  // Assets/VketShaderPack/arktoon Shaders/Editor/ArktoonManager.cs
            "5034690b290c8b74cb03497a06726ad3",  // Assets/VketShaderPack/arktoon Shaders/Editor/ArktoonMigrator.cs
            "f336693355a393a4ea5a94d414b523c1",  // Assets/VketShaderPack/arktoon Shaders/Examples/ExampleScene.unity
            "b926be28e701612428d98637dc2bf8a7",  // Assets/VketShaderPack/arktoon Shaders/Examples/ExampleScene/LightingData.asset
            "085cf3fedd6bb294eacfbd4bc414ff86",  // Assets/VketShaderPack/arktoon Shaders/Examples/ExampleScene/Lightmap-0_comp_dir.png
            "4e89ae95769497940b832301e2796fe7",  // Assets/VketShaderPack/arktoon Shaders/Examples/ExampleScene/Lightmap-0_comp_light.exr
            "0ec5b0f7100c48f458dcf280614787a1",  // Assets/VketShaderPack/arktoon Shaders/Examples/ExampleScene/ReflectionProbe-0.exr
            "2eb350b0dd339cb49b9824cf13995641",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/cloth-sample.fbx
            "f1d089ea7b8a9194daa229671bd7487e",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/HalfSphere.fbx
            "b740ced5626064a469a29ecbad7cde4f",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/HalfSphere.mqo
            "7f8da376b282b48428e6012d1d6b01e4",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/mannequin.controller
            "1b5146a1f3281774a9ae9d86d85b7cb0",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/mannequin.fbx
            "51d178f628b7f114c89afd04967fef93",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/rotate.anim
            "d4952f2db95a16447a3fc2bb0d342c9d",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/roundedCube.fbx
            "19a0ba3d86e749546b76bf5acf5d16ea",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/roundedCube.mqo
            "0bfe6778f100206489baf9dbd0c24646",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/avatar1-helloweenmqo_服_AlbedoTransparency.mat
            "7882bcb890208a14bb86157b6ff1a481",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/Cubemap.png
            "af4dae3c66f957c45a9fb9d57f26dcad",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/FadeTextureExample.png
            "47c95c2343f176e47b666b929de8f68c",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/MaskExample.jpg
            "2535c9c47d22fa74cb975bc6bf822ac7",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/MaskExample2.jpg
            "88581c9aef71ea549b2f133599cb89bf",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mat1.mat
            "00689565905a91443932ed9b91bac11c",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/Matcap.jpg
            "d96088e780c661443a32b60fa5a2b7aa",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/Matcap2.jpg
            "a3ef914d408315f4a866313ae9b15162",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/Matcap3.png
            "88728f426bf72d74b9abd9ceb8ecbd2c",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 1.mat
            "112ba1c1df66b5e47b93c5c355fb8e69",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 10.mat
            "27f323571b8327e409c9b9669fb84d93",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 11.mat
            "7d4ac9335e1cc82488a383bd849a380c",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 12.mat
            "eb0465484fd24bd458c85ad5c6554747",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 2.mat
            "d6390657f902d1142a20b5cc7f92ffe2",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 3.mat
            "119d5edced9d6bf469181f8497c65731",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 4.mat
            "2f2236791569d124eb4b48f19730cb06",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 5.mat
            "f651c02bf9fdac1408c87c0e4f6cdd2b",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 6.mat
            "345659f361c837b4cab35176f8c8d671",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 7.mat
            "57338689439fb4a4fa1a42ebf3816059",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 8.mat
            "86c25d309b5f3114ab3f949d7655aea3",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 9.mat
            "a2d8565e76f62d14e9c149040f122c19",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material.mat
            "3784a951dbf03b645afc723f23aea29b",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/roundedCubeAlbedo.png
            "5fa80aa54e3d3d64d808f8989e2e7d68",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/roundedCubeNormal.png
            "1bd6ae9520d378f408445f9d4124d0f7",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/ShadeCap-Soft.png
            "12f178d108ab0394aa4ed4acf1bad8cb",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/ShadeCap.png
            "c7e141183bc6c5c40a37d02d5dc415e6",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/starfield.png
            "a87e62033b0ad4848838ebcf5f89858f",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/violin.mat
            "b407561bc3f21de4c8808646f3a719ca",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/Walls.mat
            "f93b9ae325c77ef4ead760d39eca7b5f",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/cloth/avatar1-helloweenmqo_服_AlbedoTransparency.png
            "b1fd4b404a3a7ae4e99356a0c300f34b",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/cloth/avatar1-helloweenmqo_服_MetallicSmoothness.png
            "367c23b196b1f6749a03f63febbeb990",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/cloth/avatar1-helloweenmqo_服_Normal.png
            "5ebfcc9cd374c614dba1f903f8de36ba",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/cloth/Cloth.mat
            "130e4ea006e957749a3e19016c5b918a",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/EmissiveFreak/EmissiveFreakMaterial 1.mat
            "6182e5d390ecba149a1f8d75312e956e",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/EmissiveFreak/EmissiveFreakMaterial.mat
            "5d87d8e428ab7dc43b51a4ace5e8f55c",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/EmissiveFreak/grdient_horizontal.png
            "4d1297e8a783e3242a35e699af99982c",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/EmissiveFreak/grdient_left.png
            "358ad584c99802b4da2965f294fdfe92",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/EmissiveFreak/grdient_top.png
            "7570c67b3d1666f40bd3fdc1605ac116",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/EmissiveFreak/grdient_vertical.png
            "4329612c3238cc44091f699ba05da324",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin/mannequin1.mat
            "5cdca66777e3963468a57b44e76b86c4",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin/mannequin2.mat
            "63000287678da044197a3ff745d75c25",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-knit/mannequin-knit.mat
            "f2b7b269124aad04f8ed1394bb7a104b",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-knit/mannequin_hada_AlbedoTransparency.png
            "300593a09f3a3a847a5286da9417f56e",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-knit/mannequin_hada_Normal.png
            "c2c262af144c1b042adc2954103f4e22",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-painted-stl/mannequin-green-metal.mat
            "e9bfebf98ae9cae45b922038482fc4da",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-painted-stl/mannequin-steel.mat
            "baa8c39629448f14f9f7dd8c1428dbe1",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-painted-stl/mannequin_hada_AlbedoTransparency.png
            "d243a1118bcad54469f0c17ced97f1a0",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-painted-stl/mannequin_hada_MetallicSmoothness.png
            "7bd75a18577b92e40b20efe0ae74859a",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-painted-stl/mannequin_hada_Normal.png
            "d34ddb690407bf04c8c9788205512415",  // Assets/VketShaderPack/arktoon Shaders/Shaders/Cutout.shader
            "18d9a7533c199e740aace730c78d6c60",  // Assets/VketShaderPack/arktoon Shaders/Shaders/EmissiveFreakCutout.shader
            "3d7739f293019494fb8995a1fc38422c",  // Assets/VketShaderPack/arktoon Shaders/Shaders/EmissiveFreakFade.shader
            "ff81093a7ac88134798d4274c55cc425",  // Assets/VketShaderPack/arktoon Shaders/Shaders/EmissiveFreakFadeRefracted.shader
            "6e08acecbe384864d82690f1704a89bf",  // Assets/VketShaderPack/arktoon Shaders/Shaders/EmissiveFreakOpaque.shader
            "e71575e4ccb008d4e883335c3ad49265",  // Assets/VketShaderPack/arktoon Shaders/Shaders/EmissiveFreakStencilReader.shader
            "24eaadc58de76f74085bddf9621fe48a",  // Assets/VketShaderPack/arktoon Shaders/Shaders/EmissiveFreakStencilWriter.shader
            "fd5c20ab9c5485444b5084f464d91504",  // Assets/VketShaderPack/arktoon Shaders/Shaders/Fade.shader
            "ca4a46b6454383540b9b0b4364a2d7ee",  // Assets/VketShaderPack/arktoon Shaders/Shaders/FadeRefracted.shader
            "9566a373fffe627408d31026ce69389d",  // Assets/VketShaderPack/arktoon Shaders/Shaders/Opaque.shader
            "4867c15b078ab3948ab5a758a9bcb047",  // Assets/VketShaderPack/arktoon Shaders/Shaders/StencilReader.shader
            "0d892e826f730774797c3acfca1b43db",  // Assets/VketShaderPack/arktoon Shaders/Shaders/StencilReaderDoubleFadeFade.shader
            "753d0fc07395b8d499b66e6e00b64079",  // Assets/VketShaderPack/arktoon Shaders/Shaders/StencilReaderFade.shader
            "62d584da6ad09fc409aba9a6ea4c76ad",  // Assets/VketShaderPack/arktoon Shaders/Shaders/StencilWriter.shader
            "abc253a50f12dc0478eb8c149b35af54",  // Assets/VketShaderPack/arktoon Shaders/Shaders/StencilWriterMaskTexture.shader
            "e117484d237f25a4f9c117444d3a4ae0",  // Assets/VketShaderPack/arktoon Shaders/Shaders/cginc/arkludeAdd.cginc
            "41f08346347915f4ab25c430bc631734",  // Assets/VketShaderPack/arktoon Shaders/Shaders/cginc/arkludeDecl.cginc
            "c3830c5b3aa068745afa82287a25ceb8",  // Assets/VketShaderPack/arktoon Shaders/Shaders/cginc/arkludeFadeShadowCaster.cginc
            "b7f00477d8c2131439bc5469d268da66",  // Assets/VketShaderPack/arktoon Shaders/Shaders/cginc/arkludeFrag.cginc
            "97f31596e13b1db489cc69f4f2cbcc9e",  // Assets/VketShaderPack/arktoon Shaders/Shaders/cginc/arkludeFragOnlyStencilWrite.cginc
            "5fd6b70947bef774b882d05c744c3281",  // Assets/VketShaderPack/arktoon Shaders/Shaders/cginc/arkludeOther.cginc
            "875f4a9e268dfff44981f8902e14c44c",  // Assets/VketShaderPack/arktoon Shaders/Shaders/cginc/arkludeVertGeom.cginc
            "82e13d2a938694aedb5dbb01bd3ecf07",  // Assets/VketShaderPack/MMS3/LICENSE
            "8dd7c14dadb834c4e8324f7d08c5674e",  // Assets/VketShaderPack/MMS3/MMS3.shader
            "128f4720891e8914ab7e6673099df0f0",  // Assets/VketShaderPack/MMS3/MMS3_Cutout.shader
            "fbaec084851cef64fbd877b3b15716cb",  // Assets/VketShaderPack/MMS3/MMS3_Outline.shader
            "f889d00a055a0488e9ecbf22c558ae76",  // Assets/VketShaderPack/MMS3/MMS3_Stencil_Reader.shader
            "f55508f2ed8cc477f9574099971bc4eb",  // Assets/VketShaderPack/MMS3/MMS3_Stencil_Writer.shader
            "fda424b70f79d4e5488e1cc3ee100a95",  // Assets/VketShaderPack/MMS3/MMS3_Transparent.shader
            "ece969dbfb97d446ba8f8358a78789b5",  // Assets/VketShaderPack/MMS3/Shade_Matcap1.psd
            "909b3ce927e8cf246b13b1dbdef33f62",  // Assets/VketShaderPack/Mochie/Common/Color.cginc
            "d5468ef40ceedc549a0911e23c0b1568",  // Assets/VketShaderPack/Mochie/Common/Noise.cginc
            "71a928ffb0de3b442ab7e52a33f42d54",  // Assets/VketShaderPack/Mochie/Common/Utilities.cginc
            "5a65d8c24e698b44cbf674e0a232926a",  // Assets/VketShaderPack/Mochie/Particle Shader/Particle.shader
            "d1c93822d1541934c8fa436a39f0351a",  // Assets/VketShaderPack/Mochie/Particle Shader/PSDefines.cginc
            "56a4a30195ab7a4459b604ae189b3ccd",  // Assets/VketShaderPack/Mochie/Particle Shader/PSFunctions.cginc
            "0dfb5dc13a225ca4db23b0ee43932e34",  // Assets/VketShaderPack/Mochie/Particle Shader/PSUtilities.cginc
            "7ab63f31ad43f1e4ebab13ed1d4201cf",  // Assets/VketShaderPack/Mochie/Particle Shader/PSXFeatures.cginc
            "0d1d977ca72938b4bb8f3ed06b9a8645",  // Assets/VketShaderPack/Mochie/ScreenFX Shader/SFX.shader
            "0622846791c27d3499465434f2f63a0f",  // Assets/VketShaderPack/Mochie/ScreenFX Shader/SFXBlur.cginc
            "e06fb4e15a03e164dae45a93c3ab3591",  // Assets/VketShaderPack/Mochie/ScreenFX Shader/SFXDefines.cginc
            "e51e722628c0c834f841cbca164dc53b",  // Assets/VketShaderPack/Mochie/ScreenFX Shader/SFXFunctions.cginc
            "7cbe4084658fd6b4e8b73782d48a461d",  // Assets/VketShaderPack/Mochie/ScreenFX Shader/SFXKernel.cginc
            "9a10756a86708fc4f840711e05cf723c",  // Assets/VketShaderPack/Mochie/ScreenFX Shader/SFXPass.cginc
            "4bd03e585f1830247a19f1af0893e73f",  // Assets/VketShaderPack/Mochie/ScreenFX Shader/SFXXFeatures.cginc
            "87a52d53f3012e448b23af4d55a79d02",  // Assets/VketShaderPack/Mochie/ScreenFX Shader/SFXXPasses.cginc
            "b252ff402bce931488cf8ff5152bf2dc",  // Assets/VketShaderPack/Mochie/Uber Shader/Uber (Outline).shader
            "5398f14cd241f2649988529db4480d1c",  // Assets/VketShaderPack/Mochie/Uber Shader/Uber.shader
            "21947c9bef25458429000c46ca32e021",  // Assets/VketShaderPack/Mochie/Uber Shader/USBRDF.cginc
            "6cd01882b763be542be24bd25c155871",  // Assets/VketShaderPack/Mochie/Uber Shader/USDefines.cginc
            "6e016b6a7bd29c24581e80488f391a0e",  // Assets/VketShaderPack/Mochie/Uber Shader/USFunctions.cginc
            "6390189603c02114c9822185832e97fc",  // Assets/VketShaderPack/Mochie/Uber Shader/USKeyDefines.cginc
            "a517223ef2cd6074b9947340447724b9",  // Assets/VketShaderPack/Mochie/Uber Shader/USLighting.cginc
            "b6948e44e1f92fc4891f424daf8e7bfd",  // Assets/VketShaderPack/Mochie/Uber Shader/USPass.cginc
            "70bd95f95c93df74699e04c703304294",  // Assets/VketShaderPack/Mochie/Uber Shader/USSampling.cginc
            "4ec15cb7a78843d4fb5c7c8bdf19bd9b",  // Assets/VketShaderPack/Mochie/Uber Shader/USSSR.cginc
            "76eed4008ba5d464199dcfc895daf3b7",  // Assets/VketShaderPack/Mochie/Uber Shader/USXFeatures.cginc
            "1da8bba388ad86741b84e6899d501ca7",  // Assets/VketShaderPack/Mochie/Uber Shader/USXGeom.cginc
            "d9b054af17135c745adff39d435e039d",  // Assets/VketShaderPack/Mochie/Unity/Editor/Foldouts.cs
            "e7db49004f057a845a9464ce30210a62",  // Assets/VketShaderPack/Mochie/Unity/Editor/MaterialManager.cs
            "2f59b3e0bf10120419b941583795ef54",  // Assets/VketShaderPack/Mochie/Unity/Editor/MGUI.cs
            "fdc00d0c66b6f3f4eb834fd87b6d760c",  // Assets/VketShaderPack/Mochie/Unity/Editor/PSEditor.cs
            "4689d28cb77840b488838b0a89f5dd78",  // Assets/VketShaderPack/Mochie/Unity/Editor/SFXEditor.cs
            "566cd2268c7d9194087322ca64b68f61",  // Assets/VketShaderPack/Mochie/Unity/Editor/Toggles.cs
            "eed6a60c5f8da544690d739b516ada01",  // Assets/VketShaderPack/Mochie/Unity/Editor/USEditor.cs
            "497f8485774204244abb7ba6c0865927",  // Assets/VketShaderPack/Mochie/Unity/Prefabs/Default.mat
            "3bb643d832d69134f8fbea4efcd0e109",  // Assets/VketShaderPack/Mochie/Unity/Prefabs/Depth Light.prefab
            "cd555b15b892a6342821da231de50d42",  // Assets/VketShaderPack/Mochie/Unity/Prefabs/Screen FX.prefab
            "c5eaa139ce0fb7c4b9ee2604697e997f",  // Assets/VketShaderPack/Mochie/Unity/Resources/ClearTexIcon.png
            "3e38383d19b750046a6fa03b1c2f8bac",  // Assets/VketShaderPack/Mochie/Unity/Resources/CollapseIcon.png
            "09c9c066a27ac424da976a9ae8474231",  // Assets/VketShaderPack/Mochie/Unity/Resources/CopyTo1Icon.png
            "124358866068baa4f90186cb87430c24",  // Assets/VketShaderPack/Mochie/Unity/Resources/CopyTo2Icon.png
            "b69d260e9a20c444cb3ac36d41d2d479",  // Assets/VketShaderPack/Mochie/Unity/Resources/ExpandIcon.png
            "d29b3eb8412f5e64096afc1ab733122d",  // Assets/VketShaderPack/Mochie/Unity/Resources/Header.png
            "29f18c82d04215e4f87185a100e9ff1b",  // Assets/VketShaderPack/Mochie/Unity/Resources/Header_Pro.png
            "1cbf300790ff57b4caf3fbe023eca45f",  // Assets/VketShaderPack/Mochie/Unity/Resources/KeyIcon.psd
            "f632ab1767b9c1e45b285c0731fbd1d8",  // Assets/VketShaderPack/Mochie/Unity/Resources/KeyIcon_Pro.psd
            "8f1c2bbd99970c841b096d9447417468",  // Assets/VketShaderPack/Mochie/Unity/Resources/ParticleHeader.png
            "ca6d24562e19aab4e90be114647a98bb",  // Assets/VketShaderPack/Mochie/Unity/Resources/ParticleHeader_Pro.png
            "31fef82c771a5374b904c64a98fde2ac",  // Assets/VketShaderPack/Mochie/Unity/Resources/Patreon_Icon.png
            "ec636ed50f955cc42a934e1bd42403d0",  // Assets/VketShaderPack/Mochie/Unity/Resources/ResetIcon.png
            "2201e3ff274d60b42ba46809810c7f0e",  // Assets/VketShaderPack/Mochie/Unity/Resources/SFXHeader.png
            "30a883d22a3859443a814b6bba897043",  // Assets/VketShaderPack/Mochie/Unity/Resources/SFXHeader_Pro.png
            "dff4b38eef00de14487e9ee7ee4359b0",  // Assets/VketShaderPack/Mochie/Unity/Resources/StandardIcon.png
            "21cb8a0fd46250e489c418eeff4a2222",  // Assets/VketShaderPack/Mochie/Unity/Resources/Watermark.png
            "0b25d34e04b2c7a4c98d9cc5c69fa830",  // Assets/VketShaderPack/Mochie/Unity/Resources/Watermark_Pro.png
            "7589d70a1d40b7c47857a6722e4a0aae",  // Assets/VketShaderPack/Mochie/Unity/Textures/Blend.png
            "89819f8cb0b9e5d418f6e90ca96ac9c3",  // Assets/VketShaderPack/Mochie/Unity/Textures/Distortion.tif
            "930ac9d4c358e5846af139e693a08bd2",  // Assets/VketShaderPack/Mochie/Unity/Textures/Hair Normal.png
            "2059b62900034054f9f93aafbf8293fb",  // Assets/VketShaderPack/Mochie/Unity/Textures/Perlin (Alpha).jpg
            "dfbb7eeed695dc14d82b08d887041406",  // Assets/VketShaderPack/Mochie/Unity/Textures/Perlin.jpg
            "b8d1261e60bcece48b7708cac8798bfc",  // Assets/VketShaderPack/Mochie/Unity/Textures/Shake Noise.png
            "b7359cc7e3e84444b88656ff6c166220",  // Assets/VketShaderPack/Mochie/Unity/Textures/SSR Noise.png
            "9c8ede69ecd0f824aa80b9929c0b1e5c",  // Assets/VketShaderPack/Mochie/Unity/Textures/Transparent 4x4.png
            "f276a76437cf84847a5986084b4d11f3",  // Assets/VketShaderPack/Mochie/Unity/Textures/Ramps/DefaultRamp.png
            "9674bc46ecefab84b9f135c13b18ce36",  // Assets/VketShaderPack/Mochie/Unity/Textures/Ramps/RampImporter.cs
            "2a5e8a5d481e3574b8274fa7ce4bdc2d",  // Assets/VketShaderPack/MToon-3.4/LICENSE
            "1021e7e6d453b9f4fb2f46a130425deb",  // Assets/VketShaderPack/MToon-3.4/README.md
            "a9bc101fb0471f94a8f99fd242fdd934",  // Assets/VketShaderPack/MToon-3.4/MToon/MToon.asmdef
            "24156f9da0724eb5a159f36c69a7d90a",  // Assets/VketShaderPack/MToon-3.4/MToon/Editor/EditorEnums.cs
            "531922bb16b74a00b81445116c49b09c",  // Assets/VketShaderPack/MToon-3.4/MToon/Editor/EditorUtils.cs
            "dddf8398e965f254cae2d7519d7f67d2",  // Assets/VketShaderPack/MToon-3.4/MToon/Editor/MToon.Editor.asmdef
            "8b43baa9f62f04748bb167ad186f1b1a",  // Assets/VketShaderPack/MToon-3.4/MToon/Editor/MToonInspector.cs
            "1a97144e4ad27a04aafd70f7b915cedb",  // Assets/VketShaderPack/MToon-3.4/MToon/Resources/Shaders/MToon.shader
            "ef6682d138947ed4fbc8fbecfe75cd28",  // Assets/VketShaderPack/MToon-3.4/MToon/Resources/Shaders/MToonCore.cginc
            "084281ffd8b1b8e4a8605725d3b0760b",  // Assets/VketShaderPack/MToon-3.4/MToon/Resources/Shaders/MToonSM3.cginc
            "17d4e0f990fbc794ab41e4fcc196d559",  // Assets/VketShaderPack/MToon-3.4/MToon/Resources/Shaders/MToonSM4.cginc
            "8b731264e8acd0f4b8f56986e5eb2531",  // Assets/VketShaderPack/MToon-3.4/MToon/Samples/OutlineWidthModes.unity
            "4f42a26097c877b40a7616aa60580c43",  // Assets/VketShaderPack/MToon-3.4/MToon/Samples/Materials/Ex_OutlineWidth_Screen.mat
            "e40a129e14e378c4db040df3fd4a6077",  // Assets/VketShaderPack/MToon-3.4/MToon/Samples/Materials/Ex_OutlineWidth_World.mat
            "54da18ba3126f1343924588562df72e0",  // Assets/VketShaderPack/MToon-3.4/MToon/Samples/Materials/Ground.mat
            "9639e17dffc656345a70282f7f216672",  // Assets/VketShaderPack/MToon-3.4/MToon/Samples/Materials/Toon.mat
            "9a3fb070d7eb4114b5cf387e2cd60391",  // Assets/VketShaderPack/MToon-3.4/MToon/Scripts/Enums.cs
            "2849b99d94074fcf9e10c5ca3eab15a8",  // Assets/VketShaderPack/MToon-3.4/MToon/Scripts/MToonDefinition.cs
            "9d2012c170a74b3db0002f7ecda53622",  // Assets/VketShaderPack/MToon-3.4/MToon/Scripts/Utils.cs
            "6724aa45c8c349fabd5954a531301aa8",  // Assets/VketShaderPack/MToon-3.4/MToon/Scripts/UtilsGetter.cs
            "b24a672e82874c9fbfef9c2b2dfdab42",  // Assets/VketShaderPack/MToon-3.4/MToon/Scripts/UtilsSetter.cs
            "4702d4b2c1414cc08b4382c3762eebab",  // Assets/VketShaderPack/MToon-3.4/MToon/Scripts/UtilsVersion.cs
            "44d0643d490e16f4492b7252c658ea1a",  // Assets/VketShaderPack/SCSS-master/LICENSE
            "4c6ec922fb42b2848a1e6fd88c19bf4a",  // Assets/VketShaderPack/SCSS-master/README.md
            "163fd2e733679b948b23e92b2341f8f6",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/Default MultiGradient.asset
            "80684a860e75c9a4295d27ead38010c7",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/Info.txt
            "a7e8258f4d13af1419c0326602f31748",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/LightRamp Sharp.png
            "70853d21e5cf0a945ba9ef1baa2f37fa",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/LightRamp Skin.png
            "6af41be6e81954543bfe50e9b2131c4d",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/LightRamp Smooth (old).png
            "6584ffcc7e2c6a746afd371ec1d6ad5d",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/LightRamp Smooth.png
            "a8fbd87577f16ea43ac168bbf9ef88f3",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/LightRamp Soft (old).png
            "51b142bdc7b4f7a428477e77eb815bc7",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/LightRamp Soft.png
            "d0d2092a7d8176a419858a5536e205ee",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/LightRamp Toon v2.png
            "7f445efa362f16248af955f190843381",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/LightRamps/LightRamp Toon v3.png
            "ae6fa37de6d2b4e45a6176091e47455c",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/LICENSE.txt
            "63a9cd46c7dd97644b42c0721976f257",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/Readme.txt
            "fb2f01db930474c3fbd62634f03ffe4b",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/Matcap/MMS_Light_Hard.psd
            "4348a2a80916845739da8629005aef03",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/Matcap/MMS_Light_Hard_Hair2.psd
            "5306755cc52e04770bf7169839c6b350",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/Matcap/MMS_Light_Soft.psd
            "1f802a1910910432ca435480b93e70ec",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/Matcap/MMS_Light_Soft_Hair.psd
            "d247459fa9b47465d92f1eb93eba56e9",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/Matcap/MMS_RimLightMatcap1.psd
            "c2dda37b49c0b4bde9e211e894f7344d",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/Matcap/MMS_RimLightMatcap2.psd
            "44d209fdf321840569dd21a5b61e277d",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/Matcap/MMS_ShadowMatcap1.psd
            "ecfa3da8397834305821fe311f1cbf15",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/Mnmr/Matcap/MMS_ShadowMatcap2.psd
            "c68fab11bf4dfb044a2f51d7ddc4d064",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/mofuaki_/mofuaki_-1185084491351515136-img1.png
            "48e16bad9d9551b499dfb08af7ee7e31",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/mofuaki_/mofuaki_-1185084491351515136-img2.png
            "fb8f4c7cfbfa3f743b381bda894c2eb6",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/mofuaki_/mofuaki_-1185084491351515136.txt
            "21e7d43547251ef4bb267a4aa24f04b7",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/mofuaki_/mofuaki_-1185084491351515136.url
            "ebd77ce0e53676d49853f56eb043a827",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LICENSE
            "c855d2d0c1361d14a841af5aa24d6d26",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/README.txt
            "b7b167660549b8e48a231f62d2fcb008",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Glare.png
            "3dd155f12c76e1447bf62608fc1bf572",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Gloss(LargeFlat).png
            "3dfb01f9d1c32f048ac838f6e3fa8810",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Gloss(LargePoint).png
            "9a6b29adf08462e4f98ec4a45cc7c57c",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Gloss(MultiFlat).png
            "bd882f7694bebd04eb144979a8787993",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Gloss(MultiPoint).png
            "c6cbb49dcbadf93489feca05b6652723",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Gloss(SmallFlat).png
            "b3d17e4df2a84274f8810d14ad0d1537",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Gloss(SmallPoint).png
            "5866d4cb591aa9443b2cb4948139b112",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Hair_AngelRing(Blue).png
            "a369076245553a64eb0f96d537272196",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Hair_AngelRing(Green).png
            "a8845002a4d852249b1f5b2d0422279c",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Hair_AngelRing(Purple).png
            "0db92e9598eb9f64c82095d66efe6a1a",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Hair_AngelRing(Red).png
            "2b71b8337c476dc4b875b2836a0e2720",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Hair_AngelRing(Yellow).png
            "86e9818d2a3ca7041b09c97748be153d",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Hair_AngelRing.png
            "70ae0ed388398f14a983b9be841fbf92",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Iridescent(Large).png
            "431e901af18398a40876e71e33afcb9c",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Iridescent(Multi).png
            "d3a73c13da3082b499720fd2e340fd58",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Iridescent(Small).png
            "c3348e9a93cf3f041a47eab885eff5a4",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Skin_Dark(Peach).png
            "81aad2673b3c3564e86273be96df3985",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Skin_Dark(Red).png
            "51458ebc5861843449e59e63cfbe9312",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Skin_Dark(White).png
            "8d80aa31a13e4ca499d7a120c31b5c30",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Skin_Dark(Yellow).png
            "1e1bd6119670c6644b39d585be1c7dd4",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Skin_Pale(Peach).png
            "de1140e088e6df840abef03788989036",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Skin_Pale(Red).png
            "b249fa84e5347e047a14ebd946f5b992",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Skin_Pale(White).png
            "eeb275611fdaf2648b0749546abab7e7",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Skin_Pale(Yellow).png
            "118b92d83e2a11040921f1eb0de754f2",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Tights_HighDensity.png
            "d7043e6bdc77d9a48bdbfc3fb6dc63b8",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/LightCap/lcap_WF_Tights_LowDensity.png
            "21b34471bb21d714695594ed013671e5",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Gloss(BlackEnamel・Blue).png
            "4b7f9eac7f86d804fa4651f78c2f77a2",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Gloss(BlackEnamel・Red).png
            "a86b7309210462d49937588b29ecb453",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Gloss(BlackEnamel・White).png
            "e789df0d8e991dc46bbbcb776c5a3ada",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Gloss(Rim).png
            "cfc0ca869f3f6aa488e442597f757c16",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Gloss(RimBright).png
            "eba422e248e1b7b46a44eca939e97a7c",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Gloss(WhiteEnamel・Rainbow).png
            "d9eed75190795c742b2a4ad01169a572",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_GradientShadow(Blue).png
            "981358a9d84b3254796caa2aed07f755",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_GradientShadow(Red).png
            "cb816f85c59d0594e919df78215b8643",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_GradientShadow(White).png
            "141320f81a2860f45b14a1de5bb46964",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_GradientShadow.png
            "228a97a7223a715439f7b999a17cb9d5",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Hair_AngelRing(Blue).png
            "de0bb15fb581f874b8c33b1cc5ea50e4",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Hair_AngelRing(Green).png
            "4e89ea8f4509c2d479adc1b6eb4a59b8",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Hair_AngelRing(Purple).png
            "bf6207586b81cc14fa15f173c8e3e88d",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Hair_AngelRing(Red).png
            "731335fba7efbcb4c9c77281e6ebf259",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Hair_AngelRing(Yellow).png
            "7237239c7d9b876468e784c193ea453f",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Hair_AngelRing.png
            "140f68527af730a42884e180331e2385",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_MetalGloss(Yellow).png
            "fc5c401b877c1bf4f90c09420e4564cb",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_SimpleShadow(Hemi).png
            "fb8412e5c0ec1864d94ffbc1c6573070",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_SimpleShadow.png
            "63de7b1aca5f56547b4566d5c452971d",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_SimpleShadow・BlueReflection.png
            "cd71180b27fb20b46bd8a67b792511d4",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_SimpleShadow・SideRim.png
            "cde5a8eff47aab14f956da09db682183",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Skin_BrownSlick_GlosslessFace.png
            "6019069d567c03e40b2e57285c9cf05b",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Skin_BrownSlick_GlossyBody.png
            "e2f3f51b74c61cb4fa33d42a0d857e74",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Skin_Brown_GlossStrong.png
            "b3a2e207de951c44db9c4bacaee6010f",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shaded_Skin_Brown_Rim_GlossWeak.png
            "e2e3379d7afc6c548a77840f6fd5f488",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Glare+Gloss(PointSmall).png
            "874b5960d1ad3b442b9f03199627562f",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Glare.png
            "862bb4f308d31a449b8fbfa82451d751",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Gloss(LargeFlat).png
            "fc0cf484220685d4eafa9ed00ef8cc7e",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Gloss(LargePoint).png
            "cd6d2060efad2c846afb263d634f1f70",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Gloss(MultiFlat).png
            "2e2858828b151be4695fd36ca4d19a40",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Gloss(MultiPoint).png
            "5923f328fc4cb4147ab169d1db94b29c",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Gloss(SmallFlat).png
            "a3680a23ee096f44b9d976c690a872dd",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Gloss(SmallPoint).png
            "5ee24b69dfded3240b1e950e8cfea8bb",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Hair_AngelRing(Blue).png
            "aab7586db9bd139439746510e249d68b",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Hair_AngelRing(Green).png
            "551ec63cc2428814e811c7b90822a9ea",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Hair_AngelRing(Purple).png
            "4e03c1e10a8731844ac2136ea96dff4f",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Hair_AngelRing(Red).png
            "4456fab6540937b4f80185dfcdb32acd",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Hair_AngelRing(Yellow).png
            "9c2691948a9baf44e8231ff1ddd00b36",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Hair_AngelRing.png
            "1c368911528c60d429257dc57624517f",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Iridescent(Large).png
            "3d294a5afc79400468719f6af35dabdf",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Iridescent(Multi).png
            "efd84db93a4cca24d93687e84f48fdf8",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Iridescent(Small).png
            "ae7d1c4c107c5794c8c4ec92b3e31630",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Skin_Glare+Gloss(LargePoint).png
            "96cf3bb60ffe3384fbd847ec4857c9dc",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Shadeless_Skin_Glare.png
            "a8ca5b675c614d348ac51cc580b8e5e2",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Skin_Dark(Peach).png
            "8ace27bb9234eff44b5ec8f841b8ddaf",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Skin_Dark(Red).png
            "865d0a3b58a86df45ac20e870fcf6255",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Skin_Dark(White).png
            "bf45007d8a3c0aa4098a23916c68e58d",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Skin_Dark(Yellow).png
            "cf7bfae60977d664b911c3e163bb92a8",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Skin_Pale(Peach).png
            "01a3d35c1bc39f646a22769f40bbbb20",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Skin_Pale(Red).png
            "4fed231081a962e428e196625a7a4475",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Skin_Pale(White).png
            "478dd3812b01a39469a08b45e94ea6fa",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Skin_Pale(Yellow).png
            "4ff7604ea3c143144a465740b84499dc",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Tights_HighDensity.png
            "3d29d801cba569448b6aacb582271a69",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/WhiteFlare/MedianCap/mcap_WF_Tights_LowDensity.png
            "020b20d50dee3b64784514e35d8a53b8",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/HairMat.png
            "a2b389612cf565643b4b0bbd236f3335",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/Ramp1.png
            "8339ae69dbe9dcc439ff088723737cfb",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/Ramp2.png
            "0280c480c48fcbe40ac3bd5b8888b2d7",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/ReadMe.txt
            "f99f096fbf6cf4d40a2f990e8076c1db",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/ShadowMat.png
            "401e17d367f33e849a6fdb867b4ce269",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/ShadowMat_BGR.png
            "10af221457820f04c96c4b2932e290ab",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/SkinMat.png
            "4e1e2c12906898449933f67285cdc085",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/SpecMat.png
            "b0a5e22ce82df9b42a386995879e80d0",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/SpecMat2.png
            "c61dab59da88c87499105c1b046bcf73",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/Sample/Albedo.png
            "5f8a50cc30df039489b8ee08453375d2",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/Sample/Metal.png
            "06d8cbe587a3d2c4c967de17cac6c502",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/Sample/Normal.png
            "d469e28ac045d044fb9cb2226a7c9c72",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/Sample/Sample.mat
            "af8197deebc61ce459480bd679aa6abc",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/Sample/Sample_SCSS.mat
            "a3185396b596ad949854a764984b9171",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Editor/SCSS_Inspector.cs
            "dd58167f3f5799f4db066008579b778a",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Editor/SCSS_XSGradientEditor.cs
            "0757509132a7ee748b11bc26b6fd10dd",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Editor/SCSS_XSMultiGradient.cs
            "92b4d092592529b4f9a87764c0c44117",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/Flat Lit Toon (Cutout) (No Outline).shader
            "193c1d1febff24f46bc72d88e8b205f8",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/Flat Lit Toon (Cutout).shader
            "369d2ecd6fc95bc469360ddecf6b2155",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/Flat Lit Toon (No Outline).shader
            "f78fe2d8cca2202429d0c2e0d810c763",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/Flat Lit Toon (Transparent) (No Outline).shader
            "5028bedf4f7ad6a4aaf7727fead41880",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/Flat Lit Toon (Transparent).shader
            "a883b384ca4bc054aa10b5f554ae85a3",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/Flat Lit Toon.shader
            "949047d11aa1be843ab010f80e6e1ad7",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/SCSS_Core.cginc
            "ac54125faed4a1c4d8641c311f115c9d",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/SCSS_Forward.cginc
            "ad30dacf242f54a49b203e540fe72e8a",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/SCSS_Input.cginc
            "8acce3fdffc81da43bbff56f95bd5e98",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/SCSS_Shadows.cginc
            "e4f4f1f16f5f7a940a8a91cda2684a75",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/SCSS_UnityGI.cginc
            "4918d8dc352c4f14095b785dedffaab1",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Shaders/SCSS_Utils.cginc
            "a780591bd355dfb42b8d43171c524127",  // Assets/VketShaderPack/Sunao Shader/LICENSE
            "3e696a6fcbf6c3d48b6b18d391ac27f3",  // Assets/VketShaderPack/Sunao Shader/README.txt
            "52db967a50319a342b8d3e03e2c948c5",  // Assets/VketShaderPack/Sunao Shader/Sunao Shader 解説書.url
            "ac4920ac84fea1840bcc25ab63dd1154",  // Assets/VketShaderPack/Sunao Shader/Editor/SunaoShaderGUI.cs
            "58f628f02e892b441aa26d5402c0fb19",  // Assets/VketShaderPack/Sunao Shader/Logo/SS_logo_B.png
            "28a0ceca2c0231940b7704112685d322",  // Assets/VketShaderPack/Sunao Shader/Logo/SS_logo_BS.png
            "a626f2283039de04e867eeb889b593d2",  // Assets/VketShaderPack/Sunao Shader/Logo/SS_logo_W.png
            "ffa077d687eb240489acb287b977dfa4",  // Assets/VketShaderPack/Sunao Shader/Logo/SS_logo_WS.png
            "f5c1047620033614d8f1f260c8eaaf64",  // Assets/VketShaderPack/Sunao Shader/Sample/Sunao_Shader_Samples.unitypackage
            "01846cdaa65259e48a71d9812e4e1c22",  // Assets/VketShaderPack/Sunao Shader/Shader/Sunao_Shader_Cutout.shader
            "09296c4f29b71fb4ba42ef8983d8007f",  // Assets/VketShaderPack/Sunao Shader/Shader/Sunao_Shader_Cutout_SO.shader
            "3701d6a6f5f988b4a9cea92f1426a955",  // Assets/VketShaderPack/Sunao Shader/Shader/Sunao_Shader_Opaque.shader
            "2fb75b0069e4fe147a396141dcf70627",  // Assets/VketShaderPack/Sunao Shader/Shader/Sunao_Shader_Opaque_SO.shader
            "7362334fb65c850469785caac3918093",  // Assets/VketShaderPack/Sunao Shader/Shader/Sunao_Shader_Stencil_R.shader
            "a95ac57a344b931459880f4ca527efc4",  // Assets/VketShaderPack/Sunao Shader/Shader/Sunao_Shader_Stencil_W.shader
            "0b073aeeaec66294aa00c57784f4a0bb",  // Assets/VketShaderPack/Sunao Shader/Shader/Sunao_Shader_Transparent.shader
            "cd2723fb285798b4b801e483a793b3c3",  // Assets/VketShaderPack/Sunao Shader/Shader/Sunao_Shader_Transparent_SO.shader
            "0bcbd141d25c3594698232b7cf028e95",  // Assets/VketShaderPack/Sunao Shader/Shader/Cginc/SunaoShader_Core.cginc
            "a0a8cef7d729dd548bea8c0179114e1a",  // Assets/VketShaderPack/Sunao Shader/Shader/Cginc/SunaoShader_Frag.cginc
            "7c91ecb7ec33e624aa825469df256c8d",  // Assets/VketShaderPack/Sunao Shader/Shader/Cginc/SunaoShader_Function.cginc
            "349b3c656072d0444812de08c663ff40",  // Assets/VketShaderPack/Sunao Shader/Shader/Cginc/SunaoShader_OL.cginc
            "331fdc83d13aff84cb82da583877f0d7",  // Assets/VketShaderPack/Sunao Shader/Shader/Cginc/SunaoShader_SC.cginc
            "666562b3b8d23d64fa0f6ee5216239b1",  // Assets/VketShaderPack/Sunao Shader/Shader/Cginc/SunaoShader_Vert.cginc
            "e30857b716beae5479b313fde1a5efaf",  // Assets/VketShaderPack/Toon/Editor/CopyMaterialParameter.cs
            "cad15f56be91b744aaf8e22339bc598c",  // Assets/VketShaderPack/Toon/Editor/RemoveUnusedMaterialProperties.cs
            "a9775daf5f793f64e98ccd6c4a61bbc8",  // Assets/VketShaderPack/Toon/Editor/RemoveUnusedShaderKeywordsFromUTS2Material.cs
            "e403ef4b1d56fce47b49ec46981d9fcb",  // Assets/VketShaderPack/Toon/Editor/UTS2GUI.cs
            "4c57a42f315f467488f69755e6a7d42c",  // Assets/VketShaderPack/Toon/Shader/README.txt
            "96d4d9f975e6c8849bd1a5c06acfae84",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather.shader
            "ccd13b7f8710b264ea8bd3bc4f51f9e4",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_Clipping.shader
            "9c3978743d5db18448a8b945c723a6eb",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_Clipping_StencilMask.shader
            "d7da29588857e774bb0650f1fae494c6",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_Clipping_StencilOut.shader
            "315897103223dab42a0746aa65ec251a",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_StencilMask.shader
            "2e5cc2da6af713844956264245e092e4",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_StencilOut.shader
            "369d674ae1ba36249bb00e2f73b0cd10",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_TransClipping.shader
            "8600b2bec3ae31145afa80084df20c61",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_TransClipping_StencilMask.shader
            "43d0eeb4c46f52841b0941e99ac9b16b",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_TransClipping_StencilOut.shader
            "97b7edb5fc0f5744c9b264c2224a0b1e",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_Transparent.shader
            "3b20fc0febd34f94baf0304bf47841d8",  // Assets/VketShaderPack/Toon/Shader/ToonColor_DoubleShadeWithFeather_Transparent_StencilOut.shader
            "af8454e09b3a41448a4140e792059446",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap.shader
            "295fec4a7029edd4eb9522bef07f41ce",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_AngelRing.shader
            "e32270aa38f4b664b90f04cc475fdb81",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_AngelRing_StencilOut.shader
            "29a860a3f3c4cec43ab821338e28eac8",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_AngelRing_TransClipping.shader
            "d5d9c1f4718235248ad37448b0c74c68",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_AngelRing_TransClipping_StencilOut.shader
            "6439813c08a1f8947bb0ca6599499dd7",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_StencilMask.shader
            "b39692f1382224b4cbe21c12ae51c639",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_StencilOut.shader
            "cd7e85b59edbb7740841003baeb510b5",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_TransClipping.shader
            "6b4b6d07944415f44b1fc2f0fc24535f",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_TransClipping_StencilMask.shader
            "31c75b34739dfc64fb57bf49005e942d",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_TransClipping_StencilOut.shader
            "7737ca8c4e3939f4086a6e08f93c2ebd",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_Transparent.shader
            "be27d4be45de7dd4ab2e69c992876edb",  // Assets/VketShaderPack/Toon/Shader/ToonColor_ShadingGradeMap_Transparent_StencilOut.shader
            "9baf30ce95c751649b14d96da3a4b4d5",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather.shader
            "345def18d0906d544b7d12b050937392",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Clipping.shader
            "7a735f9b121d96349b6da0a077299424",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Clipping_StencilMask.shader
            "ed7fba947f3bccb4cbc78f55d7a56a70",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Clipping_StencilOut.shader
            "1d10c7840eb6ba74c889a27f14ba6081",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Mobile.shader
            "88791c14394118d42a5e176b433af322",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Mobile_Clipping.shader
            "41f4ee183cb66ad40bc74a9f8f944974",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Mobile_Clipping_StencilMask.shader
            "dec01cbdbc5b8da4ca8671815cda1557",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Mobile_StencilMask.shader
            "55e8b9eeaaff205469365133fe7bc744",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Mobile_StencilOut.shader
            "d4c592285a93c3844aafdaafffc07ec7",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Mobile_TransClipping.shader
            "100d373b596f44d49ac9bb944d671d32",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_Mobile_TransClipping_StencilMask.shader
            "036bc90bfe3475b4c9fadb85d0520621",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_StencilMask.shader
            "0a1e4c9dcc0e9ea4db38ae9cb5059608",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_StencilOut.shader
            "e8e7d781c3155254b9ea8956c5bd1218",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_TransClipping.shader
            "79add09e32e5c4541980118f6c4045b6",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_TransClipping_StencilMask.shader
            "fb47be5a840097b45bac228446468ef3",  // Assets/VketShaderPack/Toon/Shader/Toon_DoubleShadeWithFeather_TransClipping_StencilOut.shader
            "42a47eda2ed77084c9136507eadb8641",  // Assets/VketShaderPack/Toon/Shader/Toon_OutlineObject.shader
            "2e2edd12fbf6bcb4ea1f34c17ee42df5",  // Assets/VketShaderPack/Toon/Shader/Toon_OutlineObject_StencilOut.shader
            "ca035891872022e4f80c952b3916e450",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap.shader
            "9aadc53d7cdc63f4898ea042aa9d853b",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_AngelRing.shader
            "23e399973d807464fb195291a44a614c",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_AngelRing_Mobile.shader
            "8d33e4e4084e5af449f3e762fecce3c9",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_AngelRing_Mobile_StencilOut.shader
            "415f07ab6fd766048ac6f8c2f2b406a9",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_AngelRing_StencilOut.shader
            "b2a70923168ea0c40a3051a013c93a8a",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_AngelRing_TransClipping.shader
            "d1e11a558d143f14c864edf263332764",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_AngelRing_TransClipping_StencilOut.shader
            "f90e11a40dcf4f745ae6b21b857943fa",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_Mobile.shader
            "206c554c8b0c60041a9d242385f543d3",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_Mobile_StencilMask.shader
            "cfc201757f2519c4bb6ef9265a046582",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_Mobile_StencilOut.shader
            "cce1da34c52aff745adf0222f56a356c",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_Mobile_TransClipping.shader
            "e88039bab21b7894e918126e8fce5d1b",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_Mobile_TransClipping_StencilMask.shader
            "aa2e05ed58ca15441bd0989f008da78b",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_StencilMask.shader
            "923058fda1b61544b93d91eeee772086",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_StencilOut.shader
            "aebd33b74ef849a4882b4a8d55f0f0c9",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_TransClipping.shader
            "0a05dd221bacbb448afac3d63e6bd833",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_TransClipping_StencilMask.shader
            "67212ac11ff43b04a833d3986b997a9f",  // Assets/VketShaderPack/Toon/Shader/Toon_ShadingGradeMap_TransClipping_StencilOut.shader
            "80bd7ce6cad775a4e9de24e18eb5e61e",  // Assets/VketShaderPack/Toon/Shader/UCTS_DoubleShadeWithFeather.cginc
            "ec7b5c1d006f6be49b412bcd7a789c78",  // Assets/VketShaderPack/Toon/Shader/UCTS_Outline.cginc
            "eca315d4d2d36194b8be3cf2a6869762",  // Assets/VketShaderPack/Toon/Shader/UCTS_ShadingGradeMap.cginc
            "ae8d06deb98501947846000ba6cd3ab2",  // Assets/VketShaderPack/Toon/Shader/UCTS_ShadowCaster.cginc
            "5b8a1502578ed764c9880a7be65c9672",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_Clipping_Tess.shader
            "682e6e6cf60a51040ade19437a3f53e2",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_Clipping_Tess_StencilMask.shader
            "148d1eca2cf299e4eb949d15c4cf95ee",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_Clipping_Tess_StencilOut.shader
            "e987cf9cca0941042aa68d1dd51ee20f",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_Tess.shader
            "97df86a7afe06ef41b2a2c242b10593e",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_Tess_StencilMask.shader
            "b179fb8a87955a347b5f594a18b43475",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_Tess_StencilOut.shader
            "60fe384b76fb67d40bc7e38411073dd6",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_TransClipping_Tess.shader
            "4a20b66d106d3f5409f759b5193ecdc2",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_TransClipping_Tess_StencilMask.shader
            "a7842aa9522c7584cae2169b8e1ddb86",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_TransClipping_Tess_StencilOut.shader
            "0cb6c9e6216a91e4a9d38cd2acb4ccb6",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_Transparent_Tess.shader
            "f28bba8b2f259bb40b697d91849c8794",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_DoubleShadeWithFeather_Transparent_Tess_StencilOut.shader
            "4876871966ca2344793e439d7391d7b0",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_AngelRing_Tess.shader
            "7c48bdc9fed28c14b8ad0748673b1369",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_AngelRing_Tess_StencilOut.shader
            "d3fb22770ec830b43bdb5ccb973e6f76",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_AngelRing_Tess_TransClipping.shader
            "11e8f1e181e558a47a387492d3ecdb88",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_AngelRing_TransClipping_Tess_StencilOut.shader
            "01494e58d87212f44ab51d29caea84e4",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_Tess.shader
            "24c20b8ed5be113499b40f4e3b6b03e6",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_Tess_StencilMask.shader
            "9cf7e8eb46e9128438d50adf7a841de6",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_Tess_StencilOut.shader
            "3c39a77fda28b5043a7a17c7877cf7b2",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_TransClipping_Tess.shader
            "bf840a439c33c8b4a99d52e6c3d8511f",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_TransClipping_Tess_StencilMask.shader
            "8eff803eae89c994fae3acf2f686fafa",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_TransClipping_Tess_StencilOut.shader
            "0959cb8822a344c4da890457e668fdc9",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_Transparent_Tess.shader
            "6d115cf94d14d1842a56dfff76b57f42",  // Assets/VketShaderPack/Toon/Shader/Tess/ToonColor_ShadingGradeMap_Transparent_Tess_StencilOut.shader
            "f0b2fc9b8a189134da9c7d24f361caf4",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_Clipping_Tess.shader
            "8c94ee3046ef0574f87f6b658b4e4691",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_Clipping_Tess_StencilMask.shader
            "c4aed8662ca0f194284f3ab649e66d23",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_Clipping_Tess_StencilOut.shader
            "1f248db3b28fc5f44aabd7aca618bd1e",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_Tess.shader
            "a3214384442742648aa664ef0039d397",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_Tess_Light.shader
            "3073cd2564e4cde45a19c05e0012d22a",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_Tess_Light_StencilMask.shader
            "7e7690a767a07da4f943439680e70db8",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_Tess_Light_StencilOut.shader
            "08c65988dc25d9f44b791fcc18fb543a",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_Tess_StencilMask.shader
            "f937ea4ce96dfbe448afc0fb671198e5",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_Tess_StencilOut.shader
            "3fb99ac3775edeb4aa9530db5a614c92",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_TransClipping_Tess.shader
            "9855f226cd8152d4e99085272aceede6",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_TransClipping_Tess_StencilMask.shader
            "2a0d4af863770404faee6488b86fe3c9",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_DoubleShadeWithFeather_TransClipping_Tess_StencilOut.shader
            "1847c44f729b68e49ba63610abdf9132",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_OutlineObject_Tess.shader
            "06cae78b869a3234bab02eeb52197e1c",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_OutlineObject_Tess_StencilOut.shader
            "3a1af221400a61a4b94bae19aa79da2b",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_AngelRing_Tess.shader
            "a1449ab672051624ca3160737b630f5e",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_AngelRing_Tess_Light.shader
            "79d3dc54c32b69b42be17c48d33575f2",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_AngelRing_Tess_Light_StencilOut.shader
            "18c9172cdf36a344f9aca9bbc0e7002d",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_AngelRing_Tess_StencilOut.shader
            "54a94f776a43a074c8c2d205bb934005",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_AngelRing_TransClipping_Tess.shader
            "d496a1c70c797ad43836d5bfff575b5f",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_AngelRing_TransClipping_Tess_StencilOut.shader
            "183ea557143786346b1bfc862ad22636",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_Tess.shader
            "356dd5af8f0d40e41b647d3d0a0555c1",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_Tess_Light.shader
            "ffadecfbd9e31f840ba4109fea0f0436",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_Tess_Light_StencilMask.shader
            "98ac5d198a471494da681b7b8d1e1727",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_Tess_Light_StencilOut.shader
            "0d799eb857c0e2c45bbdfb2c033d33e6",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_Tess_StencilMask.shader
            "e667137c8b6fd3d4390fc364b2e5c70b",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_Tess_StencilOut.shader
            "feba437d8ff93f745a78828529e9a272",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_TransClipping_Tess.shader
            "8d1395a9f4bfad44d8fddd0f2af19b1e",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_TransClipping_Tess_StencilMask.shader
            "08c6bb334aed21c4198cf46b71ebca2d",  // Assets/VketShaderPack/Toon/Shader/Tess/Toon_ShadingGradeMap_TransClipping_Tess_StencilOut.shader
            "6d04fc34e9717d34d9589f39decf8333",  // Assets/VketShaderPack/Toon/Shader/Tess/UCTS_DoubleShadeWithFeather_tess.cginc
            "c139664fde6401f45a09b0f32279484b",  // Assets/VketShaderPack/Toon/Shader/Tess/UCTS_Outline_Tess.cginc
            "ad7807131760d5544843d7424e535b75",  // Assets/VketShaderPack/Toon/Shader/Tess/UCTS_ShadingGradeMap_tess.cginc
            "6261ac20c5dfa024a98d6ce3921bab70",  // Assets/VketShaderPack/Toon/Shader/Tess/UCTS_ShadowCaster_Tess.cginc
            "13aee1e1f6c49d94fa292dca9910126e",  // Assets/VketShaderPack/Toon/Shader/Tess/UCTS_Tess.cginc
            "b8bbbd51c2e41dd4bbcb0da1b7a48808",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/LICENSE
            "4ebc920fe2745624bbed02e79a222e3d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/README.txt
            "b71e250f3c9f9a54cac228148bc800f7",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Editor/WF_Common.cs
            "6b1a45934e0846141979f322772dc3b8",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Editor/WF_DebugViewEditor.cs
            "4f0275352c196ca4d864b6611897bfd7",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Editor/WF_ShaderCustomEditor.cs
            "e3269783b9ab81e4f85d813345bc1a7e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Editor/WF_ShaderToolWindow.cs
            "13aceca36091c3546a994c8c02dcc168",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample.unity
            "c5782c4aad60a544caa7f5383e6a0b90",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/README.txt
            "06913336b6f92e04a84576e8f9afd6a9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Avatar_2A-7s.unity
            "befa386322319ee4587ded7eeba1c19a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornellBox.unity
            "7f71cab99cc077946b99cc04d93355ff",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/etc/CameraRotation.anim
            "77eabe6dee64f244b8c92317eb5830c6",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/etc/CameraRotation.controller
            "cf980f93a9a0e814e8260e4040df7ffc",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/etc/Gem.fbx
            "58bdbcbbe65f69f48af5d965efb1e31c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/etc/LightPivot.anim
            "4c54433c553541d45b13620b67509da5",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/etc/LightPivot.controller
            "82c58dbbc5f31aa49ab2e0ebbd5328a1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/etc/Plane.mat
            "799b0ea89036cc54ab56d421374e38ba",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/etc/ppv_bloom.asset
            "dfa3d74db8de0af499aaa01fd0ea3d7e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/etc/UpdateRealGI.cs
            "af5aea2243dd470499bd0bf866c0b9da",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/BlackGem.mat
            "0efac9871ef36134e8cb4e3e0e58e417",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/GrayGem.mat
            "d1543206c7f9ed343b13306b48245ca1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/LavenderGem.mat
            "182eea833aea07742bfa8fc0a4569886",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/PurpleGem.mat
            "6ac01d29450339841a15c26eba3d8f69",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/RedGem.mat
            "670fd4fcf34aac041a7e8e0371e823dd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/TurquoiseGem.mat
            "df3e5d3bc81bf6c46a04d49fc90e6ffe",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/WhiteGem.mat
            "9fc65c41a4b61824fa4ceab8da248ccd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/YellowAndBlueGem.mat
            "2d1676c3e8dbb8a4d881b86906f193c8",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Baked_2a7s_2ero_A.asset
            "3af6ea1e5e16d184da3ddb6d8c119940",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Baked_2a7s_2ero_A.prefab
            "1e28938dd4d2ace42bb692fb63fcb1cd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Baked_2a7s_2ero_B.asset
            "1aba99f0c3bc49e449f300e33ab4d65e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Baked_2a7s_2ero_B.prefab
            "84dfbffad7f596740917a1141ee43da2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/LightBlue.mat
            "2818ac500dfe28a4a85d13db74f5dcbe",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/LightWhite.mat
            "f7eefc425eaa92b4ebffefdbb614d3d9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/Metallic.mat
            "88355daa712318d4eae5fce35352e6dd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/SolidGreen.mat
            "477ec3581917a6d4f8208e7033266223",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/SolidRed.mat
            "3e5c4d6f454685c48af83064384632f6",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/SolidWhite.mat
            "2f80c16eced9cb349a82cdbda5bd188d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/SolidWhiteSmooth.mat
            "a8131972d52e03346bee8239f2411e6a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_armor(Clone)_asset2.mat
            "1429d632eff8a234c93a9b7fb5f5668a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_body(Clone)_asset0.mat
            "a73dfe133639fa84e8e7d782a6aa3b74",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_face(Clone)_asset4.mat
            "43fa3186550698f47a2b59113d4f7a6f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_faceoption(Clone)_asset5.mat
            "442460180ad002b41bb56108bbcfb4dd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_hair(Clone)_asset3.mat
            "262edb4e47175d548ba2702c87fce227",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_photon(Clone)_asset1.mat
            "ca4943be5b3769a489a1cda05ee74f4c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/Transparent.mat
            "2327c096edc905747aa18533af892a14",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornellBox/LightingData.asset
            "307cfcc30b8ff834a9dbb892877b8e12",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornellBox/Lightmap-0_comp_light.exr
            "77ea737153d8e4b4c90cb950dc010279",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornellBox/ReflectionProbe-0.exr
            "2bea43a9896c1de4ba6c734dd3841a1c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornellBox/ReflectionProbe-1.exr
            "0739262731db5a0478c1bbec35cedbe5",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornellBox/ReflectionProbe-2.exr
            "182cb5733aedff348b9a2f07799d130e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/2a7s_2ero_Avatar.prefab
            "389c6d7a40a8f9e4780b541dedda1d1a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/README.txt
            "15d9dbf5cbf00034cb8d86a1259469a3",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_AllShapes.anim
            "bc735c1fbb4e03f47b8f9c9cdb3c46e9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_amazed.anim
            "f87d81f82cc675d47985484d024fdd18",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_AutoBlink.anim
            "4a592603109b8214da0035b121e30cd2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_AutoBlink.controller
            "340faa19254b3c748a03fe92eb315dd9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_badsmile.anim
            "e16dc9fb4aa51014d8ad04405339a2c7",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_battlemode.anim
            "c39959b49fe31fa4194981cf50b4bf77",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_sit.overrideController
            "07b354fca8089c444a948bd276683262",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_smile.anim
            "554ce4688f58f5748a13d70dcf18771a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_smile2.anim
            "c4979213951708648848ab54301cb2e9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_stand.overrideController
            "3e4677f38b648be41a369ff85cf58df5",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_surprise.anim
            "01b65e05c8d311c4c93f8769c13123b1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/2a72ero_wink.anim
            "80d01521a3ebf2640b0ff858fb8b4e13",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/IDLE_2a7.anim
            "a8b35788e93b1de4c9d5b9725a093640",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/move_back.anim
            "f549b1c776811c0458accc3efcc44eaa",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/move_front.anim
            "71edd79917f3a3f4c99e5c267cf4e144",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/move_Left.anim
            "a8b9b97c6ec1186488573f096fd2a23f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/move_Right.anim
            "d937351867d16274d94e7cf182cb5b36",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/SIT_2a7.anim
            "15317a9f823fb1340a061d070c9949ff",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/anim/編集用2A-7.controller
            "294a186fb5f0bdf49a1a11378bd8f4d9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/fbx/2a7s_2eroVRC.fbx
            "87becb86f20ba0e419af2c5c8a436ba4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_armor.mat
            "8b15ad46734538841955a43f514e9eeb",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_body.mat
            "1004a60cbe00f9c48b9a4416c792490f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_face.mat
            "c54ec1195bccfbd4a96cab6eda085d3a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_faceoption.mat
            "419055f2e83080543a4c34a4f539967e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_hair.mat
            "249b5835018dde04aa22f00a83f47552",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_photon.mat
            "6ad2bcf19007e9d48a7761cf7d060a33",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_armor.png
            "f8ac13ff4d61a2749b99f8679d818bd9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_armor_AMask.png
            "02e92c1301f7bd440973493d264648de",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_body.png
            "c7701c426ad72f74db46eab5968fd6ec",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_body_MMask.png
            "96d71c655cb43a0419db3c810507eee1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_body_Shade1.png
            "1f406f138ad08c740838a8ca3c5f4866",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_body_Shade2.png
            "0659339834cb17044be0508e9ffe6b67",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_body_ShadeBase.png
            "67a76e2e4360845439df1b5f7b74fa84",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_face.png
            "c4b124e9cad9e8a49ab86cde822a5723",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_faceoption.png
            "f6a48352392a79e4fb6bb2fe1dc3da35",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/2a7s_2ero_hair.png
            "932a27bc2fe7702429e2569679724d57",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/eff.png
            "5c9fbc5e0f4fbfb46ba31c3c08b9e326",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/eff_AMask.png
            "3d12ade8a7e64f84683bcdadff67bdfc",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/tex/eff_EMask.png
            "2a4dc116efeb0db4192f11f17d555b87",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Logo/README.txt
            "c02ebf9b7a5d66c4ead5f94ef99b20c8",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Logo/UnlitWFロゴ_1024.png
            "54ed4f64546b23741987a94ff9769567",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Logo/UnlitWFロゴ_256.png
            "b8e19d3beb8c169458f9b150a00f40ec",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Logo/UnlitWFロゴ_512.png
            "81bd216f29ecf2f46b29029ec01f55a3",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/README.txt
            "2d055c29a461c2a45bc8cb64201404e9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_aft_lounge_1k_128.hdr
            "3f65007764dcb6e41bae49ab65119aec",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_aft_lounge_1k_32.hdr
            "c61e595423756a54498716afa385333c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_circus_arena_1k_128.hdr
            "05ff7cbb74648c2419d2eb2755729aca",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_circus_arena_1k_32.hdr
            "31abf9744b47ba14e8df52c79381e957",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_fireplace_1k_128.hdr
            "e30afce8ff8ab3740a49a6b92e879fa2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_fireplace_1k_32.hdr
            "aa3d86f47f6207547b6e68fc337052f4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_lythwood_lounge_1k_128.hdr
            "bb9610632e748424586247724588439e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_lythwood_lounge_1k_32.hdr
            "4beb010867cc3c74984010f8c168b973",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_lythwood_room_1k_128.hdr
            "80b684ec03e5e1c40943d9eb0e0d32f4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_lythwood_room_1k_32.hdr
            "37389f65764fa0241b75028c86fd22d3",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_museum_of_ethnography_1k_128.hdr
            "aae74124d783ccb40affc2a1983d4f1d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_museum_of_ethnography_1k_32.hdr
            "7e629b3699fb05a49987bde9eec6d9f6",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_royal_esplanade_1k_128.hdr
            "8715c6cd897127f46a46aa5123b5f1b8",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_royal_esplanade_1k_32.hdr
            "4df5f1b4f073ee94caf1e0ed00ace798",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_whale_skeleton_1k_128.hdr
            "1c33a09ae8a21af439ec9a61406c55b8",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/HDRIHaven_whale_skeleton_1k_32.hdr
            "55f94f02873c1bb4bb1f43eed973a999",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/CubeMap/README.txt
            "08bbac06846e8f147844273a67efe456",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_タイツ用_低デニール.png
            "613d42ca293473648ad045320c99d552",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_タイツ用_高デニール.png
            "179a7b2e065288849bcc911ef080bdc3",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_ラバー光沢1.png
            "090079d91337d09499c80aa2e2256d46",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_ラバー光沢2.png
            "08ab99404bfb3c0468c356d247a7190a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_ラバー光沢3.png
            "d6224555b7ba6d540ae3dfe0dde6f2c7",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_光沢(フラット多).png
            "d13ca27834483ea48b672bb915b8dba1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_光沢(フラット少).png
            "c0605cdefe210b14abea15ce9fd3417f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_光沢(ポイント多).png
            "128fe33f130bcf64bbe54c19e96ec49a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_光沢(ポイント少).png
            "9ccc1ecb6ffb01b419fae6aba0dcf8de",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_光沢(大型フラット).png
            "42b40040be19b0d40b96071c8c90e864",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_光沢(大型ポイント).png
            "ad7caeb1ed0fce748acfd8a284820e23",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_照り返し.png
            "6158d64813ee5cc43bc3078670c9e5f2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_美肌効果_色白向け(桃).png
            "88c0b9178c875ee488073e573092f4c2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_美肌効果_色白向け(白).png
            "e56d0d9a30210464cac0f0efa479ede6",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_美肌効果_色白向け(赤).png
            "591b5e30a15d11e49ab61536fb547dcf",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_美肌効果_色白向け(黄).png
            "e911f7cd3f4d7d74ab20fa3a09a731ee",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_美肌効果_色黒向け(桃).png
            "c42959027d59ab841bdfca20a88e4e0d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_美肌効果_色黒向け(白).png
            "17b0ab315388e0f46ba4c0a85d64ac7f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_美肌効果_色黒向け(赤).png
            "bb8a3f515ded7fb4fb14d017fa3fb77f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_美肌効果_色黒向け(黄).png
            "ce16c6abbeafbd44ead076da94cfbea9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_虹色光沢(多).png
            "1420cb12f3399a14087808ecf127b252",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_虹色光沢(大型).png
            "6a6ff8276159f0e458f9d30d4507f0ad",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_虹色光沢(少).png
            "c46c03a2561c862429e057772da5354d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_髪用_エンジェルリング(紫).png
            "5db2aaf0a68c706458a44b6ebb8284d7",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_髪用_エンジェルリング(緑).png
            "7ca36260c2ddb0945a87c7bc666203cf",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_髪用_エンジェルリング(赤).png
            "e19fae3455aa0924aaddc7bc3e2892dd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_髪用_エンジェルリング(青).png
            "31eccd9da5305c1468ee523f9da69323",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_髪用_エンジェルリング(黄).png
            "29cc22470c914a14bae0039fb4bf4d2a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/LightCap/lcap_WF_髪用_エンジェルリング.png
            "f1134c41d474f1d4788962d9e17cf81b",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_タイツ用_低デニール.png
            "f4dc102937e1110478b0185ed60ab0b1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_タイツ用_高デニール.png
            "8797e28fe1f8d2c459bc986a84755baf",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_シンプル影(半球).png
            "04c7c759eb6253846bab498b29ad5882",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_シンプル影.png
            "b697412ceb9d5274d95ee0347afbdbf7",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_シンプル影・左右Rim.png
            "c7b09e8f29efaf34c8cba706ce178111",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_シンプル影・青反射.png
            "558b69af68dc78943b14fdc787eb120d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_光沢(Rimあり).png
            "5b8f370a659d3704d9c3e15a1bfa4f90",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_光沢(Rimあり明るめ).png
            "e1436203ff040b94b873ed59bcab6678",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_光沢(白エナメル・虹).png
            "6f4ac56faaf1d2a43a30414b1d679726",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_光沢(黒エナメル・白).png
            "9363ce1a6bde55e4fa7399d25c7743e9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_光沢(黒エナメル・赤).png
            "609254253550b214f914ce959ebb6d30",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_光沢(黒エナメル・青).png
            "b7f123b5ea2244a4aaba5d042dc00507",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_肌用_褐色_Rimあり光沢弱.png
            "39203179d751754459e2c90b0376e622",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_肌用_褐色_光沢強.png
            "e70581dcea3866e4cb251bb4be0a1739",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_肌用_褐色ぬるてか_光沢あり体用.png
            "0e5bc9a3816fa3d459ad7d38ea598ea3",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_肌用_褐色ぬるてか_光沢あり体用・淡色.png
            "a695e50ea627f7f41b2848b6de359f15",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_肌用_褐色ぬるてか_光沢あり体用・無彩色.png
            "98fe32a79800f6c4688ab111d9c49ba1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_肌用_褐色ぬるてか_光沢なし顔用.png
            "bdb8b77b018e1c04fa2df61b75411cdd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_肌用_褐色ぬるてか_光沢なし顔用・淡色.png
            "5f34a1197ebe183419d78c107bc6e9db",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_金属光沢(黄).png
            "282f8caa209b5d1488f17f966e5a89b3",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_階調影(白).png
            "f85649441a33f9144b15a40a0360c44e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_階調影(赤).png
            "4fabf7d0aa4e95d49b52276367df77b6",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_階調影(青).png
            "26e957bfcb2a91548868cd8d6142d158",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_階調影.png
            "f85432be963532143861e9167b7be9e2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_髪用_エンジェルリング(紫).png
            "c07ebf31730a9bb44bd0c487b696f1fd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_髪用_エンジェルリング(緑).png
            "071ceeffe98b2f049b10e7f02c90c430",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_髪用_エンジェルリング(赤).png
            "7a67adccf40eee149ac090548db5450d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_髪用_エンジェルリング(青).png
            "9acc4c651a02a2c4da47ac7380c7913f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_髪用_エンジェルリング(黄).png
            "ec18245b47abdb448ab5355d170aa59c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影あり_髪用_エンジェルリング.png
            "3446e1de8c0404b428b75ad8a6e87eba",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_光沢(フラット多).png
            "86dccb1fc7795f846a525a8308ee4e54",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_光沢(フラット少).png
            "5b14fa6fceeea4049ba1068eae680fbe",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_光沢(ポイント多).png
            "42aefa086f04a0c4da493cba5f967800",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_光沢(ポイント少).png
            "47c49f8937cce8349b0e0117bdfa74aa",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_光沢(大型フラット).png
            "51a89fb06dc78e44ab0109350d417f91",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_光沢(大型ポイント).png
            "63c7cbccd5cbe6e4c9cbcb0161cb3ef4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_照り返し+光沢(ポイント少).png
            "26851ace9fa99da41a7ff293022395b5",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_照り返し.png
            "b2df000ec11e0e14cb19f772ccb7e6ae",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_肌用_照り返し+光沢(フラッシュ多).png
            "32edf483debd1cd4d836b921d5f84947",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_肌用_照り返し+光沢(フラッシュ少).png
            "8d0efbd5c578c744cbe63d7555965650",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_肌用_照り返し+光沢(大型ポイント).png
            "957f1365028d90946921443d6f5b620f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_肌用_照り返し.png
            "783503ba129c3f54da129007334ca2f2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_肌用_褐色ぬるてか.png
            "2c2a5c30c8ddb3748af2d01f1a170636",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_肌用_褐色ぬるてか_光沢なし.png
            "8f8b55f4812cf3049afc082c5423314e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_虹色光沢(多).png
            "439ee1d7a7da3ff4298b7f19d47074be",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_虹色光沢(大型).png
            "95b371241f4109f49bcfdf908bbfb8a5",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_虹色光沢(少).png
            "255a7e166f0b12a488ea9aa33e3e6dc1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_髪用_エンジェルリング(紫).png
            "3b905a61940627747a08286346fd6098",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_髪用_エンジェルリング(緑).png
            "9a12e63cf5c120644a4963b56353fdee",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_髪用_エンジェルリング(赤).png
            "cd35ff0b3c632c94eaa80cc0273c1d1d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_髪用_エンジェルリング(青).png
            "a5659966a921b7c49a5679b70e631df1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_髪用_エンジェルリング(黄).png
            "0089774353388424d8f87a85c5dd84b2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_影なし_髪用_エンジェルリング.png
            "daef60d7bbc3c9c44a3e80ffe828922d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_水着の光沢_白.png
            "361575d1412309749b8ea179be01f36a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_水着の光沢_青.png
            "cf126589fa05d1346aa939a9565ada80",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_美肌効果_色白向け(桃).png
            "f4ff8e51f9e7cf14db04dcc841c5d4ec",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_美肌効果_色白向け(白).png
            "b200b5f176f4401439b00ff94e252daf",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_美肌効果_色白向け(赤).png
            "945d9c80ea372574fa01168c71306c9a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_美肌効果_色白向け(黄).png
            "fd06b399266ff8c44aa5446fc64c74f3",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_美肌効果_色黒向け(桃).png
            "05e94f0d1c6880c4182364d36e85e517",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_美肌効果_色黒向け(白).png
            "6639c74cf5cfa504787962e571f7368f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_美肌効果_色黒向け(赤).png
            "3d3742b7c46abf441a975a99aa5ce800",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/MedianCap/mcap_WF_美肌効果_色黒向け(黄).png
            "0c90f262b70f7634ea0fb53f2912f537",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_ランダム(粗)_1024.png
            "02127e119f3a2504987f0798bfcf1746",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_ランダム(細)_1024.png
            "a441101aa83065349939cbc597424ce4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_凹凸(粗)_1024.png
            "441fc4840e1fdb9438db8ff0e4bda024",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_凹凸(細)_1024.png
            "f89fef9173c00fa4198dc8a319cf21d5",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_平布1_1024.png
            "ab368b9cd1215154d94cbe2142e3c109",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_平布2_1024.png
            "47e74ccc09bb85d4c9e273e09f183fcd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_斑(粗)_1024.png
            "45c7c44b162f6f64aba19a594b3e9bd9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_斑(細)_1024.png
            "0297ab7e9e4a80e4e9bc70a13cc7987b",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_編布(粗)_1024.png
            "202d4cf5665abdc4ca30ed29f524e886",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/noise_編布(細)_1024.png
            "bbf41367697302d4eb03deed8d94c784",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_ランダム(粗)_1024.png
            "c7928488b21f3484391f5060e004cc29",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_ランダム(細)_1024.png
            "5f156cb39cc17004e953ef176689a79c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_凹凸(粗)_1024.png
            "ba587353da6c721418c7a2b4bd4cd7bf",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_凹凸(細)_1024.png
            "ac6eb3c6294756149a288c2f7f5574c2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_平布1_1024.png
            "7153dfc6361998e498d2f7e91713a218",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_平布2_1024.png
            "385ca7e21b743ff44b3cda515ea10c3b",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_斑(粗)_1024.png
            "32013e17de26e81429e188422fa26495",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_斑(細)_1024.png
            "98e490be901bd7c479e60aa479d210f7",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_編布(粗)_1024.png
            "813ee6eb54e3e3642a0bac40a9e806e2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Matcaps/Noise素材/normal_編布(細)_1024.png
            "c7e5995223250464cac205689e058693",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_DebugView.shader
            "58bb80b63bec29d4384e105c53ca6970",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_FakeFur_TransCutout.shader
            "2210f95a2274e9d4faf8a14dac933fdb",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_FakeFur_Transparent.shader
            "c0f75d3ed420fd144a74722588d3bc21",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_Gem_Opaque.shader
            "21f6eaa1dd1f25c4cb29a42c4ff5d98f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_Gem_Transparent.shader
            "4ba701b07ccc81e4aae7f053bf332eab",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Custom_GhostTransparent.shader
            "871fd7a51a8ea3e4980c3fe7b8347619",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Custom_PowerCap_Outline_Opaque.shader
            "58ccf9c912b226146a25726b8a1f04db",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Custom_Tess_PowerCap_Opaque.shader
            "4bd76f6599a5b8e4d88d81300fb74c37",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Mobile_Opaque.shader
            "af3422dc9372a89449a9f44d409d9714",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Mobile_TransCutout.shader
            "0a7a6cdca16a38548a5d81aca8d4e3ba",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Mobile_Transparent.shader
            "4e4be4aab63a2bd4fbcea2390ae92fdf",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Mobile_TransparentOverlay.shader
            "a3678756e883b9349ac22fce33313139",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Opaque.shader
            "a5ae7f40ac53e274ea0bc1262e1f6895",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Outline_Opaque.shader
            "ab4eb87c406a22f46887cf72178e2685",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Outline_TransCutout.shader
            "5523e041d29d259439fa14bd131f5c82",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Outline_Transparent.shader
            "5498b01615002d948bea7542f55e0c07",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Outline_Transparent3Pass.shader
            "9350854c6e88f3f4eb873d2f94ff3328",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Outline_Transparent_MaskOut.shader
            "ad88000744b4fb241835ba6ec106caf4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Outline_Transparent_MaskOut_Blend.shader
            "0733cfc88032e8d4eafce250263c497c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_PowerCap_Opaque.shader
            "2cf66b0706c40744baab089297afa895",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_PowerCap_TransCutout.shader
            "747bf283d686334469fb662b2fc4a5c2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_PowerCap_Transparent.shader
            "d242cb83664caae4f957030870dd801d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_PowerCap_Transparent3Pass.shader
            "dd3a683002b3a6f43bdb6c97bd0985c1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Tess_Opaque.shader
            "94ee7f8988740fd4887f8b1ce41f0c1c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Tess_TransCutout.shader
            "3bde56820d1aece41bd22966876a061c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Tess_Transparent.shader
            "78d2e3fa0b8eb674aa9cf9e048f79c93",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Tess_Transparent3Pass.shader
            "8c7888a4ac175584f81e0b6e7d4af5a7",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_TransCutout.shader
            "15212414cba0c7a4aac92d94a4ae8750",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Transparent.shader
            "d1e7b0a18e221a1409ad59065ec157e4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Transparent3Pass.shader
            "2efe527cfcbf0e1408b67463225f552f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Transparent_Mask.shader
            "0b53cf0bcd0f9db4fa9d1297d255d06d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Transparent_MaskOut.shader
            "d01a5c313ada49e488b2ef8c6b00f56d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Unlit_WF_UnToon_Transparent_MaskOut_Blend.shader
            "0380b1621ab524c43aeb10eba3346ea6",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/WF_Common.cginc
            "ef1a901a2feeb0a45859ecc184e2e3e2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/WF_FakeFur.cginc
            "45af0d16a1af0a947b445e08dd6dead4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/WF_Gem.cginc
            "22546fe6fb0bed84e8db3fc80b0b2302",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/WF_UnToon.cginc
            "8e439fa11883d4b429904a7fc398851e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/WF_UnToon_Function.cginc
            "074195645f64a224d9482cb666563c89",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/WF_UnToon_Meta.cginc
            "bf91baf439ae72542bd718eb51378f5a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/WF_UnToon_PowerCap.cginc
            "ad9922cd501663b4cbfbef594d1b22d0",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/WF_UnToon_ShadowCaster.cginc
            "95ae3c73098e55148862b3125c46785e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/WF_UnToon_Tessellation.cginc
            "261cdf12e5bca1442958cf95a815b493",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_Color.shader
            "805db4766a215044da0cb3847cc05d75",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_ColorFade.shader
            "1b0e8ee3ccd31b4439fd21a0b74b5bcb",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_Simple.shader
            "fe2d6dc08f1694b4fb5aca4b85419b93",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_Texture.shader
            "5b4c1a20adb795441b90d80f2b581d7b",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_TransCutout.shader
            "c14d7f0d267c3e64ba2ba8c749bcab04",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_Transparent.shader
            "c640751026d34764b90f5027359d888a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_Transparent3Pass.shader
            "46dd63f81fc0acb468f42b4248c47d49",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_Transparent_Mask.shader
            "c7f33aeb1c9a2994598fcf89d5a3360c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_Transparent_MaskOut.shader
            "1ecd76a113e16a443a90ad5932729a36",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/Unlit_WF_MatcapShadows_Transparent_MaskOut_Blend.shader
            "eb442eb4a8a9b8b4e938199b39363da4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Shaders/Old/WF_MatcapShadows.cginc
            "0c23e5908bcdfaf498f03fc626fe8a46",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/LICENSE
            "86d4b790f390cce47810844e4b4a93d0",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/README.md
            "5686e1cbe30779e4cb12a3cfebd04af4",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/XSToon 2.0 _ Carbon Fiber.mat
            "80add08b1b71e974cb7445f615a6d45f",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/XSToon 2.0 _ StippledHalftone.mat
            "072ae31b0e1564b4eb95e3b4437e7d1d",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/XSToon 2.0.mat
            "56bf125c9c397154ab9ee5a017746a85",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Editor/XSGradientEditor.cs
            "e89d2df0d1b52e4448cda16d9d6eed7d",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Editor/XSMultiGradient.cs
            "0e1d31a0eef7c5644832cbcbfc92e7d5",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Editor/XSReimportMyShadersPlease.cs
            "dee482cbfe1d3634ab799af2c78502f0",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Editor/XSStyles.cs
            "263ae1c7b2037ed4fbf02e938e8bceb4",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Editor/XSTextureMerger.cs
            "005c83a3d97ccf040bdbfacbf03b42dc",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Editor/XSToonInspector.cs
            "65e344abcde5260468f0010b4c73a2fa",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Editor/XSUpdater.cs
            "be9c15115645ef049adaf17bee497ab7",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Editor/Resources/MultiGradient_Object_Ico.png
            "d7083d96cb8a0da48beb300faaf2e125",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/CGIncludes/XSDefines.cginc
            "f7d2bc5531da1c44aa6e753eb1c8636f",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/CGIncludes/XSFrag.cginc
            "4bc0681c9b92ff74ba271d2b561e56cf",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/CGIncludes/XSGeom.cginc
            "3007b66203f38424caffb4c058879c59",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/CGIncludes/XSHelperFunctions.cginc
            "b34fd1827e9b4974db3ee215e80ce465",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/CGIncludes/XSLighting.cginc
            "59e9937e913f34b4c9335c6f6b288c78",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/CGIncludes/XSLightingFunctions.cginc
            "5b58e93d18a5b6e4cb9b99f377f4a994",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/CGIncludes/XSShadowCaster.cginc
            "3e944a29d3c4a044a8bfc8d73ed46f60",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/CGIncludes/XSVert.cginc
            "1f506dc0051cf3f45a07f5b7f3ec7cac",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Plugins/WireframeOverride/CGInc/XSGeom.cginc
            "6732df5575ce46d40a726c4b1fd1f922",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Plugins/WireframeOverride/Shaders/XSToon2.0_WireframeOverride.shader
            "52a12016c80b7754bb152e61e099587e",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Plugins/WireframeOverride/Shaders/XSToon2.0_WireframeOverride_A2C.shader
            "e5fbf2c44c61cdb4a9f113a0995b488f",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 Cutout.shader
            "cb3736c178a4f40499e187552b389d4a",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 CutoutA2C Outlined.shader
            "2eb687a5a03872c4aac5ed4518bfcac2",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 CutoutA2C.shader
            "a22455601ad4cc4469967733ddbef64e",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 CutoutA2CMasked.shader
            "1cd7a3c6dcaa5a149be88450dc7b72a6",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 Dithered Outlined.shader
            "00c5c2cffb09f62419ee035e43cb1027",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 Dithered.shader
            "dd611dd59dfd3ea4da520b5007f4b549",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 Fade.shader
            "956a7ff9ce5a1cf4c8735b173dfac4bc",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 Outlined.shader
            "62a1e86cebad79d4395e32051831724e",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 Transparent RecieveShadowsFromUnderneath.shader
            "ade84c4423293ed47b5a99a571e4d80c",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0 Transparent.shader
            "85c615217d617204cb497ae6838b8bae",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToon2.0.shader
            "39f23e8c24d1e864096d29da0407b88e",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Main/Shaders/XSToonStenciler.shader
            "f66d026b6ceed614ba4e5242c17e59b5",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/AO/TriaxialWeave_AO.png
            "40ea18bf7298bd3428adcd1737d4b66e",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/CubeMaps/glass_passage_1k.hdr
            "efb6603dbbc0ab040848d6b6e2d2091e",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/CubeMaps/short_tunnel_1k.hdr
            "dab1297d5c0a834408f49a7365015920",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/CubeMaps/XSStudio_3Light.exr
            "efc14fb6a410a27428a516b78b346c33",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/CubeMaps/XSStudio_SkyLight.exr
            "8a16b055fdf67054aaea56d1907f39b7",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/CubeMaps/XSStudio_SoftUnder_3Mid.exr
            "6707d30b9abd3e244b6bb7b3797b013b",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Metal/Anistropic Metal.jpg
            "4303d29ccd156034d9950aa050a59f3c",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Metal/ArtisticMetal.exr
            "0ab1477629f706a45bb7b99bbf97e33f",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Metal/FireLitMetal.exr
            "f740bde6462de5e4b96b07daeeefbff8",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Metal/LightSteel.jpg
            "2aee663d3fa347b49b73df5d27cef38e",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Metal/MetalAF.exr
            "2eb97550e316c3347831faf08ac6bb64",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Metal/MetallicPurpleGreen.exr
            "79db10ff60487f748a5cd3f0065d7400",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Metal/MetallicRegPurple.png
            "da32fe84b577f0246adf3b4ecc490b69",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Skin/DeepSkintone.exr
            "1e82fa48fd9295540ab46a89ea403a8f",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Skin/LightSkin.exr
            "0818273a570e4084a9f9d258b34ae2c2",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Skin/LightSkin2.exr
            "afa6fb48b4cd0bf48a20623477e78f85",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Skin/Skin.exr
            "5fb787fb7dd30d849837c095d7bf8e01",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Unique/Amber.exr
            "1273e32827ed4f04f9516dbbcd0ac25d",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Unique/BlueRedBacklit.exr
            "2cbdf1f25b78eba409fca976ed98e531",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Unique/Default.exr
            "6b28500662c4f1f48a8661ed99c56a2e",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Unique/Lightbulb.exr
            "3335747e6d5447b49b52f863baaaa7dc",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Unique/Normals.exr
            "420d03330b808f34b8f3f2c0b1c77dfb",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Unique/Painting.jpg
            "eb13dbc9c89b8424c8f21eabee6af2c4",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Matcap/Unique/resin.exr
            "0c540c5cf863ea743b3091ace3a20e07",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Normal Maps/CrossWeave_N.png
            "24055b3e737e1c949ac98a1f42b42f02",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Normal Maps/TriaxialTint.png
            "1632d2058ed6e554cae477f5a18dbcd6",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Normal Maps/TriaxialWeave_N.png
            "c907c0321c6c65741942d4b98c578003",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Shadow Ramps/Generated/gray to white.png
            "a49de73e4c2486943b4fd591c1607441",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Shadow Ramps/Generated/redgradient.png
            "564b27c878c5df04f86d017bb6f75452",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Shadow Ramps/Generated/skingradient.png
            "12043050a25113c4099c34d2a3ae1eb4",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Shadow Ramps/Generated/skingradient2.png
            "1ee69b57a0cfcc24c8fb898e84d8a84f",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Shadow Ramps/Generated/smoothcutoff black to white.png
            "833058007f71b1b42b6d2a052121d494",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Shadow Ramps/MGPresets/Example_MultiGradient.asset
            "cf6c1f21161d44548a43bcd566b5bbd0",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Specular Patterns/Abstract1.png
            "2d494ba3ef3a48e43abe4ae435602b78",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Specular Patterns/Brushed Map.tif
            "6e3ab83cce46dee44b40d0ea5202fce8",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Specular Patterns/Skulls.png
            "a9d899b9b5f746b4cbf7ec49e7b32ccd",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/Textures/Specular Patterns/SpecLines.png
        };

        public static string[] MaterialGUIDs = new string[]
        {
            "0de3ccc1017c4a045a4fed5f810c2748",  // Assets/VketAssets/Prefabs/AvatarPedestal/Materials/UI-Lookat.mat
            "0bfe6778f100206489baf9dbd0c24646",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/avatar1-helloweenmqo_服_AlbedoTransparency.mat
            "88581c9aef71ea549b2f133599cb89bf",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mat1.mat
            "88728f426bf72d74b9abd9ceb8ecbd2c",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 1.mat
            "112ba1c1df66b5e47b93c5c355fb8e69",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 10.mat
            "27f323571b8327e409c9b9669fb84d93",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 11.mat
            "7d4ac9335e1cc82488a383bd849a380c",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 12.mat
            "eb0465484fd24bd458c85ad5c6554747",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 2.mat
            "d6390657f902d1142a20b5cc7f92ffe2",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 3.mat
            "119d5edced9d6bf469181f8497c65731",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 4.mat
            "2f2236791569d124eb4b48f19730cb06",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 5.mat
            "f651c02bf9fdac1408c87c0e4f6cdd2b",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 6.mat
            "345659f361c837b4cab35176f8c8d671",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 7.mat
            "57338689439fb4a4fa1a42ebf3816059",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 8.mat
            "86c25d309b5f3114ab3f949d7655aea3",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material 9.mat
            "a2d8565e76f62d14e9c149040f122c19",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/material.mat
            "a87e62033b0ad4848838ebcf5f89858f",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/violin.mat
            "b407561bc3f21de4c8808646f3a719ca",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/Walls.mat
            "5ebfcc9cd374c614dba1f903f8de36ba",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/cloth/Cloth.mat
            "130e4ea006e957749a3e19016c5b918a",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/EmissiveFreak/EmissiveFreakMaterial 1.mat
            "6182e5d390ecba149a1f8d75312e956e",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/EmissiveFreak/EmissiveFreakMaterial.mat
            "4329612c3238cc44091f699ba05da324",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin/mannequin1.mat
            "5cdca66777e3963468a57b44e76b86c4",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin/mannequin2.mat
            "63000287678da044197a3ff745d75c25",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-knit/mannequin-knit.mat
            "c2c262af144c1b042adc2954103f4e22",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-painted-stl/mannequin-green-metal.mat
            "e9bfebf98ae9cae45b922038482fc4da",  // Assets/VketShaderPack/arktoon Shaders/Examples/Objects/Materials/mannequin-painted-stl/mannequin-steel.mat
            "497f8485774204244abb7ba6c0865927",  // Assets/VketShaderPack/Mochie/Unity/Prefabs/Default.mat
            "4f42a26097c877b40a7616aa60580c43",  // Assets/VketShaderPack/MToon-3.4/MToon/Samples/Materials/Ex_OutlineWidth_Screen.mat
            "e40a129e14e378c4db040df3fd4a6077",  // Assets/VketShaderPack/MToon-3.4/MToon/Samples/Materials/Ex_OutlineWidth_World.mat
            "54da18ba3126f1343924588562df72e0",  // Assets/VketShaderPack/MToon-3.4/MToon/Samples/Materials/Ground.mat
            "9639e17dffc656345a70282f7f216672",  // Assets/VketShaderPack/MToon-3.4/MToon/Samples/Materials/Toon.mat
            "d469e28ac045d044fb9cb2226a7c9c72",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/Sample/Sample.mat
            "af8197deebc61ce459480bd679aa6abc",  // Assets/VketShaderPack/SCSS-master/Assets/Silent's Cel Shading Shader/Assets/YSHT/Sample/Sample_SCSS.mat
            "82c58dbbc5f31aa49ab2e0ebbd5328a1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/etc/Plane.mat
            "af5aea2243dd470499bd0bf866c0b9da",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/BlackGem.mat
            "0efac9871ef36134e8cb4e3e0e58e417",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/GrayGem.mat
            "d1543206c7f9ed343b13306b48245ca1",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/LavenderGem.mat
            "182eea833aea07742bfa8fc0a4569886",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/PurpleGem.mat
            "6ac01d29450339841a15c26eba3d8f69",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/RedGem.mat
            "670fd4fcf34aac041a7e8e0371e823dd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/TurquoiseGem.mat
            "df3e5d3bc81bf6c46a04d49fc90e6ffe",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/WhiteGem.mat
            "9fc65c41a4b61824fa4ceab8da248ccd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/Gem_Sample_Assets/GemMaterials/YellowAndBlueGem.mat
            "84dfbffad7f596740917a1141ee43da2",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/LightBlue.mat
            "2818ac500dfe28a4a85d13db74f5dcbe",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/LightWhite.mat
            "f7eefc425eaa92b4ebffefdbb614d3d9",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/Metallic.mat
            "88355daa712318d4eae5fce35352e6dd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/SolidGreen.mat
            "477ec3581917a6d4f8208e7033266223",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/SolidRed.mat
            "3e5c4d6f454685c48af83064384632f6",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/SolidWhite.mat
            "2f80c16eced9cb349a82cdbda5bd188d",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/SolidWhiteSmooth.mat
            "a8131972d52e03346bee8239f2411e6a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_armor(Clone)_asset2.mat
            "1429d632eff8a234c93a9b7fb5f5668a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_body(Clone)_asset0.mat
            "a73dfe133639fa84e8e7d782a6aa3b74",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_face(Clone)_asset4.mat
            "43fa3186550698f47a2b59113d4f7a6f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_faceoption(Clone)_asset5.mat
            "442460180ad002b41bb56108bbcfb4dd",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_hair(Clone)_asset3.mat
            "262edb4e47175d548ba2702c87fce227",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/tex_photon(Clone)_asset1.mat
            "ca4943be5b3769a489a1cda05ee74f4c",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_CornelBox_Assets/Materials/Transparent.mat
            "87becb86f20ba0e419af2c5c8a436ba4",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_armor.mat
            "8b15ad46734538841955a43f514e9eeb",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_body.mat
            "1004a60cbe00f9c48b9a4416c792490f",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_face.mat
            "c54ec1195bccfbd4a96cab6eda085d3a",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_faceoption.mat
            "419055f2e83080543a4c34a4f539967e",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_hair.mat
            "249b5835018dde04aa22f00a83f47552",  // Assets/VketShaderPack/Unlit_WF_ShaderSuite/Examples/UnToon_Sample_Assets/2a7s_2eroVRC/mat/tex_photon.mat
            "5686e1cbe30779e4cb12a3cfebd04af4",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/XSToon 2.0 _ Carbon Fiber.mat
            "80add08b1b71e974cb7445f615a6d45f",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/XSToon 2.0 _ StippledHalftone.mat
            "072ae31b0e1564b4eb95e3b4437e7d1d",  // Assets/VketShaderPack/Xiexes-Unity-Shaders-2.2.4.1/XSToon 2.0.mat
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

        public static string[] UdonBehaviourPrefabGUIDs = new string[]
        {
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