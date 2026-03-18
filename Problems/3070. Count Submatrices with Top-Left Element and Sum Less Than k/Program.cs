using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        (2, 2),
        4)
    .CreateCase(
        (6, 9),
        15)
    .Detect()
    .Run();