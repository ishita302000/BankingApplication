using System;
using System.Runtime.Serialization;

namespace ATM.Models.Exceptions
{
    [Serializable]
    public class AccountDoesNotExistException : Exception
    {
        public AccountDoesNotExistException()
        {
        }

        public AccountDoesNotExistException(string message) : base(message)
        {
        }

        public AccountDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}