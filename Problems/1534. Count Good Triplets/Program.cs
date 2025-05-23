using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        ("[3,0,1,1,9,7]".ParseArray<int>(), 7, 2, 3),
        4)
    .CreateCase(
        ("[1,1,2,2,3]".ParseArray<int>(), 0, 0, 1),
        0)
    .Detect()
    .Run();