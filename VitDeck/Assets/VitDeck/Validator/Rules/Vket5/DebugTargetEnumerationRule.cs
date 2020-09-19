using System.Text;

namespace VitDeck.Validator
{
    public class DebugTargetEnumerationRule : BaseRule
    {
        public DebugTargetEnumerationRule(string name) : base(name)
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