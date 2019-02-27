using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    [TestClass]
    public class ArrayTest
    {

        #region TwoSum
        /*
            Input:
            [2,7,11,15]
            9

            Output:
            [0,1]

            Expected:
            [0,1]

             */

        //Approach 1
        [TestMethod]
        public void TwoSum()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            int[] result;

            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (target - nums[i] == nums[j])
                    {
                        result = new int[] { i, j };
                    }
                }
            }
        }

        //Approach 2
        [TestMethod]
        public void TwoSum_2()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            int[] result;

            var numDic = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                numDic.Add(nums[i], i);
            }

            for (var j = 0; j < numDic.Count; j++)
            {
                if (numDic.ContainsKey(target - nums[j]) && numDic[target - nums[j]] != j)
                {
                    result = new int[] { j, numDic[target - nums[j]] };
                }
            }
        }

        //Approach 3
        [TestMethod]
        public void TwoSum_3()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            int[] result;

            var numDic = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (numDic.ContainsKey(target - nums[i]))
                {
                    result = new int[] { numDic[target - nums[i]], i };
                }
                else
                {
                    numDic.Add(nums[i], i);
                }
            }
        }

        #endregion

        #region Container With Most Water
        /*
         
            [1,8,6,2,5,4,8,3,7]
            
            49

            49
             
             */

        [TestMethod]
        public void ContainerWithMostWater()
        {
            int result;
            var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            List<int> temp = new List<int>();

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    var min = input[i] > input[j] ? input[i] : input[j];
                    temp.Add(min * (j - i));
                }
            }

            result = temp.Max();
        }

        [TestMethod]
        public void ContainerWithMostWater_2()
        {
            var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            int result = 0;

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    var square = (input[i] > input[j] ? input[i] : input[j]) * (j - i);
                    if (result < square)
                    {
                        result = square;
                    }
                }
            }

        }

        [TestMethod]
        public void ContainerWithMostWater_3()
        {
            var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            int result = 0;
            var start = 0;
            var end = input.Length - 1;
            while (start < end)
            {
                var area = (end - start) * (input[start] > input[end] ? input[end] : input[start]);
                result = result > area ? result : area;
                if (input[start] > input[end])
                {
                    end--;
                }
                else
                {
                    start++;
                }
            }
        }

        #endregion

        #region 3Sum

        [TestMethod]
        public void Sum3()
        {
            int[] input = new int[] { -1, 0, 1, 2, -1, -4 };

            var temp = new List<List<int>>();
            var sortResult = input.OrderBy(x => x).ToArray<int>();
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
                        temp.Add(new List<int>() { sortResult[start], sortResult[medium], sortResult[end] });
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

            var result = temp.ToArray();
        }

        #endregion

        #region RemoveDuplicates

        [TestMethod]
        public void RemoveDuplicates()
        {
            int[] input = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            Dictionary<int, int> inputDic = new Dictionary<int, int>();
            for (var i = 0; i < input.Length; i++)
            {
                if (!inputDic.ContainsKey(input[i]))
                {
                    inputDic.Add(input[i], i);
                }
            }

            for (var i = 0; i < inputDic.Count(); i++)
            {
                input[i] = inputDic.ElementAt(i).Key;
            }

            var result = inputDic.Count();
        }

        [TestMethod]
        public void RemoveDuplicates_2()
        {
            int[] input = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            Dictionary<int, int> inputDic = new Dictionary<int, int>();
            var index = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (!inputDic.ContainsKey(input[i]))
                {
                    inputDic.Add(input[i], index);
                    input[index] = input[i];
                    index++;
                }
            }

            var result = inputDic.Count();
        }

        #endregion
    }
}
