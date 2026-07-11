using System.Text;

namespace LeetCodeDaily.Core;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public override string ToString()
    {
        return Serialize(this);
    }

    public static string Serialize(TreeNode root)
    {
        if (root == null)
            return "null";

        var sb = new StringBuilder();
        sb.Append("[");

        var queue = new Queue<TreeNode?>();
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var node = queue.Dequeue();
            if (node != null)
            {
                sb.Append(node.val.ToString() + ",");
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            else
            {
                sb.Append("null,");
            }
        }

        if (sb[sb.Length - 1] == ',')
        {
            sb.Remove(sb.Length - 1, 1);
        }

        // Trailing nulls entfernen, damit das Ergebnis dem kanonischen
        // LeetCode-Format entspricht (z.B. [1,2,3] statt [1,2,3,null,null]).
        const string trailingNull = ",null";
        while (sb.Length >= trailingNull.Length + 1
               && sb.ToString(sb.Length - trailingNull.Length, trailingNull.Length) == trailingNull)
        {
            sb.Remove(sb.Length - trailingNull.Length, trailingNull.Length);
        }

        sb.Append("]");
        return sb.ToString();
    }

    public static TreeNode? Deserialize(string treeString)
    {
        if (string.IsNullOrEmpty(treeString))
            return null;

        treeString = treeString.Trim(new[] { '[', ']' });

        if (string.IsNullOrEmpty(treeString))
            return null;

        var vals = new Queue<string>(treeString.Split(','));

        if (vals.Count == 0 || vals.Peek() == "null")
            return null;

        var queue = new Queue<TreeNode>();
        var root = new TreeNode(int.Parse(vals.Dequeue()));
        queue.Enqueue(root);

        while (queue.Count != 0 && vals.Count > 0)
        {
            var node = queue.Dequeue();

            if (vals.TryDequeue(out var left) && left != "null")
            {
                node.left = new TreeNode(int.Parse(left));
                queue.Enqueue(node.left);
            }
            if (vals.TryDequeue(out var right) && right != "null")
            {
                node.right = new TreeNode(int.Parse(right));
                queue.Enqueue(node.right);
            }
        }

        return root;
    }
}