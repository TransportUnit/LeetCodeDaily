using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
2
2
4

6
9
15
"""
.ParseCases<int, int, int>()
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