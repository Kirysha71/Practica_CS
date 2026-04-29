using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_1
{
    public class RangeFilter : IFilterStrategy
    {
        private int _min;
        private int _max;

        public RangeFilter(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public List<int> Filter(List<int> data)
        {
            List<int> result = new List<int>();
            foreach (int i in data)
            {
                if(i >= _min && i <= _max)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
