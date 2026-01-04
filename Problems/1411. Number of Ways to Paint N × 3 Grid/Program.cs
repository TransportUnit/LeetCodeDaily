using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
1
12

2
54

3
246

4
1122

5
5118

623
125280856

1134
282527091

5000
30228214
""";

cases
    .ParseCases<int, int>()
    .DetectAndRun();