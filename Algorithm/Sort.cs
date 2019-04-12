using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Sort
    {
        #region Insert Sort

        /*
         * time complexity: O(n^2)
         * space complexity: O(1)
         * 
         * pseudo code:
         * 
         * INSERTION-SORT(A)
         * for i = 2 to array length
         *     j = i
         *     while j-1 >= 0 and array[j] < array[j-1]
         *         if array[j] < array[j-1]
         *             then switch array[j] and array[j-1]
         *             j = j-1;
         *         else
         *             then break;
         * 
         */

        public int[] InsertSort(int[] numbs)
        {
            for (var i = 2; i < numbs.Length; i++)
            {
                var j = i;
                while (j >= 1 && numbs[j] < numbs[j - 1])
                {
                    numbs[j] ^= numbs[j - 1];
                    numbs[j - 1] ^= numbs[j];
                    numbs[j] ^= numbs[j - 1];
                    j--;
                }
            }

            return numbs;
        }

        #endregion

        #region Merge Sort

        /*
         * time complexity: O(n * lg n)
         * space complexity: 
         * 
         * pseudo code:
         * 
         * MERGET(A, p, q, r)
         *     n1 = q - p + 1
         *     n2 = r - q
         *     let L[1..n1 + 1] and R[1..n2 + 1] be new arrays
         *     for i = 1 to n1
         *         L[i] = A[p + i - 1]
         *     for j = 1 to n2
         *         R[j] = A[q + j]
         *     L[n1 + 1] = limitation
         *     R[n2 + 1] = limitation
         *     i = 1;
         *     j = 1;
         *     for k = p to r
         *         if L[i] <= R[j]
         *             A[k] = L[i]
         *             i = i + 1
         *         else A[k] = R[j]
         *             j = j + 1
         *             
         * MERGET-SORT(A, p, r)
         *     if p < r
         *         q = (p + r) / 2
         *         MERGE-SORT(A, p, q)
         *         MERGE-SORT(A, q + 1, r)
         *         MERGE(A, p, q, r)
         */

        public int[] MergeSort(int[] numbs)
        {
            return MergeSort(numbs, 0, numbs.Length - 1);
        }

        private int[] MergeSort(int[] numbs, int start, int end)
        {
            if (start < end)
            {
                var mid = (start + end) / 2;
                MergeSort(numbs, start, mid);
                MergeSort(numbs, mid + 1, end);
                return Merge(numbs, mid, start, end);
            }
            else
            {
                return new int[] { numbs[start] };
            }
        }

        private int[] Merge(int[] numbs, int mid, int start, int end)
        {
            var result = new int[end - start + 1];
            var leftArray = new int[mid - start + 2];
            var rightArray = new int[end - mid + 1];
            for (var i = 0; i < mid - start + 2; i++)
            {
                if (mid - start + 1 == i)
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
                if (end - mid == i)
                {
                    rightArray[i] = int.MaxValue;
                }
                else
                {
                    rightArray[i] = numbs[mid + 1 + i];
                }
            }

            var leftIndex = 0;
            var rightIndex = 0;
            for (var i = 0; i < end - start + 1; i++)
            {
                if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    result[i] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    result[i] = rightArray[rightIndex];
                    rightIndex++;
                }
            }

            return result;
        }

        #endregion

        #region BUBBLESORT

        /*
         * 
         * time complexity: O(n^2)
         * space complexity:
         * 
         * pseudo code:
         * BUBBLESORT(A)
         *     for i = 1 to A.length - 1
         *         for j = A.length downto i + 1
         *         if A[j] < A[j - 1]
         *             exchange A[j] with A[j - 1]
         * 
         */

        public int[] BubbleSort(int[] numbs)
        {
            for (var i = 0; i < numbs.Length; i++)
            {
                for (var j = numbs.Length - 1; j > i; j--)
                {
                    if (numbs[j] < numbs[j - 1])
                    {
                        numbs[j] ^= numbs[j - 1];
                        numbs[j - 1] ^= numbs[j];
                        numbs[j] ^= numbs[j - 1];
                    }
                }
            }

            return numbs;
        }

        #endregion

        #region Heap sort

        /*
         * LEFT(i)
         *     return 2i;
         *     
         * RIGHT(i)
         *     return 2i+1;
         *     
         * PARENT(i)
         *     return floor(i/2);
         * 
         * MAX-HEAPIFY(A, i)
         *     l = LEFT(i)
         *     R = RIGHT(i)
         *     if l <= A.heap-size and A[l] > A[i]
         *         largest = l
         *     else largest = i
         *     if r <= A.heap-size and A[l] > A[largest]
         *         largest = r
         *     if largest != i
         *         exchange A[i] with A[largest]
         *         MAX-HEAPIF(A, largest)
         *         
         *         
         * BUILD-MAX-HEAP(A)
         *     A.heap-size = A.length
         *     for i = floor(A.length/2) downto 1
         *         MAX-HEAPIFY(A, i)
         *         
         * HEAPSORT(A)
         *     BUILD-MAX-HEAP(A)
         *     for i = A.length downto 2
         *         exchange A[1] with A[i]
         *         A.heap-size = A.heap-size - 1
         *         MAX-HEAPIFY(A, 1)
         *         
         */

        public int Parent(int i)
        {
            return 2 * i;
        }

        public int Left(int i)
        {
            return 2 * i + 1;
        }

        public int Right(int i)
        {
            return 2 * i + 2;
        }

        public int[] MaxHeapify(int[] numbs, int i)
        {
            var left = Left(i);
            var right = Right(i);
            var largest = int.MinValue;
            if (left <= numbs.Length && numbs[left] > numbs[i])
            {
                largest = left;
            }
            else
            {
                largest = i;
            }

            if (right <= numbs.Length && numbs[left] > numbs[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                numbs[i] ^= numbs[largest];
                numbs[largest] ^= numbs[i];
                numbs[i] ^= numbs[largest];
            }

            return MaxHeapify(numbs, largest);
        }

        public int[] BuildMaxHeap(int[] numbs)
        {
            for (var i = numbs.Length / 2; i >= 1; i--)
            {
                numbs = MaxHeapify(numbs, i);
            }
            return numbs;
        }

        public int[] HeapSort(int[] numbs)
        {
            var result = new List<int>();
            for (var i = numbs.Length - 1; i >= 0; i--)
            {
                result.Add(numbs[0]);
                numbs[0] ^= numbs[i];
                numbs[i] ^= numbs[0];
                numbs[0] ^= numbs[i];

                var temp = numbs.ToList();
                temp.RemoveAt(i);
                numbs = temp.ToArray();

                numbs = MaxHeapify(numbs, 0);
            }

            return result.ToArray();
        }

        #region Priority queue

        /*
         * HEAP-MAXIMUM(A)
         *     return A[1]
         *     
         * HEAP-EXTRACT-MAX(A)
         *     if A.heap-size < 1
         *         error "heap underflow"
         *     max = A[1]
         *     A[1] = A[A.heap-size]
         *     A.heap-size = A.heap-size - 1
         *     MAX=HEAPIFY(A, 1)
         *     return max
         *     
         * HEAP-INCREASE-KEY(A, i, key)
         *     if key < A[i]
         *         error "new key is smaller than current key"
         *     A[i] = key
         *     while i > 1 and A[PARENT(i) < A[i]
         *         exchange A[i] with A[PARENT(i)]
         *         i = PARENT(i)
         *         
         * MAX-HEAP-INSERT(A, key)
         *     A.heap-size = A.heap-size + 1
         *     A[A.heap-size] = -limitation
         *     HEAP-INCREASE-KEY(A, A.heap-size, key)
         *     
         */
        public int HeapMaximum(int[] numbs)
        {
            return numbs[0];
        }

        public int HeapExtractMax(int[] numbs)
        {
            if (numbs.Length < 1)
            {
                throw new Exception("Heap Underflow");
            }

            var max = numbs[0];
            numbs[0] = numbs[numbs.Length - 1];
            numbs = MaxHeapify(numbs, 0);
            return max;
        }

        public int[] HeapIncreaseKey(int[] numbs, int i, int key)
        {
            if (key < numbs[i])
            {
                throw new Exception("New key is smaller than current key");
            }

            numbs[i] = key;
            while (i > 0 && numbs[Parent(i)] < numbs[i])
            {
                numbs[i] ^= numbs[Parent(i)];
                numbs[Parent(i)] ^= numbs[i];
                numbs[i] ^= numbs[Parent(i)];

                i = Parent(i);
            }

            return numbs;
        }

        public int[] MaxHeapInsert(int[] numbs, int key)
        {
            var result = new int[numbs.Length + 1];
            result[numbs.Length] = int.MinValue;
            for (var i = 0; i < numbs.Length; i++)
            {
                result[i] = numbs[i];
            }

            return HeapIncreaseKey(result, result.Length, key);
        }

        #endregion

        #endregion

        #region Quick Sort

        /*
         * 
         * 
         */
        public int[] QuickSort()
        {
            var result = new int[] { };
            return result;
        }

        #endregion
    }
}
