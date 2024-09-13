using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        (10, 7),
        3)
    .CreateCase(
        (3, 4),
        3)
    .Run();