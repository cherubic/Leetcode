using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ArrayProblem
    {
        #region TwoSum

        /*
         * 
         * https://leetcode.com/problems/two-sum/
         * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
         * You may assume that each input would have exactly one solution, and you may not use the same element twice.
         *
         * EXAMPLE:
         * Given nums = [2, 7, 11, 15], target = 9,
         * Because nums[0] + nums[1] = 2 + 7 = 9,
         * return [0, 1].
         * 
         */

        /// <summary>
        /// time complexity: O(n^2) 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; i < nums.Length; j++)
                {
                    if (target - nums[i] == nums[j])
                    {
                        return new int[] { i, j };
                    }
                }
            }

            throw new Exception("Not Found");
        }

        /// <summary>
        /// time complexity
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum_2(int[] nums, int target)
        {
            var numDic = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (numDic.ContainsKey(target - nums[i]))
                {
                    return new int[] { numDic[target - nums[i]], i };
                }
                else
                {
                    numDic.Add(nums[i], i);
                }
            }

            throw new Exception("Not Found");
        }

        #endregion

        #region Container With Most Water

        /*
         * https://leetcode.com/problems/container-with-most-water/
         * Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.
         * Note: You may not slant the container and n is at least 2.
         * 
         * The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
         * 
         * Input: [1,8,6,2,5,4,8,3,7]
         * Output: 49
         * 
         */

        public int ContainerWithMostWater(int[] height)
        {
            var result = 0;
            for (var i = 0; i < height.Length; i++)
            {
                for (var j = i + 1; j < height.Length; j++)
                {
                    var square = (height[i] > height[j] ? height[i] : height[j]) * (j - i);
                    if (result < square)
                    {
                        result = square;
                    }
                }
            }

            return result;
        }

        public int ContainerWithMostWater_2(int[] height)
        {
            int result = 0;
            var start = 0;
            var end = height.Length - 1;
            while (start < end)
            {
                var area = (end - start) * (height[start] > height[end] ? height[end] : height[start]);
                result = result > area ? result : area;
                if (height[start] > height[end])
                {
                    end--;
                }
                else
                {
                    start++;
                }
            }

            return result;
        }

        #endregion

        #region 3Sum

        /*
         * https://leetcode.com/problems/3sum/
         * Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
         *
         * EXAMPLE:
         * Given array nums = [-1, 0, 1, 2, -1, -4],
         * 
         * A solution set is:
         * [
         *  [-1, 0, 1],
         *  [-1, -1, 2]
         * ]
         */

        public IList<IList<int>> Sum3(int[] nums)
        {
            var result = new List<List<int>>();
            var sortResult = nums.OrderBy(x => x).ToArray<int>();
            for (var i = 0; i < sortResult.Length - 2; i++)
            {
                var start = i;
                if (i > 0 && sortResult[i] == sortResult[i - 1])
                {
                    start = i + 1;
                    continue;
                }

                var medium = start + 1;
                var end = sortResult.Length - 1;
                while (medium < end)
                {
                    if (sortResult[start] + sortResult[medium] + sortResult[end] > 0)
                    {
                        end = end - 1;
                    }
                    else if (sortResult[start] + sortResult[medium] + sortResult[end] < 0)
                    {
                        medium = medium + 1;
                    }
                    else
                    {
                        result.Add(new List<int>() { sortResult[start], sortResult[medium], sortResult[end] });
                        while (medium < end && sortResult[medium] == sortResult[medium + 1])
                        {
                            medium = medium + 1;
                        }

                        while (medium < end && sortResult[end] == sortResult[end - 1])
                        {
                            end = end - 1;
                        }

                        medium = medium + 1;
                        end = end - 1;
                    }
                }
            }

            return result.ToArray();
        }

        #endregion

        #region RemoveDuplicates

        /*
         * 
         * https://leetcode.com/problems/remove-duplicates-from-sorted-array/
         * Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
         * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
         * 
         * Example 1:
         * Given nums = [1,1,2],
         * Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.
         * It doesn't matter what you leave beyond the returned length.
         * 
         * Example 2:
         * Given nums = [0,0,1,1,1,2,2,3,3,4],
         * Your function should return length = 5, with the first five elements of nums being modified to 0, 1, 2, 3, and 4 respectively.
         * It doesn't matter what values are set beyond the returned length.
         * 
         * Clarification:
         * Confused why the returned value is an integer but your answer is an array?
         * Note that the input array is passed in by reference, which means modification to the input array will be known to the caller as well.
         * 
         * Internally you can think of this:
         * // nums is passed in by reference. (i.e., without making a copy)
         * int len = removeDuplicates(nums);
         * // any modification to nums in your function would be known by the caller.
         * // using the length returned by your function, it prints the first len elements.
         * for (int i = 0; i < len; i++) {
         *  print(nums[i]);
         * }
         * 
         */

        public int RemoveDuplicates(int[] nums)
        {
            Dictionary<int, int> numsDic = new Dictionary<int, int>();
            var index = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (!numsDic.ContainsKey(nums[i]))
                {
                    numsDic.Add(nums[i], index);
                    nums[index] = nums[i];
                    index++;
                    index++;
                }
            }

            return numsDic.Count();
        }

        #endregion

        #region MediumofTwoSortedArrays

        /*
         * 
         * https://leetcode.com/problems/median-of-two-sorted-arrays/
         * There are two sorted arrays nums1 and nums2 of size m and n respectively.
         * Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
         * You may assume nums1 and nums2 cannot be both empty.
         * 
         * Example 1:
         * nums1 = [1, 3]
         * nums2 = [2]
         * The median is 2.0
         * 
         * Example 2:
         * nums1 = [1, 2]
         * nums2 = [3, 4]
         * The median is (2 + 3)/2 = 2.5
         * 
         */

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var length1 = nums1.Length;
            var length2 = nums2.Length;
            var totalLength = length1 + length2;
            var totalArray = new int[totalLength];

            var n1 = 0;
            var n2 = 0;
            for (var i = 0; i < totalLength; i++)
            {
                if (n1 == nums1.Length)
                {
                    totalArray[i] = nums2[n2];
                    n2++;
                }
                else if (n2 == nums2.Length)
                {
                    totalArray[i] = nums1[n1];
                    n1++;
                }
                else if (nums1[n1] > nums2[n2])
                {
                    totalArray[i] = nums2[n2];
                    n2++;
                }
                else
                {
                    totalArray[i] = nums1[n1];
                    n1++;
                }
            }

            if (totalLength % 2 == 0)
            {
                var half_1 = totalLength / 2 - 1;
                var half_2 = half_1 + 1;
                return ((double)totalArray[half_1] + (double)totalArray[half_2]) / 2;
            }
            else
            {
                var half = (totalLength - 1) / 2;
                return (double)totalArray[half];
            }

        }

        #endregion
    }
}
