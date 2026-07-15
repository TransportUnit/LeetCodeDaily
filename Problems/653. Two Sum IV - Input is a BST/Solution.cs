using LeetCodeDaily.Core;

namespace _653.Two_Sum_IV___Input_is_a_BST;

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
    public bool FindTarget(TreeNode root, int k)
    {
        // guard
        if (root is null)
        {
            return false;
        }

        Queue<TreeNode> queue = new();

        // memorizing occurence for each number
        // -10^4 maps to index 0, 0 maps to index 10^4, 10^4 maps to index 2*10^4
        // -> 20001 elements
        Span<bool> freq = stackalloc bool[10_000 + 10_000 + 1];

        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var elem = queue.Dequeue();
            var diff = k - elem.val;

            if (-10_000 <= diff && diff <= 10_000)
            {
                if (freq[diff + 10_000])
                {
                    return true;
                }

                freq[elem.val + 10_000] = true;
            }

            if (elem.left is not null)
            {
                queue.Enqueue(elem.left);
            }
            if (elem.right is not null)
            {
                queue.Enqueue(elem.right);
            }

        }

        return false;
    }
}