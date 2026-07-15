using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
[5,3,6,2,4,null,7]
9
true

[5,3,6,2,4,null,7]
28
false

[2,1,3]
1
false

[2,1,3]
3
true

[2,1,3]
4
true

[2,0,3,-4,1]
-1
true

[0,-1,2,-3,null,null,4]
-1
true

[0,-1,2,-3,null,null,4]
-4
true
"""
.ParseCases<TreeNode, int, bool>()
.DetectAndRun();
