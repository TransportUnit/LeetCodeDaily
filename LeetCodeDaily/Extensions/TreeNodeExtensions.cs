using LeetCodeDaily.Core;

namespace LeetCodeDaily.Extensions;

public static class TreeNodeExtensions
{
    public static string Serialize(this TreeNode root)
    {
        return TreeNode.Serialize(root);
    }

    public static TreeNode? DeserializeTreeNode(this string treeString)
    {
        return TreeNode.Deserialize(treeString);
    }
}