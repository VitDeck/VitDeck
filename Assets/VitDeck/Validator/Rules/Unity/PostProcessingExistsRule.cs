using System.Threading;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using VitDeck.Language;

namespace VitDeck.Validator
{
    public class PostProcessingExistsRule : BaseRule
    {
        private static ListRequest _request;

        static PostProcessingExistsRule()
        {
            _request = Client.List(true);
        }
        public PostProcessingExistsRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            while (!_request.IsCompleted)
            {
                Thread.Sleep(10);
            }

            if (_request.Status != StatusCode.Success)
            {
                var message = LocalizedMessage.Get("PostProcessingExistsRule.SearchFailed");
                var solution = LocalizedMessage.Get("PostProcessingExistsRule.SearchFailed.Solution");
                var solutionURL = LocalizedMessage.Get("PostProcessingExistsRule.SearchFailed.SolutionURL");

                AddIssue(new Issue(null, IssueLevel.Error, message, solution, solutionURL));
                
                _request = Client.List(true);
                return;
            }

            bool packageExists = false;
            foreach (var package in _request.Result)
            {
                if (package.name == "com.unity.postprocessing" &&
                    package.status == PackageStatus.Available)
                {
                    packageExists = true;
                }
            }

            if (!packageExists)
            {
                var message = LocalizedMessage.Get("PostProcessingExistsRule.NotInstalled");
                var solution = LocalizedMessage.Get("PostProcessingExistsRule.NotInstalled.Solution");
                var solutionURL = LocalizedMessage.Get("PostProcessingExistsRule.NotInstalled.SolutionURL");

                AddIssue(new Issue(null, IssueLevel.Error, message, solution, solutionURL));
            }
        }
    }
}