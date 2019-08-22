﻿using System;
using System.Runtime.Serialization;

namespace kin_base
{
    [Serializable]
    public class MemoTooLongException : Exception
    {
        public MemoTooLongException()
        {
        }

        public MemoTooLongException(string message) : base(message)
        {
        }

        public MemoTooLongException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MemoTooLongException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}