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
                        if (temp + ((numRows-i-1)*2) < s.Length) result += s[temp + ((numRows - i - 1) * 2)];
                        temp += interval;
                    }
                }
            }


        }
    }
}
