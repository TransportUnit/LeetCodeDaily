using LeetCodeDaily.Extensions;
using System.Text;

namespace LeetCodeDaily.Core;

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode? Parse(string input)
    {
        var arr = input.ParseArray<int>();
        if (arr.Length == 0)
            return null;

        var head = new ListNode(arr[0]);
        var cur = head;

        for (int i = 1; i < arr.Length; i++)
        {
            cur.next = new ListNode(arr[i]);
            cur = cur.next;
        }
        return head;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var cur = this;
        while (cur != null)
        {
            sb.Append($"{cur.val},");
            cur = cur.next;
        }
        sb.Remove(sb.Length - 1, 1);
        return string.Format("[{0}]", sb.ToString());
    }
}
