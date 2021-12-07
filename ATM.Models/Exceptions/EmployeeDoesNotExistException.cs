using System;
using System.Runtime.Serialization;

namespace ATM.Models.Exceptions
{
    [Serializable]
    public class EmployeeDoesNotExistException : Exception
    {
        public EmployeeDoesNotExistException()
        {
        }

        public EmployeeDoesNotExistException(string message) : base(message)
        {
        }

        public EmployeeDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}