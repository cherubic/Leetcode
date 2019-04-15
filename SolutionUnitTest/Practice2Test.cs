using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace SolutionUnitTest
{
    [TestClass]
    public class Practice2Test
    {
        private Practice_2 practiceObj;
        private int[] testCase1;
        private int[] testCase1Expectation;
        private int[] testCase2;
        private int[] testCase2Expectation;
        private int[] testCase3;
        private int[] testCase3Expectation;
        private int[] testCase4;
        private int[] testCase4Expectation;
        private int[] testCase5;
        private int[] testCase5Expectation;
        private int[] testCase6;
        private int[] testCase6Expectation;
        private int[] testCase7;
        private int[] testCase7Expectation;
        private int[] testCase8;
        private int[] testCase8Expectation;

        [TestInitialize]
        public void Initialize()
        {
            practiceObj = new Practice_2();
            testCase1 = new int[] { };
            testCase1Expectation = new int[] { };
            testCase2 = new int[] { 1, 5, 9, 7, 5, 3, 89, 87, 79, 56, 54, 46, 23, 12, 31, 96, 63, 58, 74, 14, 52, 36 };
            testCase2Expectation = testCase2.OrderBy(x => x).ToArray();
            testCase3 = new int[] { int.MaxValue, int.MinValue };
            testCase3Expectation = testCase3.OrderBy(x => x).ToArray();
            testCase4 = new int[] { int.MaxValue, int.MaxValue };
            testCase4Expectation = testCase4.OrderBy(x => x).ToArray();
            testCase5 = new int[] { int.MinValue, int.MinValue };
            testCase5Expectation = testCase5.OrderBy(x => x).ToArray();
            testCase6 = new int[] { int.MaxValue, 5, int.MaxValue };
            testCase6Expectation = testCase6.OrderBy(x => x).ToArray();
            testCase7 = new int[] { int.MinValue, 5, int.MinValue };
            testCase7Expectation = testCase7.OrderBy(x => x).ToArray();
            testCase8 = Utility.IntArrayGenerate();
            testCase8Expectation = testCase8.OrderBy(x => x).ToArray();
        }

        [TestMethod]
        public void Problem_2_1Test()
        {
            testCase1Expectation = testCase1.OrderByDescending(x => x).ToArray();
            var testCase1Result = practiceObj.Problem_2_1(testCase1);
            Assert.IsTrue(Utility.IntArrayEqual(testCase1Expectation, testCase1Result), "InsertSort result error");

            testCase2Expectation = testCase2.OrderByDescending(x => x).ToArray();
            var testCase2Result = practiceObj.Problem_2_1(testCase2);
            Assert.IsTrue(Utility.IntArrayEqual(testCase2Expectation, testCase2Result), "InsertSort result error");

            testCase3Expectation = testCase3.OrderByDescending(x => x).ToArray();
            var testCase3Result = practiceObj.Problem_2_1(testCase3);
            Assert.IsTrue(Utility.IntArrayEqual(testCase3Expectation, testCase3Result), "InsertSort result error");

            testCase4Expectation = testCase4.OrderByDescending(x => x).ToArray();
            var testCase4Result = practiceObj.Problem_2_1(testCase4);
            Assert.IsTrue(Utility.IntArrayEqual(testCase4Expectation, testCase4Result), "InsertSort result error");

            testCase5Expectation = testCase5.OrderByDescending(x => x).ToArray();
            var testCase5Result = practiceObj.Problem_2_1(testCase5);
            Assert.IsTrue(Utility.IntArrayEqual(testCase5Expectation, testCase5Result), "InsertSort result error");

            testCase6Expectation = testCase6.OrderByDescending(x => x).ToArray();
            var testCase6Result = practiceObj.Problem_2_1(testCase6);
            Assert.IsTrue(Utility.IntArrayEqual(testCase6Expectation, testCase6Result), "InsertSort result error");

            testCase7Expectation = testCase7.OrderByDescending(x => x).ToArray();
            var testCase7Result = practiceObj.Problem_2_1(testCase7);
            Assert.IsTrue(Utility.IntArrayEqual(testCase7Expectation, testCase7Result), "InsertSort result error");

            testCase8Expectation = testCase8.OrderByDescending(x => x).ToArray();
            var testCase8Result = practiceObj.Problem_2_1(testCase8);
            Assert.IsTrue(Utility.IntArrayEqual(testCase8Expectation, testCase8Result), "InsertSort result error");
        }

        [TestMethod]
        public void Problem_3_2Test()
        {
            var testCase1Result = practiceObj.Problem_3_2(testCase1);
            Assert.IsTrue(Utility.IntArrayEqual(testCase1Expectation, testCase1Result), "MergeSort result error");

            var testCase2Result = practiceObj.Problem_3_2(testCase2);
            Assert.IsTrue(Utility.IntArrayEqual(testCase2Expectation, testCase2Result), "MergeSort result error");

            var testCase3Result = practiceObj.Problem_3_2(testCase3);
            Assert.IsTrue(Utility.IntArrayEqual(testCase3Expectation, testCase3Result), "MergeSort result error");

            var testCase4Result = practiceObj.Problem_3_2(testCase4);
            Assert.IsTrue(Utility.IntArrayEqual(testCase4Expectation, testCase4Result), "MergeSort result error");

            var testCase5Result = practiceObj.Problem_3_2(testCase5);
            Assert.IsTrue(Utility.IntArrayEqual(testCase5Expectation, testCase5Result), "MergeSort result error");

            var testCase6Result = practiceObj.Problem_3_2(testCase6);
            Assert.IsTrue(Utility.IntArrayEqual(testCase6Expectation, testCase6Result), "MergeSort result error");

            var testCase7Result = practiceObj.Problem_3_2(testCase7);
            Assert.IsTrue(Utility.IntArrayEqual(testCase7Expectation, testCase7Result), "MergeSort result error");

            var testCase8Result = practiceObj.Problem_3_2(testCase8);
            Assert.IsTrue(Utility.IntArrayEqual(testCase8Expectation, testCase8Result), "MergeSort result error");
        }

        [TestMethod]
        public void Problem_3_6Test()
        {

        }

        [TestMethod]
        public void Thinking_2_4Test()
        {

        }
    }
}
