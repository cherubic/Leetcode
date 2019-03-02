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

        #region Happy Number

        [TestMethod]
        public void HappyNumber()
        {
            var n = 19;
            bool? result = null;

            Dictionary<int, int> existNumber = new Dictionary<int, int>();
            var storageNumber = n.ToString().ToArray();
            int nextNumber = 0;
            while (nextNumber != 1)
            {
                nextNumber = 0;
                for (var i = 0; i < storageNumber.Length; i++)
                {
                    nextNumber = nextNumber + (int.Parse(storageNumber[i].ToString()) * int.Parse(storageNumber[i].ToString()));
                }

                if (existNumber.ContainsKey(nextNumber))
                {
                    result = false;
                }
                else
                {
                    existNumber.Add(nextNumber, 0);
                }

                storageNumber = nextNumber.ToString().ToArray();
            }

            result = true;

        }

        #endregion

        #region 4Sum

        public void Sum4()
        {
            IList<IList<int>> sometemp;

            int[] nums = new int[] { 1, 0, -1, 0, -2, 2 };
            int target = 0;

            var result = new List<List<int>>();
            if (nums.Count() < 4) sometemp = result.ToArray();
            var sortedNums = nums.OrderBy(x => x).ToArray();

            for (var i = 0; i < sortedNums.Count() - 3; i++)
            {

                if (sortedNums[i - 1] == sortedNums[i] && i > 0)
                {
                    continue;
                }

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

            sometemp = result.ToArray();
        }

        #endregion

        #region Substring with Concatenation of All Words

        [TestMethod]
        public void SubstringwithConcatenationofAllWords()
        {
            List<int> result = new List<int>();
            string s = "wordgoodgoodgoodbestword";
            string[] words = new string[] { "good", "good", "best", "word" };

            Dictionary<string, int> wordDic = new Dictionary<string, int>();
            var sLength = s.Length;
            var eachWordLength = 0;
            if (words.Length > 0) eachWordLength = words[0].Length;
            var wordTotalLength = eachWordLength * words.Length;

            if (s.Length < wordTotalLength || s.Length <= 0 || wordTotalLength <= 0) result = new List<int>();

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

        }

        //Should Fix
        [TestMethod]
        public void SubstringwithConcatenationofAllWords_2()
        {
            List<int> result = new List<int>();
            string s = "barfoothefoobarman";
            string[] words = new string[] { "foo", "bar" };

            Dictionary<string, int> wordDic = new Dictionary<string, int>();
            var sLength = s.Length;
            var eachWordLength = 0;
            if (words.Length > 0) eachWordLength = words[0].Length;
            var wordTotalLength = eachWordLength * words.Length;

            if (s.Length < wordTotalLength || s.Length <= 0 || wordTotalLength <= 0) result = new List<int>();

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


            for (var i = 0; i < eachWordLength; i++)
            {
                var start = 0;

                while (start <= s.Length - wordTotalLength)
                {
                    var tempSubString = s.Substring(start, wordTotalLength);
                    bool isContinue = false;

                    var tempSubStringDic = new Dictionary<int, string>();
                    for (var j = 0; j < words.Length; j++)
                    {
                        tempSubStringDic.Add(j, tempSubString.Substring(j * eachWordLength, eachWordLength));
                    }

                    var storageTempDic = new Dictionary<string, int>();
                    var moveLength = eachWordLength;
                    for (var j = 0; j < tempSubStringDic.Count(); j++)
                    {
                        if (!wordDic.ContainsKey(tempSubStringDic[j]))
                        {
                            moveLength = (eachWordLength * (j + 1));
                            isContinue = true;
                            break;
                        }
                        else
                        {
                            start = start + eachWordLength;
                            if (storageTempDic.ContainsKey(tempSubStringDic[j]))
                            {
                                storageTempDic[tempSubStringDic[j]] = storageTempDic[tempSubStringDic[j]] - 1;
                            }
                            else
                            {
                                storageTempDic.Add(tempSubStringDic[j], wordDic[tempSubStringDic[j]] - 1);
                            }
                        }
                    }

                    
                    if (storageTempDic.Values.Any(x => x != 0)) isContinue = true;
                    if (isContinue)
                    {
                        start = start + moveLength;
                        continue;
                    }
                    else
                    {
                        result.Add(start);
                        start = start + moveLength;
                    }

                }
            }
        }

        #endregion
    }
}
