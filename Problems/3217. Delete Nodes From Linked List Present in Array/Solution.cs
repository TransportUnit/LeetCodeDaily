using LeetCodeDaily.Core;

namespace _3217._Delete_Nodes_From_Linked_List_Present_in_Array;

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
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        var hash = new HashSet<int>(nums);

        // searching for valid head
        while (hash.Contains(head!.val))
        {
            head = head.next!;
        }

        var current = head;

        while (current != null)
        {
            var next = current.next;
            current.next = null;

            // searching for valid element, then setting it as current.next
            // and then repeating process for the element we just found until current is null
            while (next != null && hash.Contains(next.val))
            {
                next = next.next;
            }

            current.next = next;
            current = next;
        }

        return head;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public ListNode ModifiedListOptimised(int[] nums, ListNode head)
    {
        Span<bool> set = stackalloc bool[100_001];

        foreach (var n in nums) set[n] = true;

        while (set[head!.val])
        {
            head = head.next!;
        }

        var current = head;

        while (current.next != null)
        {
            if (set[current.next.val])
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }

        }

        return head;
    }
}