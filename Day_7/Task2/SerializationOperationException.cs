using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class SerializationOperationException : Exception
    {
        public SerializationOperationException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
