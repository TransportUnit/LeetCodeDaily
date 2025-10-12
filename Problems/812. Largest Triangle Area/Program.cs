using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
[[-15, 33], [7, 7], [12, 26], [25, -23], [32, -1], [-32, -18], [-46, 28], [10, -48], [-11, -48]]
2456.50000
""";

cases
    .ParseCases<int[][], double>()
    .Detect()
    .Run();