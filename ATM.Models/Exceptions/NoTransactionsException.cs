using System;
using System.Runtime.Serialization;

namespace ATM.Models.Exceptions
{
    [Serializable]
    public class NoTransactionsException : Exception
    {
        public NoTransactionsException()
        {
        }

        public NoTransactionsException(string message) : base(message)
        {
        }

        public NoTransactionsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoTransactionsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}