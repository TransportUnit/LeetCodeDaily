using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[1,2,3,1,2,3,1,2]
2
6

[1,2,1,2,1,2,1,2]
1
2

[5,5,5,5,5,5,5]
4
4
"""
.ParseCases<int[], int, int>()
.DetectAndRun();
