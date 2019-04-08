using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MathProblem
    {
        #region Reverse Integer

        /*
         * 
         * https://leetcode.com/problems/reverse-integer/
         * Given a 32-bit signed integer, reverse digits of an integer.
         * 
         * Example 1:
         * Input: 123
         * Output: 321
         * 
         * Example 2:
         * Input: -123
         * Output: -321
         * 
         * Example 3:
         * Input: 120
         * Output: 21
         * 
         * Note:
         * Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
         * 
         */

        public int Reverse(int x)
        {
            int result = 0;
            int index;
            if (x < 0)
            {
                index = x.ToString().Length - 2;
            }
            else
            {
                index = x.ToString().Length - 1;
            }

            while (x != 0)
            {
                double temp = (double)result;
                var tempValue = (((x % 10) * (Math.Pow(10, index))) + temp);

                if (tempValue > Int32.MaxValue)
                {
                    return 0;
                }
                else if (tempValue < Int32.MinValue)
                {
                    return 0;
                }
                else
                {
                    result = (int)tempValue;
                }

                x = x / 10;
                index--;
            }

            return result;
        }

        #endregion

        #region String to Integer (atoi)

        /*
         * 
         * https://leetcode.com/problems/string-to-integer-atoi/
         * Implement atoi which converts a string to an integer.
         * The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.
         * The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
         * If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.
         * If no valid conversion could be performed, a zero value is returned.
         * 
         * Note:
         * Only the space character ' ' is considered as whitespace character.
         * Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or INT_MIN (−231) is returned.
         * 
         * Example 1:
         * Input: "42"
         * Output: 42
         * 
         * Example 2:
         * Input: "   -42"
         * Output: -42
         * Explanation: The first non-whitespace character is '-', which is the minus sign.
         * Then take as many numerical digits as possible, which gets 42.
         * 
         * Example 3:
         * Input: "4193 with words"
         * Output: 4193
         * Explanation: Conversion stops at digit '3' as the next character is not a numerical digit.
         * 
         * Example 4:
         * Input: "words and 987"
         * Output: 0
         * Explanation: The first non-whitespace character is 'w', which is not a numerical 
         * digit or a +/- sign. Therefore no valid conversion could be performed.
         * 
         * Example 5:
         * Input: "-91283472332"
         * Output: -2147483648
         * 
         * Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.
         * Thefore INT_MIN (−231) is returned.
         * 
         */

        public int MyAtoi(string str)
        {
            int index = 0, sign = 1, total = 0;
            //1. Remove spaces
            while (index < str.Length && str[index] == ' ') index++;
            //2. Get sign
            sign = index < str.Length && (str[index] == '+' || str[index] == '-') ? str[index++] == '+' ? 1 : -1 : 1;
            //3. Calculate it and take care of overflow
            while (index < str.Length)
            {
                int digit = str[index++] - '0';
                if (digit < 0 || 9 < digit) break;
                if (int.MaxValue / 10 < total || int.MaxValue / 10 == total && int.MaxValue % 10 < digit)
                    return sign == -1 ? int.MinValue : int.MaxValue;
                total = total * 10 + digit;
            }
            return total * sign;
        }

        #endregion

        #region Palindrome Number

        /*
         * 
         * https://leetcode.com/problems/palindrome-number/
         * Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
         * Example 1:
         * Input: 121
         * Output: true
         * 
         * Example 2:
         * Input: -121
         * Output: false
         * Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
         * 
         * Example 3:
         * Input: 10
         * Output: false
         * 
         * Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
         * 
         * Follow up:
         * Coud you solve it without converting the integer to a string?
         * 
         */


        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;

            var intStr = x.ToString();
            var index = 0;

            while (intStr.Length - 1 - index > index)
            {
                if (intStr[index] != intStr[intStr.Length - 1 - index])
                {
                    return false;
                }

                index++;
            }

            return true;
        }

        #endregion

        #region Integer to Roman

        /*
         * 
         * https://leetcode.com/problems/integer-to-roman/
         * 
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
         * Given an integer, convert it to a roman numeral. Input is guaranteed to be within the range from 1 to 3999.
         * 
         * Example 1:
         * Input: 3
         * Output: "III"
         * 
         * Example 2:
         * Input: 4
         * Output: "IV"
         * 
         * Example 3:
         * Input: 9
         * Output: "IX"
         * 
         * Example 4:
         * Input: 58
         * Output: "LVIII"
         * 
         * Explanation: L = 50, V = 5, III = 3.
         * 
         * Example 5:
         * Input: 1994
         * Output: "MCMXCIV"
         * 
         * Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
         * 
         */

        public string IntToRoman(int num)
        {
            var result = string.Empty;

            while (num > 0)
            {
                if (num >= 1000)
                {
                    result = result + new string('M', num / 1000);
                    num = num - ((num / 1000) * 1000);
                }
                else if (num >= 900)
                {
                    num = num - 900;
                    result = result + "CM";
                }
                else if (num >= 500)
                {
                    num = num - 500;
                    result = result + "D";
                }
                else if (num >= 400)
                {
                    num = num - 400;
                    result = result + "CD";
                }
                else if (num >= 100)
                {
                    num = num - 100;
                    result = result + "C";
                }
                else if (num >= 90)
                {
                    num = num - 90;
                    result = result + "XC";
                }
                else if (num >= 50)
                {
                    num = num - 50;
                    result = result + "L";
                }
                else if (num >= 40)
                {
                    num = num - 40;
                    result = result + "XL";
                }
                else if (num >= 10)
                {
                    num = num - 10;
                    result = result + "X";
                }
                else if (num == 9)
                {
                    num = num - 9;
                    result = result + "IX";
                }
                else if (num >= 5)
                {
                    num = num - 5;
                    result = result + "V";
                }
                else if (num == 4)
                {
                    num = num - 4;
                    result = result + "IV";
                }
                else if (num >= 1)
                {
                    num = num - 1;
                    result = result + "I";
                }
            }

            return result;
        }

        #endregion

        #region Valid Number

        /*
         * 
         * https://leetcode.com/problems/valid-number/
         * Validate if a given string can be interpreted as a decimal number.
         * Some examples:
         * "0" => true
         * " 0.1 " => true
         * "abc" => false
         * "1 a" => false
         * "2e10" => true
         * " -90e3   " => true
         * " 1e" => false
         * "e3" => false
         * " 6e-1" => true
         * " 99e2.5 " => false
         * "53.5e93" => true
         * " --6 " => false
         * "-+3" => false
         * "95a54e53" => false
         * 
         * Note: It is intended for the problem statement to be ambiguous. You should gather all requirements up front before implementing one. However, here is a list of characters that can be in a valid decimal number:
         * Numbers 0-9
         * Exponent - "e"
         * Positive/negative sign - "+"/"-"
         * Decimal point - "."
         * Of course, the context of these characters also matters in the input.
         * 
         * Update (2015-02-10):
         * The signature of the C++ function had been updated. If you still see your function signature accepts a const char * argument, please click the reload button to reset your code definition.
         * 
         */

        
        #endregion
    }
}
