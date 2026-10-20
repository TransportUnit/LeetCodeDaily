using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[1,2,5,2,3]
2
[1,2]

[1,2,5,2,3]
3
[3]

[1,2,5,2,3]
5
[4]
"""
.ParseCases<int[], int, IList<int>>()
.DetectAndRun();
