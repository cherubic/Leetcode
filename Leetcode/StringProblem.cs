using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class StringProblem
    {
        #region Longest Palindromic Substring

        /*
         * 
         * https://leetcode.com/problems/longest-palindromic-substring/
         * Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
         * Example 1:
         * Input: "babad"
         * Output: "bab"
         * Note: "aba" is also a valid answer.
         * Example 2:
         * Input: "cbbd"
         * Output: "bb"
         * 
         */

        public string LongestPalindrome(string s)
        {

            if (s.Length < 2) return s;

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
                return doubleMaxString;
            }
            else
            {
                return maxString;
            }
        }

        #endregion

        #region ZigZagConversion

        /*
         * 
         * https://leetcode.com/problems/zigzag-conversion/
         * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
         * P   A   H   N
         * A P L S I I G
         * Y   I   R
         * And then read line by line: "PAHNAPLSIIGYIR"
         * 
         * Write the code that will take a string and make this conversion given a number of rows:
         * string convert(string s, int numRows);
         * 
         * Example 1:
         * Input: s = "PAYPALISHIRING", numRows = 3
         * Output: "PAHNAPLSIIGYIR"
         * 
         * Example 2:
         * Input: s = "PAYPALISHIRING", numRows = 4
         * Output: "PINALSIGYAHRPI"
         * Explanation:
         * P     I    N
         * A   L S  I G
         * Y A   H R
         * P     I
         *  
         */

        public string Convert(string s, int numRows)
        {
            if (numRows < 2) return s;

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

            return result;
        }

        #endregion

        #region Longest Common Prefix

        #endregion

        #region Roman to Integer

        /*
         * 
         * https://leetcode.com/problems/roman-to-integer/
         * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
         * Symbol       Value
         * I             1
         * V             5
         * X             10
         * L             50
         * C             100
         * D             500
         * M             1000
         * For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.
         * Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
         * I can be placed before V (5) and X (10) to make 4 and 9. 
         * X can be placed before L (50) and C (100) to make 40 and 90. 
         * C can be placed before D (500) and M (1000) to make 400 and 900.
         * Given a roman numeral, convert it to an integer. Input is guaranteed to be within the range from 1 to 3999.
         * 
         * Example 1:
         * Input: "III"
         * Output: 3
         * 
         * Example 2:
         * Input: "IV"
         * Output: 4
         * 
         * Example 3:
         * Input: "IX"
         * Output: 9
         * 
         * Example 4:
         * Input: "LVIII"
         * Output: 58
         * Explanation: L = 50, V= 5, III = 3.
         * 
         * Example 5:
         * Input: "MCMXCIV"
         * Output: 1994
         * Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
         * 
         */

        public int RomanToInt(string s)
        {
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

            return result;
        }

        #endregion
    }
}
