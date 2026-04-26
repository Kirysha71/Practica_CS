using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class TextReport<T> : IReport<T>
    {
        public string Generate(T data)
        {
            return $"Report: {data?.ToString() ?? "null"}";
        }
    }
}
