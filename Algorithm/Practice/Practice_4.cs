using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Practice
{
    public class Practice_4
    {
        /*
         * time complexity: O(n)
         * 
         * MAX-SUBARRAY-LINEAR(A)
         *     n = A.length
         *     max-sum = -limitation
         *     ending-here-sum = -limitation
         *     for j = 1 to n
         *         ending-here-high = j
         *         if ending-here-sum > 0
         *             ending-here-sum = ending-here-sum + A[j]
         *         else ending-here-low = j
         *             ending-here-sum = A[j]
         *         if ending-here-sum > max-sum
         *             max-sum = ending-here-sum
         *             low = ending-here-low
         *             high = ending-here-high
         *     return (low, high, max-sum)
         * 
         * 假设数组分为前n-1个和最后一个，那么第n个若是负数，则前n-1个肯定是n中最大的数组
         */

        public int[] MaxSubarrayLinear(int[] numbs)
        {
            var low = 0;
            var high = 0;
            var maxSum = int.MinValue;
            var endingHereSum = int.MinValue;
            var endingHereLow = 0;

            for (var i = 0; i < numbs.Length; i++)
            {
                var endingHereHigh = i;
                if (endingHereSum > 0)
                {
                    endingHereSum = endingHereSum + numbs[i];
                }
                else
                {
                    endingHereLow = i;
                    endingHereSum = numbs[i];
                }

                if (endingHereSum > maxSum)
                {
                    maxSum = endingHereSum;
                    low = endingHereLow;
                    high = endingHereHigh;
                }
            }

            return new int[] { low, high, maxSum };
        }
    }
}
