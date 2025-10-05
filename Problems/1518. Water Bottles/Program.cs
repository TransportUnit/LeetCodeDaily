using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        (9, 3),
        13)
    .CreateCase(
        (15, 4),
        19)
    .Detect()
    .Run();