using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStruct
{
    public class StackDataStruct
    {
        #region Array Stack

        public class ArrayStack
        {
            public int[] StackArray;
            public int Top;
        }

        public ArrayStack InitializationArrayStack(int length)
        {
            return new ArrayStack() { StackArray = new int[length], Top = -1 };
        }

        public ArrayStack Push(ArrayStack arrayStack, int val)
        {
            if (arrayStack.Top + 1 < arrayStack.StackArray.Length)
            {
                arrayStack.Top += 1;
                arrayStack.StackArray[arrayStack.Top] = val;
            }
            else
            {
                throw new Exception("Out of range");
            }

            return arrayStack;
        }

        public ArrayStack Pop(ArrayStack arrayStack)
        {
            if (arrayStack.Top < 0)
            {
                throw new Exception("Out of range");
            }
            else
            {
                arrayStack.StackArray[arrayStack.Top] = int.MinValue;
                arrayStack.Top -= 1;
            }

            return arrayStack;
        }

        public int Top(ArrayStack arrayStack)
        {
            if (arrayStack.Top < 0)
            {
                throw new Exception("Out of range");
            }
            else
            {
                return arrayStack.StackArray[arrayStack.Top];
            }
        }

        public bool Empty(ArrayStack arrayStack)
        {
            return arrayStack.Top == -1;
        }

        #endregion

        #region Linked List Stack

        public class LinkedListStack
        {
            public LinkedListStackNode Bottom;
            public LinkedListStackNode Top;
        }

        public class LinkedListStackNode
        {
            public LinkedListStackNode PreNode;
            public LinkedListStackNode NextNode;
            public object Val;
        }

        public LinkedListStack InitializationLinkedListStack()
        {
            var result = new LinkedListStack()
            {
                Bottom = new LinkedListStackNode() { PreNode = null, NextNode = null, Val = null }
            };

            result.Top = result.Bottom;

            return result;
        }

        public LinkedListStack Push(LinkedListStack linkedListStack, object val)
        {
            linkedListStack.Top.NextNode = new LinkedListStackNode() { NextNode = null, PreNode = linkedListStack.Top, Val = val };
            linkedListStack.Top = linkedListStack.Top.NextNode;
            return linkedListStack;
        }

        public LinkedListStack Pop(LinkedListStack linkedListStack)
        {
            if (linkedListStack.Top == null) throw new Exception("out of range");
            linkedListStack.Top = linkedListStack.Top.PreNode;
            linkedListStack.Top.NextNode = null;
            return linkedListStack;
        }

        public LinkedListStackNode Top(LinkedListStack linkedListStack)
        {
            return linkedListStack.Top;
        }

        public bool Empty(LinkedListStack linkedListStack)
        {
            return linkedListStack.Top.Val == null;
        }

        #endregion
    }
}
