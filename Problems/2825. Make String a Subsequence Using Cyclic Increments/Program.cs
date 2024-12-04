using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("abc", "ad"),
        true)
    .CreateCase(
        ("zc", "ad"),
        true)
    .CreateCase(
        ("ab", "d"),
        false)
    .CreateCase(
        (string.Join(null, Enumerable.Repeat('z', 8247)),
         string.Join(null, Enumerable.Repeat('a', 2491))),
        true)
    .Run();