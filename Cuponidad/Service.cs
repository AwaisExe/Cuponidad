using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuponidad
{
    public class Service
    {
        public static string Description(string description)
        {
            string shortDescriptin = "";
            return shortDescriptin;
        }
        public static string CalculateDiscount(decimal amount, decimal discountAmount)
        {
            string discount = "";
            discount = string.Format("{0:0.##}", (amount - ((amount * discountAmount) / 100)));
            return discount;
        }
    }
}
