using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    [TestClass]
    public class Algorithm
    {
        #region Insert Sort

        [TestMethod]
        public void InsertSortTest()
        {
            var input = new int[] { 9, 6, 3, 2, 5, 5, 8, 7, 4, 1, 96, 63, 32, 25, 58, 87, 74, 41, 10 };
            input = new int[] { };
            var result = input;
            if (input == null) result = null;

            //If input length < 2 and would not entry the code block.
            for (var i = 1; i < input.Length; i++)
            {
                var j = i;
                while (j - 1 >= 0 && input[j] < input[j - 1])
                {
                    if (input[j] < input[j - 1])
                    {
                        input[j] = input[j] ^ input[j - 1];
                        input[j - 1] = input[j] ^ input[j - 1];
                        input[j] = input[j] ^ input[j - 1];
                        j--;
                    }
                }
            }
        }

        #endregion

        #region Merge Sort

        [TestMethod]
        public void MergeSortIterative()
        {
            int[] input = new int[] { 9, 8, 7, 7, 4, 5, 2, 3, 2, 1, 6, 4, 6, 4, 8, 6, 10, 13, 50, 68, 90, 70, 62, 36, 68, 74 };
            int[] result = new int[] { };

            for (var step = 1; step < input.Length; step += step)
            {
                for (var arrayIndex = 0; arrayIndex < input.Length; arrayIndex = arrayIndex + step)
                {
                    var indexOfArray_1 = arrayIndex;
                    var indexOfArray_2 = arrayIndex + step;
                    int[] tempIntArray = new int[step * 2];
                    var index = 0;

                    while (indexOfArray_1 <= arrayIndex + step || indexOfArray_2 <= arrayIndex + (step * 2))
                    {
                        if (indexOfArray_1 > arrayIndex + step)
                        {
                            tempIntArray[index] = input[indexOfArray_2];
                            indexOfArray_2++;
                        }
                        else if (indexOfArray_2 > arrayIndex + (step * 2))
                        {
                            tempIntArray[index] = input[indexOfArray_1];
                            indexOfArray_1++;
                        }
                        if (input[indexOfArray_1] < input[indexOfArray_2])
                        {
                            tempIntArray[index] = input[indexOfArray_1];
                            indexOfArray_1++;
                        }
                        else
                        {
                            tempIntArray[index] = input[indexOfArray_2];
                            indexOfArray_2++;
                        }

                        index++;
                    }

                    for (var temp = 0; temp < tempIntArray.Length; temp++)
                    {
                        input[arrayIndex + temp] = tempIntArray[temp];
                    }
                }
            }

            result = input;
        }

        [TestMethod]
        public void MergeSortRecursive()
        {
            int[] input = new int[] { 9, 6, 3, 2, 5, 5, 8, 7, 4, 1, 96, 63, 32, 25, 58, 87, 74, 41, 10 };
            int[] result = new int[] { };

            result = SortMergeRecursive(input);
        }

        public int[] SortMergeRecursive(int[] input)
        {
            if (input == null) return input;
            if (input.Length < 2) return input;

            var mid = input.Length / 2;
            int[] leftArray = new int[mid];
            for (var i = 0; i < mid; i++)
            {
                leftArray[i] = input[i];
            }

            int[] rightArray = new int[input.Length-mid];
            for (var i = mid; i < input.Length; i++)
            {
                rightArray[i - mid] = input[i];
            }

            leftArray = SortMergeRecursive(leftArray);
            rightArray = SortMergeRecursive(rightArray);

            var result = new int[input.Length];
            var resultIndex = 0;
            var leftIndex = 0;
            var rightIndex = 0;
            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex] > rightArray[rightIndex])
                {
                    result[resultIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
                else
                {
                    result[resultIndex] = leftArray[leftIndex];
                    leftIndex++;
                }

                resultIndex++;
            }

            while (leftIndex == leftArray.Length && rightIndex < rightArray.Length)
            {
                result[resultIndex] = rightArray[rightIndex];
                resultIndex++;
                rightIndex++;
            }

            while (rightIndex == rightArray.Length && leftIndex < leftArray.Length)
            {
                result[resultIndex] = leftArray[leftIndex];
                resultIndex++;
                leftIndex++;
            }

            return result;
        }


        #endregion

        #region Binary Search

        [TestMethod]
        public void BinarySearchRecurisve()
        {
            int[] nums = new int[] { };
            int target = 0;

            BinarySearchHelper(nums, target, 0, nums.Length);
        }

        public int BinarySearchHelper(int[] nums, int target, int start, int end)
        {
            if (start > end) return -1;

            var k = start + (start - end) / 2;
            if (nums[k] > target)
            {
                return BinarySearchHelper(nums, target, start, k - 1);
            }
            else if (nums[k] < target)
            {
                return BinarySearchHelper(nums, target, k + 1, end);
            }
            else
            {
                return k;
            }
        }

        [TestMethod]
        public void BinarySearchWhile()
        {
            int[] nums = new int[] { };
            int target = 0;
            int result = -1;

            var start = 0;
            var end = nums.Length - 1;
            while (start <= end)
            {
                var k = start + (start - end) / 2;

                if (nums[k] > target)
                {
                    end = k - 1;
                }
                else if (nums[k] < target)
                {
                    start = k + 1;
                }
                else
                {
                    result = k;
                    break;
                }
            }
        }

        #endregion

    }
}
