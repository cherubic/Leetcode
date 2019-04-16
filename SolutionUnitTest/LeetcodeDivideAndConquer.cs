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

        [TestMethod]
        public void SearchMatrixTest()
        {
            var matrix = new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
            new DivideAndConquer().SearchMatrix2(matrix, 5);
        }
    }
}
