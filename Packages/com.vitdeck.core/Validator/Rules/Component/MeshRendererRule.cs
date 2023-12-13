using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class MeshRendererRule : ComponentBaseRule<MeshRenderer>
    {
        public MeshRendererRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(MeshRenderer component)
        {
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
            var flags = GameObjectUtility.GetStaticEditorFlags(hasComponentObject);

            if (IsLightmapStatic(flags) && IsNotInEnvironmentLayer(hasComponentObject))
            {
                AddIssue(new Issue(
                    hasComponentObject,
                    IssueLevel.Error,
                    LocalizedMessage.Get("MeshRendererRule.StaticMeshMustPutInEnvironmentLayer")));
            }
        }

        private static bool IsNotInEnvironmentLayer(GameObject hasComponentObject)
        {
            return hasComponentObject.layer != LayerMask.NameToLayer("Environment");
        }

        private static bool IsLightmapStatic(StaticEditorFlags flags)
        {
            return (flags & StaticEditorFlags.ContributeGI) == StaticEditorFlags.ContributeGI;
        }
    }
}
