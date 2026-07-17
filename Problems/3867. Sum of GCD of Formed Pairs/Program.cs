using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[2,6,4]
2

[3,6,2,8]
5

[1]
0

[1000]
0

[1000,1000]
1000

[1000,1000,1000,1000]
2000

[1234567, 2345678, 3456789, 123, 12234, 324, 324534, 345, 32453247]
8
"""
.ParseCases<int[], long>()
.DetectAndRun();
