using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Problem
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



        /*
         * 
         * RANDOMIZED-HIRE-ASSISTANT(n)
         *     randomly permute the list of candidates
         *     best = 0
         *     for i - 1 to n
         *         interview candidate i
         *         if candidate i is better than candidate best
         *             best = i
         *             hire candidate i
         * 
         */


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


        /*
         * 
         * RANDOMIZE-IN-PLACE(A)
         *     n = A.length
         *     for i = 1 to n
         *         swap A[i] with A[RANDOM(i, n)]
         * 
         */
    }
}
