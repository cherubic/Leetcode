using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Problem_5
    {
        /*
         * 
         * HIRE-ASSISTANT(n)
         *     best = 0
         *     for i = 1 to n
         *         interview candidate i
         *         if candidate i is better than candidate best
         *             best = i
         *             hire candidate i
         * 
         */
        public int HireAssistant(int[] numbs)
        {
            var best = 0;
            for (var i = 0; i < numbs.Length; i++)
            {
                if (numbs[i] > numbs[best])
                {
                    best = i;
                }
            }

            return best;
        }

        /*
         * 
         * RANDOMIZED-HIRE-ASSISTANT(n)
         *     randomly permute the list of candidates
         *     best = 0
         *     for i = 1 to n
         *         interview candidate i
         *         if candidate i is better than candidate best
         *             best = i
         *             hire candidate i
         * 
         */
        public int RandomizedHireAssistant(int[] numbs)
        {
            numbs = PermuteBySorting(numbs);
            var best = 0;
            for (var i = 0; i < numbs.Length; i++)
            {
                if (numbs[i] > numbs[best])
                {
                    best = i;
                }
            }

            return best;
        }

        /*
         * 
         * PERMUTE-BY-SORTING(A)
         *     n = A.length
         *     let P[1..n] be a new array
         *     for i = 1 to n
         *         P[i] = RANDOM(1, n^3)
         *     sort A, using P as sort keys
         * 
         */
        public int[] PermuteBySorting(int[] numbs)
        {
            var temp = new int[numbs.Length];
            for (var i = 0; i < numbs.Length; i++)
            {
                temp[i] = new Random().Next(1, (int)Math.Pow(numbs.Length, 3));
            }

            var dic = new Dictionary<int, int>();
            for (var i = 0; i < numbs.Length; i++)
            {
                dic.Add(numbs[i], temp[i]);
            }

            numbs = dic.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
            return numbs;
        }

        /*
         * 
         * RANDOMIZE-IN-PLACE(A)
         *     n = A.length
         *     for i = 1 to n
         *         swap A[i] with A[RANDOM(i, n)]
         * 
         */
        public int[] RandomizeInPlace(int[] numbs)
        {
            for (var i = 0; i < numbs.Length; i++)
            {
                var swapIndex = new Random().Next(i, numbs.Length);
                numbs[i] ^= numbs[swapIndex];
                numbs[swapIndex] ^= numbs[i];
                numbs[i] ^= numbs[swapIndex];
            }

            return numbs;
        }
    }
}
