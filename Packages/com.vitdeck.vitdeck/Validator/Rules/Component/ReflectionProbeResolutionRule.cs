using UnityEngine;

namespace VitDeck.Validator
{
    /// <summary>
    /// Reflection ProbeのCubemap capture settingsのResolutionを特定の値に制限する
    /// </summary>
    public class ReflectionProbeResolutionRule : ComponentBaseRule<ReflectionProbe>
    {
        private readonly int resolution;

        public ReflectionProbeResolutionRule(string name, int resolution) : base(name)
        {
            this.resolution = resolution;
        }

        protected override void ComponentLogic(ReflectionProbe component)
        {
            if (component.resolution != resolution)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    string.Format("Reflection ProbeのCubemap capture settingsのResolutionが{0}になっています。", component.resolution),
                    string.Format("Resolutionを{0}にしてください。", resolution)));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}
