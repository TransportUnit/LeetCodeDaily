using LeetCodeDaily.Core;

namespace LeetCodeDaily.Tests;

public class NodeTypeTests
{
    [Theory]
    [InlineData("[1,2,3]")]
    [InlineData("[1,null,2,3]")]
    [InlineData("[5]")]
    [InlineData("[1,2,3,null,null,4,5]")]
    public void TreeNode_SerializeDeserialize_RoundTrips(string treeString)
    {
        var tree = TreeNode.Deserialize(treeString);

        Assert.Equal(treeString, TreeNode.Serialize(tree!));
    }

    [Fact]
    public void TreeNode_Deserialize_KeepsLastNodeOnOddValueCount()
    {
        // Regression: "[1,2]" verlor früher den letzten Knoten,
        // weil die Schleife bei einem einzelnen Restwert abbrach.
        var tree = TreeNode.Deserialize("[1,2]");

        Assert.NotNull(tree);
        Assert.Equal(1, tree.val);
        Assert.NotNull(tree.left);
        Assert.Equal(2, tree.left.val);
        Assert.Null(tree.right);
    }

    [Theory]
    [InlineData("")]
    [InlineData("[]")]
    [InlineData("[null]")]
    public void TreeNode_Deserialize_EmptyInput_ReturnsNull(string treeString)
    {
        Assert.Null(TreeNode.Deserialize(treeString));
    }

    [Fact]
    public void ListNode_ParseAndToString_RoundTrips()
    {
        Assert.Equal("[1,2,3]", ListNode.Parse("[1,2,3]")!.ToString());
        Assert.Null(ListNode.Parse("[]"));
    }
}
