using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Practice
{
    public class Practice_10
    {
        /*
         * 两栈实现一队列
         */
        public void Problem_1_6EnQueue(Stack<int> stack1, int x)
        {
            stack1.Push(x);
        }

        public int Problem_1_6DeQueue(Stack<int> stack1, Stack<int> stack2)
        {
            if (stack2.Count() == 0)
            {
                while (stack1.Count() > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Pop();
        }

        /*
         * 两队列实现一栈
         */
        public void Problem_1_7Push(Queue<int> queue1, int x)
        {
            queue1.Enqueue(x);
        }

        public int Problem_1_7Pop(Queue<int> queue1, Queue<int> queue2)
        {
            while (queue1.Count() > 1)
            {
                queue2.Enqueue(queue1.Dequeue());
            }

            var result = queue1.Dequeue();
            while (queue2.Count() > 0)
            {
                queue1.Enqueue(queue2.Dequeue());
            }

            return result;
        }
    }
}
