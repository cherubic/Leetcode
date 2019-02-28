using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    [TestClass]
    public class HashTableTest
    {

        #region SingleNumber

        [TestMethod]
        public void SingleNumber()
        {
            int[] nums = new int[] { 2, 2, 1 };
            int result = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                bool existOther = false;
                for (var j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else
                    {
                        if (nums[i] == nums[j])
                        {
                            existOther = true;
                        }
                    }
                }

                if (existOther == false)
                {
                    result = nums[i];
                }
            }

            throw new Exception("No Found");
        }

        [TestMethod]
        public void SingleNumber_2()
        {
            int[] nums = new int[] { 2, 2, 1 };
            int result = 0;

            int temp = 0;
            foreach (var item in nums.Distinct())
            {
                temp = item + temp;
            }

            result = temp * 2 - nums.Sum();
        }

        #endregion

        #region Longest Substring Without Repeating Characters
        [TestMethod]
        public void LongestSubstringWithoutRepeatingCharacter()
        {
            string s = " ";
            Dictionary<char, int> letters = new Dictionary<char, int>();
            int length = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (letters.TryGetValue(s[i], out int index))
                {
                    length = Math.Max(length, letters.Count);
                    i = index;
                    letters.Clear();
                }
                else
                {
                    letters.Add(s[i], i);
                }
            }
            length = Math.Max(length, letters.Count);
        }

        #endregion
    }
}
