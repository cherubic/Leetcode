using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Practice_2
    {
        /// <summary>
        /// 重写过程INSERTION-SORT，使之按非升序排序
        /// </summary>
        /// <param name="numbs"></param>
        /// <returns>按降序排列好的数组</returns>
        public int[] Problem_2_1(int[] numbs)
        {
            for (var i = 1; i < numbs.Length; i++)
            {
                var j = i;
                while (j >= 1 && numbs[j] > numbs[j - 1])
                {
                    numbs[j] ^= numbs[j - 1];
                    numbs[j - 1] ^= numbs[j];
                    numbs[j] ^= numbs[j - 1];
                    j--;
                }
            }

            return numbs;
        }

        /// <summary>
        /// 重写过程MERGE，使之不使用哨兵，而是一旦数组L或R的所有元素均被复制回A就立刻停止，然后把另一个数组的剩余部分复制回A
        /// </summary>
        public int[] Problem_3_2(int[] numbs)
        {
            if (numbs == null || numbs.Length == 0) return numbs;
            return MergeSort(numbs, 0, numbs.Length - 1);
        }

        private int[] MergeSort(int[] numbs, int start, int end)
        {
            if (start < end)
            {
                var mid = (start + end) / 2;
                var left = MergeSort(numbs, start, mid);
                var right = MergeSort(numbs, mid + 1, end);
                return Merge(left, right);
            }
            else
            {
                return new int[] { numbs[start] };
            }
        }

        private int[] Merge(int[] left, int[] right)
        {
            var result = new int[left.Length + right.Length];
            var leftIndex = 0;
            var rightIndex = 0;
            var resultIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex++;
                }

                resultIndex++;
            }

            if (left.Length == leftIndex)
            {
                while (rightIndex < right.Length)
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex++;
                    resultIndex++;
                }
            }

            if (rightIndex == right.Length)
            {
                while (leftIndex < left.Length)
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex++;
                    resultIndex++;
                }
            }

            return result;
        }

        public void Problem_3_5()
        {

        }

        public void Problem_3_6()
        {

        }

        /*
         * 找出数组中逆序对的数量
         * 
         * COUNT-INVERSIONS(A, p, r)
         *     inversion = 0
         *     if p < r
         *         q = floor((p + r) / )
         *         inversions = inversions + COUNT-INVERSIONS(A, p, q)
         *         inversions = inversions + COUNT-INVERSIONS(A, q + 1, r)
         *         inversions = inversions + MERGE-INVERSIONS(A, p, q, r)
         *     return inversions
         *     
         * MERGE-INVERSIONS(A, p, q, r)
         *     n[1] = q - p + 1;
         *     n[2] = r - q
         *     let L[1..n[1] + 1] and R[1..n[2] + 1] be new arrays
         *     for i = 1 to n[2]
         *         L[i] = A[p + i - 1]
         *     for j = 1 to n[2]
         *         R[j] = A[q + j]
         *     L[n[1] + 1] = limitation
         *     L[n[2] + 1] = limitation
         *     i = 1
         *     j = 1
         *     inversions = 0
         *     for k = p to r
         *         if R[j] < L[i]
         *             inversions = inversions + n[1] - i + 1
         *             A[k] = R[j]
         *             j = j + 1
         *         else A[k] = L[i]
         *             i = i + 1
         *     return inversions
         */
        public int Thinking_2_4(int[] numbs)
        {
            return CountInversions(numbs, 0, numbs.Length - 1);
        }

        private int CountInversions(int[] numbs, int start, int end)
        {
            var inversions = 0;
            if (start < end)
            {
                var mid = (start + end) / 2;
                inversions = inversions + CountInversions(numbs, start, mid);
                inversions = inversions + CountInversions(numbs, mid + 1, end);
                inversions = inversions + MergeInversions(numbs, mid, start, end);
            }

            return inversions;
        }

        private int MergeInversions(int[] numbs, int mid, int start, int end)
        {
            var leftArray = new int[mid - start + 2];
            var rightArray = new int[end - mid + 1];

            for (var i = 0; i < mid - start + 2; i++)
            {
                if (i == mid - start + 1)
                {
                    leftArray[i] = int.MaxValue;
                }
                else
                {
                    leftArray[i] = numbs[start + i];
                }
            }

            for (var i = 0; i < end - mid + 1; i++)
            {
                if (i == end - mid)
                {
                    rightArray[i] = int.MaxValue;
                }
                else
                {
                    rightArray[i] = numbs[mid + i + 1];
                }
            }

            var leftIndex = 0;
            var rightIndex = 0;
            var inversions = 0;
            for (var i = 0; i <= end - start; i++)
            {
                if (rightArray[rightIndex] < leftArray[leftIndex])
                {
                    inversions = inversions + leftArray.Length - i + 1;
                    numbs[start + i] = rightArray[rightIndex];
                    rightIndex++;
                }
                else
                {
                    numbs[start + i] = leftArray[leftIndex];
                    leftIndex++;
                }
            }

            return inversions;
        }
    }
}
