using LeetCodeDaily.Core;

namespace _2181._Merge_Nodes_in_Between_Zeros;

public class Solution
{
    [ResultGenerator]
    public ListNode MergeNodes(ListNode head)
    {
        var current = head;
        var iterator = head.next;

        while (iterator != null)
        {
            current.val += iterator.val;
            if (iterator.val == 0 && iterator.next != null)
            {
                current = current.next;
                current!.val = 0;
            }
            iterator = iterator.next;
        }

        current.next = null;
        return head;
    }
}

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