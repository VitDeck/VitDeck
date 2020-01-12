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
                // エラー項目がでないダミー検証
                return new LightConfigRule.LightConfig(
                            new[] { LightmapBakeType.Baked, LightmapBakeType.Realtime, LightmapBakeType.Mixed });
            }
        }
        protected override LightConfigRule.LightConfig ApprovedSpotLightConfig
        {
            get
            {
                // エラー項目がでないダミー検証
                return new LightConfigRule.LightConfig(
                            new[] { LightmapBakeType.Baked, LightmapBakeType.Realtime, LightmapBakeType.Mixed });
            }
        }
        protected override LightConfigRule.LightConfig ApprovedAreaLightConfig
        {
            get
            {
                // エラー項目がでないダミー検証
                return new LightConfigRule.LightConfig(
                            new[] { LightmapBakeType.Baked, LightmapBakeType.Realtime, LightmapBakeType.Mixed });
            }
        }
    }
}