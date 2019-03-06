using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStruct
{
    public class LinkedList
    {
        #region Single LinkedList

        public class SingleLinkedListNode
        {
            public object Val;
            public SingleLinkedListNode NextNode;
        }

        public SingleLinkedListNode SingleInit()
        {
            return new SingleLinkedListNode() { Val = null, NextNode = null };
        }

        public SingleLinkedListNode AddLastSingleNode(SingleLinkedListNode head, object val)
        {
            var nextNode = head;

            while (nextNode != null)
            {
                nextNode = nextNode.NextNode;
            }

            nextNode = new SingleLinkedListNode() { Val = val, NextNode = null };

            return head;
        }

        public SingleLinkedListNode AddHeadSingleNode(SingleLinkedListNode head, object val)
        {
            var temp = head.NextNode;
            head.NextNode = new SingleLinkedListNode() { Val = val, NextNode = temp };
            return head;
        }

        public SingleLinkedListNode AddIndexSingleNode(SingleLinkedListNode head, object val, int index)
        {
            if (index < 0) throw new Exception("Not Support Negative");

            var nextNode = head;
            var length = 0;
            while (nextNode != null)
            {
                nextNode = nextNode.NextNode;

                if (length == index)
                {
                    nextNode = new SingleLinkedListNode() { Val = val, NextNode = nextNode.NextNode };
                    return head;
                }

                length++;
            }

            if (length + 1 == index)
            {
                nextNode = new SingleLinkedListNode() { Val = val, NextNode = nextNode.NextNode };
            }

            throw new Exception("Linked List Length is Not Enough");
        }

        public SingleLinkedListNode DeleteIndexSingleNode(SingleLinkedListNode head, int index)
        {
            if (index < 0) throw new Exception("Not Support Negative");

            var nextNode = head;
            var length = 0;
            while (nextNode.NextNode != null)
            {
                if (length == index)
                {
                    nextNode.NextNode = nextNode.NextNode.NextNode;
                }

                nextNode = nextNode.NextNode;
                length++;
            }

            throw new Exception("Linked List Length is Not Enough");
        }

        #endregion
    }
}
