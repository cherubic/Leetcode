using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    [TestClass]
    public class Algorithm
    {
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
        public void MergeSortRecurisve()
        {
            int[] input = new int[] { };
            int[] result = new int[] { };

            result = SortMerge(input);
        }

        public int[] SortMerge(int[] input)
        {
            if (input.Length == 1) return input;

            int k = input.Length / 2;
            int[] leftArray = new int[k];
            int[] rightArray = new int[input.Length - k];

            for (var i = 0; i < k; i++)
            {
                leftArray[i] = input[i];
            }

            for (var i = 0; i < input.Length - k; i++)
            {
                rightArray[i] = input[k + i];
            }

            var leftInput = SortMerge(leftArray);
            var rightInput = SortMerge(rightArray);

            int leftIndex = 0;
            int rightIndex = 0;
            var mergeArray = new int[leftInput.Length + rightInput.Length];
            int index = 0;

            while (leftIndex < leftInput.Length || rightIndex < rightInput.Length)
            {
                if (leftIndex == leftInput.Length)
                {
                    mergeArray[index] = rightInput[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex == rightInput.Length)
                {
                    mergeArray[index] = leftInput[leftIndex];
                    leftIndex++;
                }
                if (leftInput[leftIndex] < rightInput[rightIndex])
                {
                    mergeArray[index] = leftInput[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergeArray[index] = rightInput[rightIndex];
                    rightIndex++;
                }

                index++;
            }

            return mergeArray;
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
