using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("iiii", 1),
        36)
    .CreateCase(
        ("leetcode", 2),
        6)
     .CreateCase(
        ("zbax", 2),
        8)
    .Run();