using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    [TestClass]
    public class MathTest
    {

        #region Reverse Integer

        //It is not necessary to use int
        [TestMethod]
        public void ReverseInteger()
        {
            int x = 123;
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
                    result = 0;
                }
                else if (tempValue < Int32.MinValue)
                {
                    result = 0;
                }
                else
                {
                    result = (int)tempValue;
                }

                x = x / 10;
                index--;
            }


        }

        #endregion

        #region String to Integer (atoi)

        [TestMethod]
        public void StringtoInteger()
        {
            string str = "  -0012a42";
            int result = 0;

            if (string.IsNullOrEmpty(str))
            {
                result = 0;
            }

            bool isNegative = false;
            int index = 0;
            string resultStr = string.Empty;
            for (var i = 0; i < str.Length; i++)
            {
                if (index == 0)
                {
                    if (str[i] == '-' || str[i] == '+')
                    {
                        if (str[i] == '-')
                            isNegative = true;

                        index++;
                        continue;
                    }
                    else if (System.Text.RegularExpressions.Regex.IsMatch(str[i].ToString(), @"^[0-9]"))
                    {
                        resultStr = resultStr + str[i];
                        index++;
                    }
                    else if (str[i] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(str[i].ToString(), @"^[0-9]"))
                    {
                        resultStr = resultStr + str[i];
                        index++;
                    }
                    else if (str[i] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(resultStr)) result = 0;
            double doubleResult = double.Parse(resultStr);
            if (isNegative) doubleResult = (-1) * doubleResult;

            if (doubleResult > Int32.MaxValue)
            {
                result = Int32.MaxValue;
            }
            else if (doubleResult < Int32.MinValue)
            {
                result = Int32.MinValue;
            }
            else
            {
                result = (int)doubleResult;
            }

        }

        [TestMethod]
        public void StringtoInteger_2()
        {
            var str = string.Empty;
            var result = 0;
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
                    result = sign == -1 ? int.MinValue : int.MaxValue;
                total = total * 10 + digit;
            }
            result = total * sign;
        }

        #endregion

        #region Palindrome Number

        [TestMethod]
        public void PalindromeNumber()
        {
            var num = 3;
            string result = string.Empty;

            while (num > 0)
            {
                if (num > 1000)
                {
                    num = num - 1000;
                    result = result + "M";
                }
                else if (num > 900)
                {
                    num = num - 900;
                    result = result + "CM";
                }
                else if (num > 500)
                {
                    num = num - 500;
                    result = result + "D";
                }
                else if (num > 400)
                {
                    num = num - 400;
                    result = result + "CD";
                }
                else if (num > 100)
                {
                    num = num - 100;
                    result = result + "C";
                }
                else if (num > 90)
                {
                    num = num - 90;
                    result = result + "XC";
                }
                else if (num > 50)
                {
                    num = num - 50;
                    result = result + "L";
                }
                else if (num > 40)
                {
                    num = num - 40;
                    result = result + "XL";
                }
                else if (num > 10)
                {
                    num = num - 10;
                    result = result + "X";
                }
                else if (num == 9)
                {
                    num = num - 9;
                    result = result + "IX";
                }
                else if (num > 5)
                {
                    num = num - 5;
                    result = result + "V";
                }
                else if (num == 4)
                {
                    num = num - 4;
                    result = result + "IV";
                }
                else if (num > 1)
                {
                    num = num - 1;
                    result = result + "I";
                }
            }

            var a = result;
        }

        #endregion

        #region Integer to Roman

        [TestMethod]
        public void IntegertoRoman()
        {
            var num = 3;
            var result = string.Empty;

            while (num > 0)
            {
                if (num >= 1000)
                {
                    num = num - 1000;
                    result = result + "M";
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
        }

        [TestMethod]
        public void IntegertoRoman_2()
        {
            int num = 1994;
            var result = string.Empty;

            while (num > 0)
            {
                if (num >= 1000)
                {
                    num = num - ((num / 1000) * 1000);
                    result = result + new string('M', num / 1000);
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

        }

        #endregion

        #region Valid Number

        public void ValidNumber()
        {
            //string s = string.Empty;
            //bool result = false;
            //s.Remove(' ');

            //if (string.IsNullOrEmpty(s)) result = false;
            //int eCount = 0;
            //int pointCount = 0;
            //int index = 0;
            //int numberCount = 0;
            //for (var i = 0; i < s.Length; i++)
            //{
            //    if (i == 0 && s[i] )
            //    {
            //        index++;
            //    }
            //}



        }

        #endregion
    }
}
