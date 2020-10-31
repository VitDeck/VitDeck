using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class CameraComponentRule : ComponentBaseRule<Camera>
    {
        private Vector2 maxRenderTextureSize;

        public CameraComponentRule(string name, Vector2 maxRenderTextureSize) : base(name)
        {
            this.maxRenderTextureSize = maxRenderTextureSize;
        }

        protected override void ComponentLogic(Camera component)
        {
            DefaultDisabledLogic(component);
            MaxRenderTextureSizeLogic(component, maxRenderTextureSize);
        }

        private void DefaultDisabledLogic(Camera component)
        {
            if (component.enabled)
            {

                var message = LocalizedMessage.Get("CameraComponentRule.DefaultDisabled");
                var solution = LocalizedMessage.Get("CameraComponentRule.DefaultDisabled.Solution");

                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    message,
                    solution));
            }
        }

        private void MaxRenderTextureSizeLogic(Camera component, Vector2 maxRenderTextureSize)
        {
            var renderTexture = component.targetTexture;
            if (renderTexture == null)
            {
                return;
            }

            var message = LocalizedMessage.Get(
                "CameraComponentRule.MaxRenderTextureSize",
                maxRenderTextureSize.x,
                maxRenderTextureSize.y,
                renderTexture.width,
                renderTexture.height);
            var solution = LocalizedMessage.Get("CameraComponentRule.MaxRenderTextureSize.Solution");

            if (renderTexture.width > maxRenderTextureSize.x ||
                renderTexture.height > maxRenderTextureSize.y)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    message,
                    solution));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}