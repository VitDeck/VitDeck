using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class VideoPlayerComponentRule : ComponentBaseRule<UnityEngine.Video.VideoPlayer>
    {
        public VideoPlayerComponentRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(VideoPlayer component)
        {
            DefaultDisabledLogic(component);
            DontUseURLLogic(component);
        }

        private void DefaultDisabledLogic(VideoPlayer component)
        {
            if (component.enabled)
            {

                var message = LocalizedMessage.Get("VideoPlayerComponentRule.DefaultDisabled");
                var solution = LocalizedMessage.Get("VideoPlayerComponentRule.DefaultDisabled.Solution");

                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    message,
                    solution));
            }
        }

        private void DontUseURLLogic(VideoPlayer component)
        {
            if (component.source == VideoSource.Url)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    LocalizedMessage.Get("VideoPlayerComponentRule.DontUseURL")
                    ));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}