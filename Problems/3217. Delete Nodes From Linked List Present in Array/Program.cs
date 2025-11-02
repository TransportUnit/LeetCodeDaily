using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        ("[1,2,3]".ParseArray<int>(), ListNode.Parse("[1,2,3,4,5]")),
        ListNode.Parse("[4,5]"))
    .CreateCase(
        ("[1]".ParseArray<int>(), ListNode.Parse("[1,2,1,2,1,2]")),
        ListNode.Parse("[2,2,2]"))
    .CreateCase(
        ("[5]".ParseArray<int>(), ListNode.Parse("[1,2,3,4]")),
        ListNode.Parse("[1,2,3,4]"))
    .CreateCase(
        ("[1,7,6,2,4]".ParseArray<int>(), ListNode.Parse("[3,7,1,8,1]")),
        ListNode.Parse("[3,8]"))
    .SetResultChecker(c =>
    {
        return c.ActualResult!.ToString().Equals(c.ExpectedResult!.ToString());
    })
    .Detect()
    .Run()
    .Detect(1)
    .Run();