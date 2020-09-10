using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class F01_CameraComponentRule : ComponentBaseRule<Camera>
    {
        private Vector2 maxRenderTextureSize;

        public F01_CameraComponentRule(string name, Vector2 maxRenderTextureSize) : base(name)
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

                var message = LocalizedMessage.Get("F01_CameraComponentRule.DefaultDisabled");
                var solution = LocalizedMessage.Get("F01_CameraComponentRule.DefaultDisabled.Solution");

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
                "F01_CameraComponentRule.MaxRenderTextureSize",
                maxRenderTextureSize.x,
                maxRenderTextureSize.y,
                renderTexture.width,
                renderTexture.height);
            var solution = LocalizedMessage.Get("F01_CameraComponentRule.MaxRenderTextureSize.Solution");

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