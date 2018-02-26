using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DIPSolution.BusinessFacade
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
