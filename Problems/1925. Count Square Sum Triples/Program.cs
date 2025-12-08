using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
1
0

150
178

249
324

19
10

193
238

148
172

239
312

250
330
""";

cases
    .ParseCases<int, int>()
    .Detect()
    .Run();