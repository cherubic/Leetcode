using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace SolutionUnitTest
{
    [TestClass]
    public class AlgorithmSortTest
    {
        private Sort sort;
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
            sort = new Sort();
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
        public void InsertSortTest()
        {
            var testCase1Result = sort.InsertSort(testCase1);
            Assert.IsTrue(Utility.IntArrayEqual(testCase1Expectation, testCase1Result), "InsertSort result error");

            var testCase2Result = sort.InsertSort(testCase2);
            Assert.IsTrue(Utility.IntArrayEqual(testCase2Expectation, testCase2Result), "InsertSort result error");

            var testCase3Result = sort.InsertSort(testCase3);
            Assert.IsTrue(Utility.IntArrayEqual(testCase3Expectation, testCase3Result), "InsertSort result error");

            var testCase4Result = sort.InsertSort(testCase4);
            Assert.IsTrue(Utility.IntArrayEqual(testCase4Expectation, testCase4Result), "InsertSort result error");

            var testCase5Result = sort.InsertSort(testCase5);
            Assert.IsTrue(Utility.IntArrayEqual(testCase5Expectation, testCase5Result), "InsertSort result error");

            var testCase6Result = sort.InsertSort(testCase6);
            Assert.IsTrue(Utility.IntArrayEqual(testCase6Expectation, testCase6Result), "InsertSort result error");

            var testCase7Result = sort.InsertSort(testCase7);
            Assert.IsTrue(Utility.IntArrayEqual(testCase7Expectation, testCase7Result), "InsertSort result error");

            var testCase8Result = sort.InsertSort(testCase8);
            Assert.IsTrue(Utility.IntArrayEqual(testCase8Expectation, testCase8Result), "InsertSort result error");
        }

        [TestMethod]
        public void MergeSortTest()
        {
            var testCase1Result = sort.MergeSort(testCase1);
            Assert.IsTrue(Utility.IntArrayEqual(testCase1Expectation, testCase1Result), "MergeSort result error");

            var testCase2Result = sort.MergeSort(testCase2);
            Assert.IsTrue(Utility.IntArrayEqual(testCase2Expectation, testCase2Result), "MergeSort result error");

            var testCase3Result = sort.MergeSort(testCase3);
            Assert.IsTrue(Utility.IntArrayEqual(testCase3Expectation, testCase3Result), "MergeSort result error");

            var testCase4Result = sort.MergeSort(testCase4);
            Assert.IsTrue(Utility.IntArrayEqual(testCase4Expectation, testCase4Result), "MergeSort result error");

            var testCase5Result = sort.MergeSort(testCase5);
            Assert.IsTrue(Utility.IntArrayEqual(testCase5Expectation, testCase5Result), "MergeSort result error");

            var testCase6Result = sort.MergeSort(testCase6);
            Assert.IsTrue(Utility.IntArrayEqual(testCase6Expectation, testCase6Result), "MergeSort result error");

            var testCase7Result = sort.MergeSort(testCase7);
            Assert.IsTrue(Utility.IntArrayEqual(testCase7Expectation, testCase7Result), "MergeSort result error");

            var testCase8Result = sort.MergeSort(testCase8);
            Assert.IsTrue(Utility.IntArrayEqual(testCase8Expectation, testCase8Result), "MergeSort result error");
        }

        [TestMethod]
        public void BubbleSortTest()
        {
            var testCase1Result = sort.BubbleSort(testCase1);
            Assert.IsTrue(Utility.IntArrayEqual(testCase1Expectation, testCase1Result), "BubbleSort result error");

            var testCase2Result = sort.BubbleSort(testCase2);
            Assert.IsTrue(Utility.IntArrayEqual(testCase2Expectation, testCase2Result), "BubbleSort result error");

            var testCase3Result = sort.BubbleSort(testCase3);
            Assert.IsTrue(Utility.IntArrayEqual(testCase3Expectation, testCase3Result), "BubbleSort result error");

            var testCase4Result = sort.BubbleSort(testCase4);
            Assert.IsTrue(Utility.IntArrayEqual(testCase4Expectation, testCase4Result), "BubbleSort result error");

            var testCase5Result = sort.BubbleSort(testCase5);
            Assert.IsTrue(Utility.IntArrayEqual(testCase5Expectation, testCase5Result), "BubbleSort result error");

            var testCase6Result = sort.BubbleSort(testCase6);
            Assert.IsTrue(Utility.IntArrayEqual(testCase6Expectation, testCase6Result), "BubbleSort result error");

            var testCase7Result = sort.BubbleSort(testCase7);
            Assert.IsTrue(Utility.IntArrayEqual(testCase7Expectation, testCase7Result), "BubbleSort result error");

            var testCase8Result = sort.BubbleSort(testCase8);
            Assert.IsTrue(Utility.IntArrayEqual(testCase8Expectation, testCase8Result), "BubbleSort result error");
        }

        [TestMethod]
        public void HeapSortTest()
        {
            var heapArray1 = sort.BuildMaxHeap(testCase1);
            var testCase1Result = sort.HeapSort(heapArray1);
            Assert.IsTrue(Utility.IntArrayEqual(testCase1Expectation, testCase1Result), "HeapSort result error");

            var heapArray2 = sort.BuildMaxHeap(testCase2);
            var testCase2Result = sort.HeapSort(heapArray2);
            Assert.IsTrue(Utility.IntArrayEqual(testCase2Expectation, testCase2Result), "HeapSort result error");

            var heapArray3 = sort.BuildMaxHeap(testCase3);
            var testCase3Result = sort.HeapSort(heapArray3);
            Assert.IsTrue(Utility.IntArrayEqual(testCase3Expectation, testCase3Result), "HeapSort result error");

            var heapArray4 = sort.BuildMaxHeap(testCase4);
            var testCase4Result = sort.HeapSort(heapArray4);
            Assert.IsTrue(Utility.IntArrayEqual(testCase4Expectation, testCase4Result), "HeapSort result error");

            var heapArray5 = sort.BuildMaxHeap(testCase5);
            var testCase5Result = sort.HeapSort(heapArray5);
            Assert.IsTrue(Utility.IntArrayEqual(testCase5Expectation, testCase5Result), "HeapSort result error");

            var heapArray6 = sort.BuildMaxHeap(testCase6);
            var testCase6Result = sort.HeapSort(heapArray6);
            Assert.IsTrue(Utility.IntArrayEqual(testCase6Expectation, testCase6Result), "HeapSort result error");

            var heapArray7 = sort.BuildMaxHeap(testCase7);
            var testCase7Result = sort.HeapSort(heapArray7);
            Assert.IsTrue(Utility.IntArrayEqual(testCase7Expectation, testCase7Result), "HeapSort result error");

            var heapArray8 = sort.BuildMaxHeap(testCase8);
            var testCase8Result = sort.HeapSort(heapArray8);
            Assert.IsTrue(Utility.IntArrayEqual(testCase8Expectation, testCase8Result), "HeapSort result error");
        }
    }
}
