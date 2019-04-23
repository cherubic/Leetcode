using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode;

namespace SolutionUnitTest
{
    [TestClass]
    public class LeetcodeStackTest
    {
        [TestMethod]
        public void SimplifyPathTest()
        {
            var stack = new StackProblem();
            stack.SimplifyPath("/home//foo/");
        }

        [TestMethod]
        public void ValidParenthesesTest()
        {
            var stack = new StackProblem();
            stack.ValidParentheses("/home//foo/");
        }

        [TestMethod]
        public void LargestRectangleAreaStackTest()
        {
            var stack = new StackProblem();
            stack.LargestRectangleAreaStack(new int[] { 2, 1, 5, 6, 2, 3 });
        }

        [TestMethod]
        public void LargestRectangleAreaDynamicProgrammingTest()
        {
            
        }

        [TestMethod]
        public void MaximalRectangleStackTest()
        {
            var stack = new StackProblem();
            var input = new char[][]
            {
                new char[] {'1', '0', '1', '0', '0'},
                new char[] {'1', '0', '1', '1', '1'},
                new char[] {'1', '1', '1', '1', '1'},
                new char[] {'1', '0', '0', '1', '0'}
            };

            stack.MaximalRectangleStack(input);
        }

        [TestMethod]
        public void MaximalRectangleDynamicProgrammingTest()
        {

        }
    }
}
