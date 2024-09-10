using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ListNode.Parse("[18,6,10,3]"),
        ListNode.Parse("[18,6,6,2,10,1,3]"))
    .CreateCase(
        ListNode.Parse("[7]"),
        ListNode.Parse("[7]"))
    .SetResultChecker(c =>
    {
        return c.ActualResult!.ToString().Equals(c.ExpectedResult!.ToString());
    })
    .Run();