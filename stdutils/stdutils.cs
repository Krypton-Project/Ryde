using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace StdUtils
{
    public class stdutils
    {
        public static string echo(string ech)
        {
            return ech;
        }

        public static int exp (int _integer, int _count) 
        {
            int t = 0, s = 0;
            for (s = 0; s <= _count; ++s)
            {
                t += _integer * _integer;
            }
            return t;
        }
        
    }
}
