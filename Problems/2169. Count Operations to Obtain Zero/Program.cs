using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

var cases =
"""
234
1
234

3451
56786
50

436
34567
100

32556
8899
37

0
100000
0

456
2356
11

10360
45754
43

77772
6786
32
""";

cases
    .ParseCases<(int, int), int>()
    .Detect()
    .Run();