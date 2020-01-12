using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace VitDeck.Validator
{
    public class F02_VideoPlayerComponentRule : ComponentBaseRule<UnityEngine.Video.VideoPlayer>
    {
        public F02_VideoPlayerComponentRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(VideoPlayer component)
        {
            if (component.source == VideoSource.Url)
            {
                AddIssue(new Issue(
                    component,
                    IssueLevel.Error,
                    "VideoPlayerはURLを使用することは出来ません。"
                    ));
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }
    }
}