using System.Collections.Generic;
using UnityEngine;

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
                var message = string.Format("{0} Lightが{1}個を超えています。({2}個)", type, limit, foundLights.Count);

                foreach (var light in foundLights)
                {

                    AddIssue(new Issue(
                        light,
                        IssueLevel.Error,
                        message,
                        "別のLightを使用するか、削除して個数を減らして下さい。"));
                }
            }
        }
    }
}