using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class BinarySearchTree
    {
        public class Node
        {
            public int Val;
            public Node Left;
            public Node Right;
            public Node Parent;
        }

        public class Tree
        {
            public Node Root;
        }

        /*
         * 中序遍历
         * 
         * INORDER-TREE-WALK(x)
         *     INORDER-TREE-WALK(x.left)
         *     print x.key
         *     INORDER-TREE-WALK(x.right)
         *     
         */
        public void InorderTreeWalk(Node x, ref List<Node> result)
        {
            if (x != null)
            {
                InorderTreeWalk(x.Left, ref result);
                result.Add(x);
                InorderTreeWalk(x.Right, ref result);
            }
        }

        /*
         * 递归查询
         * TREE-SEARCH(x, k)
         *     if x == NIL or k == x.key
         *         return x
         *     if k < x.key
         *         return TREE-SEARCH(x.left, k)
         *     else return TREE-SEARCH(x.right, k)
         */
        public Node TreeSearch(Node x, int k)
        {
            if (x == null || k == x.Val)
            {
                return x;
            }
            else
            {
                if (k < x.Val)
                {
                    return TreeSearch(x.Left, k);
                }
                else
                {
                    return TreeSearch(x.Right, k);
                }
            }
        }

        /*
         * 非递归方法查询--对于更多的计算机更有效率
         * ITERATIVE-TREE-SEARCH(x, k)
         *     while x != NIL and k != x.key
         *         if k < x.key
         *             x = x.left
         *         else x = x.right
         *     return x
         */
        public Node IterativeTreeSearch(Node x, int k)
        {
            while (x != null && k != x.Val)
            {
                if (k < x.Val)
                {
                    x = x.Left;
                }
                else
                {
                    x = x.Right;
                }
            }

            return x;
        }

        /*
         * 最小元素
         * TREE-MINIMUM(x)
         *     while x.left != NIL
         *         x = x.left
         *     return x
         */
        public Node TreeMinmum(Node x)
        {
            while (x.Left != null)
            {
                x = x.Left;
            }

            return x;
        }

        /*
         * 最大元素
         * TREE-MAXIMUM(x)
         *     while x.right != NIL
         *         x = x.right
         *     return x
         */
        public Node TreeMaxmum(Node x)
        {
            while (x.Right != null)
            {
                x = x.Right;
            }

            return x;
        }

        /*
         * 后继三种情况：
         * 1.结点有右子树，则后继是右结点的最左孩子
         * 2.结点无右子树且结点为左孩子，那么后继就是其父节点
         * 3.结点无右树且结点为右孩子，那么后继节点是最底层具有左孩子的父节点
         * 
         * TREE-SUCCESSOR(x)
         *     if x.right != NIL
         *         return TREE-MINIMUM(x.right)
         *     y = x.p
         *     while y != NIL and x == y.right
         *         x = y
         *         y = y.p
         *     return y
         */
        public Node TreeSuccessor(Node x)
        {
            if (x.Right != null)
            {
                return TreeMinmum(x.Right);
            }

            var y = x.Parent;
            while (y != null && x == y.Right)
            {
                x = y;
                y = y.Parent;
            }

            return y;
        }

        /*
         * 前驱三种情况：
         * 1.结点有左子树，则前驱是做节点的最有孩子
         * 2.结点无左子树且结点为右孩子，那么前驱就是其父节点
         * 3.结点无左子树且结点为左孩子，那么前驱就是其最底层具有右孩子的父节点
         * TREE-PREDECESSOR
         *     if x.left != NIL
         *         return TREE-MAXIMUM(x.left)
         *     y = x.p
         *     while y != NIL and x == y.left
         *         x = y
         *         y = y.Parent;
         *     return y
         */
        public Node TreePredecessor(Node x)
        {
            if (x.Right != null)
            {
                return TreeMaxmum(x.Left);
            }

            var y = x.Parent;
            while (y != null && x == y.Left)
            {
                x = y;
                y = y.Parent;
            }

            return y;
        }

        /*
         * TREE-INSERT(T, z)
         *     y = NIL
         *     x = T.root
         *     while x != NIL
         *         y = x
         *         if z.key < x.key
         *             x = x.left
         *         else x = x.right
         *     z.p = y
         *     if y == NIL
         *         T.root = z
         *     else if z.key < y.key
         *         y.left = z
         *     else y.right = z
         */
        public Tree TreeInsert(Tree t, Node z)
        {
            Node y = null;
            Node x = t.Root;
            while (x != null)
            {
                y = x;
                if (z.Val < x.Val)
                {
                    x = x.Left;
                }
                else
                {
                    x = x.Right;
                }
            }

            z.Parent = y;
            if (y == null)
            {
                t.Root = z;
            }
            else if (z.Val < y.Val)
            {
                y.Left = z;
            }
            else
            {
                y.Right = z;
            }

            return t;
        }

        /*
         * TRANSPLANT(T, u, v)
         *     if u.p == NIL
         *         T.root = v
         *     else if u == u.p.left
         *         u.p.left = v
         *     else u.p.right = v
         *     if v != NIL
         *         v.p = u.p
         */
        public void Transplant(Tree t, Node u, Node v)
        {
            if (u.Parent == null)
            {
                t.Root = v;
            }
            else if (u == u.Parent.Left)
            {
                u.Parent.Left = v;
            }
            else
            {
                u.Parent.Right = v;
            }

            if (v != null)
            {
                v.Parent = u.Parent;
            }
        }

        /*
         * TREE-DELETE(T, z)
         *     if z.left == NIL
         *         TRANSPLANT(T, z, z.right)
         *     else if z.right == NIL
         *         TRANSPLANT(T, z, z.left)
         *     else y = TREE-MINIMUM(z.right)
         *         if y.p != z
         *             TRANSPLANT(T, y, y.right)
         *             y.right = z.right
         *             y.right.p = y
         *         TRANSPLANT(T, z, y)
         *         y.left = z.left
         *         y.left.p = y
         */
        public void TreeDelete(Tree t, Node z)
        {
            if (z.Left == null)
            {
                Transplant(t, z, z.Right);
            }
            else if (z.Right == null)
            {
                Transplant(t, z, z.Left);
            }
            else
            {
                var y = TreeMinmum(z.Right);
                if (y.Parent != z)
                {
                    Transplant(t, y, y.Right);
                    y.Right = z.Right;
                    y.Right.Parent = y;
                }
                Transplant(t, z, y);
                y.Left = z.Left;
                y.Left.Parent = y;
            }
        }
    }
}
