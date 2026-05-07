using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[10,15,20]
15

[1,100,1,1,1,100,1,1,100,1]
6
"""
.ParseCases<int[], int>()
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