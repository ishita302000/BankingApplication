using System;
using System.Runtime.Serialization;

namespace ATM.Models.Exceptions
{
    [Serializable]
    public class BankNameAlreadyExistsException : Exception
    {
        public BankNameAlreadyExistsException()
        {
        }

        public BankNameAlreadyExistsException(string message) : base(message)
        {
        }

        public BankNameAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BankNameAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}