using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
3
7
3

8
10
1

0
0
0

1
1
1

0
50
25

0
51
26

0
999999999
500000000
""";

cases
    .ParseCases<(int, int), int>()
    .Detect()
    .Run();