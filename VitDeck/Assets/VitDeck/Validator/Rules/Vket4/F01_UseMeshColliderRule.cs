using System;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// MeshColliderの使用を検証するルール
    /// </summary>
    public class UseMeshColliderRule : BaseRule
    {
        public UseMeshColliderRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var objs = target.GetAllObjects();

            foreach (var obj in objs)
            {
                var collider = obj.GetComponent<MeshCollider>();

                if (collider != null)
                {
                    AddIssue(
                        new Issue(
                            obj, 
                            IssueLevel.Warning,
                            LocalizedMessage.Get("UseMeshColliderRule.ShouldNotUse"),
                            LocalizedMessage.Get("UseMeshColliderRule.ShouldNotUse.Solution")
                        ));
                }
            }
        }
    }
}