using System;
using System.Collections.Generic;
using System.Text;

namespace GFGTests
{
    
  //Definition for singly-linked list.
  public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }


    public static class LinkedList
    {
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(int.MinValue);
            var root = result;

            while (l1 != null && l2 != null)
            {
                if (l1 == null)
                {
                    result.next = l2;
                    break;
                }

                if (l2 == null)
                {
                    result.next = l1;
                    break;
                }

                if (l1.val > l2.val)
                {
                    result.next = new ListNode(l2.val);
                    l2 = l2.next;
                }
                else
                {
                    result.next = new ListNode(l1.val);
                    l1 = l1.next;
                }

                result = result.next;
            }

            return root.next;
        }
    }
}
