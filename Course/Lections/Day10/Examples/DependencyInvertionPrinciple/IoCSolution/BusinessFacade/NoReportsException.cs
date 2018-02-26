using System;
using System.Runtime.Serialization;

namespace IoCSolution.BusinessFacade
{
    [Serializable]
    public class NoReportsException : Exception
    {
        public NoReportsException()
        {
        }

        public NoReportsException(string message)
            : base(message)
        {
        }

        public NoReportsException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected NoReportsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
