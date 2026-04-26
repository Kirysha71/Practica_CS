using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public interface IReport<T>
    {
        string Generate(T data);
    }
}
