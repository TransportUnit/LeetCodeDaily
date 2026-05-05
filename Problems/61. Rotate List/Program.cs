using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ParserRegistry.Register<ListNode>(ListNode.Parse); ;

"""
[1,2,3,4,5]
2
[4,5,1,2,3]

[0,1,2]
4
[2,0,1]

[1]
1
[1]

[1,2,3]
10
[3,1,2]

[]
0
[]

[1,2]
0
[1,2]

[1,2]
2
[1,2]
"""
.ParseCases<(ListNode, int), ListNode>()
.SetResultChecker(c => c.ActualResult is null && c.ExpectedResult is null ||  c.ActualResult!.ToString().Equals(c.ExpectedResult.ToString()))
.DetectAndRun();

/*
// Legacy
Case
    .CreateCase(
        (2, 2),
        4)
    .CreateCase(
        (6, 9),
        15)
    .Detect()
    .Run();
*/