using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
[[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]
8

[[3,2],[1,0]]
0
""";

cases
    .ParseCases<int[][], int>()
    .DetectAndRun();