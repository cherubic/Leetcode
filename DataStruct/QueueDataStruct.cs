using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct
{
    /*
     * ENQUEUE(Q, x)
     *     Q[Q.tail] = x
     *     if Q.tail = Q.length
     *         Q.tail = 1
     *     else Q.tail = Q.tail + 1
     *     
     *     
     * DEQUEUE(Q)
     *     x = Q[Q.head]
     *     if Q.head = Q.length
     *         Q.head = 1
     *     else Q.head = Q.head + 1
     *     return x
     * 
     */
    public class QueueDataStruct
    {
        #region Linked List Queue

        public class LinkedListQueueNode
        {
            public LinkedListQueueNode PreNode;
            public LinkedListQueueNode NextNode;
            public int Val;
        }

        public class LinkedListQueue
        {
            public LinkedListQueueNode Front;
            public LinkedListQueueNode Rear;
            public int Length;

            public LinkedListQueue()
            {
                Length = 0;
            }
        }

        public void EnQueue(LinkedListQueue linkedListQueue, int val)
        {
            linkedListQueue.Rear.NextNode = new LinkedListQueueNode() { PreNode = linkedListQueue.Rear, NextNode = null, Val = val };
            linkedListQueue.Rear = linkedListQueue.Rear.NextNode;
            linkedListQueue.Length++;
        }

        public int DeQueue(LinkedListQueue linkedListQueue)
        {
            var result = linkedListQueue.Front.Val;
            linkedListQueue.Front.NextNode.PreNode = linkedListQueue.Front.NextNode;
            linkedListQueue.Front = linkedListQueue.Front.NextNode;
            linkedListQueue.Length--;
            return result;
        }

        public bool QueueEmpty(LinkedListQueue linkedListQueue)
        {
            return linkedListQueue.Length == 0;
        }

        #endregion

        #region Circle Queue
        #endregion
    }
}
