using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VitDeck.Validator.Test
{
    public class F01_TestAnimationMakesMoveCollidersRule
    {
        [Test]
        public void Test()
        {
            var target = new ValidationTargetFinder()
                .Find("Assets/VitDeck/Validator/Tests/Data/F01_AnimationMakesMoveCollidersRule", true);

            var result = new AnimationMakesMoveCollidersRule("")
                .Validate(target);

            foreach (var issue in result.Issues)
            {
                var component = issue.target as Component;
                Debug.Log(string.Format("{0}:{1}:{3}/{2}", issue.level, issue.message, issue.target, component.transform.parent.name), issue.target);
            }

            var errors = result.Issues.Where(issue => issue.level == IssueLevel.Error);

            Assert.That(errors.Count(DetectedDontMoveCollider), Is.Zero);
            Assert.That(errors.Count(issue => IsRootGameobjectNameOf(issue, "Animator")), Is.EqualTo(3));
            Assert.That(errors.Count(issue => IsRootGameobjectNameOf(issue, "Animator (OverrideController)")), Is.EqualTo(1));
            Assert.That(errors.Count(issue => IsRootGameobjectNameOf(issue, "Animator (No Node Connection)")), Is.EqualTo(1));
            Assert.That(errors.Count(issue => IsRootGameobjectNameOf(issue, "Animation")), Is.EqualTo(1));
            Assert.That(errors.Count(issue => IsRootGameobjectNameOf(issue, "Animation (Has In Array)")), Is.EqualTo(1));


        }

        private bool DetectedDontMoveCollider(Issue issue)
        {
            return issue.target.name.Contains("FixedCollider");
        }

        private bool IsRootGameobjectNameOf(Issue issue, string name)
        {
            var component = issue.target as Component;
            if (component != null)
            {
                return component.transform.root.name == name;
            }

            return false;
        }
    }
}