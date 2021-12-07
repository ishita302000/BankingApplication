using System;
using System.Runtime.Serialization;

namespace ATM.Models.Exceptions
{
    [Serializable]
    public class StaffDoesNotExistException : Exception
    {
        public StaffDoesNotExistException()
        {
        }

        public StaffDoesNotExistException(string message) : base(message)
        {
        }

        public StaffDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StaffDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}