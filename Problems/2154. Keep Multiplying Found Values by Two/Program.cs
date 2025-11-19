using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
[5,3,6,1,12, 24]
3
48

[2,7,9]
4
4
""";

cases
    .ParseCases<(int[], int), int>()
    .Detect()
    .Run();