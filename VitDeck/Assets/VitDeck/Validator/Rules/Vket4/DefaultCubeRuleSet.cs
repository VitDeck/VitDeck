using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace VitDeck.Validator
{
    public class DefaultCubeRuleSet : Vket4RuleSetBase
    {
        public override string RuleSetName
        {
            get
            {
                return "Vket4 - DefaultCube";
            }
        }

        protected override int MaterialUsesLimit
        {
            get
            {
                return 60;
            }
        }

        protected override int AreaLightUsesLimit
        {
            get
            {
                return 3;
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
    }
}