using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct
{
    /*
     * 
     * STACK-EMPTY(S)
     *     if S.top == 0
     *         return TRUE
     *     else return FALSE
     *     
     * PUSH(S, x)
     *     S.top = S.top + 1
     *     S[S.top] = x
     *     
     * POP(s)
     *     if STACK-EMPTY(S)
     *         error "underflow"
     *     else S.top = S.top - 1
     *         return S[S.top + 1]
     * 
     * TOP(S)
     *     return S[S.top];
     * 
     */

    public class StackDataStruct
    {
        #region Array Stack

        public class ArrayStack
        {
            public int[] Val;
            public int Top;

            public ArrayStack(int StackLength = 10)
            {
                Val = new int[StackLength];
                Top = -1;
            }
        }

        public bool ArrayStackEmpty(ArrayStack arrayStack)
        {
            if (arrayStack.Top == -1) return true;
            return false;
        }

        public void ArrayStackPush(ArrayStack arrayStack, int x)
        {
            arrayStack.Top = arrayStack.Top + 1;
            if (arrayStack.Top < arrayStack.Val.Length)
            {
                arrayStack.Val[arrayStack.Top] = x;
            }
            else
            {
                throw new Exception("Stack overflow");
            }
        }

        public int ArrayStackPop(ArrayStack arrayStack)
        {
            if (ArrayStackEmpty(arrayStack))
            {
                throw new Exception("Stack underflow");
            }
            else
            {
                arrayStack.Top = arrayStack.Top - 1;
                return arrayStack.Val[arrayStack.Top + 1];
            }
        }

        public int ArrayStackTop(ArrayStack arrayStack)
        {
            if (ArrayStackEmpty(arrayStack))
            {
                throw new Exception("Stack underflow");
            }
            else
            {
                return arrayStack.Val[arrayStack.Top];
            }
        }

        #endregion

        #region Linked List Stack

        public class LinkedListStack
        {
        }


        #endregion
    }
}
