using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
2
1

3
2

4
3

0
0

30
832040
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