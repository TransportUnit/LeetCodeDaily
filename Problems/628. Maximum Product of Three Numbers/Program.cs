using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[1,2,3]
6

[1,2,3,4]
24

[-1,-2,-3]
-6

[-10,-10,1,2,3]
300

[-10,-10,1,2,30]
3000

[-10,1,2,3]
6

[-5,2,3]
-30

[-5,-4,2,3]
60

[-5,-4,2,30]
600

[-4,-3,5]
60

[10,-1,-9,-10,20]
1800
"""
.ParseCases<int[], int>()
.DetectAndRun();
