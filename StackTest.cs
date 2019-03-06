using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode
{
    public class StackTest
    {
        public class StackStruct
        {
            public int top;
            public int bottom;
            public int maxLength;
            public int[] stackArray;

            public StackStruct()
            {
                top = 0;
                bottom = 0;
                maxLength = 10;
                stackArray = new int[10];
            }

            public StackStruct push(int val)
            {
                if (top + 1 < 10)
                {
                    top = top + 1;
                    stackArray[top] = val;
                }
                else
                {
                    throw new Exception("overflow");
                }

                return this;
            }

            public int pop()
            {
                var result = int.MinValue;
                if (top - 1 >= bottom)
                {
                    result = stackArray[top];
                    stackArray[top] = int.MinValue;
                    top = top - 1;
                }
                else
                {
                    throw new Exception("underflow");
                }

                return result;
            }
        }
    }
}
