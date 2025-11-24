using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;


string cases =
"""
4
2

8
2

1
1

0
0

2147395600
46340

69
8

2147395599
46339
""";

cases
    .ParseCases<int, int>()
    .Detect()
    .Run()
    .Detect(1)
    .Run()
    .Detect(2)
    .Run();