using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        5,
        "[-1,1,2,0,-2]".ParseArray<int>())
    .CreateCase(
        3,
        "[1,0,-1]".ParseArray<int>())
    .CreateCase(
        1,
        "[0]".ParseArray<int>())
    .CreateCase(
        4,
        "[2,-1,1,-2]".ParseArray<int>())
    .CreateCase(
        6,
        "[-2,2,1,-1,-3,3]".ParseArray<int>())
    .SetResultChecker(c => c.ActualResult?.Sum() == c.ExpectedResult?.Sum())
    .Detect()
    .Run()
    .Detect(1)
    .Run();