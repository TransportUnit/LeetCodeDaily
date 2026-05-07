using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
2
2

3
3

4
5

5
8
"""
.ParseCases<int, int>()
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