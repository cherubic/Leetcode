using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Problem
{
    public class Problem_4
    {
        /// <summary>
        /// 
        /// FIND-MAX-CROSSING-SUBARRAY(A, low, mid, high)
        ///     left-sum = -limitation
        ///     sum = 0
        ///     for i = mid downto low
        ///         sum = sum + A[i]
        ///         if sum > left-sum
        ///             left-sum = sum
        ///             max-left = i
        ///     right-sum = -limitation
        ///     sum = 0
        ///     for j = mid to high
        ///         sum = sum + A[j]
        ///         if sum > right-sum
        ///             right-sum = sum
        ///             max-right = j
        ///     return (max-left, max-right, left-sum + right-sum)
        ///     
        /// 
        /// FIND-MAXIMUM-SUBARRAY(A, low, high)
        ///     if high == low
        ///         return (low, high, A[low])  //base case: only one element
        ///     else mid = floor((low + high) / 2)
        ///         (left-low, left-high, left-sum) = 
        ///             FIND-MAXIMUM-SUBARRAY(A, low, mid)
        ///         (right-low, right-high, right-sum) = 
        ///             FIND-MAXIMUM-SUBARRAY(A, mid + 1, high)
        ///         (cross-low, cross-high, cross-sum) = 
        ///             FIND-MAX-CROSSING-SUBARRAY(A, low, mid, high)
        ///         if left-sum >= right-sum and left-sum >= cross-sum
        ///             return (left-low, left-high, left-sum)
        ///         else if right-sum >= left-sum and right-sum >= cross-sum
        ///             return (right-low, right-high, right-sum)
        ///         else return (cross-low, cross-high, cross-sum)
        ///         
        /// </summary>
        /// <returns></returns>


        public int[] MaximumSubarray_1(int[] numbs)
        {
            return FindMaximumSubarray(numbs, 0, numbs.Length - 1);
        }

        private int[] FindMaximumSubarray(int[] numbs, int low, int high)
        {
            if (high == low)
            {
                return new int[] { low, high, numbs[low] };
            }
            else
            {
                var mid = (low + high) / 2;
                var leftArray = FindMaximumSubarray(numbs, low, mid);
                var rightArray = FindMaximumSubarray(numbs, mid + 1, high);
                var midArray = FindMaxCrossingSubarray(numbs, low, mid, high);
                if (leftArray[2] >= rightArray[2] && leftArray[2] >= midArray[2])
                {
                    return leftArray;
                }
                else if (rightArray[2] >= leftArray[2] && rightArray[2] >= midArray[2])
                {
                    return rightArray;
                }
                else
                {
                    return midArray;
                }
            }
        }

        private int[] FindMaxCrossingSubarray(int[] numbs, int low, int mid, int high)
        {
            var leftSum = int.MinValue;
            var sum = 0;
            var maxLeft = mid;
            for (var i = mid; i >= low; i--)
            {
                sum = sum + numbs[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            sum = 0;
            var rightSum = int.MinValue;
            var maxRight = mid + 1;
            for (var i = mid + 1; i <= high; i++)
            {
                sum = sum + numbs[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = i;
                }
            }

            return new int[] { maxLeft, maxRight, leftSum + rightSum };
        }
    }
}
