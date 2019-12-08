using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VitDeck.Validator
{
    public abstract class Vket4RuleSetBase : IRuleSet
    {
        public abstract string RuleSetName
        {
            get;
        }

        public IValidationTargetFinder TargetFinder { get { return new Vket4TargetFinder(); } }

        public IRule[] GetRules()
        {
            return new IRule[] { new DebugEnumerateRule("Enumerate") };
        }
    }

    public class DebugEnumerateRule : BaseRule
    {
        public DebugEnumerateRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            AddIssue(new Issue(
                null,
                IssueLevel.Info,
                "gameObjects = " + ArrayToString(target.GetAllObjects())
                ));

            AddIssue(new Issue(
                null,
                IssueLevel.Info,
                "assets = " + ArrayToString(target.GetAllAssets())
                ));
        }

        private string ArrayToString(object[] objects)
        {
            var builder = new StringBuilder();

            builder.Append("{");
            foreach (var obj in objects)
            {
                builder.Append(obj.ToString());
                builder.Append(", ");
            }
            builder.Append("}");

            return builder.ToString();
        }
    }
}