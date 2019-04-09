using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct
{
    /*
     * LIST-SEARCH(L, k)
     *     x = L.head
     *     while x != NIL and x.key != k
     *         x = x.next
     *     return x
     *     
     * LIST-INSERT(L, x)
     *     x.next = L.head
     *     if L.head != NIL
     *         L.head.prev = x
     *     L.head = x
     *     x.prev = NIL
     *     
     * LIST-DELETE(L, x)
     *     if x.prev != NIL
     *         x.prev.next = x.next
     *     else L.head = x.next
     *     if x.next != NIL
     *         x.next.prev = x.prev
     *         
     * sentinel pseudo code        
     *         
     * LIST-DELETE'(L, x)
     *     x.prev.next = x.next
     *     x.next.prev = x.prev
     *     
     * LIST-SEARCH'(L, x)
     *     x = L.nil.next
     *     while x != L.nil and x.key != k
     *         x = x.next
     *     return x
     *     
     * LIST-INSERT'(L, x)
     *     x.next = L.nil.next
     *     L.nil.next.prev = x
     *     L.nil.next = x
     *     x.prev = L.nil
     * 
     */

    public class LinkedListDataStruct
    {
        #region Singly LinkedList
        #endregion

        #region Doubly Linked List
        #endregion

        #region Multiply Linked List
        #endregion

        #region Circular Linked List
        #endregion
    }
}
