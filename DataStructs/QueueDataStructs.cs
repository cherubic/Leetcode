using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStruct
{
    public class QueueDataStructs
    {

        #region Linked List Queue

        public class LinkedListQueue
        {
            public LinkedListQueueNode Front;
            public LinkedListQueueNode Rear;
            public int Length;
        }

        public class LinkedListQueueNode
        {
            public LinkedListQueueNode PreNode;
            public LinkedListQueueNode NextNode;
            public object Val;
        }

        public LinkedListQueue InitializationLinkedListQueue()
        {
            var first = new LinkedListQueueNode() { NextNode = null, Val = null };
            first.PreNode = first;
            var result = new LinkedListQueue() { Front = first, Rear = first, Length = 0 };
            return result;
        }

        public LinkedListQueue Put(LinkedListQueue linkedListQueue, object val)
        {
            linkedListQueue.Rear.NextNode = new LinkedListQueueNode() { PreNode = linkedListQueue.Rear, NextNode = null, Val = val };
            linkedListQueue.Rear = linkedListQueue.Rear.NextNode;
            linkedListQueue.Length++;
            return linkedListQueue;
        }

        public object Poll(LinkedListQueue linkedListQueue)
        {
            if (linkedListQueue.Front == linkedListQueue.Rear) throw new Exception("Out of range");

            var result = linkedListQueue.Front.Val;
            linkedListQueue.Front = linkedListQueue.Front.NextNode;
            linkedListQueue.Front.PreNode = linkedListQueue.Front;
            linkedListQueue.Length--;

            return result;
        }

        //Destory
        //Clean

        #endregion

        #region Circle Queue



        #endregion

    }
}
