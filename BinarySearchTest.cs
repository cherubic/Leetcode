using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void DivideTwoIntegers()
        {
            var dividend = -2147483648;
            var divisor = 1;

            var isNegative = ((dividend ^ divisor) >> 31);
            var result = 0;
            if (dividend == int.MinValue && divisor == -1)
            {
                result = int.MaxValue;
            }


            double dividendLeft = Math.Abs((double)dividend);
            double divisorAbs = Math.Abs((double)divisor);
            while (dividendLeft - divisorAbs >= 0)
            {
                dividendLeft = dividendLeft - divisorAbs;
                result++;
            }

            if (isNegative == -1)
            {
                result = ~result + 1;
            }

        }
    }
}
