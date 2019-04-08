using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LinkedListProblem
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        #region Merge Two Sorted Lists

        /*
         *
         * https://leetcode.com/problems/merge-two-sorted-lists/
         * Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
         * Example:
         * Input: 1->2->4, 1->3->4
         * Output: 1->1->2->3->4->4
         * 
         */

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode topLink = null;
            ListNode nextLink = null;

            while (l1 != null || l2 != null)
            {

                if (l1 == null && l2 != null)
                {
                    if (topLink == null)
                    {
                        topLink = new ListNode(l2.val);
                        nextLink = topLink;
                    }
                    else
                    {
                        nextLink.next = new ListNode(l2.val);
                        nextLink = nextLink.next;
                    }

                    l2 = l2.next;
                }
                else if (l2 == null && l1 != null)
                {
                    if (topLink == null)
                    {
                        topLink = new ListNode(l1.val);
                        nextLink = topLink;
                    }
                    else
                    {
                        nextLink.next = new ListNode(l1.val);
                        nextLink = nextLink.next;
                    }

                    l1 = l1.next;
                }
                else
                {
                    if (l1.val > l2.val)
                    {
                        if (topLink == null)
                        {
                            topLink = new ListNode(l2.val);
                            nextLink = topLink;
                        }
                        else
                        {
                            nextLink.next = new ListNode(l2.val);
                            nextLink = nextLink.next;
                        }

                        l2 = l2.next;
                    }
                    else
                    {
                        if (topLink == null)
                        {
                            topLink = new ListNode(l1.val);
                            nextLink = topLink;
                        }
                        else
                        {
                            nextLink.next = new ListNode(l1.val);
                            nextLink = nextLink.next;
                        }

                        l1 = l1.next;
                    }
                }
            }

            return topLink;
        }

        #endregion

        #region Add Two Numbers

        /*
         * 
         * https://leetcode.com/problems/add-two-numbers/
         * You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
         * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
         * Example:
         * Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
         * Output: 7 -> 0 -> 8
         * Explanation: 342 + 465 = 807.
         * 
         */

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode headLink = null;
            ListNode nextLink = null;
            int nextValue = 0;
            while (l1 != null || l2 != null)
            {
                if (l1 == null && l2 != null)
                {
                    var value = 0 + l2.val + nextValue;
                    nextValue = value / 10;

                    if (headLink == null)
                    {
                        headLink = new ListNode(value % 10);
                        nextLink = headLink;
                    }
                    else
                    {
                        nextLink.next = new ListNode(value % 10);
                        nextLink = nextLink.next;
                    }

                    l2 = l2.next;
                }
                else if (l2 == null && l1 != null)
                {
                    var value = l1.val + 0 + nextValue;
                    nextValue = value / 10;

                    if (headLink == null)
                    {
                        headLink = new ListNode(value % 10);
                        nextLink = headLink;
                    }
                    else
                    {
                        nextLink.next = new ListNode(value % 10);
                        nextLink = nextLink.next;
                    }

                    l1 = l1.next;
                }
                else
                {
                    var value = l1.val + l2.val + nextValue;
                    nextValue = value / 10;

                    if (headLink == null)
                    {
                        headLink = new ListNode(value % 10);
                        nextLink = headLink;
                    }
                    else
                    {
                        nextLink.next = new ListNode(value % 10);
                        nextLink = nextLink.next;
                    }

                    l1 = l1.next;
                    l2 = l2.next;
                }
            }


            if (nextValue > 0)
            {
                nextLink.next = new ListNode(nextValue);
            }

            return headLink;
        }

        #endregion

        #region Remove Nth Node From End of List

        /*
         * 
         * https://leetcode.com/problems/remove-nth-node-from-end-of-list/
         * Given a linked list, remove the n-th node from the end of list and return its head.
         * 
         * Example:
         * Given linked list: 1->2->3->4->5, and n = 2.
         * After removing the second node from the end, the linked list becomes 1->2->3->5.
         * 
         * Note:
         * Given n will always be valid.
         * 
         * Follow up:
         * Could you do this in one pass?
         * 
         */

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            Dictionary<int, ListNode> indexOfNode = new Dictionary<int, ListNode>();
            int index = 0;
            ListNode nextNode = null;
            nextNode = head;

            while (nextNode != null)
            {
                indexOfNode.Add(index, nextNode);
                nextNode = nextNode.next;
                index++;
            }

            var length = indexOfNode.Count();
            if (n < 1 || n > length)
            {
                throw new Exception("");
            }

            if (n == length && n == 1)
            {
                head = null;
            }
            else if (n == length)
            {
                head = indexOfNode[0].next;
            }
            else if (n == 1)
            {
                indexOfNode[length - n - 1].next = null;
            }
            else
            {
                indexOfNode[length - n - 1].next = indexOfNode[length - n + 1];
            }

            return head;
        }

        #endregion

        #region Remove Duplicates from Sorted List

        /*
         * 
         * https://leetcode.com/problems/remove-duplicates-from-sorted-list/
         * Given a sorted linked list, delete all duplicates such that each element appear only once.
         * 
         * Example 1:
         * Input: 1->1->2
         * Output: 1->2
         * 
         * Example 2:
         * Input: 1->1->2->3->3
         * Output: 1->2->3
         * 
         */

        public ListNode DeleteDuplicates(ListNode head)
        {

            if (head == null) return head;
            ListNode fastNode = head.next;
            ListNode slowNode = head;

            while (fastNode != null)
            {
                if (slowNode.val == fastNode.val)
                {
                    slowNode.next = fastNode.next;
                    fastNode = fastNode.next;
                }
                else
                {
                    fastNode = fastNode.next;
                    slowNode = slowNode.next;
                }
            }

            return head;
        }

        #endregion

        #region Merge k Sorted Lists

        /*
         * 
         * https://leetcode.com/problems/merge-k-sorted-lists/
         * Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
         * Example:
         * Input:
         * [
         * 1->4->5,
         * 1->3->4,
         * 2->6
         * ]
         * 
         * Output: 1->1->2->3->4->4->5->6
         * 
         */

        public ListNode MergeKLists(ListNode[] lists)
        {
            Dictionary<int, int> linkValueDic = new Dictionary<int, int>();

            for (var i = 0; i < lists.Length; i++)
            {
                ListNode tempNode = lists[i];

                while (tempNode != null)
                {
                    if (linkValueDic.ContainsKey(tempNode.val))
                    {
                        linkValueDic[tempNode.val]++;
                    }
                    else
                    {
                        linkValueDic.Add(tempNode.val, 1);
                    }

                    tempNode = tempNode.next;
                }
            }

            ListNode result = null;
            ListNode nextNode = null;
            for (var i = 0; i < linkValueDic.Count(); i++)
            {
                var tempDic = linkValueDic.OrderBy(x => x.Key).ToList();
                for (var j = 0; j < tempDic[i].Value; j++)
                {
                    if (result == null)
                    {
                        result = new ListNode(tempDic[i].Key);
                        nextNode = result;
                    }
                    else
                    {
                        nextNode.next = new ListNode(tempDic[i].Key);
                        nextNode = nextNode.next;
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
