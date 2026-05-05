using LeetCodeDaily.Core;

namespace _61.Rotate_List;

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
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head?.next == null || k == 0)
            return head;

        int count = 1;
        var cur = head;
        while (cur.next != null)
        {
            count++;
            cur = cur.next;
        }

        k = k % count;

        if (k == 0)
            return head;

        var newHeadIndex = count - k;

        if (newHeadIndex == 0)
            return head;

        cur.next = head;

        int i = 0;
        cur = head;

        while (i++ < newHeadIndex - 1)
        {
            cur = cur.next;
        }

        var newHead = cur.next;
        cur.next = null;

        return newHead;
    }
}