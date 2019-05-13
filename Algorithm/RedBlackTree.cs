using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class RedBlackTree
    {
        public class Node
        {
            public Node Left;
            public Node Right;
            public Node Parent;
            public int Color;
            public int Key;
        }

        public class Tree
        {
            public Node Root;
            public Node Nil;
        }

        public Node TreeMinimum(Node x)
        {
            while (x.Left != null)
            {
                x = x.Left;
            }

            return x;
        }

        public Node TreeMaximum(Node x)
        {
            while (x.Right != null)
            {
                x = x.Right;
            }

            return x;
        }

        /*
         * LEFT-ROTATE(T, x)
         *     y = x.right
         *     x.right = y.left
         *     if y.left != T.nil
         *         y.left.p = x
         *     y.p = x.p
         *     if x.p == T.nil
         *         T.root = y
         *     elseif x == x.p.left
         *         x.p.left = y
         *     else x.p.right = y
         *     y.left = x
         *     x.p = y
         * 
         */
        public void LeftRotate(Tree t, Node x)
        {
            var y = x.Right;
            x.Right = y.Left;
            if (y.Left != t.Nil)
            {
                y.Left.Parent = x;
            }

            y.Parent = x.Parent;

            if (x.Parent == t.Nil)
            {
                t.Root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }

            y.Left = x;
            x.Parent = y;
        }

        /*
         * RIGHT-ROTATE(T, x)
         *     y = x.left
         *     x.left = y.right
         *     if y.right != T.NIL
         *         y.right.p = x
         *     y.p = x.p
         *     if x.p = NIL
         *         T.root = y
         *     elseif x.p.left == x
         *         x.p.left = y
         *     else x.p.right = y
         *     y.right = x
         *     x.p = y
         */
        public void RightRotate(Tree t, Node x)
        {
            var y = x.Left;
            x.Left = y.Right;
            if (y.Right != t.Nil)
            {
                y.Right.Parent = x;
            }

            y.Parent = x.Parent;
            if (x.Parent == t.Nil)
            {
                t.Root = y;
            }
            else if (x.Parent.Left == x)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }

            y.Right = x;
            x.Parent = y;
        }

        /*
         * RB-INSERT(T, z)
         *     y = T.nil
         *     x = T.root
         *     while x != T.nil
         *         y = x
         *         if z.key < x.key
         *             x = x.left
         *         else x = x.right
         *     z.p = y
         *     if y == T.nil
         *         T.root = z
         *     else if z.key < y.key
         *         y.left = z
         *     else y.right = z
         *     z.left = T.nil
         *     z.right = T.nil
         *     z.color = RED
         *     BE-INSERT-FIXUP(T, z)
         *     
         * BE-INSERT-FIXUP(T, z)
         *     while z.p.color == RED
         *         if z.p == z.p.p.left 
         *             y = z.p.p.right 
         *             if y.color == RED 
         *                 z.p.color = BLACK
         *                 y.color = BLACK 
         *                 z.p.p.color = RED 
         *                 z = z.p.p 
         *             else if z == z.p.right 
         *                 z = z.p
         *                 LEFT-ROTATE(T, z)
         *             z.p.color = BLACK 
         *             z.p.p.color = RED 
         *             RIGHT-ROTATE(T, z.p.p)
         *         else same as then clause with "right" and "left" exchanged)
         *     T.root.color = BLACK
         */
        public void ReInsert(Tree t, Node z)
        {
            var y = t.Nil;
            var x = t.Root;
            while (x != t.Nil)
            {
                y = x;
                if (z.Key < x.Key)
                {
                    x = x.Left;
                }
                else
                {
                    x = x.Right;
                }
            }

            z.Parent = y;
            if (y == t.Nil)
            {
                t.Root = z;
            }
            else
            {
                if (z.Key < y.Key)
                {
                    y.Left = z;
                }
                else
                {
                    y.Right = z;
                }
            }

            z.Left = t.Nil;
            z.Right = t.Nil;
            z.Color = 1;
            BeInsertFixup(t, z);
        }

        public void BeInsertFixup(Tree t, Node z)
        {
            while (z.Parent.Color == 1 && z.Parent != t.Nil)
            {
                if (z.Parent == z.Parent.Parent.Left)
                {
                    var y = z.Parent.Parent.Right;
                    if (y.Color == 1)
                    {
                        z.Parent.Color = 0;
                        y.Color = 0;
                        z.Parent.Parent.Color = 1;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Right)
                        {
                            z = z.Parent;
                            LeftRotate(t, z);
                        }
                        z.Parent.Color = 0;
                        z.Parent.Parent.Color = 1;
                        RightRotate(t, z.Parent.Parent);
                    }
                }
                else
                {
                    var y = z.Parent.Parent.Left;
                    if (y.Color == 1)
                    {
                        z.Parent.Color = 0;
                        y.Color = 0;
                        z.Parent.Parent.Color = 1;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Left)
                        {
                            z = z.Parent;
                            RightRotate(t, z);
                        }
                        z.Parent.Color = 0;
                        z.Parent.Parent.Color = 1;
                        LeftRotate(t, z.Parent.Parent);
                    }
                }
            }

            t.Root.Color = 0;
        }

        /*
         * RB-TRANSPLANT(T, u, v)
         *     if u.p == T.nil
         *         T.root = v
         *     elseif u == u.p.left
         *         u.p.left = v
         *     else u.p.right = v
         *     v.p = u.p
         */
        public void RbTransplant(Tree t, Node u, Node v)
        {
            if (u.Parent == t.Nil)
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

            v.Parent = u.Parent;
        }

        /*
         * RB-DELETE(T, z)
         *     y = z
         *     y-original-color = y.color
         *     if z.left == T.nil
         *         x = z.right
         *         RB-TRANSPLANT(T, z, z.right)
         *     elseif z.right == T.nil
         *         x = z.left
         *         RB-TRANSPLANT(T, z, z.left)
         *     else y = TREE-MINIMUM(z.right)
         *         y-original-color = y.color
         *         x= y.right
         *         if y.p == z
         *             x.p = y
         *         else RB-TRANSPLANT(T, y, y.right)
         *             y.right = z.right
         *             y.right.p = y
         *         BR-TRANSPLANT(T, z, y)
         *         y.left = z.left
         *         y.left.p = y
         *         y.color = z.color
         *     if y-original-color = BLACK
         *         RB-DELETE-FIXUP(T, x)
         */
        public void RbDelete(Tree t, Node z)
        {
            var y = z;
            var yOriginalColor = y.Color;

            var x = t.Nil;

            if (z.Left == t.Nil)
            {
                x = z.Left;
                RbTransplant(t, z, z.Left);
            }
            else if (z.Right == t.Nil)
            {
                x = z.Left;
                RbTransplant(t, z, z.Left);
            }
            else
            {
                y = TreeMinimum(z.Right);
                yOriginalColor = y.Color;
                x = y.Right;
                if (y.Parent == z)
                {
                    x.Parent = y;
                }
                else
                {
                    RbTransplant(t, y, y.Right);
                    y.Right = z.Right;
                    y.Right.Parent = y;
                }
                RbTransplant(t, z, y);
                y.Left = z.Left;
                y.Left.Parent = y;
                y.Color = z.Color;
            }

            if (yOriginalColor == 0)
            {
                RbDeleteFixup(t, x);
            }
        }

        /*
         * RB-DELETE-FIXUP(T, x)
         *     if x == x.p.left
         *         w = x.p.right
         *         if w.color == RED
         *             w.color = BLACK
         *             x.p.color = RED
         *             LEFT-ROTATE(T, x.p)
         *             w = x.p.right
         *         if w.left.color == BLACK and w.right.color = BLACK
         *             w.color = RED
         *             x = x.p
         *         else if w.right.color == BLACK
         *             w.left.color = BLACK
         *             w.color = RED
         *             RIGHT-ROTATE(T, w)
         *             w = x.p.right
         *         w.color = x.p.color
         *         x.p.color = BLACK
         *         w.right.color = BLACK
         *         LEFT-ROTATE(T, x.p)
         *         x = T.root
         *     else (same as then clause with "right" and "left" exchanged)
         *     x.color = BLACK
         * 
         */
        public void RbDeleteFixup(Tree t, Node x)
        {
            while (x != t.Root && x.Color == 0)
            {
                if (x == x.Parent.Left)
                {
                    var w = x.Parent.Right;
                    if (w.Color == 1)
                    {
                        w.Color = 0;
                        x.Parent.Color = 1;
                        LeftRotate(t, x.Parent);
                        w = x.Parent.Right;
                    }
                    if (w.Left.Color == 0 && w.Right.Color == 0)
                    {
                        w.Color = 1;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.Right.Color == 0)
                        {
                            w.Left.Color = 0;
                            w.Color = 1;
                            RightRotate(t, w);
                            w = x.Parent.Right;
                        }

                        w.Color = x.Parent.Color;
                        x.Parent.Color = 0;
                        w.Right.Color = 0;
                        LeftRotate(t, x.Parent);
                        x = t.Root;
                    }
                }
                else
                {
                    var w = x.Parent.Left;
                    if (w.Color == 1)
                    {
                        w.Color = 0;
                        w.Parent.Color = 1;
                        RightRotate(t, x.Parent);
                        w = x.Parent.Left;
                    }
                    if (w.Right.Color == 0 && w.Right.Color == 0)
                    {
                        w.Color = 1;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.Left.Color == 0)
                        {
                            w.Left.Color = 0;
                            w.Color = 1;
                            LeftRotate(t, w);
                            w = x.Parent.Left;
                        }

                        w.Color = x.Parent.Color;
                        x.Parent.Color = 0;
                        w.Left.Color = 0;
                        RightRotate(t, x.Parent);
                        x = t.Root;
                    }
                }
            }

            x.Color = 0;
        }
    }
}
