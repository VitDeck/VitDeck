using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using VitDeck.Language;

namespace VitDeck.Validator
{
    internal class ReflectionProbeRule : ComponentBaseRule<ReflectionProbe>
    {
        private readonly IEnumerable<ReflectionProbeMode> allowedModes;

        public ReflectionProbeRule(string name, IEnumerable<ReflectionProbeMode> allowedModes) : base(name)
        {
            this.allowedModes = allowedModes;
        }

        protected override void ComponentLogic(ReflectionProbe component)
        {
            if (!allowedModes.Contains(component.mode))
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    LocalizedMessage.Get(
                        "ReflectionProbeRule.UnauthorizedType",
                        string.Join(", ", allowedModes.Select(mode => mode.ToString())),
                        component.mode)));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}