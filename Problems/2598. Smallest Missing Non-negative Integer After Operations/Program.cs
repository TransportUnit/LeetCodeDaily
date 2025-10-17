using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
[1,-10,7,13,6,8]
5
4

[1,-10,7,13,6,8]
7
2

[1,-10,7,13,6,8]
6
3

[1,-10,7,13,6,8]
4
4

[3,0,3,2,4,2,1,1,0,4]
5
10

[0,1,2,3,4]
12
5
""";

cases
    .ParseCases<(int[], int), int>()
    .Detect()
    .Run()
    .Detect(1)
    .Run();