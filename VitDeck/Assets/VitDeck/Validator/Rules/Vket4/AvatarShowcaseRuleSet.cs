using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public class AvatarShowcaseRuleSet : Vket4RuleSetBase
    {
        public override string RuleSetName
        {
            get
            {
                return "Vket4 - AvatarShowcase";
            }
        }

        protected override int MaterialUsesLimit
        {
            get
            {
                return 10;
            }
        }

        protected override int AreaLightUsesLimit
        {
            get
            {
                return 0;
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
    }
}