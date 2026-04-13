using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[1,2,3,4,5]
5
3
1

[1]
1
0
0

[1,1,1,1,1,1,1,1,1,1]
1
0
0

[5,3,6]
5
2
2
"""
.ParseCases<int[], int, int, int>()
.DetectAndRun();