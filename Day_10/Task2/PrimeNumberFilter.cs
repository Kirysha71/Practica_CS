using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_1
{
    public class PrimeNumberFilter : IFilterStrategy
    {
        public List<int> Filter(List<int> data)
        {
            List<int> result = new List<int>();
            foreach (int i in data)
            {
                if (isPrime(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        private bool isPrime(int num)
        {
            if(num < 2) return false;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }
}
