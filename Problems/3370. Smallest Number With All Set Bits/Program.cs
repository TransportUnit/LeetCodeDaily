using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
554
1023

105
127

39
63

103
127

122
127

22
31

31
31
""";

cases
    .ParseCases<int, int>()
    .Detect()
    .Run()
    .Detect(1)
    .Run();