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
        private readonly ICustomPropertyIgnorer propertyIgnorer;

        public UseLightModeRule(string name, LightType type, LightmapBakeType[] unusableBakeTypes, ICustomPropertyIgnorer propertyIgnorer = null) : base(name)
        {
            this.type = type;
            this.unusableBakeTypes = unusableBakeTypes;
            this.propertyIgnorer = propertyIgnorer ?? new DummyPropertyIgnorer();
        }

        protected override void Logic(ValidationTarget target)
        {
            if (unusableBakeTypes.Length <= 0)
            {
                return;
            }

            if(propertyIgnorer.IsIgnored(typeof(Light), "m_Lightmapping"))
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