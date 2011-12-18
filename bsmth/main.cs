using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsmth
{
    public class basicMath
    {
        public static double addition(double i, int count)
        {
            int f = 0;
            double total = 0;
            for (f = 0; f <= count; f++)
            {
                total += i;
            }

            return total;
        }
    }
}
