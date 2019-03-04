using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    [TestClass]
    public class LinkedListTest
    {

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode pre;
            public ListNode(int x) { val = x; }
        }


        #region Merge Two Sorted Lists

        [TestMethod]
        public void MergeTwoSortedLists()
        {
            var l1 = new ListNode(1) { next = new ListNode(2) { next = new ListNode(4) } };
            var l2 = new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } };

            var oneTemp = l1;
            var twoTemp = l2;
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
        }

        [TestMethod]
        public void MergeTwoSortedLists_2()
        {
            var l1 = new ListNode(1) { next = new ListNode(2) { next = new ListNode(4) } };
            var l2 = new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } };


        }

        #endregion

        #region Add Two Numbers

        public void AddTwoNumbers()
        {
            var l1 = new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } };
            var l2 = new ListNode(5) { next = new ListNode(6) { next = new ListNode(4) } };

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

        }

        #endregion

        #region Remove Nth Node From End of List

        [TestMethod]
        public void RemoveNthNodeFromEndofList()
        {
            var head = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(5) } } } };
            var n = 2;

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
        }

        [TestMethod]
        public void RemoveNthNodeFromEndofList_2()
        {
            //One fast One slow
        }

        #endregion

        #region Remove Duplicates from Sorted List

        public void RemoveDuplicatesfromSortedList()
        {
            var head = new ListNode(1) { next = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(3) } } } };

            ListNode fastNode = head.next;
            ListNode slowNode = head;
            if (head == null)
            {
            }

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
        }

        #endregion

        #region Merge k Sorted Lists

        [TestMethod]
        public void MergekSortedLists()
        {
            ListNode[] lists = new ListNode[] { new ListNode(1) { next = new ListNode(4) { next = new ListNode(5) } } ,
            new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } },
            new ListNode(2) { next = new ListNode(6)}};

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
        }

        //Merge sort
        [TestMethod]
        public void MergekSortedLists_2()
        {

        }

        #endregion

        #region Singly Linked List Operation

        public void AddToIndex()
        {
        }

        public void DeleteByIndex()
        {
        }

        #endregion

        #region Doubly Linked List


        #endregion

        #region Multiply Linked List
        #endregion

        #region Circular Linked List
        #endregion
    }
}
