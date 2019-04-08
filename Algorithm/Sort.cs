using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Sort
    {
        #region Insert Sort

        /*
         * time complexity: O(n^2)
         * space complexity: O(1)
         * 
         * pseudo code:
         * 
         * INSERTION-SORT(A)
         * for i = 2 to array length
         *     j = i
         *     while j-1 >= 0 and array[j] < array[j-1]
         *         if array[j] < array[j-1]
         *             then switch array[j] and array[j-1]
         *             j = j-1;
         *         else
         *             then break;
         * 
         */


        public int[] InsertSort()
        {
            var result = new int[] { };
            return result;
        }

        #endregion

        #region Merge Sort

        /*
         * time complexity: O(n * lg n)
         * space complexity: 
         * 
         * pseudo code:
         * 
         * MERGET(A, p, q, r)
         *     n1 = q - p + 1
         *     n2 = r - q
         *     let L[1..n1 + 1] and R[1..n2 + 1] be new arrays
         *     for i = 1 to n1
         *         L[i] = A[p + i - 1]
         *     for j = 1 to n2
         *         R[j] = A[q + j]
         *     L[n1 + 1] = limitation
         *     R[n2 + 1] = limitation
         *     i = 1;
         *     j = 1;
         *     for k = p to r
         *         if L[i] <= R[j]
         *             A[k] = L[i]
         *             i = i + 1
         *         else A[k] = R[j]
         *             j = j + 1
         *             
         * MERGET-SORT(A, p, r)
         *     if p < r
         *         q = (p + r) / 2
         *         MERGE-SORT(A, p, q)
         *         MERGE-SORT(A, q + 1, r)
         *         MERGE(A, p, q, r)
         */

        public int[] MergeSort()
        {
            var result = new int[] { };
            return result;
        }

        #endregion

        #region Quick Sort

        public int[] QuickSort()
        {
            var result = new int[] { };
            return result;
        }

        #endregion

        #region BUBBLESORT

        /*
         * 
         * time complexity: O(n^2)
         * space complexity:
         * 
         * pseudo code:
         * BUBBLESORT(A)
         *     for i = 1 to A.length - 1
         *         if A[j] < A[j - 1]
         *             exchange A[j] with A[j - 1]
         * 
         */

        #endregion
    }
}
