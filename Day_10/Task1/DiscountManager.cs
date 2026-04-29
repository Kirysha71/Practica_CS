using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class DiscountManager
    {
        private static DiscountManager _instance;
        private readonly Dictionary<string, double> _discounts;

        private DiscountManager()
        {
            _discounts = new Dictionary<string, double>();
        }

        public static DiscountManager Instance
        {
            get
            {
                if( _instance == null)
                {
                    _instance = new DiscountManager();
                }
                return _instance;
            }
        }

        public void SetDiscount(string product, double percent)
        {
            if( percent < 0 || percent > 100)
            {
                throw new ArgumentException("Скидка не может быть меньше 0 и больше 100");
            }
            _discounts[product] = percent;
        }

        public double GetDiscount(string product)
        {
            if(_discounts.TryGetValue(product, out double discount))
            {
                return discount;
            }
            return 0;
        }
    }
}
