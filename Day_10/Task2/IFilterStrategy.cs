using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_1
{
    public interface IFilterStrategy
    {
        List<int> Filter(List<int> data);
    }
}
