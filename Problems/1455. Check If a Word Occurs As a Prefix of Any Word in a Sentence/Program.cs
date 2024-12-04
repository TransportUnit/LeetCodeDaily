using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("i love eating burger", "burg"),
        4)
    .CreateCase(
        ("this problem is an easy problem", "pro"),
        2)
    .CreateCase(
        ("i am tired", "you"),
        -1)
    .Run();