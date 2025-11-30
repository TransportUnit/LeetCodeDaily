using LeetCodeDaily.Core;

namespace _94.Binary_Tree_Inorder_Traversal;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    [ResultGenerator]
    public IList<int> InorderTraversalRecursive(TreeNode root)
    {
        var result = new List<int>();
        Recursive(root, result);
        return result;
    }

    public void Recursive(TreeNode node, IList<int> list)
    {
        if (node == null)
            return;

        Recursive(node.left, list);
        list.Add(node.val);
        Recursive(node.right, list);
    }

    [ResultGenerator(ApproachIndex = 1)]
    public IList<int> InorderTraversalStack(TreeNode root)
    {
        List<int> res = new();
        Stack<TreeNode> stack = new();
        TreeNode curr = root;

        while (curr != null || stack.Count > 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            res.Add(curr.val);
            curr = curr.right;
        }
        return res;
    }

    [ResultGenerator(ApproachIndex = 2)]
    public IList<int> InorderTraversalMorris(TreeNode root)
    {
        List<int> res = new();
        TreeNode curr = root;
        TreeNode pre;

        while (curr != null)
        {
            if (curr.left == null)
            {
                res.Add(curr.val);
                curr = curr.right; // move to next right node
            }
            else
            { // has a left subtree
                pre = curr.left;
                // Find the rightmost node in the left subtree, or the node that already points to curr
                while (pre.right != null && pre.right != curr)
                {
                    pre = pre.right;
                }

                if (pre.right == null)
                {
                    // Establish a temporary thread back to the current node
                    pre.right = curr;
                    curr = curr.left;
                }
                else
                {
                    // The thread already exists, which means we've returned to curr after visiting left subtree
                    pre.right = null; // Restore the tree
                    res.Add(curr.val); // Add the current node to result
                    curr = curr.right; // Move to the right subtree
                }
            }
        }

        return res;
    }
}