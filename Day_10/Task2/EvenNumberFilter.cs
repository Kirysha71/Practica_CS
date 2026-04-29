using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_1
{
    public class EvenNumberFilter : IFilterStrategy
    {
        public List<int> Filter(List<int> data)
        {
            List<int> result = new List<int>();
            foreach (int i in data)
            {
                if(i % 2 == 0)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
