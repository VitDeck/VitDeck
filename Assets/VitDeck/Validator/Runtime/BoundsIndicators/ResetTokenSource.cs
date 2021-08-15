namespace VitDeck.Validator.BoundsIndicators
{
    public class ResetTokenSource
    {
        private readonly InternalResetToken token;
        public ResetToken Token
        {
            get
            {
                return token;
            }
        }

        public ResetTokenSource()
        {
            token = new InternalResetToken();
        }

        public void Reset()
        {
            token.InvokeEvent();
        }

        private class InternalResetToken : ResetToken
        {
            public void InvokeEvent()
            {
                base.Invoke();
            }
        }
    }
}