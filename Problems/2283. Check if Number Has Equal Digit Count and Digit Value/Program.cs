using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "1210",
        true)
    .CreateCase(
        "030",
        false)
    .Run();