using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
1001101
4

00111
0

001110
3

1001101
4

00111
0

110
2

0011010101100
15

1010101010100000
21
""";

cases
    .ParseCases<string, int>()
    .Detect()
    .Run()
    .Detect(1)
    .Run();