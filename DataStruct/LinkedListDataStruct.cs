using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct
{
    /*
     * LIST-SEARCH(L, k)
     *     x = L.head
     *     while x != NIL and x.key != k
     *         x = x.next
     *     return x
     *     
     * LIST-INSERT(L, x)
     *     x.next = L.head
     *     if L.head != NIL
     *         L.head.prev = x
     *     L.head = x
     *     x.prev = NIL
     *     
     * LIST-DELETE(L, x)
     *     if x.prev != NIL
     *         x.prev.next = x.next
     *     else L.head = x.next
     *     if x.next != NIL
     *         x.next.prev = x.prev
     *         
     * sentinel pseudo code        
     *         
     * LIST-DELETE'(L, x)
     *     x.prev.next = x.next
     *     x.next.prev = x.prev
     *     
     * LIST-SEARCH'(L, x)
     *     x = L.nil.next
     *     while x != L.nil and x.key != k
     *         x = x.next
     *     return x
     *     
     * LIST-INSERT'(L, x)
     *     x.next = L.nil.next
     *     L.nil.next.prev = x
     *     L.nil.next = x
     *     x.prev = L.nil
     * 
     */

    public class LinkedListDataStruct
    {
        #region Singly LinkedList

        public class SinglyLinkedListNode
        {
            public int Val;
            public SinglyLinkedListNode Next;
        }

        public class SinglyLinkedList
        {
            public SinglyLinkedListNode headNode;
            public int Length;

            public SinglyLinkedList()
            {
                this.Length = 0;
            }
        }

        public SinglyLinkedListNode SinglyLinkedListSearch(SinglyLinkedList singlyLinkedList, int key)
        {
            var next = singlyLinkedList.headNode;
            while (next != null)
            {
                if (next.Val == key)
                {
                    return next;
                }
            }

            return null;
        }

        public void SinglyLinkedListInsertAfter(SinglyLinkedList singlyLinkedList, int val)
        {
            var next = singlyLinkedList.headNode;
            while (next != null)
            {
                next = next.Next;
            }

            next = new SinglyLinkedListNode() { Next = null, Val = val };
            singlyLinkedList.Length = singlyLinkedList.Length + 1;
        }

        public void SinglyLinkedListInsertBeginning(SinglyLinkedList singlyLinkedList, int val)
        {
            singlyLinkedList.headNode = new SinglyLinkedListNode() { Next = singlyLinkedList.headNode, Val = val };
            singlyLinkedList.Length = singlyLinkedList.Length + 1;
        }

        public void SinglyLinkedListDelete(SinglyLinkedList singlyLinkedList, int val)
        {
            var current = singlyLinkedList.headNode;
            var next = singlyLinkedList.headNode.Next;
            if (current != null && current.Val == val)
            {
                singlyLinkedList.headNode = singlyLinkedList.headNode.Next;
            }
            else
            {
                while (next != null)
                {
                    if (next.Val == val)
                    {
                        current.Next = next.Next;
                        next = null;
                    }
                    else
                    {
                        current = next;
                        next = next.Next;
                    }
                }
            }
        }

        #endregion

        #region Doubly Linked List

        public class DoublyLinkedListNode
        {
            public int Val;
            public DoublyLinkedListNode PreNode;
            public DoublyLinkedListNode NextNode;
        }

        public class DoublyLinkedList
        {
            public DoublyLinkedListNode headNode;
            public int Length;

            public DoublyLinkedList()
            {
                this.Length = 0;
            }
        }

        public DoublyLinkedListNode DoublyLinkedListSearch(DoublyLinkedList doublyLinkedList, int val)
        {
            var next = doublyLinkedList.headNode;
            while (next != null)
            {
                if (next.Val == val)
                {
                    return next;
                }
            }

            throw new Exception("Not Found");
        }

        public void DoublyLinkedListInsertAfter(DoublyLinkedList doublyLinkedList, int val)
        {
            var next = doublyLinkedList.headNode;
            if (doublyLinkedList.headNode == null)
            {
                doublyLinkedList.headNode = new DoublyLinkedListNode() { NextNode = null, Val = val };
                doublyLinkedList.headNode.PreNode = doublyLinkedList.headNode;
            }

            while (next.NextNode != null)
            {
                next = next.NextNode;
            }

            next.NextNode = new DoublyLinkedListNode() { NextNode = null, PreNode = next, Val = val };
            doublyLinkedList.Length += 1;
        }

        public void DoublyLinkedListInserBeginning(DoublyLinkedList doublyLinkedList, int val)
        {
            doublyLinkedList.headNode = new DoublyLinkedListNode() { NextNode = doublyLinkedList.headNode, Val = val };
            doublyLinkedList.headNode.PreNode = doublyLinkedList.headNode;
            if (doublyLinkedList.headNode.NextNode != null)
            {
                doublyLinkedList.headNode.NextNode.PreNode = doublyLinkedList.headNode;
            }

            doublyLinkedList.Length += 1;
        }

        public void DoublyLinkedListDelete(DoublyLinkedList doublyLinkedList, int val)
        {
            if (doublyLinkedList.headNode.Val == val)
            {
                doublyLinkedList.headNode = doublyLinkedList.headNode.NextNode;
                doublyLinkedList.headNode.PreNode = doublyLinkedList.headNode;
                doublyLinkedList.Length -= 1;
            }
            else
            {
                var next = doublyLinkedList.headNode;
                while (next != null)
                {
                    if (next.Val == val)
                    {
                        next.PreNode.NextNode = next.NextNode;
                        next = null;
                        doublyLinkedList.Length -= 1;
                    }
                    else
                    {
                        next = next.NextNode;
                    }
                }
            }
        }

        #endregion

        #region Multiply Linked List
        #endregion

        #region Circular Linked List
        #endregion
    }
}
