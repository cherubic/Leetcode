using System;
using Leetcode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolutionUnitTest
{
    [TestClass]
    public class LeetcodeDivideAndConquer
    {
        [TestMethod]
        public void FindKthLargestTest()
        {
            new DivideAndConquer().FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6, 7, 7, 8, 2, 3, 1, 1, 1, 10, 11, 5, 6, 2, 4, 7, 8, 5, 6 }, 20);
        }
    }
}
