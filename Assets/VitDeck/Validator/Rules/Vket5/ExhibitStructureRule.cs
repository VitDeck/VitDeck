using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class ExhibitStructureRule : BaseRule
    {
        public ExhibitStructureRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjects = target.GetRootObjects();

            foreach (var rootObject in rootObjects)
            {
                LogicForRootObject(rootObject);
            }
        }

        void LogicForRootObject(GameObject rootObject)
        {
            CheckObjectIdentity(rootObject);
            
            GameObject staticRoot = null;
            GameObject dynamicRoot = null;

            foreach (Transform child in rootObject.transform)
            {
                if (child.name == "Static" && staticRoot == null)
                {
                    staticRoot = child.gameObject;
                }
                else if (child.name == "Dynamic" && dynamicRoot == null)
                {
                    dynamicRoot = child.gameObject;
                }
                else
                {
                    AddIssue(new Issue(
                        child,
                        IssueLevel.Error,
                        LocalizedMessage.Get("ExhibitStructureRule.UnauthorizedObject"),
                        LocalizedMessage.Get("ExhibitStructureRule.UnauthorizedObject.Solution")
                        ));
                }
            }

            CheckRootObject(rootObject, "Static", staticRoot);
            CheckRootObject(rootObject, "Dynamic", dynamicRoot);
        }

        private void CheckRootObject(GameObject rootObject, string instanceName, GameObject instance)
        {
            if (instance == null)
            {
                AddIssue(new Issue(
                        rootObject,
                        IssueLevel.Error,
                        LocalizedMessage.Get("ExhibitStructureRule.RootObjectNotFound", instanceName),
                        LocalizedMessage.Get("ExhibitStructureRule.RootObjectNotFound.Solution", instanceName)
                        ));
                return;
            }

            CheckObjectIdentity(instance);
            
            var components = instance.GetComponents<Component>();

            if (components.Length > 1 || components[0] is RectTransform)
            {
                AddIssue(new Issue(
                        instance,
                        IssueLevel.Error,
                        LocalizedMessage.Get("ExhibitStructureRule.UnauthorizedComponent", instanceName),
                        LocalizedMessage.Get("ExhibitStructureRule.UnauthorizedComponent.Solution", instanceName)
                        ));
            }
        }
        
        private void CheckObjectIdentity(GameObject instance)
        {
            var transform = instance.transform;
            if (transform.localPosition != Vector3.zero)
            {
                var message = LocalizedMessage.Get("ExhibitStructureRule.NotInitialPosition");
                var solution = LocalizedMessage.Get("ExhibitStructureRule.NotInitialPosition.Solution");
                var solutionURL = LocalizedMessage.Get("ExhibitStructureRule.NotInitialPosition.SolutionURL");
                AddIssue(new Issue(
                    instance,
                    IssueLevel.Error,
                    message, solution, solutionURL));
            }
            if (transform.localRotation != Quaternion.identity)
            {
                var message = LocalizedMessage.Get("ExhibitStructureRule.NotInitialRotation");
                var solution = LocalizedMessage.Get("ExhibitStructureRule.NotInitialRotation.Solution");
                var solutionURL = LocalizedMessage.Get("ExhibitStructureRule.NotInitialRotation.SolutionURL");
                AddIssue(new Issue(
                    instance,
                    IssueLevel.Error,
                    message, solution, solutionURL));
            }
            if (transform.localScale != Vector3.one)
            {
                var message = LocalizedMessage.Get("ExhibitStructureRule.NotInitialScale");
                var solution = LocalizedMessage.Get("ExhibitStructureRule.NotInitialScale.Solution");
                var solutionURL = LocalizedMessage.Get("ExhibitStructureRule.NotInitialScale.SolutionURL");
                AddIssue(new Issue(
                    instance,
                    IssueLevel.Error,
                    message, solution, solutionURL));
            }
        }
    }
}
