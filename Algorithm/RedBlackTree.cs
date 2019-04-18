using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class RedBlackTree
    {
        /*
         * LEFT-ROTATE(T, x)
         *     y = x.right
         *     x.right = y.left
         *     if y.left != T.nil
         *         y.left.p = x
         *     y.p = x.p
         *     if x.p == T.nil
         *         T.root = y
         *     else if x == x.p.left
         *         x.p.left = y
         *     else x.p.right = y
         *     y.left = x
         *     x.p = y
         * 
         */

        /*
         * RIGHT-ROTATE(T, x)
         *     y = x.left
         *     x.left = y.right
         *     if y.right != T.NIL
         *         y.right.p = x
         *     y.p = x.p
         *     if x.p = NIL
         *         T.root = y
         *     else if x.p.left == x
         *         x.p.left = y
         *     else x.p.right = y
         *     y.right = x
         *     x.p = y
         */

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
         *                 z.color = BLACK 
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

        /*
         * RB-TRANSPLANT(T, u, v)
         *     if u.p == T.nil
         *         T.root = v
         *     else if u == u.p.left
         *         u.p.left = v
         *     else u.p.right = v
         *     v.p = u.p
         */

        /*
         * RB-DELETE(T, z)
         *     y = z
         *     y-original-color = y.color
         *     if z.left == T.nil
         *         x = z.right
         *         RB-TRANSPLANT(T, z, z.right)
         */
    }
}
