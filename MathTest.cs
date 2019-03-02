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
        public void Stringtonteger()
        {
            string str = "   -42";
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
                if (index == 0 && str[i] == '-')
                {
                    isNegative = true;
                    continue;
                }
                if (Regex.IsMatch(str[i].ToString(), @"^[0-9]"))
                {
                    resultStr = resultStr + str[i];
                    index++;
                }else if (str[i] == ' ')
                {
                    continue;
                }
                else
                {
                    result = 0;
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

        #endregion
    }
}
