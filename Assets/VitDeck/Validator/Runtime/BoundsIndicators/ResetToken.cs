using System;

namespace VitDeck.Validator.BoundsIndicators
{
    public class ResetToken
    {
        private bool invoked = false;
        public event Action Reset;

        protected void Invoke()
        {
            if (invoked)
            {
                return;
            }

            if (Reset != null)
            {
                Reset.Invoke();
            }

            invoked = true;
        }
    }
}