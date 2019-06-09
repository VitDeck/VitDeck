using System;
using System.Runtime.Serialization;

namespace VitDeck.Validator
{
    [Serializable]
    public class FatalValidationErrorException : Exception
    {
        public FatalValidationErrorException()
        {
        }

        public FatalValidationErrorException(string message) : base(message)
        {
        }

        public FatalValidationErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FatalValidationErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}