// This file was modified by Kin Ecosystem (2019)


using System;
using System.Runtime.Serialization;

namespace Kin.Base
{
    public class FormatException : Exception
    {
        public FormatException()
        {
        }

        public FormatException(string message) : base(message)
        {
        }

        public FormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
