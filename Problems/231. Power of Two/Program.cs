using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        1,
        true)
    .CreateCase(
        16,
        true)
    .CreateCase(
        3,
        false)
    .CreateCase(
        -5,
        false)
    .CreateCase(
        -8,
        false)
    .CreateCase(
        0,
        false)
    .CreateCase(
        -2,
        false)
    .CreateCase(
        -2147483648,
        false)
    .CreateCase(
        2147483647,
        false)
    .CreateCase(
        1073741824,
        true)
    .Run();