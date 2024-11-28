using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("ilovecodingonleetcode", "code"),
        2)
    .CreateCase(
        ("abcba", "abc"),
        1)
    .CreateCase(
        ("abbaccaddaeea", "aaaaa"),
        1)
    .Run();