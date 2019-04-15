using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeautyOfProgramming;

namespace SolutionUnitTest
{
    /// <summary>
    /// Summary description for BeautyProblem1Test
    /// </summary>
    [TestClass]
    public class BeautyProblem1Test
    {
        [TestMethod]
        public void Approach1Test()
        {
            var problem1 = new Problem1();
            problem1.Approach1();
        }

        [TestMethod]
        public void Approach2Test()
        {
            var problem1 = new Problem1();
            problem1.Approach2();
        }

        [TestMethod]
        public void Approach3Test()
        {
            var problem1 = new Problem1();
            problem1.Approach3(50);
        }

        [TestMethod]
        public void Approach4Test()
        {
            var problem1 = new Problem1();
            problem1.Approach4();
        }
    }
}
