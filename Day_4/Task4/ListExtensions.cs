using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Task4
{
    public static class ListExtensions
    {
        public static List<string> SortByLength(this List<string> list)
        {
            return list.OrderBy(x => x.Length).ToList();
        }
    }
}
