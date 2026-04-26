using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class TooManyConnectionsException : Exception
    {
        public TooManyConnectionsException(int count)
            : base($"Превышен лимит подключений: {count}. Максимум - 10") { }
    }
}
