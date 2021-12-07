using System;
using System.Runtime.Serialization;

namespace ATM.Models.Exceptions
{
    [Serializable]
    public class BankDoesnotExistException : Exception
    {
        public BankDoesnotExistException()
        {
        }

        public BankDoesnotExistException(string message) : base(message)
        {
        }

        public BankDoesnotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BankDoesnotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}