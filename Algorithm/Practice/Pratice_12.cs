using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Pratice_12
    {
        public class Node
        {
            public int Val;
            public Node Left;
            public Node Right;
            public Node Parent;
        }

        public void Problem_1_3()
        {

        }

        public void Problem_1_4a()
        {

        }

        public void Problem_1_4b()
        {

        }

        /*
         * TREE-MINIMUM
         */
        public Node Problem_2_2a(Node x)
        {
            if (x.Left != null)
            {
                return Problem_2_2a(x.Left);
            }
            else
            {
                return x;
            }
        }

        /*
         * TREE-MAXIMUM
         */
        public Node Problem_2_2b(Node x)
        {
            if (x.Right != null)
            {
                return Problem_2_2b(x.Right);
            }
            else
            {
                return x;
            }
        }

        /*
         * TREE-PREDECESSOR(x)
         *     if x.left != NIL
         *         return MAXIMUM(x.left)
         *     y = x.p
         *     while y != NIL and x == y.left
         *         x = y
         *         y = y.Parent;
         *     return y
         */
        public void Problem_2_3()
        {

        }

        public void Problem_2_7()
        {

        }
    }
}
