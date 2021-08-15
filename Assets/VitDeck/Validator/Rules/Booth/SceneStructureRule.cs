using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using VitDeck.Language;
using VitDeck.Validator;

namespace VitDeck.Validator
{
    public class SceneStructureRule : BaseRule
    {
        public SceneStructureRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var loadedScenes =  new HashSet<Scene>(GetLoadedScenes());
            var targetScenes= target.GetScenes();
            
            foreach (var scene in targetScenes)
            {
                loadedScenes.Remove(scene);
            }

            foreach (var unrelatedScene in loadedScenes)
            {
                var message = LocalizedMessage.Get("SceneStructureRule.UnrelatedSceneDetected", unrelatedScene.name);
                var solution = LocalizedMessage.Get("SceneStructureRule.UnrelatedSceneDetected.Solution");
                var solutionURL = LocalizedMessage.Get("SceneStructureRule.UnrelatedSceneDetected.SolutionURL");

                var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(unrelatedScene.path);
                AddIssue(new Issue(sceneAsset, IssueLevel.Error, message, solution, solutionURL));
            }

            foreach (var targetScene in targetScenes)
            {
                ValidateRootObject(target, targetScene);
            }
        }

        private void ValidateRootObject(ValidationTarget target, Scene scene)
        {
            var allowedRootObjects = target.GetRootObjects();
            var rootObjects = new HashSet<GameObject>(scene.GetRootGameObjects());

            rootObjects.RemoveWhere(obj => obj.name == "Reference Object");
            foreach (var allowedRootObject in allowedRootObjects)
            {
                rootObjects.Remove(allowedRootObject);
            }

            foreach (var unrelatedRootObject in rootObjects)
            {
                var message = LocalizedMessage.Get("SceneStructureRule.UnrelatedRootObjectDetected", unrelatedRootObject.name);
                var solution = LocalizedMessage.Get("SceneStructureRule.UnrelatedRootObjectDetected.Solution");
                var solutionURL = LocalizedMessage.Get("SceneStructureRule.UnrelatedRootObjectDetected.SolutionURL");

                AddIssue(new Issue(unrelatedRootObject, IssueLevel.Error, message, solution, solutionURL));
            }
        }


        private Scene[] GetLoadedScenes()
        {
            var sceneCount = SceneManager.sceneCount;
            var scenes = new List<Scene>(sceneCount);
            
            for (var i = 0; i < sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (!scene.isLoaded)
                {
                    continue;
                }
                scenes.Add(scene);
            }

            return scenes.ToArray();
        }
    }
}