using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "abacbc",
        true)
    .CreateCase(
        "aaabb",
        false)
    .CreateCase(
        "abcdefghijklmnopqrstuvwxyzz",
        false)
    .Run();