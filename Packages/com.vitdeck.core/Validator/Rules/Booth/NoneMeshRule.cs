using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public class NoneMeshRule : BaseRule
    {
        public NoneMeshRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var gameObjects = target.GetAllObjects();

            foreach(var gameObject in gameObjects)
            {
                foreach(var component in gameObject.GetComponents<Component>())
                {
                    if (component == null)
                        continue;

                    var meshCollider = component as MeshCollider;
                    if(meshCollider != null && meshCollider.sharedMesh == null)
                    {
                        var issue = new Issue(meshCollider, IssueLevel.Error, meshCollider + "にメッシュが設定されていません。");
                        AddIssue(issue);
                        continue;
                    }

                    var meshFilter = component as MeshFilter;
                    if(meshFilter != null && meshFilter.sharedMesh == null)
                    {
                        var issue = new Issue(meshFilter, IssueLevel.Error, meshFilter + "にメッシュが設定されていません。");
                        AddIssue(issue);
                        continue;
                    }

                    var skinnedMeshRenderer = component as SkinnedMeshRenderer;
                    if(skinnedMeshRenderer != null && skinnedMeshRenderer.sharedMesh == null)
                    {
                        var issue = new Issue(skinnedMeshRenderer, IssueLevel.Error, skinnedMeshRenderer + "にメッシュが設定されていません。");
                        AddIssue(issue);
                        continue;
                    }

                    var particleSystem = component as ParticleSystem;
                    if(particleSystem != null)
                    {
                        var shapeModule = particleSystem.shape;
                        if(shapeModule.shapeType == ParticleSystemShapeType.Mesh && 
                            shapeModule.meshShapeType != ParticleSystemMeshShapeType.Vertex &&
                            shapeModule.mesh == null)
                        {
                            var issue = new Issue(particleSystem, IssueLevel.Error, particleSystem + "/Shapeがメッシュに依存する設定であるにも関わらず、メッシュが設定されていません。");
                            AddIssue(issue);
                        }
                        continue;
                    }
                }
            }
        }
    }
}