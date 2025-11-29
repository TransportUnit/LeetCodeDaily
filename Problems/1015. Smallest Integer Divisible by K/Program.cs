using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
3719
1859

3
3

6
-1

7
6

9
9

79
13

19
18

37
3
""";

cases
    .ParseCases<int, int>()
    .Detect()
    .Run();