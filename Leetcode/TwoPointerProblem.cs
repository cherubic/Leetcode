using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class TwoPointerProblem
    {
        #region 3Sum Closest

        /*
         * 
         * https://leetcode.com/problems/3sum-closest/
         * Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target. Return the sum of the three integers. You may assume that each input would have exactly one solution.
         * Example:
         * Given array nums = [-1, 2, 1, -4], and target = 1.
         * The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
         * 
         */

        public int ThreeSumClosest(int[] nums, int target)
        {
            int? result = null;

            nums = nums.OrderBy(x => x).ToArray();
            for (var i = 0; i < nums.Length - 2; i++)
            {
                var j = i + 1;
                var end = 1;
                while (j < nums.Length - end)
                {
                    var sum = nums[i] + nums[j] + nums[nums.Length - end];
                    if (result != null)
                    {
                        result = Math.Abs(target - (int)result) < Math.Abs(target - sum) ? result : sum;
                    }
                    else
                    {
                        result = sum;
                    }

                    if (sum == target)
                    {
                        return sum;
                    }
                    else if (sum < target)
                    {
                        j++;
                    }
                    else
                    {
                        end++;
                    }
                }
            }

            return (int)result;
        }

        #endregion

        #region Remove Element

        /*
         * 
         * https://leetcode.com/problems/remove-element/
         * Given an array nums and a value val, remove all instances of that value in-place and return the new length.
         * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
         * The order of elements can be changed. It doesn't matter what you leave beyond the new length.
         * 
         * Example 1:
         * Given nums = [3,2,2,3], val = 3,
         * Your function should return length = 2, with the first two elements of nums being 2.
         * It doesn't matter what you leave beyond the returned length.
         * 
         * Example 2:
         * Given nums = [0,1,2,2,3,0,4,2], val = 2,
         * Your function should return length = 5, with the first five elements of nums containing 0, 1, 3, 0, and 4.
         * Note that the order of those five elements can be arbitrary.
         * It doesn't matter what values are set beyond the returned length.
         * Clarification:
         * Confused why the returned value is an integer but your answer is an array?
         * Note that the input array is passed in by reference, which means modification to the input array will be known to the caller as well.
         * Internally you can think of this:
         * // nums is passed in by reference. (i.e., without making a copy)
         * int len = removeElement(nums, val);
         * // any modification to nums in your function would be known by the caller.
         * // using the length returned by your function, it prints the first len elements.
         * for (int i = 0; i < len; i++) {
         *  print(nums[i]);
         * }
         * 
         */

        public int RemoveElement(int[] nums, int val)
        {
            var result = 0;
            int temp = 0;
            var lastLength = nums.Length - 1;
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == val)
                {
                    temp = nums[i];

                    for (var j = i; j < lastLength; j++)
                    {
                        nums[j] = nums[j + 1];
                    }

                    nums[lastLength] = temp;

                    lastLength--;
                }
            }

            return result = 1 + lastLength; ;
        }

        #endregion

        #region  Implement strStr()

        /*
         * 
         * https://leetcode.com/problems/implement-strstr/
         * Implement strStr().
         * Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
         * 
         * Example 1:
         * Input: haystack = "hello", needle = "ll"
         * Output: 2
         * 
         * Example 2:
         * Input: haystack = "aaaaa", needle = "bba"
         * Output: -1
         * Clarification:
         * 
         * What should we return when needle is an empty string? This is a great question to ask during an interview.
         * For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().
         * 
         */

        public int StrStr(string haystack, string needle)
        {
            for (var i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion

        #region Rotate List

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        /*
         * 
         * https://leetcode.com/problems/rotate-list/
         * Given a linked list, rotate the list to the right by k places, where k is non-negative.
         * 
         * Example 1:
         * Input: 1->2->3->4->5->NULL, k = 2
         * Output: 4->5->1->2->3->NULL
         * Explanation:
         * rotate 1 steps to the right: 5->1->2->3->4->NULL
         * rotate 2 steps to the right: 4->5->1->2->3->NULL
         * 
         * Example 2:
         * Input: 0->1->2->NULL, k = 4
         * Output: 2->0->1->NULL
         * Explanation:
         * rotate 1 steps to the right: 2->0->1->NULL
         * rotate 2 steps to the right: 1->2->0->NULL
         * rotate 3 steps to the right: 0->1->2->NULL
         * rotate 4 steps to the right: 2->0->1->NULL
         * 
         */

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;
            ListNode nextNode = head;
            int linkLength = 0;
            while (nextNode != null)
            {
                nextNode = nextNode.next;
                linkLength++;
            }

            var changeCount = k % linkLength;
            for (var i = 0; i < changeCount; i++)
            {
                nextNode = head;
                ListNode tempNode;

                while (true)
                {
                    if (nextNode.next.next == null)
                    {
                        tempNode = head;
                        nextNode.next.next = tempNode;
                        head = nextNode.next;
                        nextNode.next = null;
                        break;
                    }

                    nextNode = nextNode.next;

                }
            }

            return head;
        }

        #endregion

        #region Minimum Window Substring
        #endregion
    }
}
