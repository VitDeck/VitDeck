#if VRC_SDK_VRCSDK3
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using VRC.SDKBase;

namespace VitDeck.Validator
{
    public class UdonCubeRuleSet : Vket5UdonRuleSetBase
    {
        public override string RuleSetName
        {
            get
            {
                return "Vket5 - UdonCube";
            }
        }

        protected override long FolderSizeLimit
        {
            get
            {
                return 100 * MegaByte;
            }
        }

        protected override Vector3 BoothSizeLimit
        {
            get
            {
                return new Vector3(10, 10, 10);
            }
        }

        protected override VRC_EventHandler.VrcBroadcastType[] VRCTriggerBroadcastTypesWhitelist
        {
            get
            {
                return base.VRCTriggerBroadcastTypesWhitelist.Concat(new[] {
                    VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered }).ToArray();
            }
        }

        protected override VRC_EventHandler.VrcEventType[] VRCTriggerActionWhitelist
        {
            get
            {
                return base.VRCTriggerActionWhitelist.Concat(new[] {
                    VRC_EventHandler.VrcEventType.TeleportPlayer }).ToArray();
            }
        }

        protected override int VRCTriggerCountLimit
        {
            get
            {
                return 50;
            }
        }

        protected override int MaterialUsesLimit
        {
            get
            {
                return 60;
            }
        }

        protected override int LightmapCountLimit
        {
            get
            {
                return 2;
            }
        }

        protected override LightConfigRule.LightConfig ApprovedPointLightConfig
        {
            get
            {
                return new LightConfigRule.LightConfig(
                            new [] { LightmapBakeType.Baked, LightmapBakeType.Realtime });
            }
        }

        protected override LightConfigRule.LightConfig ApprovedSpotLightConfig
        {
            get
            {
                return new LightConfigRule.LightConfig(
                            new[] { LightmapBakeType.Baked, LightmapBakeType.Realtime });
            }
        }

        protected override LightConfigRule.LightConfig ApprovedAreaLightConfig
        {
            get
            {
                return new LightConfigRule.LightConfig(
                            new[] { LightmapBakeType.Baked });
            }
        }

        protected override int AreaLightUsesLimit
        {
            get
            {
                return 3;
            }
        }

        protected override LightmapBakeType[] unusablePointLightModes
        {
            get
            {
                return new LightmapBakeType[] { LightmapBakeType.Realtime, LightmapBakeType.Mixed };
            }
        }

        protected override LightmapBakeType[] unusableSpotLightModes
        {
            get
            {
                return new LightmapBakeType[] { LightmapBakeType.Realtime, LightmapBakeType.Mixed };
            }
        }

        protected override ValidationLevel MoreAdvancedObjectValidationLevel
        {
            get
            {
                return ValidationLevel.ALLOW;
            }
        }

        protected override int ChairPrefabUsesLimit
        {
            get
            {
                return 1;
            }
        }

        protected override int PickupObjectSyncUsesLimit
        {
            get
            {
                return 10;
            }
        }
    }
}
#endif