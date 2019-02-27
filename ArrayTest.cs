﻿using System;
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
        public int[] TwoSum()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;

            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (target - nums[i] == nums[j])
                    {
                        return new int[] { i, j };
                    }
                }
            }

            throw new Exception("Not Find");
        }

        //Approach 2
        [TestMethod]
        public int[] TwoSum_2()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;

            var numDic = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                numDic.Add(nums[i], i);
            }

            for (var j = 0; j < numDic.Count; j++)
            {
                if (numDic.ContainsKey(target - nums[j]) && numDic[target - nums[j]] != j)
                {
                    return new int[] { j, numDic[target - nums[j]] };
                }
            }

            throw new Exception("Not found");
        }

        //Approach 3
        [TestMethod]
        public int[] TwoSum_3()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;

            var numDic = new Dictionary<int, int>();
            for(var i=0; i< nums.Length; i++)
            {
                if(numDic.ContainsKey(target - nums[i]))
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
        [TestMethod]
        public void TestMethod1()
        {
            var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };


        }

        #endregion
    }
}
