using System;
using System.Runtime.Serialization;

namespace Task1Logic.Exeptions
{
    [Serializable]
    internal class VersionException : ApplicationException
    {
        public VersionException()
        {
        }

        public VersionException(string message)
            : base(message)
        {
        }

        public VersionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VersionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}