using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    [TestClass]
    public class TwoPointer
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        #region 3Sum Closest

        [TestMethod]
        public void ThreeSumClosest()
        {
            int[] nums = new int[] { -1, 2, 1, -4 };
            int target = -1;
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
                        result = sum;
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
        }

        #endregion

        #region Remove Element

        [TestMethod]
        public void RemoveElement()
        {
            var nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            int val = 2;


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

            result = 1 + lastLength;
        }

        #endregion

        #region  Implement strStr()

        public void ImplementstrStr()
        {
            string haystack = "hello";
            string needle = "ll";
            var result = 0;

            if (string.IsNullOrEmpty(haystack)) result = -1;

            for (var i = 0; i < haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    result = i;
                }
            }

            result = -1;
        }

        #endregion

        #region Rotate List

        [TestMethod]
        public void RotateRight()
        {
            ListNode head = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(5) } } } };
            int k = 2;

            ListNode result;
            if (head.next == null) result = head;
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

            result = head;
        }

        #endregion
    }
}
