using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public class AvatarShowcaseRuleSet : Vket5RuleSetBase
    {
        public override string RuleSetName
        {
            get
            {
                return "Vket5 - AvatarShowcase";
            }
        }

        protected override long FolderSizeLimit
        {
            get
            {
                return 30 * MegaByte;
            }
        }

        protected override Vector3 BoothSizeLimit
        {
            get
            {
                return new Vector3(2, 2.5f, 2);
            }
        }

        protected override int VRCTriggerCountLimit
        {
            get
            {
                return 12;
            }
        }
        protected override int MaterialUsesLimit
        {
            get
            {
                return 10;
            }
        }

        protected override int LightmapCountLimit
        {
            get
            {
                return 1;
            }
        }

        protected override LightConfigRule.LightConfig ApprovedPointLightConfig
        {
            get
            {
                return new LightConfigRule.LightConfig(new LightmapBakeType[] { });
            }
        }

        protected override LightConfigRule.LightConfig ApprovedSpotLightConfig
        {
            get
            {
                return new LightConfigRule.LightConfig(new LightmapBakeType[] { });
            }
        }

        protected override LightConfigRule.LightConfig ApprovedAreaLightConfig
        {
            get
            {
                return new LightConfigRule.LightConfig(new LightmapBakeType[] { });
            }
        }

        protected override int AreaLightUsesLimit
        {
            get
            {
                return 0;
            }
        }

        protected override LightmapBakeType[] unusablePointLightModes
        {
            get
            {
                return new LightmapBakeType[] { };
            }
        }

        protected override LightmapBakeType[] unusableSpotLightModes
        {
            get
            {
                return new LightmapBakeType[] { };
            }
        }

        protected override ValidationLevel AdvancedObjectValidationLevel
        {
            get
            {
                return ValidationLevel.DISALLOW;
            }
        }

        protected override int ChairPrefabUsesLimit
        {
            get
            {
                return 0;
            }
        }

        protected override int PickupObjectSyncUsesLimit
        {
            get
            {
                return 3;
            }
        }
    }
}