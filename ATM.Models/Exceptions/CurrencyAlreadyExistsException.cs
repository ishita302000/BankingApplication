using System;
using System.Runtime.Serialization;

namespace ATM.Models.Exceptions
{
    [Serializable]
    public class CurrencyAlreadyExistsException : Exception
    {
        public CurrencyAlreadyExistsException()
        {
        }

        public CurrencyAlreadyExistsException(string message) : base(message)
        {
        }

        public CurrencyAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CurrencyAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}