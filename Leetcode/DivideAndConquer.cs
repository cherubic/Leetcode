using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class DivideAndConquer
    {
        #region Maximum Subarray
        /*
         * 
         * https://leetcode.com/problems/maximum-subarray/
         */
        public int MaximumSubarray(int[] numbs)
        {
            if (numbs == null) return 0;
            return MaximumSubarray(numbs, 0, numbs.Length - 1);
        }

        private int MaximumSubarray(int[] numbs, int low, int high)
        {
            if (low < high)
            {
                var mid = (low + high) / 2;
                var left = MaximumSubarray(numbs, low, mid);
                var right = MaximumSubarray(numbs, mid + 1, high);
                var crossing = MaximumSubarrayCrossing(numbs, low, mid, high);

                if (left >= right && left >= crossing)
                {
                    return left;
                }
                else if (right >= left && right >= crossing)
                {
                    return right;
                }
                else
                {
                    return crossing;
                }
            }
            else
            {
                return numbs[low];
            }
        }

        private int MaximumSubarrayCrossing(int[] numbs, int low, int mid, int high)
        {
            var leftMax = int.MinValue;
            var sum = 0;
            for (var i = mid; i >= low; i--)
            {
                sum += numbs[i];
                if (sum > leftMax)
                {
                    leftMax = sum;
                }
            }

            var rightMax = int.MinValue;
            sum = 0;
            for (var i = mid + 1; i <= high; i++)
            {
                sum += numbs[i];
                if (sum > rightMax)
                {
                    rightMax = sum;
                }
            }

            return leftMax + rightMax;
        }

        public int MaximumSubarray2(int[] numbs)
        {
            var maxSum = int.MinValue;
            var endingHereSum = int.MinValue;

            for (var i = 0; i < numbs.Length; i++)
            {
                if (endingHereSum > 0)
                {
                    endingHereSum = endingHereSum + numbs[i];
                }
                else
                {
                    endingHereSum = numbs[i];
                }

                if (endingHereSum > maxSum)
                {
                    maxSum = endingHereSum;
                }
            }

            return maxSum;
        }

        #endregion

        #region Majority Element
        /*
         * https://leetcode.com/problems/majority-element/
         */
        public int MajorityElement(int[] numbs)
        {
            int major = numbs[0];
            int count = 1;

            for (var i = 1; i < numbs.Length; i++)
            {
                if (numbs[i] == major)
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count == 0)
                {
                    major = numbs[i];
                    count++;
                }
            }

            return major;
        }

        public int MajorityElement2(int[] numbs)
        {
            return 0;
        }
        #endregion

        #region K th Largest Element in an Array
        /*
         * https://leetcode.com/problems/kth-largest-element-in-an-array/
         */
        public int FindKthLargest(int[] numbs, int k)
        {
            var maxHeap = MaxHeapBuild(numbs);

            var result = 0;
            for (var i = 0; i < k; i++)
            {
                result = maxHeap[0];
                var templist = maxHeap.ToList();
                templist[0] ^= templist[templist.Count() - 1];
                templist[templist.Count() - 1] ^= templist[0];
                templist[0] ^= templist[templist.Count() - 1];
                templist.RemoveAt(templist.Count() - 1);
                maxHeap = templist.ToArray();
                maxHeap = Maxheapify(maxHeap, 0);
            }

            return result;
        }

        private int[] MaxHeapBuild(int[] numbs)
        {
            var result = numbs;
            for (var i = (numbs.Length - 1) / 2; i >= 0; i--)
            {
                result = Maxheapify(numbs, i);
            }

            return result;
        }

        private int[] Maxheapify(int[] numbs, int i)
        {
            var left = 2 * i + 1;
            var right = 2 * i + 2;
            var largest = i;
            if (left < numbs.Length && numbs[left] > numbs[largest])
            {
                largest = left;
            }

            if (right < numbs.Length && numbs[right] > numbs[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                numbs[largest] ^= numbs[i];
                numbs[i] ^= numbs[largest];
                numbs[largest] ^= numbs[i];
                Maxheapify(numbs, largest);
            }

            return numbs;
        }

        public int FindKthLargest2(int[] numbs, int k)
        {
            return 0;
        }
        #endregion

        #region The Skyline Problem

        /*
         * https://leetcode.com/problems/the-skyline-problem/
         */
        public IList<int[]> GetSkyline(int[][] buildings)
        {
            return null;
        }

        #endregion

        #region Search a 2D Matrix II

        /*
         * https://leetcode.com/problems/search-a-2d-matrix-ii/
         */
        public bool SearchMatrix(int[,] matrix, int target)
        {
            var row = matrix.GetLength(0);
            var column = matrix.GetLength(1);
            return false;
        }

        private bool SearchMatrix(int[,] matrix, int target, int rowStart, int rowEnd, int columnStart, int columnEnd)
        {


            return false;
        }
        #endregion
    }
}
