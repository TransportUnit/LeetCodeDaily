using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        ("[\"are\",\"amy\",\"u\"]".ParseArray<string>(), 0, 2),
        2)
    .CreateCase(
        ("[\"hey\",\"aeo\",\"mu\",\"ooo\",\"artro\"]".ParseArray<string>(), 1, 4),
        3)
    .Detect()
    .Run();