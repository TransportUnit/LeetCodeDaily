using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
[1,2,3,4]
3

[3,6,9]
0
""";

cases
    .ParseCases<int[], int>()
    .Detect()
    .Run();