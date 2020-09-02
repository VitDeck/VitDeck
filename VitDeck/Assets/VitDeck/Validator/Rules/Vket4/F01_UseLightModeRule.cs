using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// 特定のLightのModeが使用されているか検証するルール
    /// </summary>
    public class UseLightModeRule : BaseRule
    {
        private readonly LightType type;
        private readonly LightmapBakeType[] unusableBakeTypes;

        public UseLightModeRule(string name, LightType type, LightmapBakeType[] unusableBakeTypes) : base(name)
        {
            this.type = type;
            this.unusableBakeTypes = unusableBakeTypes;
        }

        protected override void Logic(ValidationTarget target)
        {
            if (unusableBakeTypes.Length <= 0)
            {
                return;
            }

            var objs = target.GetAllObjects();

            foreach (var obj in objs)
            {
                var light = obj.GetComponent<Light>();

                if (light != null && light.type == type)
                {
                    if (unusableBakeTypes.Contains(light.lightmapBakeType))
                    {
                        AddIssue(new Issue(
                            obj, 
                            IssueLevel.Error, 
                            LocalizedMessage.Get("UseLightModeRule.MustNotUse", type, light.lightmapBakeType),
                            LocalizedMessage.Get("UseLightModeRule.MustNotUse.Solution")
                            ));
                    }
                }
            }
        }
    }
}