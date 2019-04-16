using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode;

namespace SolutionUnitTest
{
    [TestClass]
    public class LeetcodeDynamicProgramming
    {
        [TestMethod]
        public void RegularExpressionMatchingIsMatchTest()
        {
            new DynamicProgramming().RegularExpressionMatchingIsMatch("ab",".*c");
        }
    }
}
