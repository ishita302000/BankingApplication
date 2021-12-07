using System;
using System.Runtime.Serialization;

namespace ATM.Models.Exceptions
{
    [Serializable]
    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException()
        {
        }

        public TransactionNotFoundException(string message) : base(message)
        {
        }

        public TransactionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}