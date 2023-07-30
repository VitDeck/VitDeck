using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// 特定のLightの設定が制限に従っていることを検証するルール
    /// </summary>
    public class LightConfigRule : BaseRule
    {
        public const float NO_LIMIT = -1;

        private LightType type;
        private readonly LightmapBakeType[] approvedLightmapBakeTypes;
        private readonly LightShadows[] approvedLightShadows;
        private readonly float minRange;
        private readonly float maxRange;
        private readonly float minIntensity;
        private readonly float maxIntensity;
        private readonly float minBounceIntensity;
        private readonly float maxBounceIntensity;

        private string bakeTypeListString;
        private string shadowsListString;

        public LightConfigRule(
                string name,
                LightType type,
                LightmapBakeType[] approvedLightmapBakeTypes,
                float minRange = NO_LIMIT, float maxRange = NO_LIMIT,
                float minIntensity = NO_LIMIT, float maxIntensity = NO_LIMIT,
                float minBounceIntensity = NO_LIMIT, float maxBounceIntensity = NO_LIMIT
        ) : base(name)
        {
            this.type = type;
            this.approvedLightmapBakeTypes = approvedLightmapBakeTypes;
            this.minRange = minRange;
            this.maxRange = maxRange;
            this.minIntensity = minIntensity;
            this.maxIntensity = maxIntensity;
            this.minBounceIntensity = minBounceIntensity;
            this.maxBounceIntensity = maxBounceIntensity;
        }

        public LightConfigRule(
            string name,
            LightType type,
            LightConfig approvedConfig
        ) : base(name)
        {
            this.type = type;
            this.approvedLightmapBakeTypes = approvedConfig.bakeTypes;
            this.approvedLightShadows = approvedConfig.lightShadows;
            this.minRange = approvedConfig.minRange;
            this.maxRange = approvedConfig.maxRange;
            this.minIntensity = approvedConfig.minIntensity;
            this.maxIntensity = approvedConfig.maxIntensity;
            this.minBounceIntensity = approvedConfig.minBounceIntensity;
            this.maxBounceIntensity = approvedConfig.maxBounceIntensity;
        }

        protected override void Logic(ValidationTarget target)
        {
            var objs = target.GetAllObjects();

            bakeTypeListString = string.Join(", ", approvedLightmapBakeTypes.Select(x => x.ToString()).ToArray());
            if (approvedLightShadows != null)
            {
                shadowsListString = string.Join(", ", approvedLightShadows.Select(x => x.ToString()).ToArray());
            }

            foreach (var obj in objs)
            {
                var light = obj.GetComponent<Light>();
                if (light != null && light.type == type)
                {
                    LogicForLight(light);
                }
            }
        }

        private void LogicForLight(Light light)
        {
            if (approvedLightmapBakeTypes.Length <= 0)
            {
                AddIssue(new Issue(
                    light.gameObject,
                    IssueLevel.Error,
                    LocalizedMessage.Get("LightConfigRule.UnauthorizedLightType", light.type),
                    LocalizedMessage.Get("LightConfigRule.UnauthorizedLightType.Solution")));

                return;
            }

            if (!approvedLightmapBakeTypes.Contains(light.lightmapBakeType))
            {
                AddIssue(new Issue(
                    light.gameObject,
                    IssueLevel.Error,
                    LocalizedMessage.Get("LightConfigRule.UnauthorizedLightMode",
                        light.type, bakeTypeListString, light.lightmapBakeType),
                    LocalizedMessage.Get("LightConfigRule.UnauthorizedLightMode.Solution", bakeTypeListString)
                    ));
            }

            if (approvedLightShadows != null && !approvedLightShadows.Contains(light.shadows))
            {
                AddIssue(new Issue(
                    light.gameObject,
                    IssueLevel.Error,
                    LocalizedMessage.Get("LightConfigRule.UnauthorizedShadowTypes",
                        light.type, shadowsListString, light.shadows),
                    LocalizedMessage.Get("LightConfigRule.UnauthorizedShadowTypes.Solution", shadowsListString)
                    ));
            }

            if (minRange != NO_LIMIT && maxRange != NO_LIMIT)
            {
                if (light.range < minRange || light.range > maxRange)
                {
                    AddIssue(new Issue(
                        light.gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("LightConfigRule.OverRange", 
                            light.type, minRange, maxRange, light.range),
                        LocalizedMessage.Get("LightConfigRule.OverRange.Solution")
                        ));
                }
            }

            if (minIntensity != NO_LIMIT && maxIntensity != NO_LIMIT)
            {
                if (light.intensity < minIntensity || light.intensity > maxIntensity)
                {
                    AddIssue(new Issue(
                        light.gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("LightConfigRule.OverIntensity", 
                            light.type, minIntensity, maxIntensity, light.intensity),
                        LocalizedMessage.Get("LightConfigRule.OverIntensity.Solution")
                        ));
                }
            }

            if (minBounceIntensity != NO_LIMIT && maxBounceIntensity != NO_LIMIT)
            {
                if (light.bounceIntensity < minBounceIntensity || light.bounceIntensity > maxBounceIntensity)
                {
                    AddIssue(new Issue(
                        light.gameObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("LightConfigRule.OverIndirectMultiplier",
                            light.type, minBounceIntensity, maxBounceIntensity, light.bounceIntensity),
                        LocalizedMessage.Get("LightConfigRule.OverIndirectMultiplier.Solution")
                        ));
                }
            }
        }

        public class LightConfig
        {
            public LightmapBakeType[] bakeTypes { get; private set; }
            public LightShadows[] lightShadows { get; private set; }
            public float minRange { get; private set; }
            public float maxRange { get; private set; }
            public float minIntensity { get; private set; }
            public float maxIntensity { get; private set; }
            public float minBounceIntensity { get; private set; }
            public float maxBounceIntensity { get; private set; }

            public LightConfig(
                LightmapBakeType[] bakeTypes,
                LightShadows[] lightShadows = null,
                float minRange = NO_LIMIT, float maxRange = NO_LIMIT, 
                float minIntensity = NO_LIMIT, float maxIntensity = NO_LIMIT, 
                float minBounceIntensity = NO_LIMIT, float maxBounceIntensity = NO_LIMIT)
            {
                this.bakeTypes = bakeTypes;
                this.lightShadows = lightShadows;
                this.minRange = minRange;
                this.maxRange = maxRange;
                this.minIntensity = minIntensity;
                this.maxIntensity = maxIntensity;
                this.minBounceIntensity = minBounceIntensity;
                this.maxBounceIntensity = maxBounceIntensity;
            }
        }
    }
}
