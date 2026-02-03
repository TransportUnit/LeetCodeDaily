using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[1,3,5,4,2,6]
true

[2,1,3]
false

[1,1,2,1,2]
false

[1,2,1,2]
true

[7,6,4,4]
false

[1,4,8,9]
false

[6,7,5,1]
false

[1,2,3]
false
"""
.ParseCases<int[], bool>()
.DetectAndRun(0)
.DetectAndRun(1)
.DetectAndRun(2);