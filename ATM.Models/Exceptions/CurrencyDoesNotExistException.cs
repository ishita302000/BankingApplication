using System;
using System.Runtime.Serialization;

namespace ATM.Models.Exceptions
{
    [Serializable]
    public class CurrencyDoesNotExistException : Exception
    {
        public CurrencyDoesNotExistException()
        {
        }

        public CurrencyDoesNotExistException(string message) : base(message)
        {
        }

        public CurrencyDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CurrencyDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}