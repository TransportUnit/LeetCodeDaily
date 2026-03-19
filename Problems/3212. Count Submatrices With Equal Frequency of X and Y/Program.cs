using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[["X"]]
0

[["Y"]]
0

[["."]]
0

[["X","Y"]]
1

[["Y","X"]]
1

[["X","Y","X","Y"]]
2

[["X","X","X"],["Y","Y","Y"]]
3

[["X",".","Y"],[".","X","."],["Y",".","X"]]
2
"""
.ParseCases<char[][], int>()
.DetectAndRun();