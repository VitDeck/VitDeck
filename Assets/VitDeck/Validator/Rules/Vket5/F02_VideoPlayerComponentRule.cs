using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class F02_VideoPlayerComponentRule : ComponentBaseRule<UnityEngine.Video.VideoPlayer>
    {
        public F02_VideoPlayerComponentRule(string name) : base(name)
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

                var message = LocalizedMessage.Get("F02_VideoPlayerComponentRule.DefaultDisabled");
                var solution = LocalizedMessage.Get("F02_VideoPlayerComponentRule.DefaultDisabled.Solution");

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
                    LocalizedMessage.Get("F02_VideoPlayerComponentRule.DontUseURL")
                    ));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}