using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class HashTableProblem
    {
        #region SingleNumber

        /*
         * https://leetcode.com/problems/single-number/
         * Given a non-empty array of integers, every element appears twice except for one. Find that single one.
         * Note:
         * Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
         * 
         * Example 1:
         * Input: [2,2,1]
         * Output: 1
         * 
         * Example 2:
         * Input: [4,1,2,1,2]
         * Output: 4
         * 
         */

        public int SingleNumber(int[] nums)
        {
            int result = 0;

            int temp = 0;
            foreach (var item in nums.Distinct())
            {
                temp = item + temp;
            }

            result = temp * 2 - nums.Sum();
            return result;
        }

        #endregion

        #region Longest Substring Without Repeating Characters

        /*
         * Given a string, find the length of the longest substring without repeating characters.
         * 
         * Example 1:
         * Input: "abcabcbb"
         * Output: 3 
         * 
         * Explanation: The answer is "abc", with the length of 3. 
         * Example 2:
         * Input: "bbbbb"
         * Output: 1
         * 
         * Explanation: The answer is "b", with the length of 1.
         * Example 3:
         * Input: "pwwkew"
         * Output: 3
         * 
         * Explanation: The answer is "wke", with the length of 3. 
         * Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
         */

        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> tempDic = new Dictionary<char, int>();

            var result = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (tempDic.TryGetValue(s[i], out int index))
                {
                    result = Math.Max(result, tempDic.Count());
                    i = index;
                    tempDic.Clear();
                }
                else
                {
                    tempDic.Add(s[i], i);
                }
            }

            result = Math.Max(result, tempDic.Count());

            return result;

        }

        #endregion

        #region Happy Number

        /*
         * https://leetcode.com/problems/happy-number/
         * Write an algorithm to determine if a number is "happy".
         * A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
         * Example: 
         * Input: 19
         * Output: true
         * Explanation: 
         * 12 + 92 = 82
         * 82 + 22 = 68
         * 62 + 82 = 100
         * 12 + 02 + 02 = 1
         * 
         */

        public bool IsHappy(int n)
        {
            Dictionary<int, int> existNumber = new Dictionary<int, int>();
            var storageNumber = n.ToString().ToArray();
            while (true)
            {
                int nextNumber = 0;

                for (var i = 0; i < storageNumber.Length; i++)
                {
                    nextNumber = nextNumber + (int.Parse(storageNumber[i].ToString()) * int.Parse(storageNumber[i].ToString()));
                }

                if (nextNumber == 1)
                {
                    return true;
                }

                if (existNumber.ContainsKey(nextNumber))
                {
                    return false;
                }
                else
                {
                    existNumber.Add(nextNumber, 0);
                }

                storageNumber = nextNumber.ToString().ToArray();
            }
        }

        #endregion

        #region 4Sum

        /*
         * 
         * https://leetcode.com/problems/4sum/
         * Given an array nums of n integers and an integer target, are there elements a, b, c, and d in nums such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.
         * Note:
         * The solution set must not contain duplicate quadruplets.
         * Example:
         * Given array nums = [1, 0, -1, 0, -2, 2], and target = 0.
         * A solution set is:
         * [
         *   [-1,  0, 0, 1],
         *   [-2, -1, 1, 2],
         *   [-2,  0, 0, 2]
         * ]
         * 
         */

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<List<int>>();
            if (nums.Count() < 4) return result.ToArray();
            var sortedNums = nums.OrderBy(x => x).ToArray();

            for (var i = 0; i < sortedNums.Count() - 3; i++)
            {

                if (i > 0 && sortedNums[i] == sortedNums[i - 1]) continue; //prevents duplicate result in ans list

                for (var j = i + 1; j < sortedNums.Count() - 2; j++)
                {
                    if (sortedNums[j - 1] == sortedNums[j] && j > i + 1)
                    {
                        continue;
                    }

                    var start = j + 1;
                    var end = sortedNums.Count() - 1;

                    while (start < end)
                    {
                        var sum = sortedNums[i] + sortedNums[j] + sortedNums[start] + sortedNums[end];
                        if (target == sum)
                        {
                            result.Add(new List<int>() { sortedNums[i], sortedNums[j], sortedNums[start], sortedNums[end] });
                            while (start < end && sortedNums[start] == sortedNums[start + 1]) start++; //skipping over duplicate on low
                            while (start < end && sortedNums[end] == sortedNums[end - 1]) end--; //skipping over duplicate on high
                            end--;
                            start++;
                        }
                        else if (target < sum)
                        {
                            end--;
                        }
                        else if (target > sum)
                        {
                            start++;
                        }
                    }
                }
            }

            return result.ToArray();
        }

        #endregion

        #region Substring with Concatenation of All Words

        /*
         * 
         * https://leetcode.com/problems/substring-with-concatenation-of-all-words/
         * You are given a string, s, and a list of words, words, that are all of the same length. Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.
         * Example 1:
         * Input:
         * s = "barfoothefoobarman",
         * words = ["foo","bar"]
         * Output: [0,9]
         * Explanation: Substrings starting at index 0 and 9 are "barfoor" and "foobar" respectively.
         * The output order does not matter, returning [9,0] is fine too.
         * 
         * Example 2:
         * Input:
         * s = "wordgoodgoodgoodbestword",
         * words = ["word","good","best","word"]
         * Output: []
         * 
         */

        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> result = new List<int>();
            Dictionary<string, int> wordDic = new Dictionary<string, int>();
            var sLength = s.Length;
            var eachWordLength = 0;
            if (words.Length > 0) eachWordLength = words[0].Length;
            var wordTotalLength = eachWordLength * words.Length;

            if (s.Length < wordTotalLength || s.Length <= 0 || wordTotalLength <= 0) return new List<int>();

            for (var i = 0; i < words.Length; i++)
            {
                if (wordDic.ContainsKey(words[i]))
                {
                    wordDic[words[i]]++;
                }
                else
                {
                    wordDic.Add(words[i], 1);
                }
            }


            for (var i = 0; i < s.Length - wordTotalLength + 1; i++)
            {
                var tempStringDic = new Dictionary<string, int>();
                var tempString = s.Substring(i, wordTotalLength);
                for (var j = 0; j < words.Length; j++)
                {
                    var tempSub = tempString.Substring(j * eachWordLength, eachWordLength);

                    if (tempStringDic.ContainsKey(tempSub))
                    {
                        tempStringDic[tempSub]++;
                    }
                    else
                    {
                        tempStringDic.Add(tempSub, 1);
                    }
                }

                bool isContinue = false;
                for (var j = 0; j < wordDic.Count(); j++)
                {
                    var workKeyValut = wordDic.ElementAt(j);
                    if (tempStringDic.ContainsKey(workKeyValut.Key) && tempStringDic[workKeyValut.Key] == workKeyValut.Value)
                    {
                        tempStringDic.Remove(workKeyValut.Key);
                    }
                    else
                    {
                        isContinue = true;
                    }
                }

                if (isContinue)
                {
                    continue;
                }
                else
                {
                    result.Add(i);
                }
            }

            return result;
        }
        #endregion
    }
}
