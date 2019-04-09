using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Practice
{
    public class Practice_5
    {
        /*
         * 
         * time complexity: O(lg(b-a))
         * 
         * RANDOM(a, b)
         *     if a == b
         *         return a
         *     mid = (a + b) / 2
         *     r = RANDOM(0, 1)
         *     if r == 0
         *         return RANDOM(a, floor(mid))
         *     else return RANDOM(ceil(mid), b)
         * 
         */

        public int Random(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            var mid = (decimal)(a + b) / 2;
            var random = new Random().Next(0, 1);
            if (random == 0)
            {
                return Random(a, (int)Math.Floor(mid));
            }
            else
            {
                return Random((int)Math.Ceiling(mid), b);
            }
        }
    }
}
