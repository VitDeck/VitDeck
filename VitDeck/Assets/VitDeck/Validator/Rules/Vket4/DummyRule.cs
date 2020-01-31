namespace VitDeck.Validator
{
    public class DummyRule : IRule
    {
        private readonly string name;

        private ValidationResult result;

        public static IRule Get(string name)
        {
            return new DummyRule(name);
        }

        public DummyRule(string name)
        {
            this.name = name;
        }

        public ValidationResult GetResult()
        {
            if (result == null)
            {
                result = new ValidationResult(name);
            }
            return result;
        }

        public ValidationResult Validate(ValidationTarget target)
        {
            return GetResult();
        }
    }
}