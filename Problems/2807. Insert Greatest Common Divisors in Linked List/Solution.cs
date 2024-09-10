using LeetCodeDaily.Core;

namespace _2807._Insert_Greatest_Common_Divisors_in_Linked_List;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    [ResultGenerator]
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        var current = head;

        while (current?.next != null)
        {
            current.next =
                new ListNode(
                    GCD(current.val, current.next.val),
                    current.next
                );
            current = current.next.next;
        }

        return head;
    }

    // i stole this routine
    private static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}