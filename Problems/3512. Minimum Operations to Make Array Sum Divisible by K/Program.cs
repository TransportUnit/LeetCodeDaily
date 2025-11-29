using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
[3,9,7]
5
4

[4,1,3]
4
0

[3,2]
6
5
""";

cases
    .ParseCases<(int[], int), int>()
    .Detect()
    .Run();