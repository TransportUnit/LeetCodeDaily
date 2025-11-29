using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
[-2,1,-3,4,-1,2,1,-5,4]
6

[1]
1

[5,4,-1,7,8]
23
""";

cases
    .ParseCases<int[], int>()
    .Detect()
    .Run();