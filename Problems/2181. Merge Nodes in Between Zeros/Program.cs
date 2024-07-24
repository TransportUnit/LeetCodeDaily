using LeetCodeDaily.Core;

ResultGeneratorAttribute.Detect();

Case.SetResultChecker<ListNode, ListNode>(c =>
{
    return c.ActualResult!.ToString().Equals(c.ExpectedResult.ToString());
});

Case
    .CreateCase(
        ListNode.Parse("[0,3,1,0,4,5,2,0]"),
        ListNode.Parse("[4,11]"))
    .CreateCase(
        ListNode.Parse("[0,1,0,3,0,2,2,0]"),
        ListNode.Parse("[1,3,4]"))
    .Run();