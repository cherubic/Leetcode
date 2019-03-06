using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    [TestClass]
    public class StringTest
    {

        [TestMethod]
        public void LongestPalindromicSubString()
        {
            var s = "bb";

            string result = string.Empty;

            if (s.Length < 2) result = string.Empty;

            var maxString = string.Empty;
            var doubleMaxString = s.Length > 0 ? s[0].ToString() : string.Empty;
            for (var i = 0; i < s.Length; i++)
            {

                var left = i - 1;
                var right = i + 1;
                var subString = s[i].ToString();

                while (left >= 0 && right < s.Length)
                {
                    if (s[left] == s[right])
                    {
                        subString = s[left] + subString + s[right];
                        left--;
                        right++;
                    }
                    else
                    {
                        break;
                    }
                }

                maxString = maxString.Length > subString.Length ? maxString : subString;

                var doubleLeft = i - 1;
                var doubleRight = i;
                var doubleSubString = string.Empty;


                while (doubleLeft >= 0 && doubleRight < s.Length)
                {
                    if (s[doubleLeft] == s[doubleRight])
                    {
                        doubleSubString = s[doubleLeft] + doubleSubString + s[doubleRight];
                        doubleLeft--;
                        doubleRight++;
                    }
                    else
                    {
                        break;
                    }
                }

                doubleMaxString = doubleSubString.Length > doubleMaxString.Length ? doubleSubString : doubleMaxString;
            }

            if (doubleMaxString.Length > maxString.Length)
            {
                result = doubleMaxString;
            }
            else
            {
                result = maxString;
            }
        }

        [TestMethod]
        public void ZigZagConversion()
        {
            int numRows = 2;
            string s = "Abcd";
            //"PINALSIGYAHRPI"

            int interval = numRows + numRows - 2;
            string result = string.Empty;
            for (var i = 0; i < numRows; i++)
            {
                var temp = i;

                if (i == 0 || i == numRows - 1)
                {
                    while (temp < s.Length)
                    {
                        result += s[temp];
                        temp += interval;
                    }
                }
                else
                {
                    while (temp < s.Length)
                    {
                        result += s[temp];
                        if (temp + ((numRows - i - 1) * 2) < s.Length) result += s[temp + ((numRows - i - 1) * 2)];
                        temp += interval;
                    }
                }
            }


        }

        #region Longest Common Prefix

        [TestMethod]
        public void LongestCommonPrefix()
        {
            var strs = new string[] { "abab", "aba", "" };
            var result = string.Empty;

            var common = new Dictionary<int, char>();
            for (var i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length == 0) result = string.Empty;

                for (var j = 0; j < strs[i].Length; j++)
                {
                    if (i == 0)
                    {
                        common.Add(j, strs[i][j]);
                    }
                    else
                    {
                        if (common.Count() > strs[i].Length)
                        {
                            var temp = strs[i].Length;

                            while (common.Count() > strs[i].Length)
                            {
                                common.Remove(temp);
                                temp++;
                            }
                        }

                        if (common.ContainsKey(j))
                        {
                            if (common[j] != strs[i][j])
                            {
                                var temp = common.Count();
                                while (j < temp)
                                {
                                    common.Remove(j);
                                    j++;
                                }
                            }
                        }
                    }
                }
            }

            for (var i = 0; i < common.Count(); i++)
            {
                result += common[i];
            }

        }

        #endregion

        #region Roman to Integer

        public void RomaintoInteger()
        {
            string s = string.Empty;

            int result = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == 'C')
                {
                    if (i + 1 < s.Length)
                    {
                        if (s[i + 1] == 'D')
                        {
                            result += 400;
                            i++;
                        }
                        else if (s[i + 1] == 'M')
                        {
                            result += 900;
                            i++;
                        }
                        else
                        {
                            result += 100;
                        }
                    }
                    else
                    {
                        result += 100;
                    }

                }
                else if (s[i] == 'X')
                {
                    if (i + 1 < s.Length)
                    {
                        if (s[i + 1] == 'L')
                        {
                            result += 40;
                            i++;
                        }
                        else if (s[i + 1] == 'C')
                        {
                            result += 90;
                            i++;
                        }
                        else
                        {
                            result += 10;
                        }
                    }
                    else
                    {
                        result += 10;
                    }

                }
                else if (s[i] == 'I')
                {
                    if (i + 1 < s.Length)
                    {
                        if (s[i + 1] == 'V')
                        {
                            result += 4;
                            i++;
                        }
                        else if (s[i + 1] == 'X')
                        {
                            result += 9;
                            i++;
                        }
                        else
                        {
                            result += 1;
                        }
                    }
                    else
                    {
                        result += 1;
                    }
                }
                else if (s[i] == 'V')
                {
                    result += 5;
                }
                else if (s[i] == 'L')
                {
                    result += 50;
                }
                else if (s[i] == 'D')
                {
                    result += 500;
                }
                else if (s[i] == 'M')
                {
                    result += 1000;
                }
                else
                {
                    throw new Exception("NOT SUPPORT");
                }
            }
        }

        #endregion
    }
}
