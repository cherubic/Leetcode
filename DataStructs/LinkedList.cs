using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStruct
{
    public class LinkedList
    {
        #region Singly LinkedList

        public class SinglyLinkedListNode
        {
            public object Val;
            public SinglyLinkedListNode NextNode;
        }

        public class SinglyLinkedList
        {
            public int length;
            public SinglyLinkedListNode head;
        }

        public SinglyLinkedList SingleInit()
        {
            return new SinglyLinkedList() { head = new SinglyLinkedListNode() { Val = null, NextNode = null }, length = 0 };
        }

        public SinglyLinkedList AppendSinglyNode(SinglyLinkedList linkedList, object val)
        {
            var nextNode = linkedList.head;

            while (nextNode != null)
            {
                nextNode = nextNode.NextNode;
            }

            nextNode = new SinglyLinkedListNode() { Val = val, NextNode = null };
            linkedList.length++;

            return linkedList;
        }

        public SinglyLinkedList PrependSinglyNode(SinglyLinkedList linkedList, object val)
        {
            linkedList.head.NextNode = new SinglyLinkedListNode() { Val = val, NextNode = linkedList.head.NextNode };
            linkedList.length++;
            return linkedList;
        }

        public SinglyLinkedList AddIndexSinglyNode(SinglyLinkedList linkedList, object val, int index)
        {
            if (index < 0) throw new Exception("Not Support Negative");
            if (index > linkedList.length) throw new Exception("Not Support Negative");

            var nextNode = linkedList.head.NextNode;
            var length = 0;
            while (nextNode != null)
            {
                if (length == index)
                {
                    nextNode = new SinglyLinkedListNode() { Val = val, NextNode = nextNode };
                    linkedList.length++;
                    return linkedList;
                }

                nextNode = nextNode.NextNode;
                length++;
            }

            if (length == index)
            {
                nextNode = new SinglyLinkedListNode() { Val = val, NextNode = null };
                linkedList.length++;
                return linkedList;
            }

            throw new Exception("Linked List Length is Not Enough");
        }

        public SinglyLinkedList DeleteIndexSinglyNode(SinglyLinkedList linkedList, int index)
        {
            if (index < 0) throw new Exception("Not Support Negative");
            if (index >= linkedList.length) throw new Exception("Not Support Negative");

            var nextNode = linkedList.head.NextNode;
            var helperNode = linkedList.head;
            var length = 0;
            while (nextNode != null)
            {
                if (length == index)
                {
                    helperNode.NextNode = nextNode.NextNode;
                    linkedList.length--;
                    return linkedList;
                }

                helperNode = helperNode.NextNode;
                nextNode = nextNode.NextNode;
                length++;
            }

            throw new Exception("Linked List Length is Not Enough");
        }

        public SinglyLinkedListNode SearchNode(SinglyLinkedList linkedList, object val)
        {
            var nextNode = linkedList.head.NextNode;

            while (nextNode != null)
            {
                if (nextNode.Val == val) return nextNode;
                nextNode = nextNode.NextNode;
            }

            throw new Exception("Can not find.");
        }

        #endregion


        #region Doubly Linked List

        public class DoublyLinkedNode
        {
            public DoublyLinkedNode PreNode;
            public DoublyLinkedNode NextNode;
            public object Val;
        }

        public class DoublyLinkedList
        {
            public DoublyLinkedNode Head;
            public int length;
        }

        public DoublyLinkedList InitDoublyLinkedList()
        {
            var head = new DoublyLinkedNode() { Val = null };
            head.NextNode = null;
            head.PreNode = head;

            return new DoublyLinkedList() { Head = head, length = 0 };
        }

        public DoublyLinkedList AppendDoublyLinkedList(DoublyLinkedList doublyLinkedList, object val)
        {
            var nextNode = doublyLinkedList.Head.NextNode;

            while (nextNode != null)
            {
                nextNode = nextNode.NextNode;
            }

            nextNode = new DoublyLinkedNode() { PreNode = nextNode.PreNode, NextNode = null, Val = val };
            doublyLinkedList.length++;
            return doublyLinkedList;
        }

        public DoublyLinkedList PrependDoublyLinkedList(DoublyLinkedList doublyLinkedList, object val)
        {
            doublyLinkedList.Head.NextNode = new DoublyLinkedNode() { Val = val, NextNode = doublyLinkedList.Head.NextNode, PreNode = doublyLinkedList.Head };
            doublyLinkedList.length++;
            return doublyLinkedList;
        }

        public DoublyLinkedList AddIndexLinkedNode(DoublyLinkedList doublyLinkedList, int index, object val)
        {
            if (index < 0 || index > doublyLinkedList.length) throw new Exception("Out of range");

            var nextNode = doublyLinkedList.Head.NextNode;
            var length = 0;

            while (nextNode != null)
            {
                if (index == length)
                {
                    var temp = new DoublyLinkedNode() { NextNode = nextNode.NextNode, PreNode = nextNode, Val = nextNode.Val };
                    nextNode.Val = val;
                    nextNode.NextNode = temp;
                }

                nextNode = nextNode.NextNode;
                length++;
            }

            if (length == index)
            {
                if (index == length)
                {
                    var temp = new DoublyLinkedNode() { NextNode = nextNode.NextNode, PreNode = nextNode, Val = nextNode.Val };
                    nextNode.Val = val;
                    nextNode.NextNode = temp;
                }
            }

            return doublyLinkedList;
        }

        public DoublyLinkedList DeleteIndexLinkedNode(DoublyLinkedList doublyLinkedList, int index, object val)
        {
            if (index < 0 || index >= doublyLinkedList.length) throw new Exception("Out of range");

            var nextNode = doublyLinkedList.Head.NextNode;
            var length = 0;

            while (nextNode != null)
            {
                if (index == length)
                {
                    nextNode.PreNode.NextNode = nextNode.NextNode;
                    nextNode.NextNode.PreNode = nextNode.PreNode;
                    nextNode.PreNode = null;
                    nextNode.NextNode = null;
                }

                nextNode = nextNode.NextNode;
                length++;
            }

            return doublyLinkedList;
        }

        public DoublyLinkedNode SearchLinkedNode(DoublyLinkedList doublyLinkedList, object val)
        {
            var nextNode = doublyLinkedList.Head.NextNode;

            while (nextNode != null)
            {
                if (nextNode.Val == val) return nextNode;
                nextNode = nextNode.NextNode;
            }

            throw new Exception("Can not find this value");
        }

        #endregion

        #region Multiply Linked List

        public class MultiplyLinkedList
        {
            public MultiplyLinkedNode Head;
            public int length;
        }

        public class MultiplyLinkedNode
        {
            public MultiplyLinkedNode NextNode;
            public MultiplyLinkedNode PreNode;
            public object[] Vals;
        }

        #endregion

        #region Circular Linked List
        #endregion
    }
}
