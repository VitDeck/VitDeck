using System;
using System.Runtime.Serialization;

namespace VitDeck.Validator
{
    [Serializable]
    public class InvalidVersionFormatException : Exception
    {
        public InvalidVersionFormatException()
        {
        }

        public InvalidVersionFormatException(string message) : base(message)
        {
        }

        public InvalidVersionFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidVersionFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
