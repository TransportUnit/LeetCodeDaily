using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        11,
        3)
    .CreateCase(
        128,
        1)
    .CreateCase(
        2147483645,
        30)
    .Run();