using GFGTests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test
{
    public class LinkedListTest
    {
        [Fact]
        public static void MergeTwoListsTest()
        {
            var l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);

            var l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            Assert.NotNull(LinkedList.MergeTwoLists(l1,l2));
        }
    }
}
