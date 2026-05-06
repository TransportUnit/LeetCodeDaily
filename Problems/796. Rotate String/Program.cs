using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
abcde
cdeab
true

abcde
abced
false
"""
.ParseCases<string, string, bool>()
.DetectAndRun()
.DetectAndRun(1);

/*
// Legacy
Case
    .CreateCase(
        (2, 2),
        4)
    .CreateCase(
        (6, 9),
        15)
    .Detect()
    .Run();
*/