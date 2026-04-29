using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_1
{
    public class DataFilter
    {
        private IFilterStrategy _strategy;

        public DataFilter(IFilterStrategy strategy)
        {
            _strategy = strategy;
        }

        public List<int> Apply(List<int> data)
        {
            return _strategy.Filter(data);
        }
    }
}
