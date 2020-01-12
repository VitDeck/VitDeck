using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

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
        private readonly float minRange;
        private readonly float maxRange;
        private readonly float minIntensity;
        private readonly float maxIntensity;
        private readonly float minBounceIntensity;
        private readonly float maxBounceIntensity;

        private string bakeTypeListString;

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

        protected override void Logic(ValidationTarget target)
        {
            var objs = target.GetAllObjects();

            bakeTypeListString = string.Join(", ", approvedLightmapBakeTypes.Select(x => x.ToString()).ToArray());

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
            if (!approvedLightmapBakeTypes.Contains(light.lightmapBakeType))
            {
                AddIssue(new Issue(
                    light.gameObject, 
                    IssueLevel.Error, 
                    string.Format("{0}LightのModeが{1}以外に設定されています。({2})", 
                        light.type, bakeTypeListString, light.lightmapBakeType),
                    string.Format("Modeを{0}に設定して下さい。", bakeTypeListString)
                    ));
            }

            if (minRange != NO_LIMIT && maxRange != NO_LIMIT)
            {
                if (light.range < minRange || light.range > maxRange)
                {
                    AddIssue(new Issue(
                        light.gameObject,
                        IssueLevel.Error,
                        string.Format("{0}LightのRangeが{1}～{2}の範囲を超えています。(設定値：{3})", 
                            light.type, minRange, maxRange, light.range),
                        string.Format("Rangeを範囲内になるように設定して下さい。")
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
                        string.Format("{0}LightのIntensityが{1}～{2}の範囲を超えています。(設定値：{3})", 
                            light.type, minIntensity, maxIntensity, light.intensity),
                        string.Format("Intensityを範囲内になるように設定して下さい。")
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
                        string.Format("{0}LightのIndirect Multiplierが{1}～{2}の範囲を超えています。(設定値：{3})",
                            light.type, minBounceIntensity, maxBounceIntensity, light.bounceIntensity),
                        string.Format("Indirect Multiplierを範囲内になるように設定して下さい。")
                        ));
                }
            }
        }
    }
}