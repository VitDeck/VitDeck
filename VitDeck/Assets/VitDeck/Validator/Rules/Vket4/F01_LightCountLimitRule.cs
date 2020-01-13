using System.Collections.Generic;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// 特定のLightの個数が制限を超えていることを検出するルール
    /// </summary>
    public class LightCountLimitRule : BaseRule
    {
        private LightType type;
        private int limit;

        public LightCountLimitRule(string name, LightType type, int limit) : base(name)
        {
            this.type = type;
            this.limit = limit;
        }

        protected override void Logic(ValidationTarget target)
        {
            var objs = target.GetAllObjects();

            var foundLights = new List<Light>();

            foreach (var obj in objs)
            {
                var light = obj.GetComponent<Light>();
                if (light != null && light.type == type)
                {
                    foundLights.Add(light);
                }
            }

            if (foundLights.Count > limit)
            {
                var message = LocalizedMessage.Get("LightCountLimitRule.Overuse", type, limit, foundLights.Count);
                var solution = LocalizedMessage.Get("LightCountLimitRule.Overuse.Solution");

                foreach (var light in foundLights)
                {

                    AddIssue(new Issue(
                        light,
                        IssueLevel.Error,
                        message,
                        solution));
                }
            }
        }
    }
}