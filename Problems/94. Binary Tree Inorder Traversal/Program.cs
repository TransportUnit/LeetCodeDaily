using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        TreeNode.Deserialize("[1,null,2,3,null]"),
        "[1,3,2]".ParseArray<int>().ToList() as IList<int>)
    .CreateCase(
        TreeNode.Deserialize("[1,2,3,4,5,null,8,null,null,6,7,9,null]"),
        "[4,2,6,5,7,1,3,9,8]".ParseArray<int>())
    .CreateCase(
        TreeNode.Deserialize("[]"),
        "".ParseArray<int>())
    .CreateCase(
        TreeNode.Deserialize("[1]"),
        "[1]".ParseArray<int>())
    .Detect()
    .Run()
    .Detect(1)
    .Run()
    .Detect(2)
    .Run();