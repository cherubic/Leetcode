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
    }
}
